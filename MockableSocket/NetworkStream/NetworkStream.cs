using MockableSocket.Interfaces.NetworkStream;
using MockableSocket.Interfaces.Sockets;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MockableSocket.NetworkStream;

/// <summary>
/// This class is a fork from Microsoft's / the .NET Foundation's NetworkStream class.
/// All copyright of the original code belongs to them!
/// </summary>

public class NetworkStream : Stream, INetworkStream
{

    private readonly ISocket _streamSocket;

    private readonly bool _ownsSocket;

    private bool _readable;

    private bool _writeable;

    private int _disposed;

    /// <summary>
    /// Creates a new instance of the <see cref="NetworkStream"/> class for the specified <see cref="ISocket"/>.
    /// </summary>
    public NetworkStream(ISocket socket)
        : this(socket, FileAccess.ReadWrite, ownsSocket: false)
    {
    }

    public NetworkStream(ISocket socket, bool ownsSocket)
        : this(socket, FileAccess.ReadWrite, ownsSocket)
    {
    }

    public NetworkStream(ISocket socket, FileAccess access)
        : this(socket, access, ownsSocket: false)
    {
    }

    public NetworkStream(ISocket socket, FileAccess access, bool ownsSocket)
    {
        ArgumentNullException.ThrowIfNull(socket);

        if (!socket.Blocking)
        {
            // Stream.Read*/Write* are incompatible with the semantics of non-blocking sockets, and
            // allowing non-blocking sockets could result in non-deterministic failures from those
            // operations. A developer that requires using NetworkStream with a non-blocking socket can
            // temporarily flip Socket.Blocking as a workaround.
            throw new IOException("The operation is not allowed on a non - blocking Socket.");
        }
        if (!socket.Connected)
        {
            throw new IOException("The operation is not allowed on non-connected sockets.");
        }
        if (socket.SocketType != SocketType.Stream)
        {
            throw new IOException("The operation is not allowed on non-stream oriented sockets.");
        }

        _streamSocket = socket;
        _ownsSocket = ownsSocket;

        switch (access)
        {
            case FileAccess.Read:
                _readable = true;
                break;
            case FileAccess.Write:
                _writeable = true;
                break;
            case FileAccess.ReadWrite:
            default: // assume FileAccess.ReadWrite
                _readable = true;
                _writeable = true;
                break;
        }
    }

    /// <inheritdoc/>
    public ISocket Socket => _streamSocket;

    /// <inheritdoc/>
    protected bool Readable
    {
        get { return _readable; }
        set { _readable = value; }
    }

    /// <inheritdoc/>
    protected bool Writeable
    {
        get { return _writeable; }
        set { _writeable = value; }
    }

    /// <inheritdoc/>
    public override bool CanRead => _readable;

    /// <inheritdoc/>
    public override bool CanSeek => false;

    /// <inheritdoc/>
    public override bool CanWrite => _writeable;

    /// <inheritdoc/>
    public override bool CanTimeout => true;

    /// <inheritdoc/>
    public override int ReadTimeout
    {
        get
        {
            int timeout = (int)_streamSocket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout)!;
            if (timeout == 0)
            {
                return -1;
            }
            return timeout;
        }
        set
        {
            if (value <= 0 && value != System.Threading.Timeout.Infinite)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Timeout can be only be set to 'System.Threading.Timeout.Infinite' or a value &gt; 0.");
            }
            SetSocketTimeoutOption(SocketShutdown.Receive, value, false);
        }
    }

    /// <inheritdoc/>
    public override int WriteTimeout
    {
        get
        {
            int timeout = (int)_streamSocket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout)!;
            if (timeout == 0)
            {
                return -1;
            }
            return timeout;
        }
        set
        {
            if (value <= 0 && value != System.Threading.Timeout.Infinite)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Timeout can be only be set to 'System.Threading.Timeout.Infinite' or a value &gt; 0.");
            }
            SetSocketTimeoutOption(SocketShutdown.Send, value, false);
        }
    }

    /// <inheritdoc/>
    public virtual bool DataAvailable
    {
        get
        {
            ThrowIfDisposed();

            // Ask the socket how many bytes are available. If it's
            // not zero, return true.
            return _streamSocket.Available != 0;
        }
    }

    /// <inheritdoc/>
    public override long Length
    {
        get
        {
            throw new NotSupportedException("This stream does not support seek operations.");
        }
    }

    /// <inheritdoc/>
    public override long Position
    {
        get
        {
            throw new NotSupportedException("This stream does not support seek operations.");
        }

        set
        {
            throw new NotSupportedException("This stream does not support seek operations.");
        }
    }

    /// <inheritdoc/>
    public override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotSupportedException("This stream does not support seek operations.");
    }

    /// <inheritdoc/>
    public override int Read(byte[] buffer, int offset, int count)
    {
        ValidateBufferArguments(buffer, offset, count);
        ThrowIfDisposed();
        if (!CanRead)
        {
            throw new InvalidOperationException("This stream does not support seek operations.");
        }

        try
        {
            return _streamSocket.Receive(buffer, offset, count, 0);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException("Unable to read data from the transport connection: {0}.", exception);
        }
    }

    /// <inheritdoc/>
    public override int Read(Span<byte> buffer)
    {
        if (GetType() != typeof(NetworkStream))
        {
            // NetworkStream is not sealed, and a derived type may have overridden Read(byte[], int, int) prior
            // to this Read(Span<byte>) overload being introduced.  In that case, this Read(Span<byte>) overload
            // should use the behavior of Read(byte[],int,int) overload.
            return base.Read(buffer);
        }

        ThrowIfDisposed();
        if (!CanRead) throw new InvalidOperationException("The stream does not support reading. ");

        try
        {
            return _streamSocket.Receive(buffer, SocketFlags.None);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException("Unable to read data from the transport connection: {0}.", exception);
        }
    }

    /// <inheritdoc/>
    public override unsafe int ReadByte()
    {
        byte b;
        return Read(new Span<byte>(&b, 1)) == 0 ? -1 : b;
    }

    /// <inheritdoc/>
    public override void Write(byte[] buffer, int offset, int count)
    {
        ValidateBufferArguments(buffer, offset, count);
        ThrowIfDisposed();
        if (!CanWrite)
        {
            throw new InvalidOperationException(SR.net_readonlystream);
        }

        try
        {
            // Since the socket is in blocking mode this will always complete
            // after ALL the requested number of bytes was transferred.
            _streamSocket.Send(buffer, offset, count, SocketFlags.None);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException("The stream does not support writing", exception);
        }
    }

    /// <inheritdoc/>
    public override void Write(ReadOnlySpan<byte> buffer)
    {
        if (GetType() != typeof(NetworkStream))
        {
            // NetworkStream is not sealed, and a derived type may have overridden Write(byte[], int, int) prior
            // to this Write(ReadOnlySpan<byte>) overload being introduced.  In that case, this Write(ReadOnlySpan<byte>)
            // overload should use the behavior of Write(byte[],int,int) overload.
            base.Write(buffer);
            return;
        }

        ThrowIfDisposed();
        if (!CanWrite) throw new InvalidOperationException("The stream does not support writing.");

        try
        {
            _streamSocket.Send(buffer, SocketFlags.None);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException("Unable to write data to the transport connection: {0}.", exception);
        }
    }

    /// <inheritdoc/>
    public override unsafe void WriteByte(byte value) =>
        Write(new ReadOnlySpan<byte>(&value, 1));

    /// <inheritdoc/>
    private int _closeTimeout = ISocket.DefaultCloseTimeout; // -1 = respect linger options

    /// <inheritdoc/>
    public void Close(int timeout)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(timeout, -1);
        _closeTimeout = timeout;
        Dispose();
    }

    /// <inheritdoc/>
    public void Close(TimeSpan timeout) => Close(ToTimeoutMilliseconds(timeout));

    /// <inheritdoc/>
    private static int ToTimeoutMilliseconds(TimeSpan timeout)
    {
        long totalMilliseconds = (long)timeout.TotalMilliseconds;

        ArgumentOutOfRangeException.ThrowIfLessThan(totalMilliseconds, -1, nameof(timeout));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(totalMilliseconds, int.MaxValue, nameof(timeout));

        return (int)totalMilliseconds;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (Interlocked.Exchange(ref _disposed, 1) != 0)
        {
            return;
        }

        if (disposing)
        {
            // The only resource we need to free is the network stream, since this
            // is based on the client socket, closing the stream will cause us
            // to flush the data to the network, close the stream and (in the
            // NetoworkStream code) close the socket as well.
            _readable = false;
            _writeable = false;
            if (_ownsSocket)
            {
                // If we own the Socket (false by default), close it
                // ignoring possible exceptions (eg: the user told us
                // that we own the Socket but it closed at some point of time,
                // here we would get an ObjectDisposedException)
                _streamSocket.InternalShutdown(SocketShutdown.Both);
                _streamSocket.Close(_closeTimeout);
            }
        }

        base.Dispose(disposing);
    }

    /// <inheritdoc/>
    ~NetworkStream() => Dispose(false);

    /// <inheritdoc/>
    public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
    {
        ValidateBufferArguments(buffer, offset, count);
        ThrowIfDisposed();
        if (!CanRead)
        {
            throw new InvalidOperationException(SR.net_writeonlystream);
        }

        try
        {
            return _streamSocket.BeginReceive(
                    buffer,
                    offset,
                    count,
                    SocketFlags.None,
                    callback,
                    state);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException(SR.net_io_readfailure, exception);
        }
    }

    /// <inheritdoc/>
    public override int EndRead(IAsyncResult asyncResult)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(asyncResult);

        try
        {
            return _streamSocket.EndReceive(asyncResult);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException(SR.net_io_readfailure, exception);
        }
    }

    /// <inheritdoc/>
    public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
    {
        ValidateBufferArguments(buffer, offset, count);
        ThrowIfDisposed();
        if (!CanWrite)
        {
            throw new InvalidOperationException(SR.net_readonlystream);
        }

        try
        {
            // Call BeginSend on the Socket.
            return _streamSocket.BeginSend(
                    buffer,
                    offset,
                    count,
                    SocketFlags.None,
                    callback,
                    state);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException(SR.net_io_writefailure, exception);
        }
    }

    /// <inheritdoc/>
    public override void EndWrite(IAsyncResult asyncResult)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(asyncResult);

        try
        {
            _streamSocket.EndSend(asyncResult);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException(SR.net_io_writefailure, exception);
        }
    }

    /// <inheritdoc/>
    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        ValidateBufferArguments(buffer, offset, count);
        ThrowIfDisposed();
        if (!CanRead)
        {
            throw new InvalidOperationException(SR.net_writeonlystream);
        }

        try
        {
            return _streamSocket.ReceiveAsync(
                new Memory<byte>(buffer, offset, count),
                SocketFlags.None,
                fromNetworkStream: true,
                cancellationToken).AsTask();
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException(SR.net_io_readfailure, exception);
        }
    }

    /// <inheritdoc/>
    public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        bool canRead = CanRead; // Prevent race with Dispose.
        ThrowIfDisposed();
        if (!canRead)
        {
            throw new InvalidOperationException(SR.net_writeonlystream);
        }

        try
        {
            return _streamSocket.ReceiveAsync(
                buffer,
                SocketFlags.None,
                fromNetworkStream: true,
                cancellationToken: cancellationToken);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException(SR.net_io_readfailure, exception);
        }
    }

    /// <inheritdoc/>
    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        ValidateBufferArguments(buffer, offset, count);
        ThrowIfDisposed();
        if (!CanWrite)
        {
            throw new InvalidOperationException(SR.net_readonlystream);
        }

        try
        {
            return _streamSocket.SendAsyncForNetworkStream(
                new ReadOnlyMemory<byte>(buffer, offset, count),
                SocketFlags.None,
                cancellationToken).AsTask();
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException(SR.net_io_writefailure, exception);
        }
    }

    /// <inheritdoc/>
    public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        bool canWrite = CanWrite; // Prevent race with Dispose.
        ThrowIfDisposed();
        if (!canWrite)
        {
            throw new InvalidOperationException(SR.net_readonlystream);
        }

        try
        {
            return _streamSocket.SendAsyncForNetworkStream(
                buffer,
                SocketFlags.None,
                cancellationToken);
        }
        catch (Exception exception) when (!(exception is OutOfMemoryException))
        {
            throw WrapException(SR.net_io_writefailure, exception);
        }
    }

    /// <inheritdoc/>
    public override void Flush()
    {
    }

    public override Task FlushAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public override void SetLength(long value)
    {
        throw new NotSupportedException(SR.net_noseek);
    }

    private int _currentReadTimeout = -1;
    private int _currentWriteTimeout = -1;
    internal void SetSocketTimeoutOption(SocketShutdown mode, int timeout, bool silent)
    {
        if (timeout < 0)
        {
            timeout = 0; // -1 becomes 0 for the winsock stack
        }

        if (mode == SocketShutdown.Send || mode == SocketShutdown.Both)
        {
            if (timeout != _currentWriteTimeout)
            {
                _streamSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, timeout, silent);
                _currentWriteTimeout = timeout;
            }
        }

        if (mode == SocketShutdown.Receive || mode == SocketShutdown.Both)
        {
            if (timeout != _currentReadTimeout)
            {
                _streamSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, timeout, silent);
                _currentReadTimeout = timeout;
            }
        }
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed != 0, this);
    }

    private static IOException WrapException(string resourceFormatString, Exception innerException)
    {
        return new IOException(SR.Format(resourceFormatString, innerException.Message), innerException);
    }
}
