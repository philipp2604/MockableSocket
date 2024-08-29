using MockableSocket.Interfaces.NetworkStream;
using MockableSocket.Interfaces.Sockets;
using MockableSocket.Interfaces.Tcp;
using MockableSocket.NetworkStream;
using MockableSocket.Sockets;
using System.Net;
using System.Net.Sockets;

namespace MockableSocket.Tcp;

/// <summary>
/// A class implementing <see cref="ITcpClient"/>, providing TCP services, compatible to <see cref="System.Net.Sockets.TcpClient"/>.
/// </summary>
public class TcpClient : ITcpClient
{
    private bool _disposed;
    private INetworkStream? _stream;

    /// <summary>
    /// Creates a new instance of <see cref="TcpClient"/>.
    /// </summary>
    /// <param name="client">An <see cref="ISocket"/> to use as underlying socket.</param>
    public TcpClient(ISocket? client = null)
    {
        Client = client ?? new SocketW(SocketType.Stream, ProtocolType.Tcp);
    }

    /// <summary>
    /// Creates a new instance of <see cref="TcpClient"/> and binds it to the specified local <see cref="IPEndPoint"/>.
    /// </summary>
    /// <param name="localEndPoint">The <see cref="IPEndPoint"/> to which you bind the TCP Socket.</param>
    /// <param name="client">An <see cref="ISocket"/> to use as underlying socket.</param>
    public TcpClient(IPEndPoint localEndPoint, ISocket? client = null)
    {
        ArgumentNullException.ThrowIfNull(localEndPoint, nameof(localEndPoint));

        Client = client ?? (localEndPoint.AddressFamily == AddressFamily.Unknown
                ? new SocketW(SocketType.Stream, ProtocolType.Tcp)
                : (ISocket)new SocketW(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp));

        Client!.Bind(localEndPoint);
    }

    /// <summary>
    /// Creates a new instance of <see cref="TcpClient"/> with the specified <see cref="AddressFamily"/>.
    /// </summary>
    /// <param name="family">The <see cref="AddressFamily"/> of the IP protocol.</param>
    /// <param name="client">An <see cref="ISocket"/> to use as underlying socket.</param>
    public TcpClient(AddressFamily family, ISocket? client = null)
    {
        Client = client ?? (family == AddressFamily.Unknown
            ? new SocketW(SocketType.Stream, ProtocolType.Tcp)
            : (ISocket)new SocketW(family, SocketType.Stream, ProtocolType.Tcp));
    }

    /// <summary>
    /// Creates a new instance of <see cref="TcpClient"/> and connects to the specified host and port.
    /// </summary>
    /// <param name="host">The DNS name of the remote host to connect to.</param>
    /// <param name="port">The port number to connect to.</param>
    /// <param name="client">An <see cref="ISocket"/> to use as underlying socket.</param>
    public TcpClient(string host, int port, ISocket? client = null) : this(AddressFamily.Unknown, client)
    {
        try
        {
            Connect(host, port);
        }
        catch
        {
            Client.Close();
            throw;
        }
    }

    /// <inheritdoc/>
    public bool Active { get; private set; }

    /// <inheritdoc/>
    public bool Connected => Client.Connected;

    /// <inheritdoc/>
    public ISocket Client { get; set; }

    /// <inheritdoc/>
    public bool ExclusiveAddressUse { get => Client.ExclusiveAddressUse; set => Client.ExclusiveAddressUse = value; }

    /// <inheritdoc/>
    public LingerOption? LingerState { get => Client.LingerState; set => Client.LingerState = value; }

    /// <inheritdoc/>
    public bool NoDelay { get => Client.NoDelay; set => Client.NoDelay = value; }

    /// <inheritdoc/>
    public int ReceiveBufferSize { get => Client.ReceiveBufferSize; set => Client.ReceiveBufferSize = value; }

    /// <inheritdoc/>
    public int ReceiveTimeout { get => Client.ReceiveTimeout; set => Client.ReceiveTimeout = value; }

    /// <inheritdoc/>
    public int SendBufferSize { get => Client.SendBufferSize; set => Client.SendBufferSize = value; }

    /// <inheritdoc/>
    public int SendTimeout { get => Client.SendTimeout; set => Client.SendTimeout = value; }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(IPAddress address, int port, AsyncCallback? requestCallback, object? state)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return Client.BeginConnect(address, port, requestCallback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(IPAddress[] addresses, int port, AsyncCallback? requestCallback, object? state)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return Client.BeginConnect(addresses, port, requestCallback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(string host, int port, AsyncCallback? requestCallback, object? state)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return Client.BeginConnect(host, port, requestCallback, state);
    }

    /// <inheritdoc/>
    public void Close()
    {
        Active = false;
        Dispose();
    }

    /// <inheritdoc/>
    public void Connect(IPEndPoint remoteEndPoint)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        Client.Connect(remoteEndPoint);
        Active = true;
    }

    /// <inheritdoc/>
    public void Connect(IPAddress address, int port)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        Client.Connect(address, port);
        Active = true;
    }

    /// <inheritdoc/>
    public void Connect(IPAddress[] addresses, int port)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        Client.Connect(addresses, port);
        Active = true;
    }

    /// <inheritdoc/>
    public void Connect(string host, int port)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        Client.Connect(host, port);
        Active = true;
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(string host, int port, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return CompleteConnectAsync(Client.ConnectAsync(host, port, cancellationToken));
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(IPAddress[] addresses, int port, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return CompleteConnectAsync(Client.ConnectAsync(addresses, port, cancellationToken));
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(IPAddress address, int port, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return CompleteConnectAsync(Client.ConnectAsync(address, port, cancellationToken));
    }

    /// <inheritdoc/>
    public Task ConnectAsync(string host, int port)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return CompleteConnectAsync(Client.ConnectAsync(host, port));
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(IPEndPoint remoteEP, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return CompleteConnectAsync(Client.ConnectAsync(remoteEP, cancellationToken));
    }

    /// <inheritdoc/>
    public Task ConnectAsync(IPAddress[] addresses, int port)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return CompleteConnectAsync(Client.ConnectAsync(addresses, port));
    }

    /// <inheritdoc/>
    public Task ConnectAsync(IPAddress address, int port)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        return CompleteConnectAsync(Client.ConnectAsync(address, port));
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                if (_stream != null)
                {
                    _stream.Dispose();
                }
                else
                {
                    try
                    {
                        Client?.Shutdown(SocketShutdown.Both);
                    }
                    finally
                    {
                        Client?.Close();
                    }
                }
            }
            _disposed = true;
            Active = false;
        }
    }

    /// <inheritdoc/>
    public void EndConnect(IAsyncResult asyncResult)
    {
        ArgumentNullException.ThrowIfNull(Client, nameof(Client));
        Client.EndConnect(asyncResult);
        Active = true;
    }

    /// <inheritdoc/>
    public INetworkStream GetStream()
    {
        return !Connected ? throw new InvalidOperationException() : (_stream ??= new NetworkStreamW(Client, true));
    }

    private async ValueTask CompleteConnectAsync(ValueTask task)
    {
        await task.ConfigureAwait(false);
        Active = true;
    }

    private async Task CompleteConnectAsync(Task task)
    {
        await task.ConfigureAwait(false);
        Active = true;
    }

    ~TcpClient()
    {
        Dispose(false);
    }
}