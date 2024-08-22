using MockableTcp.Interfaces;
using System.Net;
using System.Net.Sockets;

namespace MockableTcp;

/// <summary>
/// A class implementing <see cref="ITcpClient"/>
/// </summary>
/// <remarks>
/// Creates a new instance of TcpClient class.
/// </remarks>
public class TcpClient(ISocketFactory socketFactory) : ITcpClient
{
    private bool _disposed;
    private readonly ISocketFactory _socketFactory = socketFactory;

    /// <inheritdoc/>
    public event EventHandler? Connected;

    /// <inheritdoc/>
    public event EventHandler? Disconnected;

    /// <inheritdoc/>
    public bool IsConnected { get; private set; }

    /// <inheritdoc/>
    public ISocket? Socket { get; private set; }

    /// <inheritdoc/>
    public int ReceiveBufferSize { get; set; } = 8192;

    /// <inheritdoc/>
    public int SendBufferSize { get; set; } = 8192;

    /// <inheritdoc/>
    public TimeSpan ReceiveTimeout { get; set; } = TimeSpan.FromSeconds(1);

    /// <inheritdoc/>
    public TimeSpan SendTimeout { get; set; } = TimeSpan.FromSeconds(1);

    /// <inheritdoc/>
    public IPEndPoint? IPEndPoint { get; set; }

    /// <inheritdoc/>
    public void Initialize(IPEndPoint? ipEndPoint = null)
    {
        if(ipEndPoint != null)
            IPEndPoint = ipEndPoint;

        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentNullException.ThrowIfNull(IPEndPoint, nameof(IPEndPoint));

        Disconnect();

        Socket = IPEndPoint != null ? _socketFactory.CreateSocket(IPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp) : _socketFactory.CreateSocket(null, SocketType.Stream, ProtocolType.Tcp);
        Socket.ReceiveBufferSize = ReceiveBufferSize;
        Socket.SendBufferSize = SendBufferSize;
        Socket.ReceiveTimeout = ReceiveTimeout.Milliseconds;
        Socket.SendTimeout = SendTimeout.Milliseconds;
    }

    /// <inheritdoc/>
    public void Connect()
    {
        if (Socket == null)
            Initialize();

        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentNullException.ThrowIfNull(IPEndPoint, nameof(IPEndPoint));

        if (Socket == null)
            throw new NullReferenceException(nameof(Socket));

        try
        {
            Socket.Connect(IPEndPoint);
            IsConnected = true;
            Connected?.Invoke(this, EventArgs.Empty);
        }
        catch
        {
            Disconnect();
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        if (IsConnected)
            return;

        if (Socket == null)
            Initialize();

        ObjectDisposedException.ThrowIf(_disposed, this);
        if (IPEndPoint == null)
            throw new NullReferenceException(nameof(IPEndPoint));

        if (Socket == null)
            throw new NullReferenceException(nameof(Socket));

        try
        {
            await Socket.ConnectAsync(IPEndPoint, cancellationToken);
            IsConnected = true;
            Connected?.Invoke(this, EventArgs.Empty);
        }
        catch
        {
            Disconnect();
            throw;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~TcpClient()
    {
        Dispose(false);
    }

    /// <inheritdoc/>
    public void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            Disconnect();
            _disposed = true;
        }
    }

    /// <inheritdoc/>
    public int Send(List<byte> buffer)
    {
        ArgumentNullException.ThrowIfNull(buffer);

        ArgumentOutOfRangeException.ThrowIfZero(buffer.Count, nameof(buffer));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(buffer.Count, SendBufferSize);

        ObjectDisposedException.ThrowIf(_disposed, this);
        if (Socket == null)
            throw new NullReferenceException(nameof(Socket));

        if (!IsConnected)
            throw new InvalidOperationException("Socket not connected.");

        try
        {
            var sentBytes = Socket.Send([.. buffer], SocketFlags.None, out SocketError ec);

            if (ec != SocketError.Success)
                Disconnect();

            return sentBytes;
        }
        catch (Exception)
        {
            Disconnect();
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<int> SendAsync(List<byte> buffer, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(buffer);

        ArgumentOutOfRangeException.ThrowIfZero(buffer.Count, nameof(buffer));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(buffer.Count, SendBufferSize);

        ObjectDisposedException.ThrowIf(_disposed, this);
        if (Socket == null)
            throw new NullReferenceException(nameof(Socket));

        if (!IsConnected)
            throw new InvalidOperationException("Socket not connected.");

        try
        {
            return await Socket.SendAsync([.. buffer], SocketFlags.None, cancellationToken);
        }
        catch (Exception)
        {
            Disconnect();
            throw;
        }
    }

    /// <inheritdoc/>
    public List<byte> Receive()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        if (Socket == null)
            throw new NullReferenceException(nameof(Socket));

        if (!IsConnected)
            throw new InvalidOperationException("Socket not connected.");

        try
        {
            var buffer = new byte[ReceiveBufferSize];
            var receivedBytes = Socket.Receive(buffer, SocketFlags.None, out SocketError ec);

            if (ec != SocketError.Success)
                Disconnect();

            List<byte> result = new(buffer);
            result.RemoveRange(receivedBytes, result.Count - receivedBytes);
            return result;
        }
        catch (Exception)
        {
            Disconnect();
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<List<byte>> ReceiveAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        if (Socket == null)
            throw new NullReferenceException(nameof(Socket));

        if (!IsConnected)
            throw new InvalidOperationException("Socket not connected.");

        try
        {
            var buffer = new byte[ReceiveBufferSize];
            var receivedBytes = await Socket.ReceiveAsync(buffer, SocketFlags.None, cancellationToken);

            List<byte> result = new(buffer);
            result.RemoveRange(receivedBytes, result.Count - receivedBytes);
            return result;
        }
        catch (Exception)
        {
            Disconnect();
            throw;
        }
    }

    /// <inheritdoc/>
    public void Disconnect()
    {
        if (IsConnected && Socket != null)
            Disconnected?.Invoke(this, EventArgs.Empty);

        IsConnected = false;
        Socket?.Close();
    }
}