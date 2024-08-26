using MockableTcp.Interfaces;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace MockableTcp.Sockets;

#pragma warning disable RCS1047 // Non-asynchronous method name should not end with 'Async'

/// <summary>
/// Wraps <see cref="Socket"/> to implement ISocket
/// </summary>
public class SocketW : ISocket
{
    private readonly Socket _socket;
    private bool _disposed;

    /// <summary>
    /// Creates a new instance of <see cref="SocketW"/> for the specific <see cref="Socket"/>
    /// </summary>
    /// <param name="socket">The <see cref="Socket"/> for the <see cref="SocketW"/> to encapsulate.</param>
    public SocketW(Socket socket)
    {
        _socket = socket;
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketW"/> for the specific socket handle.
    /// </summary>
    /// <param name="handle">The socket handle for the <see cref="SocketW"/> to encapsulate.</param>
    public SocketW(SafeSocketHandle handle)
    {
        _socket = new Socket(handle);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketW"/> using the specified value returned from <see cref="DuplicateAndClose"/>
    /// </summary>
    /// <param name="socketInformation">The socket information returned by <see cref="DuplicateAndClose"/></param>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public SocketW(SocketInformation socketInformation)
    {
        _socket = new Socket(socketInformation);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketW"/> using the specified socket type and protocol.<br/>If the operating system supports IPv6, this constructor creates a dual-mode socket; otherwise, it creates an IPv4 socket.
    /// </summary>
    /// <param name="socketType">One of the <see cref="SocketType"/> values.</param>
    /// <param name="protocolType">One of the <see cref="ProtocolType"/> values.</param>
    public SocketW(SocketType socketType, ProtocolType protocolType)
    {
        _socket = new Socket(socketType, protocolType);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketW" /> using the specified address family, socket type and protocol.
    /// </summary>
    /// <param name="addressFamily">One of the <see cref="AddressFamily"/> values.</param>
    /// <param name="socketType">One of the <see cref="SocketType"/> values.</param>
    /// <param name="protocolType">One of the <see cref="ProtocolType"/> values.</param>
    public SocketW(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
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

    /// <summary>
    /// Cancels an asynchronous request for a remote host connection.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object used to request the connection to the remote host by calling one of the <see cref="ConnectAsync(SocketType, ProtocolType, SocketAsyncEventArgs)"/> methods.</param>
    public static void CancelConnectAsync(SocketAsyncEventArgs e)
    {
        Socket.CancelConnectAsync(e);
    }

    /// <inheritdoc/>
    public void Close()
    {
        _socket.Close();
    }

    /// <inheritdoc/>
    public void Close(int timeout)
    {
        _socket.Close(timeout);
    }

    /// <inheritdoc/>
    public void Connect(EndPoint remoteEP)
    {
        _socket.Connect(remoteEP);
    }

    /// <inheritdoc/>
    public void Connect(IPAddress address, int port)
    {
        _socket.Connect(address, port);
    }

    /// <inheritdoc/>
    public void Connect(IPAddress[] addresses, int port)
    {
        _socket.Connect(addresses, port);
    }

    /// <inheritdoc/>
    public void Connect(string host, int port)
    {
        _socket.Connect(host, port);
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(IPAddress[] addresses, int port, CancellationToken cancellationToken)
    {
        return _socket.ConnectAsync(addresses, port, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(string host, int port, CancellationToken cancellationToken)
    {
        return _socket.ConnectAsync(host, port, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(IPAddress address, int port, CancellationToken cancellationToken)
    {
        return _socket.ConnectAsync(address, port, cancellationToken);
    }

    /// <inheritdoc/>
    public Task ConnectAsync(string host, int port)
    {
        return _socket.ConnectAsync(host, port);
    }

    /// <inheritdoc/>
    public Task ConnectAsync(IPAddress[] addresses, int port)
    {
        return _socket.ConnectAsync(addresses, port);
    }

    /// <inheritdoc/>
    public Task ConnectAsync(IPAddress address, int port)
    {
        return _socket.ConnectAsync(address, port);
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(EndPoint remoteEP, CancellationToken cancellationToken)
    {
        return _socket.ConnectAsync(remoteEP, cancellationToken);
    }

    /// <inheritdoc/>
    public bool ConnectAsync(SocketAsyncEventArgs e)
    {
        return _socket.ConnectAsync(e);
    }

    /// <inheritdoc/>
    public Task ConnectAsync(EndPoint remoteEP)
    {
        return _socket.ConnectAsync(remoteEP);
    }

    /// <inheritdoc/>
    public void Disconnect(bool reuseSocket)
    {
        _socket.Disconnect(reuseSocket);
    }

    /// <inheritdoc/>
    public bool DisconnectAsync(SocketAsyncEventArgs e)
    {
        return _socket.DisconnectAsync(e);
    }

    /// <inheritdoc/>
    public ValueTask DisconnectAsync(bool reuseSocket, CancellationToken cancellationToken = default)
    {
        return _socket.DisconnectAsync(reuseSocket, cancellationToken);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
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

    /// <inheritdoc/>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public SocketInformation DuplicateAndClose(int targetProcessId)
    {
        return _socket.DuplicateAndClose(targetProcessId);
    }

    /// <inheritdoc/>
    public ISocket EndAccept(IAsyncResult asyncResult)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public ISocket EndAccept(out byte[] buffer, IAsyncResult asyncResult)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public ISocket EndAccept(out byte[] buffer, out int bytesTransferred, IAsyncResult asyncResult)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void EndConnect(IAsyncResult asyncResult)
    {
        _socket.EndConnect(asyncResult);
    }

    /// <inheritdoc/>
    public void EndDisconnect(IAsyncResult asyncResult)
    {
        _socket.EndDisconnect(asyncResult);
    }

    /// <inheritdoc/>
    public int EndReceive(IAsyncResult asyncResult)
    {
        return _socket.EndReceive(asyncResult);
    }

    /// <inheritdoc/>
    public int EndReceive(IAsyncResult asyncResult, out SocketError errorCode)
    {
        return _socket.EndReceive(asyncResult, out errorCode);
    }

    /// <inheritdoc/>
    public int EndReceiveFrom(IAsyncResult asyncResult, ref EndPoint endPoint)
    {
        return _socket.EndReceiveFrom(asyncResult, ref endPoint);
    }

    /// <inheritdoc/>
    public int EndReceiveMessageFrom(IAsyncResult asyncResult, ref SocketFlags socketFlags, ref EndPoint endPoint, out IPPacketInformation ipPacketInformation)
    {
        return _socket.EndReceiveMessageFrom(asyncResult, ref  socketFlags, ref endPoint, out ipPacketInformation);
    }

    /// <inheritdoc/>
    public int EndSend(IAsyncResult asyncResult)
    {
        return _socket.EndSend(asyncResult);
    }

    /// <inheritdoc/>
    public int EndSend(IAsyncResult asyncResult, out SocketError errorCode)
    {
        return _socket.EndSend(asyncResult, out errorCode);
    }

    /// <inheritdoc/>
    public void EndSendFile(IAsyncResult asyncResult)
    {
        _socket.EndSendFile(asyncResult);
    }

    /// <inheritdoc/>
    public int EndSendTo(IAsyncResult asyncResult)
    {
        return _socket.EndSendTo(asyncResult);
    }

    /// <inheritdoc/>
    public int GetRawSocketOption(int optionLevel, int optionName, Span<byte> optionValue)
    {
        return _socket.GetRawSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue)
    {
        _socket.GetSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public byte[] GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionLength)
    {
        return _socket.GetSocketOption(optionLevel, optionName, optionLength);
    }

    /// <inheritdoc/>
    public object? GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName)
    {
        return _socket.GetSocketOption(optionLevel, optionName);
    }

    /// <inheritdoc/>
    public int IOControl(int ioControlCode, byte[]? optionInValue, byte[]? optionOutValue)
    {
        return _socket.IOControl(ioControlCode, optionInValue, optionOutValue);
    }

    /// <inheritdoc/>
    public int IOControl(IOControlCode ioControlCode, byte[]? optionInValue, byte[]? optionOutValue)
    {
        return _socket.IOControl(ioControlCode, optionInValue, optionOutValue);
    }

    /// <inheritdoc/>
    public void Listen()
    {
        _socket.Listen();
    }

    /// <inheritdoc/>
    public void Listen(int backlog)
    {
        _socket.Listen(backlog);
    }

    /// <inheritdoc/>
    public bool Poll(TimeSpan timeout, SelectMode mode)
    {
        return _socket.Poll(timeout, mode);
    }

    /// <inheritdoc/>
    public bool Poll(int microSeconds, SelectMode mode)
    {
        return _socket.Poll(microSeconds, mode);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Receive(buffer, offset, size, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Receive(Span<byte> buffer, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Receive(buffer, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Receive(buffers, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer, int size, SocketFlags socketFlags)
    {
        return _socket.Receive(buffer, size, socketFlags);
    }

    /// <inheritdoc/>
    public int Receive(Span<byte> buffer, SocketFlags socketFlags)
    {
        return _socket.Receive(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags)
    {
        return _socket.Receive(buffer, offset, size, socketFlags);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer, SocketFlags socketFlags)
    {
        return _socket.Receive(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public int Receive(Span<byte> buffer)
    {
        return _socket.Receive(buffer);
    }

    /// <inheritdoc/>
    public int Receive(IList<ArraySegment<byte>> buffers)
    {
        return _socket.Receive(buffers);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer)
    {
        return _socket.Receive(buffer);
    }

    /// <inheritdoc/>
    public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
        return _socket.Receive(buffers, socketFlags);
    }

    /// <inheritdoc/>
    public Task<int> ReceiveAsync(ArraySegment<byte> buffer)
    {
        return _socket.ReceiveAsync(buffer);
    }

    /// <inheritdoc/>
    public Task<int> ReceiveAsync(IList<ArraySegment<byte>> buffers)
    {
        return _socket.ReceiveAsync(buffers);
    }

    /// <inheritdoc/>
    public bool ReceiveAsync(SocketAsyncEventArgs e)
    {
        return _socket.ReceiveAsync(e);
    }

    /// <inheritdoc/>
    public Task<int> ReceiveAsync(ArraySegment<byte> buffer, SocketFlags socketFlags)
    {
        return _socket.ReceiveAsync(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public Task<int> ReceiveAsync(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
        return _socket.ReceiveAsync(buffers, socketFlags);
    }

    /// <inheritdoc/>
    public ValueTask<int> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        return _socket.ReceiveAsync(buffer, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<int> ReceiveAsync(Memory<byte> buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default)
    {
        return _socket.ReceiveAsync(buffer, socketFlags, cancellationToken);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(byte[] buffer, int size, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
        return _socket.ReceiveFrom(buffer, size, socketFlags, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
        return _socket.ReceiveFrom(buffer, offset, size, socketFlags, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(Span<byte> buffer, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
        return _socket.ReceiveFrom(buffer, socketFlags, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(byte[] buffer, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
        return _socket.ReceiveFrom(buffer, socketFlags, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(Span<byte> buffer, SocketFlags socketFlags, SocketAddress receivedAddress)
    {
        return _socket.ReceiveFrom(buffer, socketFlags, receivedAddress);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(Span<byte> buffer, ref EndPoint remoteEP)
    {
        return _socket.ReceiveFrom(buffer, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(byte[] buffer, ref EndPoint remoteEP)
    {
        return _socket.ReceiveFrom(buffer, ref remoteEP);
    }

    /// <inheritdoc/>
    public bool ReceiveFromAsync(SocketAsyncEventArgs e)
    {
        return _socket.ReceiveFromAsync(e);
    }

    /// <inheritdoc/>
    public Task<SocketReceiveFromResult> ReceiveFromAsync(ArraySegment<byte> buffer, EndPoint remoteEndPoint)
    {
        return _socket.ReceiveFromAsync(buffer, remoteEndPoint);
    }

    /// <inheritdoc/>
    public Task<SocketReceiveFromResult> ReceiveFromAsync(ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint)
    {
        return _socket.ReceiveFromAsync(buffer, socketFlags, remoteEndPoint);
    }

    /// <inheritdoc/>
    public ValueTask<SocketReceiveFromResult> ReceiveFromAsync(Memory<byte> buffer, EndPoint remoteEndPoint, CancellationToken cancellationToken = default)
    {
        return _socket.ReceiveFromAsync(buffer, remoteEndPoint, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<SocketReceiveFromResult> ReceiveFromAsync(Memory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint, CancellationToken cancellationToken = default)
    {
        return _socket.ReceiveFromAsync(buffer, socketFlags, remoteEndPoint, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<int> ReceiveFromAsync(Memory<byte> buffer, SocketFlags socketFlags, SocketAddress receivedAddress, CancellationToken cancellationToken = default)
    {
        return _socket.ReceiveFromAsync(buffer, socketFlags, receivedAddress, cancellationToken);
    }

    /// <inheritdoc/>
    public int ReceiveMessageFrom(byte[] buffer, int offset, int size, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation)
    {
        return _socket.ReceiveMessageFrom(buffer, offset, size, ref socketFlags, ref remoteEP, out ipPacketInformation);
    }

    /// <inheritdoc/>
    public int ReceiveMessageFrom(Span<byte> buffer, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation)
    {
        return _socket.ReceiveMessageFrom(buffer, ref socketFlags, ref remoteEP, out ipPacketInformation);
    }

    /// <inheritdoc/>
    public bool ReceiveMessageFromAsync(SocketAsyncEventArgs e)
    {
        return _socket.ReceiveMessageFromAsync(e);
    }

    /// <inheritdoc/>
    public Task<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(ArraySegment<byte> buffer, EndPoint remoteEndPoint)
    {
        return _socket.ReceiveMessageFromAsync(buffer, remoteEndPoint);
    }

    /// <inheritdoc/>
    public Task<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint)
    {
        return _socket.ReceiveMessageFromAsync(buffer, socketFlags, remoteEndPoint);
    }

    /// <inheritdoc/>
    public ValueTask<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(Memory<byte> buffer, EndPoint remoteEndPoint, CancellationToken cancellationToken = default)
    {
        return _socket.ReceiveMessageFromAsync(buffer, remoteEndPoint, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(Memory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint, CancellationToken cancellationToken = default)
    {
        return _socket.ReceiveMessageFromAsync(buffer, socketFlags, remoteEndPoint, cancellationToken);
    }

    /// <summary>
    /// Determines the status of one or more sockets.
    /// </summary>
    /// <param name="checkRead">An <see cref="IList"/> of Socket instances to check for readability.</param>
    /// <param name="checkWrite">An <see cref="IList"/> of Socket instances to check for writability.</param>
    /// <param name="checkError">An <see cref="IList"/> of Socket instances to check for errors.</param>
    /// <param name="timeout">The timeout value. A value equal to -1 microseconds indicates an infinite timeout.</param>
    public static void Select(IList? checkRead, IList? checkWrite, IList? checkError, TimeSpan timeout)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines the status of one or more sockets.
    /// </summary>
    /// <param name="checkRead">An <see cref="IList"/> of Socket instances to check for readability.</param>
    /// <param name="checkWrite">An <see cref="IList"/> of Socket instances to check for writability.</param>
    /// <param name="checkError">An <see cref="IList"/> of Socket instances to check for errors.</param>
    /// <param name="microSeconds">The time-out value, in microseconds. A -1 value indicates an infinite time-out.</param>
    public static void Select(IList? checkRead, IList? checkWrite, IList? checkError, int microSeconds)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public int Send(ReadOnlySpan<byte> buffer, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Send(buffer, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Send(ReadOnlySpan<byte> buffer)
    {
        return _socket.Send(buffer);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Send(buffer, offset, size, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Send(buffers, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags)
    {
        return _socket.Send(buffer, offset, size, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer, int size, SocketFlags socketFlags)
    {
        return _socket.Send(buffer, size, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(IList<ArraySegment<byte>> buffers)
    {
        return _socket.Send(buffers);
    }

    /// <inheritdoc/>
    public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
        return _socket.Send(buffers, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer, SocketFlags socketFlags)
    {
        return _socket.Send(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(ReadOnlySpan<byte> buffer, SocketFlags socketFlags)
    {
        return _socket.Send(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer)
    {
        return _socket.Send(buffer);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        return _socket.SendAsync(buffer, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<int> SendAsync(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
        return _socket.SendAsync(buffers, socketFlags);
    }

    /// <inheritdoc/>
    public Task<int> SendAsync(ArraySegment<byte> buffer, SocketFlags socketFlags)
    {
        return _socket.SendAsync(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default)
    {
        return _socket.SendAsync(buffer, socketFlags, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<int> SendAsync(IList<ArraySegment<byte>> buffers)
    {
        return _socket.SendAsync(buffers);
    }

    /// <inheritdoc/>
    public Task<int> SendAsync(ArraySegment<byte> buffer)
    {
        return _socket.SendAsync(buffer);
    }

    /// <inheritdoc/>
    public bool SendAsync(SocketAsyncEventArgs e)
    {
        return _socket.SendAsync(e);
    }

    /// <inheritdoc/>
    public void SendFile(string? fileName)
    {
        _socket.SendFile(fileName);
    }

    /// <inheritdoc/>
    public void SendFile(string? fileName, byte[]? preBuffer, byte[]? postBuffer, TransmitFileOptions flags)
    {
        _socket.SendFile(fileName, preBuffer, postBuffer, flags);
    }

    /// <inheritdoc/>
    public void SendFile(string? fileName, ReadOnlySpan<byte> preBuffer, ReadOnlySpan<byte> postBuffer, TransmitFileOptions flags)
    {
        _socket.SendFile(fileName, preBuffer, postBuffer, flags);
    }

    /// <inheritdoc/>
    public ValueTask SendFileAsync(string? fileName, CancellationToken cancellationToken = default)
    {
        return _socket.SendFileAsync(fileName, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask SendFileAsync(string? fileName, ReadOnlyMemory<byte> preBuffer, ReadOnlyMemory<byte> postBuffer, TransmitFileOptions flags, CancellationToken cancellationToken = default)
    {
        return _socket.SendFileAsync(fileName, preBuffer, postBuffer, flags, cancellationToken);
    }

    /// <inheritdoc/>
    public bool SendPacketsAsync(SocketAsyncEventArgs e)
    {
        return _socket.SendPacketsAsync(e);
    }

    /// <inheritdoc/>
    public int SendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP)
    {
        return _socket.SendTo(buffer, offset, size, socketFlags, remoteEP);
    }

    /// <inheritdoc/>
    public int SendTo(byte[] buffer, int size, SocketFlags socketFlags, EndPoint remoteEP)
    {
        return _socket.SendTo(buffer, size, socketFlags, remoteEP);
    }

    /// <inheritdoc/>
    public int SendTo(ReadOnlySpan<byte> buffer, SocketFlags socketFlags, SocketAddress socketAddress)
    {
        return _socket.SendTo(buffer, socketFlags, socketAddress);
    }

    /// <inheritdoc/>
    public int SendTo(ReadOnlySpan<byte> buffer, EndPoint remoteEP)
    {
        return _socket.SendTo(buffer, remoteEP);
    }

    /// <inheritdoc/>
    public int SendTo(byte[] buffer, SocketFlags socketFlags, EndPoint remoteEP)
    {
        return _socket.SendTo(buffer, socketFlags, remoteEP);
    }

    /// <inheritdoc/>
    public int SendTo(byte[] buffer, EndPoint remoteEP)
    {
        return _socket.SendTo(buffer, remoteEP);
    }

    /// <inheritdoc/>
    public bool SendToAsync(SocketAsyncEventArgs e)
    {
        return _socket.SendToAsync(e);
    }

    /// <inheritdoc/>
    public Task<int> SendToAsync(ArraySegment<byte> buffer, EndPoint remoteEP)
    {
        return _socket.SendToAsync(buffer, remoteEP);
    }

    /// <inheritdoc/>
    public Task<int> SendToAsync(ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEP)
    {
        return _socket.SendToAsync(buffer, socketFlags, remoteEP);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, EndPoint remoteEP, CancellationToken cancellationToken = default)
    {
        return _socket.SendToAsync(buffer, remoteEP, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEP, CancellationToken cancellationToken = default)
    {
        return _socket.SendToAsync(buffer, socketFlags, remoteEP, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, SocketAddress socketAddress, CancellationToken cancellationToken = default)
    {
        return _socket.SendToAsync(buffer, socketFlags, socketAddress, cancellationToken);
    }

    /// <inheritdoc/>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public void SetIPProtectionLevel(IPProtectionLevel level)
    {
        _socket.SetIPProtectionLevel(level);
    }

    /// <inheritdoc/>
    public void SetRawSocketOption(int optionLevel, int optionName, ReadOnlySpan<byte> optionValue)
    {
        _socket.SetRawSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
    {
        _socket.SetSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue)
    {
        _socket.SetSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue)
    {
        _socket.SetSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, object optionValue)
    {
        _socket.SetSocketOption(optionLevel , optionName , optionValue);
    }

    /// <inheritdoc/>
    public void Shutdown(SocketShutdown how)
    {
        _socket.Shutdown(how);
    }

    ~SocketW()
    {
        Dispose(false);
    }
}

#pragma warning restore RCS1047 // Non-asynchronous method name should not end with 'Async'