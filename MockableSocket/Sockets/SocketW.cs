using MockableSocket.Interfaces.Sockets;
using System;
using System.Collections;
using System.Drawing;
using System.Net;
using System.Net.Sockets;

namespace MockableSocket.Sockets;

#pragma warning disable RCS1047 // Non-asynchronous method name should not end with 'Async'

/// <summary>
/// Wraps <see cref="Socket"/> to implement ISocket
/// </summary>
public class SocketW : ISocket
{
    private bool _disposed;

    /// <summary>
    /// Creates a new instance of <see cref="SocketW"/> for the specific <see cref="Socket"/>
    /// </summary>
    /// <param name="socket">The <see cref="Socket"/> for the <see cref="SocketW"/> to encapsulate.</param>
    public SocketW(Socket socket)
    {
        Socket = socket;
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketW"/> for the specific socket handle.
    /// </summary>
    /// <param name="handle">The socket handle for the <see cref="SocketW"/> to encapsulate.</param>
    public SocketW(SafeSocketHandle handle)
    {
        Socket = new Socket(handle);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketW"/> using the specified value returned from <see cref="DuplicateAndClose"/>
    /// </summary>
    /// <param name="socketInformation">The socket information returned by <see cref="DuplicateAndClose"/></param>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public SocketW(SocketInformation socketInformation)
    {
        Socket = new Socket(socketInformation);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketW"/> using the specified socket type and protocol.<br/>If the operating system supports IPv6, this constructor creates a dual-mode socket; otherwise, it creates an IPv4 socket.
    /// </summary>
    /// <param name="socketType">One of the <see cref="SocketType"/> values.</param>
    /// <param name="protocolType">One of the <see cref="ProtocolType"/> values.</param>
    public SocketW(SocketType socketType, ProtocolType protocolType)
    {
        Socket = new Socket(socketType, protocolType);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketW" /> using the specified address family, socket type and protocol.
    /// </summary>
    /// <param name="addressFamily">One of the <see cref="AddressFamily"/> values.</param>
    /// <param name="socketType">One of the <see cref="SocketType"/> values.</param>
    /// <param name="protocolType">One of the <see cref="ProtocolType"/> values.</param>
    public SocketW(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
    {
        Socket = new Socket(addressFamily, socketType, protocolType);
    }

    /// <inheritdoc/>
    public AddressFamily AddressFamily { get => Socket.AddressFamily; }

    /// <inheritdoc/>
    public int Available { get => Socket.Available; }

    /// <inheritdoc/>
    public bool Blocking { get => Socket.Blocking; set => Socket.Blocking = value; }

    /// <inheritdoc/>
    public bool Connected { get => Socket.Connected; }

    /// <inheritdoc/>
    public bool DontFragment { get => Socket.DontFragment; set => Socket.DontFragment = value; }

    /// <inheritdoc/>
    public bool DualMode { get => Socket.DualMode; set => Socket.DualMode = value; }

    /// <inheritdoc/>
    public bool EnableBroadcast { get => Socket.EnableBroadcast; set => Socket.EnableBroadcast = value; }

    /// <inheritdoc/>
    public bool ExclusiveAddressUse { get => Socket.ExclusiveAddressUse; set => Socket.ExclusiveAddressUse = value; }

    /// <inheritdoc/>
    public IntPtr Handle { get => Socket.Handle; }

    /// <inheritdoc/>
    public bool IsBound { get => Socket.IsBound; }

    /// <inheritdoc/>
    public LingerOption? LingerState { get => Socket.LingerState; set => Socket.LingerState = value!; }

    /// <inheritdoc/>
    public EndPoint? LocalEndPoint { get => Socket.LocalEndPoint; }

    /// <inheritdoc/>
    public bool MulticastLoopback { get => Socket.MulticastLoopback; set => Socket.MulticastLoopback = value; }

    /// <inheritdoc/>
    public bool NoDelay { get => Socket.NoDelay; set => Socket.NoDelay = value; }

    /// <inheritdoc/>
    public static bool OSSupportsIPv4 { get => Socket.OSSupportsIPv4; }

    /// <inheritdoc/>
    public static bool OSSupportsIPv6 { get => Socket.OSSupportsIPv6; }

    /// <inheritdoc/>
    public static bool OSSupportsUnixDomainSockets { get => Socket.OSSupportsUnixDomainSockets; }

    /// <inheritdoc/>
    public ProtocolType ProtocolType { get => Socket.ProtocolType; }

    /// <inheritdoc/>
    public int ReceiveBufferSize { get => Socket.ReceiveBufferSize; set => Socket.ReceiveBufferSize = value; }

    /// <inheritdoc/>
    public int ReceiveTimeout { get => Socket.ReceiveTimeout; set => Socket.ReceiveTimeout = value; }

    /// <inheritdoc/>
    public EndPoint? RemoteEndPoint { get => Socket.RemoteEndPoint; }

    /// <inheritdoc/>
    public SafeSocketHandle SafeHandle { get => Socket.SafeHandle; }

    /// <inheritdoc/>
    public Socket Socket { get; }

    /// <inheritdoc/>
    public int SendBufferSize { get => Socket.SendBufferSize; set => Socket.SendBufferSize = value; }

    /// <inheritdoc/>
    public int SendTimeout { get => Socket.SendTimeout; set => Socket.SendTimeout = value; }

    /// <inheritdoc/>
    public SocketType SocketType { get => Socket.SocketType; }

    /// <inheritdoc/>
    public short Ttl { get => Socket.Ttl; set => Socket.Ttl = value; }

    /// <inheritdoc/>
    public ISocket Accept()
    {
        return new SocketW(Socket.Accept());
    }

    /// <inheritdoc/>
    public async Task<ISocket> AcceptAsync()
    {
        return new SocketW(await Socket.AcceptAsync());
    }

    /// <inheritdoc/>
    public async Task<ISocket> AcceptAsync(ISocket? acceptSocket)
    {
        return new SocketW(await Socket.AcceptAsync(acceptSocket?.Socket));
    }

    /// <inheritdoc/>
    public bool AcceptAsync(SocketWAsyncEventArgs e)
    {
        return Socket.AcceptAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public async ValueTask<ISocket> AcceptAsync(CancellationToken cancellationToken = default)
    {
        return new SocketW(await Socket.AcceptAsync(cancellationToken));
    }

    /// <inheritdoc/>
    public async ValueTask<ISocket> AcceptAsync(ISocket? acceptSocket, CancellationToken cancellationToken = default)
    {
        return new SocketW(await Socket.AcceptAsync(acceptSocket?.Socket, cancellationToken));
    }

    /// <inheritdoc/>
    public IAsyncResult BeginAccept(AsyncCallback? callback, object? state)
    {
        return Socket.BeginAccept(callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginAccept(int receiveSize, AsyncCallback? callback, object? state)
    {
        return Socket.BeginAccept(receiveSize, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginAccept(ISocket? acceptSocket, int receiveSize, AsyncCallback? callback, object? state)
    {
        return Socket.BeginAccept(acceptSocket?.Socket, receiveSize, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback? callback, object? state)
    {
        return Socket.BeginConnect(remoteEP, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(IPAddress address, int port, AsyncCallback? requestCallback, object? state)
    {
        return Socket.BeginConnect(address, port, requestCallback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(IPAddress[] addresses, int port, AsyncCallback? requestCallback, object? state)
    {
        return Socket.BeginConnect(addresses, port, requestCallback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginConnect(string host, int port, AsyncCallback? requestCallback, object? state)
    {
        return Socket.BeginConnect(host, port, requestCallback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginDisconnect(bool reuseSocket, AsyncCallback? callback, object? state)
    {
        return Socket.BeginDisconnect(reuseSocket, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult? BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state)
    {
        return Socket.BeginReceive(buffer, offset, size, socketFlags, out errorCode, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback? callback, object? state)
    {
        return Socket.BeginReceive(buffer, offset, size, socketFlags, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback? callback, object? state)
    {
        return Socket.BeginReceive(buffers, socketFlags, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult? BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state)
    {
        return Socket.BeginReceive(buffers, socketFlags, out errorCode, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback? callback, object? state)
    {
        return Socket.BeginReceiveFrom(buffer, offset, size, socketFlags, ref remoteEP, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginReceiveMessageFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback? callback, object? state)
    {
        return Socket.BeginReceiveMessageFrom(buffer, offset, size, socketFlags, ref remoteEP, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback? callback, object? state)
    {
        return Socket.BeginSend(buffers, socketFlags, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult? BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state)
    {
        return Socket.BeginSend(buffers, socketFlags, out errorCode, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback? callback, object? state)
    {
        return Socket.BeginSend(buffer, offset, size, socketFlags, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult? BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state)
    {
        return Socket.BeginSend(buffer, offset, size, socketFlags, out errorCode, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSendFile(string? fileName, AsyncCallback? callback, object? state)
    {
        return Socket.BeginSendFile(fileName, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSendFile(string? fileName, byte[]? preBuffer, byte[]? postBuffer, TransmitFileOptions flags, AsyncCallback? callback, object? state)
    {
        return Socket.BeginSendFile(fileName, preBuffer, postBuffer, flags, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginSendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP, AsyncCallback? callback, object? state)
    {
        return Socket.BeginSendTo(buffer, offset, size, socketFlags, remoteEP, callback, state);
    }

    /// <inheritdoc/>
    public void Bind(EndPoint localEP)
    {
        Socket.Bind(localEP);
    }

    /// <summary>
    /// Cancels an asynchronous request for a remote host connection.
    /// </summary>
    /// <param name="e">The <see cref="SocketWAsyncEventArgs"/> object used to request the connection to the remote host by calling one of the <see cref="ConnectAsync(SocketType, ProtocolType, SocketWAsyncEventArgs)"/> methods.</param>
    public static void CancelConnectAsync(SocketWAsyncEventArgs e)
    {
        Socket.CancelConnectAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public void Close()
    {
        Socket.Close();
    }

    /// <inheritdoc/>
    public void Close(int timeout)
    {
        Socket.Close(timeout);
    }

    /// <inheritdoc/>
    public void Connect(EndPoint remoteEP)
    {
        Socket.Connect(remoteEP);
    }

    /// <inheritdoc/>
    public void Connect(IPAddress address, int port)
    {
        Socket.Connect(address, port);
    }

    /// <inheritdoc/>
    public void Connect(IPAddress[] addresses, int port)
    {
        Socket.Connect(addresses, port);
    }

    /// <inheritdoc/>
    public void Connect(string host, int port)
    {
        Socket.Connect(host, port);
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(IPAddress[] addresses, int port, CancellationToken cancellationToken)
    {
        return Socket.ConnectAsync(addresses, port, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(string host, int port, CancellationToken cancellationToken)
    {
        return Socket.ConnectAsync(host, port, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(IPAddress address, int port, CancellationToken cancellationToken)
    {
        return Socket.ConnectAsync(address, port, cancellationToken);
    }

    /// <inheritdoc/>
    public Task ConnectAsync(string host, int port)
    {
        return Socket.ConnectAsync(host, port);
    }

    /// <inheritdoc/>
    public Task ConnectAsync(IPAddress[] addresses, int port)
    {
        return Socket.ConnectAsync(addresses, port);
    }

    /// <inheritdoc/>
    public Task ConnectAsync(IPAddress address, int port)
    {
        return Socket.ConnectAsync(address, port);
    }

    /// <inheritdoc/>
    public ValueTask ConnectAsync(EndPoint remoteEP, CancellationToken cancellationToken)
    {
        return Socket.ConnectAsync(remoteEP, cancellationToken);
    }

    /// <inheritdoc/>
    public bool ConnectAsync(SocketWAsyncEventArgs e)
    {
        return Socket.ConnectAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public Task ConnectAsync(EndPoint remoteEP)
    {
        return Socket.ConnectAsync(remoteEP);
    }

    /// <inheritdoc/>
    public void Disconnect(bool reuseSocket)
    {
        Socket.Disconnect(reuseSocket);
    }

    /// <inheritdoc/>
    public bool DisconnectAsync(SocketWAsyncEventArgs e)
    {
        return Socket.DisconnectAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public ValueTask DisconnectAsync(bool reuseSocket, CancellationToken cancellationToken = default)
    {
        return Socket.DisconnectAsync(reuseSocket, cancellationToken);
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
            Socket.Close();
            _disposed = true;
        }
    }

    /// <inheritdoc/>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public SocketInformation DuplicateAndClose(int targetProcessId)
    {
        return Socket.DuplicateAndClose(targetProcessId);
    }

    /// <inheritdoc/>
    public ISocket EndAccept(IAsyncResult asyncResult)
    {
        return new SocketW(Socket.EndAccept(asyncResult));
    }

    /// <inheritdoc/>
    public ISocket EndAccept(out byte[] buffer, IAsyncResult asyncResult)
    {
        return new SocketW(Socket.EndAccept(out buffer, asyncResult));
    }

    /// <inheritdoc/>
    public ISocket EndAccept(out byte[] buffer, out int bytesTransferred, IAsyncResult asyncResult)
    {
        return new SocketW(Socket.EndAccept(out buffer, out bytesTransferred, asyncResult));
    }

    /// <inheritdoc/>
    public void EndConnect(IAsyncResult asyncResult)
    {
        Socket.EndConnect(asyncResult);
    }

    /// <inheritdoc/>
    public void EndDisconnect(IAsyncResult asyncResult)
    {
        Socket.EndDisconnect(asyncResult);
    }

    /// <inheritdoc/>
    public int EndReceive(IAsyncResult asyncResult)
    {
        return Socket.EndReceive(asyncResult);
    }

    /// <inheritdoc/>
    public int EndReceive(IAsyncResult asyncResult, out SocketError errorCode)
    {
        return Socket.EndReceive(asyncResult, out errorCode);
    }

    /// <inheritdoc/>
    public int EndReceiveFrom(IAsyncResult asyncResult, ref EndPoint endPoint)
    {
        return Socket.EndReceiveFrom(asyncResult, ref endPoint);
    }

    /// <inheritdoc/>
    public int EndReceiveMessageFrom(IAsyncResult asyncResult, ref SocketFlags socketFlags, ref EndPoint endPoint, out IPPacketInformation ipPacketInformation)
    {
        return Socket.EndReceiveMessageFrom(asyncResult, ref  socketFlags, ref endPoint, out ipPacketInformation);
    }

    /// <inheritdoc/>
    public int EndSend(IAsyncResult asyncResult)
    {
        return Socket.EndSend(asyncResult);
    }

    /// <inheritdoc/>
    public int EndSend(IAsyncResult asyncResult, out SocketError errorCode)
    {
        return Socket.EndSend(asyncResult, out errorCode);
    }

    /// <inheritdoc/>
    public void EndSendFile(IAsyncResult asyncResult)
    {
        Socket.EndSendFile(asyncResult);
    }

    /// <inheritdoc/>
    public int EndSendTo(IAsyncResult asyncResult)
    {
        return Socket.EndSendTo(asyncResult);
    }

    /// <inheritdoc/>
    public int GetRawSocketOption(int optionLevel, int optionName, Span<byte> optionValue)
    {
        return Socket.GetRawSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue)
    {
        Socket.GetSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public byte[] GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionLength)
    {
        return Socket.GetSocketOption(optionLevel, optionName, optionLength);
    }

    /// <inheritdoc/>
    public object? GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName)
    {
        return Socket.GetSocketOption(optionLevel, optionName);
    }

    /// <inheritdoc/>
    public int IOControl(int ioControlCode, byte[]? optionInValue, byte[]? optionOutValue)
    {
        return Socket.IOControl(ioControlCode, optionInValue, optionOutValue);
    }

    /// <inheritdoc/>
    public int IOControl(IOControlCode ioControlCode, byte[]? optionInValue, byte[]? optionOutValue)
    {
        return Socket.IOControl(ioControlCode, optionInValue, optionOutValue);
    }

    /// <inheritdoc/>
    public void Listen()
    {
        Socket.Listen();
    }

    /// <inheritdoc/>
    public void Listen(int backlog)
    {
        Socket.Listen(backlog);
    }

    /// <inheritdoc/>
    public bool Poll(TimeSpan timeout, SelectMode mode)
    {
        return Socket.Poll(timeout, mode);
    }

    /// <inheritdoc/>
    public bool Poll(int microSeconds, SelectMode mode)
    {
        return Socket.Poll(microSeconds, mode);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
    {
        return Socket.Receive(buffer, offset, size, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Receive(Span<byte> buffer, SocketFlags socketFlags, out SocketError errorCode)
    {
        return Socket.Receive(buffer, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode)
    {
        return Socket.Receive(buffers, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer, int size, SocketFlags socketFlags)
    {
        return Socket.Receive(buffer, size, socketFlags);
    }

    /// <inheritdoc/>
    public int Receive(Span<byte> buffer, SocketFlags socketFlags)
    {
        return Socket.Receive(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags)
    {
        return Socket.Receive(buffer, offset, size, socketFlags);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer, SocketFlags socketFlags)
    {
        return Socket.Receive(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public int Receive(Span<byte> buffer)
    {
        return Socket.Receive(buffer);
    }

    /// <inheritdoc/>
    public int Receive(IList<ArraySegment<byte>> buffers)
    {
        return Socket.Receive(buffers);
    }

    /// <inheritdoc/>
    public int Receive(byte[] buffer)
    {
        return Socket.Receive(buffer);
    }

    /// <inheritdoc/>
    public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
        return Socket.Receive(buffers, socketFlags);
    }

    /// <inheritdoc/>
    public Task<int> ReceiveAsync(ArraySegment<byte> buffer)
    {
        return Socket.ReceiveAsync(buffer);
    }

    /// <inheritdoc/>
    public Task<int> ReceiveAsync(IList<ArraySegment<byte>> buffers)
    {
        return Socket.ReceiveAsync(buffers);
    }

    /// <inheritdoc/>
    public bool ReceiveAsync(SocketWAsyncEventArgs e)
    {
        return Socket.ReceiveAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public Task<int> ReceiveAsync(ArraySegment<byte> buffer, SocketFlags socketFlags)
    {
        return Socket.ReceiveAsync(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public Task<int> ReceiveAsync(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
        return Socket.ReceiveAsync(buffers, socketFlags);
    }

    /// <inheritdoc/>
    public ValueTask<int> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        return Socket.ReceiveAsync(buffer, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<int> ReceiveAsync(Memory<byte> buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default)
    {
        return Socket.ReceiveAsync(buffer, socketFlags, cancellationToken);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(byte[] buffer, int size, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
        return Socket.ReceiveFrom(buffer, size, socketFlags, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
        return Socket.ReceiveFrom(buffer, offset, size, socketFlags, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(Span<byte> buffer, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
        return Socket.ReceiveFrom(buffer, socketFlags, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(byte[] buffer, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
        return Socket.ReceiveFrom(buffer, socketFlags, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(Span<byte> buffer, SocketFlags socketFlags, SocketAddress receivedAddress)
    {
        return Socket.ReceiveFrom(buffer, socketFlags, receivedAddress);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(Span<byte> buffer, ref EndPoint remoteEP)
    {
        return Socket.ReceiveFrom(buffer, ref remoteEP);
    }

    /// <inheritdoc/>
    public int ReceiveFrom(byte[] buffer, ref EndPoint remoteEP)
    {
        return Socket.ReceiveFrom(buffer, ref remoteEP);
    }

    /// <inheritdoc/>
    public bool ReceiveFromAsync(SocketWAsyncEventArgs e)
    {
        return Socket.ReceiveFromAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public Task<SocketReceiveFromResult> ReceiveFromAsync(ArraySegment<byte> buffer, EndPoint remoteEndPoint)
    {
        return Socket.ReceiveFromAsync(buffer, remoteEndPoint);
    }

    /// <inheritdoc/>
    public Task<SocketReceiveFromResult> ReceiveFromAsync(ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint)
    {
        return Socket.ReceiveFromAsync(buffer, socketFlags, remoteEndPoint);
    }

    /// <inheritdoc/>
    public ValueTask<SocketReceiveFromResult> ReceiveFromAsync(Memory<byte> buffer, EndPoint remoteEndPoint, CancellationToken cancellationToken = default)
    {
        return Socket.ReceiveFromAsync(buffer, remoteEndPoint, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<SocketReceiveFromResult> ReceiveFromAsync(Memory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint, CancellationToken cancellationToken = default)
    {
        return Socket.ReceiveFromAsync(buffer, socketFlags, remoteEndPoint, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<int> ReceiveFromAsync(Memory<byte> buffer, SocketFlags socketFlags, SocketAddress receivedAddress, CancellationToken cancellationToken = default)
    {
        return Socket.ReceiveFromAsync(buffer, socketFlags, receivedAddress, cancellationToken);
    }

    /// <inheritdoc/>
    public int ReceiveMessageFrom(byte[] buffer, int offset, int size, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation)
    {
        return Socket.ReceiveMessageFrom(buffer, offset, size, ref socketFlags, ref remoteEP, out ipPacketInformation);
    }

    /// <inheritdoc/>
    public int ReceiveMessageFrom(Span<byte> buffer, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation)
    {
        return Socket.ReceiveMessageFrom(buffer, ref socketFlags, ref remoteEP, out ipPacketInformation);
    }

    /// <inheritdoc/>
    public bool ReceiveMessageFromAsync(SocketWAsyncEventArgs e)
    {
        return Socket.ReceiveMessageFromAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public Task<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(ArraySegment<byte> buffer, EndPoint remoteEndPoint)
    {
        return Socket.ReceiveMessageFromAsync(buffer, remoteEndPoint);
    }

    /// <inheritdoc/>
    public Task<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint)
    {
        return Socket.ReceiveMessageFromAsync(buffer, socketFlags, remoteEndPoint);
    }

    /// <inheritdoc/>
    public ValueTask<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(Memory<byte> buffer, EndPoint remoteEndPoint, CancellationToken cancellationToken = default)
    {
        return Socket.ReceiveMessageFromAsync(buffer, remoteEndPoint, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(Memory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint, CancellationToken cancellationToken = default)
    {
        return Socket.ReceiveMessageFromAsync(buffer, socketFlags, remoteEndPoint, cancellationToken);
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
        List<Socket>? checkReadList = null;
        List<Socket>? checkWriteList = null;
        List<Socket>? checkErrorList = null;

        if (checkRead != null)
        {
            checkReadList = [];
            foreach (ISocket sock in checkRead)
            {
                checkReadList.Add(sock.Socket);
            }
        }

        if (checkWrite != null)
        {
            checkWriteList = [];
            foreach (ISocket sock in checkWrite)
            {
                checkWriteList.Add(sock.Socket);
            }
        }

        if (checkError != null)
        {
            checkErrorList = [];
            foreach (ISocket sock in checkError)
            {
                checkErrorList.Add(sock.Socket);
            }
        }

        Socket.Select(checkReadList, checkWriteList, checkErrorList, timeout);
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
        List<Socket>? checkReadList = null;
        List<Socket>? checkWriteList = null;
        List<Socket>? checkErrorList = null;

        if(checkRead != null)
        {
            checkReadList = [];
            foreach (ISocket sock in checkRead)
            {
                checkReadList.Add(sock.Socket);
            }
        }

        if (checkWrite != null)
        {
            checkWriteList = [];
            foreach (ISocket sock in checkWrite)
            {
                checkWriteList.Add(sock.Socket);
            }
        }

        if (checkError != null)
        {
            checkErrorList = [];
            foreach (ISocket sock in checkError)
            {
                checkErrorList.Add(sock.Socket);
            }
        }

        Socket.Select(checkReadList, checkWriteList, checkErrorList, microSeconds);
    }

    /// <inheritdoc/>
    public int Send(ReadOnlySpan<byte> buffer, SocketFlags socketFlags, out SocketError errorCode)
    {
        return Socket.Send(buffer, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Send(ReadOnlySpan<byte> buffer)
    {
        return Socket.Send(buffer);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
    {
        return Socket.Send(buffer, offset, size, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode)
    {
        return Socket.Send(buffers, socketFlags, out errorCode);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags)
    {
        return Socket.Send(buffer, offset, size, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer, int size, SocketFlags socketFlags)
    {
        return Socket.Send(buffer, size, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(IList<ArraySegment<byte>> buffers)
    {
        return Socket.Send(buffers);
    }

    /// <inheritdoc/>
    public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
        return Socket.Send(buffers, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer, SocketFlags socketFlags)
    {
        return Socket.Send(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(ReadOnlySpan<byte> buffer, SocketFlags socketFlags)
    {
        return Socket.Send(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public int Send(byte[] buffer)
    {
        return Socket.Send(buffer);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        return Socket.SendAsync(buffer, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<int> SendAsync(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
        return Socket.SendAsync(buffers, socketFlags);
    }

    /// <inheritdoc/>
    public Task<int> SendAsync(ArraySegment<byte> buffer, SocketFlags socketFlags)
    {
        return Socket.SendAsync(buffer, socketFlags);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default)
    {
        return Socket.SendAsync(buffer, socketFlags, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<int> SendAsync(IList<ArraySegment<byte>> buffers)
    {
        return Socket.SendAsync(buffers);
    }

    /// <inheritdoc/>
    public Task<int> SendAsync(ArraySegment<byte> buffer)
    {
        return Socket.SendAsync(buffer);
    }

    /// <inheritdoc/>
    public bool SendAsync(SocketWAsyncEventArgs e)
    {
        return Socket.SendAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public void SendFile(string? fileName)
    {
        Socket.SendFile(fileName);
    }

    /// <inheritdoc/>
    public void SendFile(string? fileName, byte[]? preBuffer, byte[]? postBuffer, TransmitFileOptions flags)
    {
        Socket.SendFile(fileName, preBuffer, postBuffer, flags);
    }

    /// <inheritdoc/>
    public void SendFile(string? fileName, ReadOnlySpan<byte> preBuffer, ReadOnlySpan<byte> postBuffer, TransmitFileOptions flags)
    {
        Socket.SendFile(fileName, preBuffer, postBuffer, flags);
    }

    /// <inheritdoc/>
    public ValueTask SendFileAsync(string? fileName, CancellationToken cancellationToken = default)
    {
        return Socket.SendFileAsync(fileName, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask SendFileAsync(string? fileName, ReadOnlyMemory<byte> preBuffer, ReadOnlyMemory<byte> postBuffer, TransmitFileOptions flags, CancellationToken cancellationToken = default)
    {
        return Socket.SendFileAsync(fileName, preBuffer, postBuffer, flags, cancellationToken);
    }

    /// <inheritdoc/>
    public bool SendPacketsAsync(SocketWAsyncEventArgs e)
    {
        return Socket.SendPacketsAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public int SendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP)
    {
        return Socket.SendTo(buffer, offset, size, socketFlags, remoteEP);
    }

    /// <inheritdoc/>
    public int SendTo(byte[] buffer, int size, SocketFlags socketFlags, EndPoint remoteEP)
    {
        return Socket.SendTo(buffer, size, socketFlags, remoteEP);
    }

    /// <inheritdoc/>
    public int SendTo(ReadOnlySpan<byte> buffer, SocketFlags socketFlags, SocketAddress socketAddress)
    {
        return Socket.SendTo(buffer, socketFlags, socketAddress);
    }

    /// <inheritdoc/>
    public int SendTo(ReadOnlySpan<byte> buffer, EndPoint remoteEP)
    {
        return Socket.SendTo(buffer, remoteEP);
    }

    /// <inheritdoc/>
    public int SendTo(byte[] buffer, SocketFlags socketFlags, EndPoint remoteEP)
    {
        return Socket.SendTo(buffer, socketFlags, remoteEP);
    }

    /// <inheritdoc/>
    public int SendTo(byte[] buffer, EndPoint remoteEP)
    {
        return Socket.SendTo(buffer, remoteEP);
    }

    /// <inheritdoc/>
    public bool SendToAsync(SocketWAsyncEventArgs e)
    {
        return Socket.SendToAsync(e.EventArgs);
    }

    /// <inheritdoc/>
    public Task<int> SendToAsync(ArraySegment<byte> buffer, EndPoint remoteEP)
    {
        return Socket.SendToAsync(buffer, remoteEP);
    }

    /// <inheritdoc/>
    public Task<int> SendToAsync(ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEP)
    {
        return Socket.SendToAsync(buffer, socketFlags, remoteEP);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, EndPoint remoteEP, CancellationToken cancellationToken = default)
    {
        return Socket.SendToAsync(buffer, remoteEP, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEP, CancellationToken cancellationToken = default)
    {
        return Socket.SendToAsync(buffer, socketFlags, remoteEP, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, SocketAddress socketAddress, CancellationToken cancellationToken = default)
    {
        return Socket.SendToAsync(buffer, socketFlags, socketAddress, cancellationToken);
    }

    /// <inheritdoc/>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public void SetIPProtectionLevel(IPProtectionLevel level)
    {
        Socket.SetIPProtectionLevel(level);
    }

    /// <inheritdoc/>
    public void SetRawSocketOption(int optionLevel, int optionName, ReadOnlySpan<byte> optionValue)
    {
        Socket.SetRawSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
    {
        Socket.SetSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue)
    {
        Socket.SetSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue)
    {
        Socket.SetSocketOption(optionLevel, optionName, optionValue);
    }

    /// <inheritdoc/>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, object optionValue)
    {
        Socket.SetSocketOption(optionLevel , optionName , optionValue);
    }

    /// <inheritdoc/>
    public void Shutdown(SocketShutdown how)
    {
        Socket.Shutdown(how);
    }

    ~SocketW()
    {
        Dispose(false);
    }
}

#pragma warning restore RCS1047 // Non-asynchronous method name should not end with 'Async'