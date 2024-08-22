using MockableTcp.Interfaces;
using System.Net;
using System.Net.Sockets;

namespace MockableTcp.Sockets;

/// <summary>
/// Wraps <see cref="Socket"/> to implement ISocket
/// </summary>
public class SocketWrapper : ISocket
{
    private readonly Socket _socket;
    private bool _disposed;

    /// <summary>
    /// Creates a new instance of <see cref="SocketWrapper"/> for the specific socket handle.
    /// </summary>
    /// <param name="handle">The socket handle for the <see cref="SocketWrapper"/> that the Socket object will encapsulate.</param>
    public SocketWrapper(SafeSocketHandle handle)
    {
        _socket = new Socket(handle);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketWrapper"/> using the specified value returned from <see cref="DuplicateAndClose"/>
    /// </summary>
    /// <param name="socketInformation">The socket information returned by <see cref="DuplicateAndClose"/></param>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public SocketWrapper(SocketInformation socketInformation)
    {
        _socket = new Socket(socketInformation);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketWrapper"/> using the specified socket type and protocol.<br/>If the operating system supports IPv6, this constructor creates a dual-mode socket; otherwise, it creates an IPv4 socket.
    /// </summary>
    /// <param name="socketType">One of the <see cref="SocketType"/> values.</param>
    /// <param name="protocolType">One of the <see cref="ProtocolType"/> values.</param>
    public SocketWrapper(SocketType socketType, ProtocolType protocolType)
    {
        _socket = new Socket(socketType, protocolType);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketWrapper" /> using the specified address family, socket type and protocol.
    /// </summary>
    /// <param name="addressFamily">One of the <see cref="AddressFamily"/> values.</param>
    /// <param name="socketType">One of the <see cref="SocketType"/> values.</param>
    /// <param name="protocolType">One of the <see cref="ProtocolType"/> values.</param>
    public SocketWrapper(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
    {
        _socket = new Socket(addressFamily, socketType, protocolType);
    }

    /// <inheritdoc/>
    public AddressFamily AddressFamily { get => _socket.AddressFamily; }

    /// <inheritdoc/>
    public int Available { get => _socket.Available; }

    /// <inheritdoc/>
    public bool Blocking { get => _socket.Blocking; set => _socket.Blocking = value; }

    /// <inheritdoc/>
    public bool Connected { get => _socket.Connected; }

    /// <inheritdoc/>
    public bool DontFragment { get => _socket.DontFragment; set => _socket.DontFragment = value; }

    /// <inheritdoc/>
    public bool DualMode { get => _socket.DualMode; set => _socket.DualMode = value; }

    /// <inheritdoc/>
    public bool EnableBroadcast { get => _socket.EnableBroadcast; set => _socket.EnableBroadcast = value; }

    /// <inheritdoc/>
    public bool ExclusiveAddressUse { get => _socket.ExclusiveAddressUse; set => _socket.ExclusiveAddressUse = value; }

    /// <inheritdoc/>
    public IntPtr Handle { get => _socket.Handle; }

    /// <inheritdoc/>
    public bool IsBound { get => _socket.IsBound; }

    /// <inheritdoc/>
    public LingerOption? LingerState { get => _socket.LingerState; set => _socket.LingerState = value!; }

    /// <inheritdoc/>
    public EndPoint? LocalEndPoint { get => _socket.LocalEndPoint; }

    /// <inheritdoc/>
    public bool MulticastLoopback { get => _socket.MulticastLoopback; set => _socket.MulticastLoopback = value; }

    /// <inheritdoc/>
    public bool NoDelay { get => _socket.NoDelay; set => _socket.NoDelay = value; }

    /// <inheritdoc/>
    public static bool OSSupportsIPv4 { get => Socket.OSSupportsIPv4; }

    /// <inheritdoc/>
    public static bool OSSupportsIPv6 { get => Socket.OSSupportsIPv6; }

    /// <inheritdoc/>
    public static bool OSSupportsUnixDomainSockets { get => Socket.OSSupportsUnixDomainSockets; }

    /// <inheritdoc/>
    public ProtocolType ProtocolType { get => _socket.ProtocolType; }

    /// <inheritdoc/>
    public int ReceiveBufferSize { get => _socket.ReceiveBufferSize; set => _socket.ReceiveBufferSize = value; }

    /// <inheritdoc/>
    public int ReceiveTimeout { get => _socket.ReceiveTimeout; set => _socket.ReceiveTimeout = value; }

    /// <inheritdoc/>
    public EndPoint? RemoteEndPoint { get => _socket.RemoteEndPoint; }

    /// <inheritdoc/>
    public SafeSocketHandle SafeHandle { get => _socket.SafeHandle; }

    /// <inheritdoc/>
    public int SendBufferSize { get => _socket.SendBufferSize; set => _socket.SendBufferSize = value; }

    /// <inheritdoc/>
    public int SendTimeout { get => _socket.SendTimeout; set => _socket.SendTimeout = value; }

    /// <inheritdoc/>
    public SocketType SocketType { get => _socket.SocketType; }

    /// <inheritdoc/>
    public short Ttl { get => _socket.Ttl; set => _socket.Ttl = value; }

    /// <inheritdoc/>
    public ISocket Accept()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<ISocket> AcceptAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<ISocket> AcceptAsync(ISocket? acceptSocket)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool AcceptAsync(SocketAsyncEventArgs e)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public ValueTask<ISocket> AcceptAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public ValueTask<ISocket> AcceptAsync(ISocket? acceptSocket, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginAccept(AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginAccept(int receiveSize, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginAccept(ISocket? acceptSocket, int receiveSize, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(IPAddress address, int port, AsyncCallback? requestCallback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(IPAddress[] addresses, int port, AsyncCallback? requestCallback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(string host, int port, AsyncCallback? requestCallback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginDisconnect(bool reuseSocket, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult? BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult? BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginReceiveMessageFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult? BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult? BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSendFile(string? fileName, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSendFile(string? fileName, byte[]? preBuffer, byte[]? postBuffer, TransmitFileOptions flags, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP, AsyncCallback? callback, object? state)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void Bind(EndPoint localEP)
    {
        _socket.Bind(localEP);
    }

    /// <inheritdoc/>
    public void Connect(EndPoint remoteEndpoint)
    {
        _socket.Connect(remoteEndpoint);
    }

    /// <inheritdoc/>
    public async Task ConnectAsync(IPEndPoint remoteEndpoint, CancellationToken cancellationToken = default)
    {
        await _socket.ConnectAsync(remoteEndpoint, cancellationToken);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Send(buffer, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public async Task<int> SendAsync(byte[] buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default)
    {
        return await _socket.SendAsync(buffer, socketFlags, cancellationToken);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Receive(buffer, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public async Task<int> ReceiveAsync(byte[] buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default)
    {
        return await _socket.ReceiveAsync(buffer, SocketFlags.None, cancellationToken);
    }

    /// <inheritdoc/>
    public void Close()
    {
        _socket.Close();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~SocketWrapper()
    {
        Dispose(false);
    }

    /// <inheritdoc/>
    public void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _socket.Close();
            _disposed = true;
        }
    }
}