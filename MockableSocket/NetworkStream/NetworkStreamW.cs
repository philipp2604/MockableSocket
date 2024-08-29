using MockableSocket.Interfaces.NetworkStream;
using MockableSocket.Interfaces.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MockableSocket.NetworkStream;

/// <summary>
/// Wraps <see cref="NetworkStream"/> to implement <see cref="INetworkStream"/> and to support <see cref="ISocket"/>
/// </summary>
public class NetworkStreamW : Stream, INetworkStream
{
    private bool _disposed;
    private readonly bool _ownsSocket;

    /// <summary>
    /// Creates a new instance of the <see cref="NetworkStreamW"/> class for the specified <see cref="ISocket"/>.
    /// </summary>
    /// <param name="socket">The <see cref="ISocket"/> that the <see cref="NetworkStreamW"/> will use to send and receive data.</param>
    public NetworkStreamW(ISocket socket) : this(socket, FileAccess.ReadWrite, false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NetworkStreamW"/> class for the specified <see cref="ISocket"/> with the specified Socket ownership.
    /// </summary>
    /// <param name="socket">The <see cref="ISocket"/> that the <see cref="NetworkStreamW"/> will use to send and receive data.</param>
    /// <param name="ownsSocket">Set to true to indicate that the <see cref="NetworkStreamW"/> will take ownership of the <see cref="ISocket"/>; otherwise, false.</param>
    public NetworkStreamW(ISocket socket, bool ownsSocket) : this (socket, FileAccess.ReadWrite, ownsSocket)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="NetworkStreamW"/> class for the specified <see cref="ISocket"/> with the specified access rights.
    /// </summary>
    /// <param name="socket">The <see cref="ISocket"/> that the <see cref="NetworkStreamW"/> will use to send and receive data.</param>
    /// <param name="access">A bitwise combination of the <see cref="FileAccess"/> values that specify the type of access given to the <see cref="NetworkStreamW"/> over the provided <see cref="ISocket"/>.</param>
    public NetworkStreamW(ISocket socket, FileAccess access) : this (socket, access, false)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="NetworkStreamW"/> class for the specified <see cref="ISocket"/> with the specified access rights and the specified <see cref="ISocket"/> ownership.
    /// </summary>
    /// <param name="socket">The <see cref="ISocket"/> that the <see cref="NetworkStreamW"/> will use to send and receive data.</param>
    /// <param name="access">A bitwise combination of the <see cref="FileAccess"/> values that specify the type of access given to the <see cref="NetworkStreamW"/> over the provided <see cref="ISocket"/>.</param>
    /// <param name="ownsSocket">Set to true to indicate that the <see cref="NetworkStreamW"/> will take ownership of the <see cref="ISocket"/>; otherwise, false.</param>
    public NetworkStreamW(ISocket socket, FileAccess access, bool ownsSocket)
    {
        Socket = socket;
        _ownsSocket = ownsSocket;
        NetworkStream = new System.Net.Sockets.NetworkStream(socket.Socket, access, ownsSocket);
    }

    /// <inheritdoc/>v
    public override bool CanRead { get => NetworkStream.CanRead; }

    /// <inheritdoc/>
    public override bool CanSeek { get => NetworkStream.CanSeek; }

    /// <inheritdoc/>
    public override bool CanTimeout { get => NetworkStream.CanTimeout; }

    /// <inheritdoc/>
    public override bool CanWrite { get; }

    /// <inheritdoc/>
    public virtual bool DataAvailable { get => NetworkStream.DataAvailable; }

    /// <inheritdoc/>
    public override long Length { get; }

    /// <inheritdoc/>
    public System.Net.Sockets.NetworkStream NetworkStream { get; }

    /// <inheritdoc/>
    public override long Position { get => NetworkStream.Position; set => NetworkStream.Position = value; }

    /// <inheritdoc/>
    public bool Readable { get => CanRead; }

    /// <inheritdoc/>
    public override int ReadTimeout { get => NetworkStream.ReadTimeout; set => NetworkStream.ReadTimeout = value; }

    /// <inheritdoc/>
    public ISocket Socket { get; }

    /// <inheritdoc/>
    public bool Writeable { get => CanWrite; }

    /// <inheritdoc/>
    public override int WriteTimeout { get => NetworkStream.WriteTimeout; set => NetworkStream.WriteTimeout = value; }

    /// <inheritdoc/>
    public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
    {
        return NetworkStream.BeginRead(buffer, offset, count, callback, state);
    }

    /// <inheritdoc/>
    public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
    {
        return NetworkStream.BeginWrite(buffer, offset, count, callback, state);
    }

    /// <inheritdoc/>
    public void Close(int timeout)
    {
        NetworkStream.Close(timeout);
        Dispose();
    }

    /// <inheritdoc/>
    public void Close(TimeSpan timeout)
    {
        NetworkStream.Close(timeout);
        Dispose();
    }

    public new void CopyTo(Stream destination)
    {
        NetworkStream.CopyTo(destination);
    }

    /// <inheritdoc/>
    public new void CopyTo(Stream destination, int bufferSize)
    {
        NetworkStream.CopyTo(destination, bufferSize);
    }

    /// <inheritdoc/>
    public new Task CopyToAsync(Stream destination)
    {
        return NetworkStream.CopyToAsync(destination);
    }

    /// <inheritdoc/>
    public new Task CopyToAsync(Stream destination, CancellationToken cancellationToken)
    {
        return NetworkStream.CopyToAsync(destination, cancellationToken);
    }

    /// <inheritdoc/>
    public new Task CopyToAsync(Stream destination, int bufferSize)
    {
        return NetworkStream.CopyToAsync(destination, bufferSize);
    }

    /// <inheritdoc/>
    public new Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
    {
        return NetworkStream.CopyToAsync(destination, bufferSize, cancellationToken);
    }

    protected override void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        NetworkStream.Dispose();
        if (_ownsSocket)
            Socket.Close();
        _disposed = true;
    }

    public new void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public new virtual ValueTask DisposeAsync()
    {
        return NetworkStream.DisposeAsync();
    }

    /// <summary>
    /// Handles the end of an asynchronous read.
    /// </summary>
    /// <param name="asyncResult">The <see cref="IAsyncResult"/> that represents the asynchronous call.</param>
    /// <returns>The number of bytes read from the <see cref="INetworkStream"/>.</returns>
    public override int EndRead(IAsyncResult asyncResult)
    {
        return NetworkStream.EndRead(asyncResult);
    }

    /// <summary>
    /// Handles the end of an asynchronous write.
    /// </summary>
    /// <param name="asyncResult">The <see cref="IAsyncResult"/> that represents the asynchronous call.</param>
    public override void EndWrite(IAsyncResult asyncResult)
    {
        NetworkStream.EndWrite(asyncResult);
    }

    /// <summary>
    /// Flushes data from the stream. This method is reserved for future use.
    /// </summary>
    public override void Flush()
    {
        NetworkStream.Flush();
    }

    /// <summary>
    /// Flushes data from the stream as an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public override Task FlushAsync(CancellationToken cancellationToken)
    {
        return NetworkStream.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Reads data from the <see cref="INetworkStream"/> and stores it to a byte array.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the location in memory to store data read from the <see cref="INetworkStream"/>.</param>
    /// <param name="offset">The location in buffer to begin storing the data to.</param>
    /// <param name="count">The number of bytes to read from the <see cref="INetworkStream"/>.</param>
    /// <returns>The number of bytes read from the <see cref="INetworkStream"/>.</returns>
    public override int Read(byte[] buffer, int offset, int count)
    {
        return NetworkStream.Read(buffer, offset, count);
    }

    /// <summary>
    /// Reads data from the <see cref="INetworkStream"/> and stores it to a span of bytes in memory.
    /// </summary>
    /// <param name="buffer">A region of memory to store data read from the <see cref="INetworkStream"/>.</param>
    /// <returns>The number of bytes read from the <see cref="INetworkStream"/>.</returns>
    public override int Read(Span<byte> buffer)
    {
        return NetworkStream.Read(buffer);
    }

    /// <summary>
    /// Reads data from the <see cref="INetworkStream"/> and stores it to a specified range of a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="buffer">The buffer to write the data into.</param>
    /// <param name="offset">The location in buffer to begin storing the data to.</param>
    /// <param name="count">The number of bytes to read from the <see cref="INetworkStream"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        return NetworkStream.ReadAsync(buffer, offset, count, cancellationToken);
    }

    /// <summary>
    /// Reads data from the <see cref="INetworkStream"/> and stores it in a byte memory range as an asynchronous operation.
    /// </summary>
    /// <param name="buffer">The buffer to write the data to.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        return NetworkStream.ReadAsync(buffer, cancellationToken);
    }

    /// <summary>
    /// Reads a <see cref="byte"/> from the <see cref="INetworkStream"/> and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
    /// </summary>
    /// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
    public override unsafe int ReadByte()
    {
        return NetworkStream.ReadByte();
    }

    /// <summary>
    /// Sets the current position of the stream to the given value. This method is not currently supported and always throws a <see cref="NotSupportedException"/>.
    /// </summary>
    /// <param name="offset">This parameter is not used.</param>
    /// <param name="origin">This parameter is not used.</param>
    /// <returns>The position in the stream.</returns>
    public override long Seek(long offset, SeekOrigin origin)
    {
        return NetworkStream.Seek(offset, origin);
    }

    /// <summary>
    /// Sets the length of the stream. This method always throws a <see cref="NotSupportedException"/>.
    /// </summary>
    /// <param name="value">This parameter is not used.</param>
    public override void SetLength(long value)
    {
        NetworkStream.SetLength(value);
    }

    /// <summary>
    /// Writes data to the <see cref="INetworkStream"/> from a specified range of a byte array.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to write to the <see cref="INetworkStream"/>.</param>
    /// <param name="offset">The location in buffer from which to start writing data.</param>
    /// <param name="count">The number of bytes to write to the <see cref="INetworkStream"/>.</param>
    public override void Write(byte[] buffer, int offset, int count)
    {
        NetworkStream.Write(buffer, offset, count);
    }

    /// <summary>
    /// Writes data to the <see cref="INetworkStream"/> from a read-only byte span.
    /// </summary>
    /// <param name="buffer">The data to write to the <see cref="INetworkStream"/>.</param>
    public override void Write(ReadOnlySpan<byte> buffer)
    {
        NetworkStream.Write(buffer);
    }

    /// <summary>
    /// Writes data to the <see cref="INetworkStream"/> from the specified range of a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="buffer">A <see cref="byte"/> array that contains the data to write to the <see cref="INetworkStream"/>.</param>
    /// <param name="offset">The location in buffer from which to start writing data.</param>
    /// <param name="count">The number of bytes to write to the <see cref="INetworkStream"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        return NetworkStream.WriteAsync(buffer, offset,count, cancellationToken);
    }

    /// <summary>
    /// Writes data to the <see cref="INetworkStream"/> from a read-only memory byte memory range as an asynchronous operation.
    /// </summary>
    /// <param name="buffer">The region of memory to write data from.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        return NetworkStream.WriteAsync(buffer, cancellationToken);
    }

    /// <summary>
    /// Writes a byte to the current position in the stream and advances the position within the stream by one byte.
    /// </summary>
    /// <param name="value">The byte to write to the stream.</param>
    public override unsafe void WriteByte(byte value)
    {
        NetworkStream.WriteByte(value);
    }

    ~NetworkStreamW()
    {
        Dispose(false);
    }
}
