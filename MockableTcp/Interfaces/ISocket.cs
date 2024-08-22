using System.Net;
using System.Net.Sockets;

namespace MockableTcp.Interfaces;

public interface ISocket : IDisposable
{
    /// <summary>
    /// Gets the address family of the Socket.
    /// </summary>
    public AddressFamily AddressFamily { get; }

    /// <summary>
    /// Gets the amount of data that has been received from the network and is available to be read.
    /// </summary>
    public int Available { get; }

    /// <summary>
    /// Gets or sets a value that indicates whether the Socket is in blocking mode.
    /// </summary>
    public bool Blocking { get; set; }

    /// <summary>
    /// Gets a value that indicates whether a Socket is connected to a remote host as of the last Send or Receive operation.
    /// </summary>
    public bool Connected { get; }

    /// <summary>
    /// Gets or sets a value that specifies whether the Socket allows Internet Protocol (IP) datagrams to be fragmented.
    /// </summary>
    public bool DontFragment { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies whether the Socket is a dual-mode socket used for both IPv4 and IPv6.
    /// </summary>
    public bool DualMode { get; set; }

    /// <summary>
    /// Gets or sets a Boolean value that specifies whether the Socket can send broadcast packets.
    /// </summary>
    public bool EnableBroadcast { get; set; }

    /// <summary>
    /// Gets or sets a Boolean value that specifies whether the Socket allows only one process to bind to a port.
    /// </summary>
    public bool ExclusiveAddressUse { get; set; }

    /// <summary>
    /// Gets the operating system handle for the Socket.
    /// </summary>
    public IntPtr Handle { get; }

    /// <summary>
    /// Gets a value that indicates whether the Socket is bound to a specific local port.
    /// </summary>
    public bool IsBound { get; }

    /// <summary>
    /// Gets or sets a value that specifies whether the Socket will delay closing a socket in an attempt to send all pending data.
    /// </summary>
    public LingerOption? LingerState { get; set; }

    /// <summary>
    /// Gets the local endpoint.
    /// </summary>
    public EndPoint? LocalEndPoint { get; }

    /// <summary>
    /// Gets or sets a value that specifies whether outgoing multicast packets are delivered to the sending application.
    /// </summary>
    public bool MulticastLoopback { get; set; }

    /// <summary>
    /// Gets or sets a Boolean value that specifies whether the stream Socket is using the Nagle algorithm.
    /// </summary>
    public bool NoDelay { get; set; }

    /// <summary>
    /// Indicates whether the underlying operating system and network adaptors support Internet Protocol version 4 (IPv4).
    /// </summary>
    public static bool OSSupportsIPv4 { get; }

    /// <summary>
    /// Indicates whether the underlying operating system and network adaptors support Internet Protocol version 6 (IPv6).
    /// </summary>
    public static bool OSSupportsIPv6 { get; }

    /// <summary>
    /// Indicates whether the underlying operating system support the Unix domain sockets.
    /// </summary>
    public static bool OSSupportsUnixDomainSockets { get; }

    /// <summary>
    /// Gets the protocol type of the Socket.
    /// </summary>
    public ProtocolType ProtocolType { get; }

    /// <summary>
    /// Gets or sets a value that specifies the size of the receive buffer of the Socket.
    /// </summary>
    public int ReceiveBufferSize { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies the amount of time after which a synchronous Receive call will time out.
    /// </summary>
    public int ReceiveTimeout { get; set; }

    /// <summary>
    /// Gets the remote endpoint.
    /// </summary>
    public EndPoint? RemoteEndPoint { get; }

    /// <summary>
    /// Gets a SafeSocketHandle that represents the socket handle that the current Socket object encapsulates.
    /// </summary>
    public SafeSocketHandle SafeHandle { get; }

    /// <summary>
    /// Gets or sets a value that specifies the size of the send buffer of the Socket.
    /// </summary>
    public int SendBufferSize { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies the amount of time after which a synchronous Send call will time out.
    /// </summary>
    public int SendTimeout { get; set; }

    /// <summary>
    /// Gets the type of the Socket.
    /// </summary>
    public SocketType SocketType { get; }

    /// <summary>
    /// Gets or sets a value that specifies the Time To Live (TTL) value of Internet Protocol (IP) packets sent by the Socket.
    /// </summary>
    public short Ttl { get; set; }

    /// <summary>
    /// Creates a new Socket for a newly created connection.
    /// </summary>
    /// <returns>A <see cref="ISocket"></see> for a newly created connection.</returns>
    public ISocket Accept();

    /// <summary>
    /// Accepts an incoming connection.
    /// </summary>
    /// <returns>An asynchronous task that completes with the accepted Socket.</returns>
    public Task<ISocket> AcceptAsync();

    /// <summary>
    /// Accepts an incoming connection.
    /// </summary>
    /// <param name="acceptSocket">The <see cref="ISocket"></see> to use for accepting the connection.</param>
    /// <returns>An asynchronous task that completes with the accepted <see cref="ISocket"/>.</returns>
    public Task<ISocket> AcceptAsync(ISocket? acceptSocket);

    /// <summary>
    /// Begins an asynchronous operation to accept an incoming connection attempt.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object to use for this asynchronous socket operation.</param>
    /// <returns>True if the I/O operation is pending, false if the I/O operation completed synchronously.</returns>
    public bool AcceptAsync(SocketAsyncEventArgs e);

    /// <summary>
    /// Accepts an incoming connection.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with the accepted <see cref="ISocket"/>.</returns>
    public ValueTask<ISocket> AcceptAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Accepts an incoming connection.
    /// </summary>
    /// <param name="acceptSocket">The <see cref="ISocket"></see> to use for accepting the connection.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with the accepted <see cref="ISocket"/>.</returns>
    public ValueTask<ISocket> AcceptAsync(ISocket? acceptSocket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Begins an asynchronous operation to accept an incoming connection attempt.
    /// </summary>
    /// <param name="callback">The <see cref="AsyncCallback"></see> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous <see cref="ISocket"/> creation.</returns>
    public IAsyncResult BeginAccept(AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins an asynchronous operation to accept an incoming connection attempt and receives the first block of data sent by the client application.
    /// </summary>
    /// <param name="receiveSize">The number of bytes to accept from the sender.</param>
    /// <param name="callback">The <see cref="AsyncCallback"></see> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous <see cref="ISocket"/> creation.</returns>
    public IAsyncResult BeginAccept(int receiveSize, AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins an asynchronous operation to accept an incoming connection attempt from a specified socket and receives the first block of data sent by the client application.
    /// </summary>
    /// <param name="acceptSocket">The accepted <see cref="ISocket"/> object. This value may be null.</param>
    /// <param name="receiveSize">The maximum number of bytes to receive.</param>
    /// <param name="callback">The <see cref="AsyncCallback"></see> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous <see cref="ISocket"/> creation.</returns>
    public IAsyncResult BeginAccept(ISocket? acceptSocket, int receiveSize, AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins an asynchronous request for a remote host connection.
    /// </summary>
    /// <param name="remoteEP">An <see cref="EndPoint"/> that represents the remote host.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous connection.</returns>
    public IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins an asynchronous request for a remote host connection. The host is specified by an <see cref="IPAddress"/> and a port number.
    /// </summary>
    /// <param name="address">The <see cref="IPAddress"/> of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <param name="requestCallback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the connect operation is complete.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous connection.</returns>
    public IAsyncResult BeginConnect(IPAddress address, int port, AsyncCallback? requestCallback, object? state);

    /// <summary>
    /// Begins an asynchronous request for a remote host connection. The host is specified by an <see cref="IPAddress"/> array and a port number.
    /// </summary>
    /// <param name="addresses">At least one <see cref="IPAddress"/>, designating the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <param name="requestCallback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the connect operation is complete.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous connection.</returns>
    public IAsyncResult BeginConnect(IPAddress[] addresses, int port, AsyncCallback? requestCallback, object? state);

    /// <summary>
    /// Begins an asynchronous request for a remote host connection. The host is specified by a host name and a port number.
    /// </summary>
    /// <param name="host">The name of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <param name="requestCallback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the connect operation is complete.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous connection.</returns>
    public IAsyncResult BeginConnect(string host, int port, AsyncCallback? requestCallback, object? state);

    /// <summary>
    /// Begins an asynchronous request to disconnect from a remote endpoint.
    /// </summary>
    /// <param name="reuseSocket">True if this socket can be reused after the connection is closed; otherwise, false.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> object that references the asynchronous operation.</returns>
    public IAsyncResult BeginDisconnect(bool reuseSocket, AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins to asynchronously receive data from a connected <see cref="ISocket"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="offset">The location in buffer to store the received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
    /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to the <see cref="EndReceive(IAsyncResult)"/> delegate when the operation is complete.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous read.</returns>
    public IAsyncResult? BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins to asynchronously receive data from a connected <see cref="ISocket"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="offset">The location in buffer to store the received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
    /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to the <see cref="EndReceive(IAsyncResult)"/> delegate when the operation is complete.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous read.</returns>
    public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins to asynchronously receive data from a connected <see cref="ISocket"/>.
    /// </summary>
    /// <param name="buffers">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
    /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to the <see cref="EndReceive(IAsyncResult)"/> delegate when the operation is complete.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous read.</returns>
    public IAsyncResult BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins to asynchronously receive data from a connected <see cref="ISocket"/>.
    /// </summary>
    /// <param name="buffers">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
    /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to the <see cref="EndReceive(IAsyncResult)"/> delegate when the operation is complete.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous read.</returns>
    public IAsyncResult? BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state);

    /// <summary>
    /// Connects to a remote endpoint.
    /// </summary>
    /// <param name="remoteEndpoint">The remote endpoint to connect to.</param>
    public void Connect(EndPoint remoteEndpoint);

    /// <summary>
    /// Connects asynchronously to the remote <see cref="IPEndPoint"></see>.
    /// </summary>
    /// <param name="remoteEndpoint">The remote <see cref="IPEndPoint"></see> to connect to.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task"> that represents the asynchronous operation.</returns>
    public Task ConnectAsync(IPEndPoint remoteEndpoint, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send data to the remote endpoint.
    /// </summary>
    /// <param name="buffer">Buffer containing the data to be sent.</param>
    /// <param name="socketFlags">Socket flags.</param>
    /// <param name="errorCode">Error code.</param>
    /// <returns>An <see cref="int"/> representing the number of sent bytes.</returns>
    public int Send(byte[] buffer, SocketFlags socketFlags, out SocketError errorCode);

    /// <summary>
    /// Asynchronously sends data to the remote endpoint.
    /// </summary>
    /// <param name="buffer">Buffer containing the data to be sent.</param>
    /// <param name="socketFlags">Socket flags.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.<br/>The task's result contains the number of successfully sent bytes.</returns>
    public Task<int> SendAsync(byte[] buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives data from the remote endpoint.
    /// </summary>
    /// <param name="buffer">Buffer to store the received data.</param>
    /// <param name="socketFlags">Socket flags.</param>
    /// <param name="errorCode">Error code.</param>
    /// <returns>An <see cref="int"/> representing the number of received bytes.</returns>
    public int Receive(byte[] buffer, SocketFlags socketFlags, out SocketError errorCode);

    /// <summary>
    /// Asynchronously receives data from the remote endpoint.
    /// </summary>
    /// <param name="buffer">Buffer to store the received data.</param>
    /// <param name="socketFlags">Socket flags.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.<br/>The task's result contains the number of successfully received bytes.</returns>
    public Task<int> ReceiveAsync(byte[] buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Closes the socket.
    /// </summary>
    public void Close();
}