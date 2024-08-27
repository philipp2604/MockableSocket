using System.Diagnostics.Metrics;
using System.Net;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MockableTcp.Interfaces.Sockets;

#pragma warning disable RCS1047 // Non-asynchronous method name should not end with 'Async'
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
    public nint Handle { get; }

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
    /// Gets the encapsulated socket.
    /// </summary>
    public Socket Socket { get; }

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
    /// Begins to asynchronously receive data from a specified network device.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="offset">The location in buffer to store the received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on synchronous receive.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous read.</returns>
    public IAsyncResult BeginReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins to asynchronously receive the specified number of bytes of data into the specified location of the data buffer, using the specified SocketFlags, and stores the endpoint and packet information.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="offset">The location in buffer to store the received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on synchronous receive.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous read.</returns>
    public IAsyncResult BeginReceiveMessageFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback? callback, object? state);

    /// <summary>
    /// Sends data asynchronously to a connected Socket.
    /// </summary>
    /// <param name="buffers">An array of type <see cref="byte"/> that contains the data to send</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous send.</returns>
    public IAsyncResult BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback? callback, object? state);

    /// <summary>
    /// Sends data asynchronously to a connected Socket.
    /// </summary>
    /// <param name="buffers">An array of type <see cref="byte"/> that contains the data to send</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous send.</returns>
    public IAsyncResult? BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state);

    /// <summary>
    /// Sends data asynchronously to a connected Socket.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to send</param>
    /// <param name="offset">The zero-based position in the buffer parameter at which to begin sending data.</param>
    /// <param name="size">The number of bytes to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous send.</returns>
    public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback? callback, object? state);

    /// <summary>
    /// Sends data asynchronously to a connected Socket.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to send</param>
    /// <param name="offset">The zero-based position in the buffer parameter at which to begin sending data.</param>
    /// <param name="size">The number of bytes to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous send.</returns>
    public IAsyncResult? BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback? callback, object? state);

    /// <summary>
    /// Sends a file asynchronously to a connected <see cref="ISocket"/> object.
    /// </summary>
    /// <param name="fileName">A string that contains the path and name of the file to send. This parameter can be null.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous send.</returns>
    public IAsyncResult BeginSendFile(string? fileName, AsyncCallback? callback, object? state);

    /// <summary>
    /// Sends a file asynchronously to a connected <see cref="ISocket"/> object.
    /// </summary>
    /// <param name="fileName">A string that contains the path and name of the file to send. This parameter can be null.</param>
    /// <param name="preBuffer">The data to be sent before the file is sent. This parameter can be null.</param>
    /// <param name="postBuffer">The data to be sent after the file is sent. This parameter can be null.</param>
    /// <param name="flags">A bitwise combination of the <see cref="TransmitFileOptions"/> enumeration values.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous send.</returns>
    public IAsyncResult BeginSendFile(string? fileName, byte[]? preBuffer, byte[]? postBuffer, TransmitFileOptions flags, AsyncCallback? callback, object? state);

    /// <summary>
    /// Sends data asynchronously to a specific remote host.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to send</param>
    /// <param name="offset">The zero-based position in the buffer parameter at which to begin sending data.</param>
    /// <param name="size">The number of bytes to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">An <see cref="EndPoint"/> that represents the remote device.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
    /// <param name="state">An object that contains state information for this request.</param>
    /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous send.</returns>
    public IAsyncResult BeginSendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP, AsyncCallback? callback, object? state);

    /// <summary>
    /// Associates an <see cref="ISocket"/> with a local endpoint.
    /// </summary>
    /// <param name="localEP">The local <see cref="EndPoint"/> to associate with the <see cref="ISocket"/>.</param>
    public void Bind(EndPoint localEP);

    /// <summary>
    /// Closes the <see cref="ISocket"/> connection and releases all associated resources.
    /// </summary>
    public void Close();

    /// <summary>
    /// Closes the <see cref="ISocket"/> connection and releases all associated resources with a specified timeout to allow queued data to be sent.
    /// </summary>
    /// <param name="timeout">Wait up to timeout milliseconds to send any remaining data, then close the socket.</param>
    public void Close(int timeout);

    /// <summary>
    /// Establishes a connection to a remote host.
    /// </summary>
    /// <param name="remoteEP">An <see cref="EndPoint"/> that represents the remote device.</param>
    public void Connect(EndPoint remoteEP);

    /// <summary>
    /// Establishes a connection to a remote host. The host is specified by an IP address and a port number.
    /// </summary>
    /// <param name="address">The IP address of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    public void Connect(IPAddress address, int port);

    /// <summary>
    /// Establishes a connection to a remote host. The host is specified by an array of IP addresses and a port number.
    /// </summary>
    /// <param name="addresses">The IP addresses of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    public void Connect(IPAddress[] addresses, int port);

    /// <summary>
    /// Establishes a connection to a remote host. The host is specified by a host name and a port number.
    /// </summary>
    /// <param name="host">The name of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    public void Connect(string host, int port);

    /// <summary>
    /// Establishes a connection to a remote host.
    /// </summary>
    /// <param name="addresses">A list of <see cref="IPAddress"/> for the remote host that will be used to attempt to connect to the remote host.</param>
    /// <param name="port">The port on the remote host to connect to.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes when the connection is established.</returns>
    public ValueTask ConnectAsync(IPAddress[] addresses, int port, CancellationToken cancellationToken);

    /// <summary>
    /// Establishes a connection to a remote host.
    /// </summary>
    /// <param name="host">The hostname of the remote host to connect to.</param>
    /// <param name="port">The port on the remote host to connect to.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes when the connection is established.</returns>
    public ValueTask ConnectAsync(string host, int port, CancellationToken cancellationToken);

    /// <summary>
    /// Establishes a connection to a remote host.
    /// </summary>
    /// <param name="address">The <see cref="IPAddress"/> of the remote host to connect to.</param>
    /// <param name="port">The port on the remote host to connect to.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes when the connection is established.</returns>
    public ValueTask ConnectAsync(IPAddress address, int port, CancellationToken cancellationToken);

    /// <summary>
    /// Establishes a connection to a remote host.
    /// </summary>
    /// <param name="host">The hostname of the remote host to connect to.</param>
    /// <param name="port">The port on the remote host to connect to.</param>
    /// <returns>An asynchronous task that completes when the connection is established.</returns>
    public Task ConnectAsync(string host, int port);

    /// <summary>
    /// Establishes a connection to a remote host.
    /// </summary>
    /// <param name="addresses">A list of <see cref="IPAddress"/> for the remote host that will be used to attempt to connect to the remote host.</param>
    /// <param name="port">The port on the remote host to connect to.</param>
    /// <returns>An asynchronous task that completes when the connection is established.</returns>
    public Task ConnectAsync(IPAddress[] addresses, int port);

    /// <summary>
    /// Establishes a connection to a remote host.
    /// </summary>
    /// <param name="address">The <see cref="IPAddress"/> of the remote host to connect to.</param>
    /// <param name="port">The port on the remote host to connect to.</param>
    /// <returns>An asynchronous task that completes when the connection is established.</returns>
    public Task ConnectAsync(IPAddress address, int port);

    /// <summary>
    /// Establishes a connection to a remote host.
    /// </summary>
    /// <param name="remoteEP">The <see cref="EndPoint"/> to connect to.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes when the connection is established.</returns>
    public ValueTask ConnectAsync(EndPoint remoteEP, CancellationToken cancellationToken);

    /// <summary>
    /// Begins an asynchronous request for a connection to a remote host.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object to use for this asynchronous socket operation.</param>
    /// <returns>True if the I/O operation is pending, false if it completed successfully.</returns>
    public bool ConnectAsync(SocketAsyncEventArgs e);

    /// <summary>
    /// Establishes a connection to a remote host.
    /// </summary>
    /// <param name="remoteEP">The <see cref="EndPoint"/> to connect to.</param>
    /// <returns>An asynchronous task that completes when the connection is established.</returns>
    public Task ConnectAsync(EndPoint remoteEP);

    /// <summary>
    /// Closes the socket connection and allows reuse of the socket.
    /// </summary>
    /// <param name="reuseSocket">true if this socket can be reused after the current connection is closed; otherwise, false.</param>
    public void Disconnect(bool reuseSocket);

    /// <summary>
    /// Begins an asynchronous request to disconnect from a remote endpoint.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object to use for this asynchronous socket operation.</param>
    /// <returns>True if the I/O operation is pending, false if it completed successfully.</returns>
    public bool DisconnectAsync(SocketAsyncEventArgs e);

    /// <summary>
    /// Disconnects a connected socket from the remote host.
    /// </summary>
    /// <param name="reuseSocket">Indicates whether the socket should be available for reuse after disconnect.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes when the connection is established.</returns>
    public ValueTask DisconnectAsync(bool reuseSocket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Duplicates the socket reference for the target process, and closes the socket for this process.
    /// </summary>
    /// <param name="targetProcessId">The ID of the target process where a duplicate of the socket reference is created.</param>
    /// <returns>The socket reference to be passed to the target process.</returns>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public SocketInformation DuplicateAndClose(int targetProcessId);

    /// <summary>
    /// Asynchronously accepts an incoming connection attempt and creates a new <see cref="ISocket"/> to handle remote host communication.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information for this asynchronous operation as well as any user defined data.</param>
    /// <returns>An <see cref="ISocket"/> to handle communication with the remote host.</returns>
    public ISocket EndAccept(IAsyncResult asyncResult);

    /// <summary>
    /// Asynchronously accepts an incoming connection attempt and creates a new <see cref="ISocket"/> to handle remote host communication.<br/>This method returns a buffer that contains the initial data transferred.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the bytes transferred.</param>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information for this asynchronous operation as well as any user defined data.</param>
    /// <returns>An <see cref="ISocket"/> to handle communication with the remote host.</returns>
    public ISocket EndAccept(out byte[] buffer, IAsyncResult asyncResult);

    /// <summary>
    /// Asynchronously accepts an incoming connection attempt and creates a new <see cref="ISocket"/> to handle remote host communication.<br/>This method returns a buffer that contains the initial data and the number of bytes transferre
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the bytes transferred.</param>
    /// <param name="bytesTransferred">The number of bytes transferred.</param>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information for this asynchronous operation as well as any user defined data.</param>
    /// <returns>An <see cref="ISocket"/> to handle communication with the remote host.</returns>
    public ISocket EndAccept(out byte[] buffer, out int bytesTransferred, IAsyncResult asyncResult);

    /// <summary>
    /// Ends a pending asynchronous connection request.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    public void EndConnect(IAsyncResult asyncResult);

    /// <summary>
    /// Ends a pending asynchronous disconnect request.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    public void EndDisconnect(IAsyncResult asyncResult);

    /// <summary>
    /// Ends a pending asynchronous read.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    /// <returns>The number of bytes received.</returns>
    public int EndReceive(IAsyncResult asyncResult);

    /// <summary>
    /// Ends a pending asynchronous read.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <returns>The number of bytes received.</returns>
    public int EndReceive(IAsyncResult asyncResult, out SocketError errorCode);

    /// <summary>
    /// Ends a pending asynchronous read from a specific endpoint.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    /// <param name="endPoint">The source <see cref="EndPoint"/>.</param>
    /// <returns>If successful, the number of bytes received. If unsuccessful, returns 0.</returns>
    public int EndReceiveFrom(IAsyncResult asyncResult, ref EndPoint endPoint);

    /// <summary>
    /// Ends a pending asynchronous read from a specific endpoint.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values for the received packet.</param>
    /// <param name="endPoint">The source <see cref="EndPoint"/>.</param>
    /// <param name="ipPacketInformation">The <see cref="IPAddress"/> and interface of the received packet.</param>
    /// <returns>If successful, the number of bytes received. If unsuccessful, returns 0.</returns>
    public int EndReceiveMessageFrom(IAsyncResult asyncResult, ref SocketFlags socketFlags, ref EndPoint endPoint, out IPPacketInformation ipPacketInformation);

    /// <summary>
    /// Ends a pending asynchronous send.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    /// <returns>If successful, the number of bytes sent to the Socket; otherwise, an invalid Socket error.</returns>
    public int EndSend(IAsyncResult asyncResult);

    /// <summary>
    /// Ends a pending asynchronous send.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <returns>If successful, the number of bytes sent to the Socket; otherwise, an invalid Socket error.</returns>
    public int EndSend(IAsyncResult asyncResult, out SocketError errorCode);

    /// <summary>
    /// Ends a pending asynchronous send of a file.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    public void EndSendFile(IAsyncResult asyncResult);

    /// <summary>
    /// Ends a pending asynchronous send to a specific location.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> that stores state information and any user defined data for this asynchronous operation.</param>
    /// <returns>If successful, the number of bytes sent; otherwise, an invalid Socket error.</returns>
    public int EndSendTo(IAsyncResult asyncResult);

    /// <summary>
    /// Gets a socket option value using platform-specific level and name identifiers.
    /// </summary>
    /// <param name="optionLevel">The platform-defined option level.</param>
    /// <param name="optionName">The platform-defined option name.</param>
    /// <param name="optionValue">The span into which the retrieved option value should be stored.</param>
    /// <returns>The number of bytes written into optionValue for a successfully retrieved value.</returns>
    public int GetRawSocketOption(int optionLevel, int optionName, Span<byte> optionValue);

    /// <summary>
    /// Returns the value of a Socket option.
    /// </summary>
    /// <param name="optionLevel">One of the <see cref="SocketOptionLevel"/> values.</param>
    /// <param name="optionName">One of the <see cref="SocketOptionName"/> values.</param>
    /// <param name="optionValue">An array of type <see cref="byte"/> that is to receive the option setting.</param>
    public void GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue);

    /// <summary>
    /// Returns the value of the specified Socket option in an array.
    /// </summary>
    /// <param name="optionLevel">One of the <see cref="SocketOptionLevel"/> values.</param>
    /// <param name="optionName">One of the <see cref="SocketOptionName"/> values.</param>
    /// <param name="optionLength">The length, in bytes, of the expected return value.</param>
    /// <returns>An array of type <see cref="byte"/> that contains the value of the socket option.</returns>
    public byte[] GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionLength);

    /// <summary>
    /// Returns the value of a specified Socket option, represented as an object.
    /// </summary>
    /// <param name="optionLevel">One of the <see cref="SocketOptionLevel"/> values.</param>
    /// <param name="optionName">One of the <see cref="SocketOptionName"/> values.</param>
    /// <returns>An object that represents the value of the option.</returns>
    public object? GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName);

    /// <summary>
    /// Sets low-level operating modes for the Socket using numerical control codes.
    /// </summary>
    /// <param name="ioControlCode">An <see cref="int"/> value that specifies the control code of the operation to perform.</param>
    /// <param name="optionInValue">A <see cref="byte"/> array that contains the input data required by the operation.</param>
    /// <param name="optionOutValue">A <see cref="byte"/> array that contains the output data returned by the operation.</param>
    /// <returns>The number of bytes in the optionOutValue parameter.</returns>
    public int IOControl(int ioControlCode, byte[]? optionInValue, byte[]? optionOutValue);

    /// <summary>
    /// Sets low-level operating modes for the Socket using the IOControlCode enumeration to specify control codes.
    /// </summary>
    /// <param name="ioControlCode">A <see cref="IOControlCode"/> value that specifies the control code of the operation to perform.</param>
    /// <param name="optionInValue">A <see cref="byte"/> array that contains the input data required by the operation.</param>
    /// <param name="optionOutValue">A <see cref="byte"/> array that contains the output data returned by the operation.</param>
    /// <returns>The number of bytes in the optionOutValue parameter.</returns>
    public int IOControl(IOControlCode ioControlCode, byte[]? optionInValue, byte[]? optionOutValue);

    /// <summary>
    /// Places an <see cref="ISocket"/> in a listening state.
    /// </summary>
    public void Listen();

    /// <summary>
    /// Places an <see cref="ISocket"/> in a listening state.
    /// </summary>
    /// <param name="backlog">The maximum length of the pending connections queue.</param>
    public void Listen(int backlog);

    /// <summary>
    /// Determines the status of the <see cref="ISocket"/>.
    /// </summary>
    /// <param name="timeout">The time to wait for a response.</param>
    /// <param name="mode">One of the <see cref="SelectMode"/> values.</param>
    /// <returns>The status of the Socket based on the polling mode value passed in the mode parameter. Returns true if any of the following conditions occur before the timeout expires, otherwise, false.</returns>
    public bool Poll(TimeSpan timeout, SelectMode mode);

    /// <summary>
    /// Determines the status of the <see cref="ISocket"/>.
    /// </summary>
    /// <param name="microSeconds">The time to wait for a response, in microseconds.</param>
    /// <param name="mode">One of the <see cref="SelectMode"/> values.</param>
    /// <returns>The status of the Socket based on the polling mode value passed in the mode parameter. Returns true if any of the following conditions occur before the timeout expires, otherwise, false.</returns>
    public bool Poll(int microSeconds, SelectMode mode);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into a receive buffer, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="offset">The position in the buffer parameter to store the received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into a receive buffer, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(Span<byte> buffer, SocketFlags socketFlags, out SocketError errorCode);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into the list of receive buffers, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffers">A list of <see cref="ArraySegment{T}"/>s of type <see cref="byte"/> that contains the received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into a receive buffer, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(byte[] buffer, int size, SocketFlags socketFlags);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into a receive buffer, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">A <see cref="Span{T}"/> of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(Span<byte> buffer, SocketFlags socketFlags);

    /// <summary>
    /// Receives the specified number of bytes from a bound <see cref="ISocket"/> into the specified offset position of the receive buffer, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="offset">The location in buffer to store the received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into a receive buffer, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(byte[] buffer, SocketFlags socketFlags);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into a receive buffer.
    /// </summary>
    /// <param name="buffer">A <see cref="Span{T}"/> of <see cref="byte"/> that is the storage location for the received data.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(Span<byte> buffer);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into the list of receive buffers.
    /// </summary>
    /// <param name="buffers">A list of <see cref="ArraySegment{T}"/>s of type <see cref="byte"/> that contains the received data.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(IList<ArraySegment<byte>> buffers);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into a receive buffer.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for the received data.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(byte[] buffer);

    /// <summary>
    /// Receives data from a bound <see cref="ISocket"/> into the list of receive buffers.
    /// </summary>
    /// <param name="buffers">A list of <see cref="ArraySegment{T}"/>s of type <see cref="byte"/> that contains the received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes received.</returns>
    public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);

    /// <summary>
    /// Receives data from a connected socket.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <returns>An asynchronous task that completes with the number of bytes received.</returns>
    public Task<int> ReceiveAsync(ArraySegment<byte> buffer);

    /// <summary>
    /// Receives data from a connected socket.
    /// </summary>
    /// <param name="buffers">A list of buffers for the received data.</param>
    /// <returns>An asynchronous task that completes with the number of bytes received.</returns>
    public Task<int> ReceiveAsync(IList<ArraySegment<byte>> buffers);

    /// <summary>
    /// Begins an asynchronous request to receive data from a connected Socket object.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object to use for this asynchronous socket operation.</param>
    /// <returns>true if the I/O operation is pending, false if it completed synchronously.</returns>
    public bool ReceiveAsync(SocketAsyncEventArgs e);

    /// <summary>
    /// Receives data from a connected socket.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when receiving the data.</param>
    /// <returns>An asynchronous task that completes with the number of bytes received.</returns>
    public Task<int> ReceiveAsync(ArraySegment<byte> buffer, SocketFlags socketFlags);

    /// <summary>
    /// Receives data from a connected socket.
    /// </summary>
    /// <param name="buffers">A list of buffers for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when receiving the data.</param>
    /// <returns>An asynchronous task that completes with the number of bytes received.</returns>
    public Task<int> ReceiveAsync(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);

    /// <summary>
    /// Receives data from a connected socket.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with the number of bytes received.</returns>
    public ValueTask<int> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives data from a connected socket.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when receiving the data.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with the number of bytes received.</returns>
    public ValueTask<int> ReceiveAsync(Memory<byte> buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives the specified number of bytes into the data buffer, using the specified <see cref="SocketFlags"/>, and stores the <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on successful receive.</param>
    /// <returns>The number of bytes received.</returns>
    public int ReceiveFrom(byte[] buffer, int size, SocketFlags socketFlags, ref EndPoint remoteEP);

    /// <summary>
    /// Receives the specified number of bytes of data into the specified location of the data buffer, using the specified <see cref="SocketFlags"/>, and stores the <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="offset">The position in the buffer parameter to store the received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on successful receive.</param>
    /// <returns>The number of bytes received.</returns>
    public int ReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP);

    /// <summary>
    /// Receives a datagram into the data buffer, using the specified <see cref="SocketFlags"/>, and stores the <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">A <see cref="Span{T}"/> of <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on successful receive.</param>
    /// <returns>The number of bytes received.</returns>
    public int ReceiveFrom(Span<byte> buffer, SocketFlags socketFlags, ref EndPoint remoteEP);

    /// <summary>
    /// Receives a datagram into the data buffer, using the specified <see cref="SocketFlags"/>, and stores the <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on successful receive.</param>
    /// <returns>The number of bytes received.</returns>
    public int ReceiveFrom(byte[] buffer, SocketFlags socketFlags, ref EndPoint remoteEP);

    /// <summary>
    /// Receives a datagram into the data buffer, using the specified <see cref="SocketFlags"/>, and stores the <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">A <see cref="Span{T}"/> of <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="receivedAddress">A <see cref="SocketAddress"/> instance that gets updated with the value of the remote peer when this method returns.</param>
    /// <returns>The number of bytes received.</returns>
    public int ReceiveFrom(Span<byte> buffer, SocketFlags socketFlags, SocketAddress receivedAddress);

    /// <summary>
    /// Receives a datagram into the data buffer and stores the <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">A <see cref="Span{T}"/> of <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on successful receive.</param>
    /// <returns>The number of bytes received.</returns>
    public int ReceiveFrom(Span<byte> buffer, ref EndPoint remoteEP);

    /// <summary>
    /// Receives a datagram into the data buffer and stores the <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on successful receive.</param>
    /// <returns>The number of bytes received.</returns>
    public int ReceiveFrom(byte[] buffer, ref EndPoint remoteEP);

    /// <summary>
    /// Begins to asynchronously receive data from a specified network device.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object to use for this asynchronous socket operation.</param>
    /// <returns>true if the I/O operation is pending, false if it completed synchronously.</returns>
    public bool ReceiveFromAsync(SocketAsyncEventArgs e);

    /// <summary>
    /// Receives data and returns the <see cref="EndPoint"/> of the sending host.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="remoteEndPoint">An <see cref="EndPoint"/> of the same type as the endpoint of the remote host.</param>
    /// <returns>An asynchronous task that completes with a <see cref="SocketReceiveFromResult"/> containing the number of bytes received and the endpoint of the sending host.</returns>
    public Task<SocketReceiveFromResult> ReceiveFromAsync(ArraySegment<byte> buffer, EndPoint remoteEndPoint);

    /// <summary>
    /// Receives data and returns the <see cref="EndPoint"/> of the sending host.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when receiving the data.</param>
    /// <param name="remoteEndPoint">An <see cref="EndPoint"/> of the same type as the endpoint of the remote host.</param>
    /// <returns>An asynchronous task that completes with a <see cref="SocketReceiveFromResult"/> containing the number of bytes received and the endpoint of the sending host.</returns>
    public Task<SocketReceiveFromResult> ReceiveFromAsync(ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint);

    /// <summary>
    /// Receives data and returns the <see cref="EndPoint"/> of the sending host.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="remoteEndPoint">An <see cref="EndPoint"/> of the same type as the endpoint of the remote host.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with a <see cref="SocketReceiveFromResult"/> containing the number of bytes received and the endpoint of the sending host.</returns>
    public ValueTask<SocketReceiveFromResult> ReceiveFromAsync(Memory<byte> buffer, EndPoint remoteEndPoint, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives data and returns the <see cref="EndPoint"/> of the sending host.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when receiving the data.</param>
    /// <param name="remoteEndPoint">An <see cref="EndPoint"/> of the same type as the endpoint of the remote host.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with a <see cref="SocketReceiveFromResult"/> containing the number of bytes received and the endpoint of the sending host.</returns>
    public ValueTask<SocketReceiveFromResult> ReceiveFromAsync(Memory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives a datagram into the data buffer, using the specified <see cref="SocketFlags"/>, and stores the <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when receiving the data.</param>
    /// <param name="receivedAddress">A <see cref="SocketAddress"/> instance that gets updated with the value of the remote peer when this method returns.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns></returns>
    public ValueTask<int> ReceiveFromAsync(Memory<byte> buffer, SocketFlags socketFlags, SocketAddress receivedAddress, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives the specified number of bytes of data into the specified location of the data buffer, using the specified <see cref="SocketFlags"/>, and stores the <see cref="EndPoint"/> and <see cref="IPPacketInformation"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="offset">The position in the buffer parameter to store the received data.</param>
    /// <param name="size">The number of bytes to receive.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on successful receive.</param>
    /// <param name="ipPacketInformation">An <see cref="IPPacketInformation"/> holding address and interface information.</param>
    /// <returns>The number of bytes received.</returns>
    public int ReceiveMessageFrom(byte[] buffer, int offset, int size, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation);

    /// <summary>
    /// Receives the specified number of bytes of data into the specified location of the data buffer, using the specified <see cref="SocketFlags"/>, and stores the <see cref="EndPoint"/> and <see cref="IPPacketInformation"/>.
    /// </summary>
    /// <param name="buffer">An <see cref="Span{T}"/> of type <see cref="byte"/> that is the storage location for received data.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">A reference to an <see cref="EndPoint"/> of the same type as the endpoint of the remote host to be updated on successful receive.</param>
    /// <param name="ipPacketInformation">An <see cref="IPPacketInformation"/> holding address and interface information.</param>
    /// <returns>The number of bytes received.</returns>
    public int ReceiveMessageFrom(Span<byte> buffer, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation);

    /// <summary>
    /// Begins to asynchronously receive the specified number of bytes of data into the specified location in the data buffer, using the specified <see cref="SocketFlags"/>, and stores the <see cref="EndPoint"/> and packet information.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object to use for this asynchronous socket operation.</param>
    /// <returns>true if the I/O operation is pending. The Completed event on the e parameter will be raised upon completion of the operation. false if the I/O operation completed synchronously.</returns>
    public bool ReceiveMessageFromAsync(SocketAsyncEventArgs e);

    /// <summary>
    /// Receives data and returns additional information about the sender of the message.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="remoteEndPoint">An <see cref="EndPoint"/> of the same type as the endpoint of the remote host.</param>
    /// <returns>An asynchronous task that completes with a <see cref="SocketReceiveMessageFromResult"/> containing the number of bytes received and additional information about the sending host.</returns>
    public Task<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(ArraySegment<byte> buffer, EndPoint remoteEndPoint);

    /// <summary>
    /// Receives data and returns additional information about the sender of the message.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when receiving the data.</param>
    /// <param name="remoteEndPoint">An <see cref="EndPoint"/> of the same type as the endpoint of the remote host.</param>
    /// <returns>An asynchronous task that completes with a <see cref="SocketReceiveMessageFromResult"/> containing the number of bytes received and additional information about the sending host.</returns>
    public Task<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint);

    /// <summary>
    /// Receives data and returns additional information about the sender of the message.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="remoteEndPoint">An <see cref="EndPoint"/> of the same type as the endpoint of the remote host.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with a <see cref="SocketReceiveMessageFromResult"/> containing the number of bytes received and additional information about the sending host.</returns>
    public ValueTask<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(Memory<byte> buffer, EndPoint remoteEndPoint, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives data and returns additional information about the sender of the message.
    /// </summary>
    /// <param name="buffer">The buffer for the received data.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when receiving the data.</param>
    /// <param name="remoteEndPoint">An <see cref="EndPoint"/> of the same type as the endpoint of the remote host.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to signal the asynchronous operation should be canceled.</param>
    /// <returns>An asynchronous task that completes with a <see cref="SocketReceiveMessageFromResult"/> containing the number of bytes received and additional information about the sending host.</returns>
    public ValueTask<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(Memory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends data to a connected <see cref="ISocket"/> using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">A span of <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> enumeration values that specifies send and receive behaviors.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(ReadOnlySpan<byte> buffer, SocketFlags socketFlags, out SocketError errorCode);

    /// <summary>
    /// Sends data to a connected <see cref="ISocket"/>.
    /// </summary>
    /// <param name="buffer">A span of <see cref="byte"/> that contains the data to be sent.</param>
    /// <returns>The number of bytes sent to the Socket.</returns>
    public int Send(ReadOnlySpan<byte> buffer);

    /// <summary>
    /// Sends the specified number of bytes of data to a connected <see cref="ISocket"/>, starting at the specified offset, and using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="offset">The position in the data buffer at which to begin sending data.</param>
    /// <param name="size">The number of bytes to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode);

    /// <summary>
    /// Sends the set of buffers in the list to a connected <see cref="ISocket"/>, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffers">A list of <see cref="ArraySegment{T}"/>s of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="errorCode">A <see cref="SocketError"/> object that stores the socket error.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode);

    /// <summary>
    /// Sends the specified number of bytes of data to a connected <see cref="ISocket"/>, starting at the specified offset, and using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="offset">The position in the data buffer at which to begin sending data.</param>
    /// <param name="size">The number of bytes to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags);

    /// <summary>
    /// Sends the specified number of bytes of data to a connected <see cref="ISocket"/>, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to be sent.</param
    /// <param name="size">The number of bytes to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(byte[] buffer, int size, SocketFlags socketFlags);

    /// <summary>
    /// Sends the specified number of bytes of data to a connected <see cref="ISocket"/>.
    /// </summary>
    /// <param name="buffers">A list of <see cref="ArraySegment{T}"/>s of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(IList<ArraySegment<byte>> buffers);

    /// <summary>
    /// Sends the set of buffers in the list to a connected <see cref="ISocket"/>, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffers">A list of <see cref="ArraySegment{T}"/>s of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);

    /// <summary>
    /// Sends the set of buffers in the list to a connected <see cref="ISocket"/>, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(byte[] buffer, SocketFlags socketFlags);

    /// <summary>
    /// Sends the set of buffers in the list to a connected <see cref="ISocket"/>, using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">A span of <see cref="byte"/>s that contains the data to be sent.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(ReadOnlySpan<byte> buffer, SocketFlags socketFlags);

    /// <summary>
    /// Sends the set of buffers in the list to a connected <see cref="ISocket"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <returns>The number of bytes sent to the <see cref="ISocket"/>.</returns>
    public int Send(byte[] buffer);

    /// <summary>
    /// Sends data on a connected socket.
    /// </summary>
    /// <param name="buffer">The buffer for the data to send.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends data on a connected socket.
    /// </summary>
    /// <param name="buffers">A list of buffers for the data to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public Task<int> SendAsync(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);

    /// <summary>
    /// Sends data on a connected socket.
    /// </summary>
    /// <param name="buffer">The buffer for the data to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public Task<int> SendAsync(ArraySegment<byte> buffer, SocketFlags socketFlags);

    /// <summary>
    /// Sends data on a connected socket
    /// </summary>
    /// <param name="buffer">The buffer for the data to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends data on a connected socket.
    /// </summary>
    /// <param name="buffers">A list of buffers for the data to send.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public Task<int> SendAsync(IList<ArraySegment<byte>> buffers);

    /// <summary>
    /// Sends data on a connected socket.
    /// </summary>
    /// <param name="buffer">The buffer for the data to send.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public Task<int> SendAsync(ArraySegment<byte> buffer);

    /// <summary>
    /// Sends data asynchronously to a connected <see cref="ISocket"/> object.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object to use for this asynchronous socket operation.</param>
    /// <returns>true if the I/O operation is pending. The Completed event on the e parameter will be raised upon completion of the operation.false if the I/O operation completed synchronously. In this case, The Completed event on the e parameter will not be raised and the e object passed as a parameter may be examined immediately after the method call returns to retrieve the result of the operation.</returns>
    public bool SendAsync(SocketAsyncEventArgs e);

    /// <summary>
    /// Sends the file 'fileName' to a connected <see cref="ISocket"/> object with the <see cref="UseDefaultWorkerThread"/> transmit flag.
    /// </summary>
    /// <param name="fileName">A <see cref="string"/> that contains the path and name of the file to be sent. This parameter can be null.</param>
    public void SendFile(string? fileName);

    /// <summary>
    /// Sends the file 'fileName' and buffers of data to a connected <see cref="ISocket"/> object using the specified <see cref="TransmitFileOptions"/> value.
    /// </summary>
    /// <param name="fileName">The path and name of the file to be sent. This parameter can be null.</param>
    /// <param name="preBuffer">The data to be sent before the file is sent. This parameter can be null.</param>
    /// <param name="postBuffer">The data to be sent after the file is sent. This parameter can be null.</param>
    /// <param name="flags">A bitwise combination of the <see cref="TransmitFileOptions"/> enumeration values that specifies how the file is transferred.</param>
    public void SendFile(string? fileName, byte[]? preBuffer, byte[]? postBuffer, TransmitFileOptions flags);

    /// <summary>
    /// Sends the file 'fileName' and buffers of data to a connected <see cref="ISocket"/> object using the specified <see cref="TransmitFileOptions"/> value.
    /// </summary>
    /// <param name="fileName">The path and name of the file to be sent. This parameter can be null.</param>
    /// <param name="preBuffer">The data to be sent before the file is sent. This parameter can be null.</param>
    /// <param name="postBuffer">The data to be sent after the file is sent. This parameter can be null.</param>
    /// <param name="flags">A bitwise combination of the <see cref="TransmitFileOptions"/> enumeration values that specifies how the file is transferred.</param>
    public void SendFile(string? fileName, ReadOnlySpan<byte> preBuffer, ReadOnlySpan<byte> postBuffer, TransmitFileOptions flags);

    /// <summary>
    /// Sends the file 'fileName' to a connected <see cref="ISocket"/> object.
    /// </summary>
    /// <param name="fileName">A <see cref="string"/> that contains the path and name of the file to be sent. This parameter can be null.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous send file operation.</returns>
    public ValueTask SendFileAsync(string? fileName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends the file 'fileName' and buffers of data to a connected <see cref="ISocket"/> object using the specified <see cref="TransmitFileOptions"/> value.
    /// </summary>
    /// <param name="fileName">A <see cref="string"/> that contains the path and name of the file to be sent. This parameter can be null.</param>
    /// <param name="preBuffer">A <see cref="byte"/> array that contains data to be sent before the file is sent. This parameter can be null.</param>
    /// <param name="postBuffer">A <see cref="byte"/> array that contains data to be sent after the file is sent. This parameter can be null.</param>
    /// <param name="flags">One or more of <see cref="TransmitFileOptions"/> values.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous send file operation.</returns>
    public ValueTask SendFileAsync(string? fileName, ReadOnlyMemory<byte> preBuffer, ReadOnlyMemory<byte> postBuffer, TransmitFileOptions flags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a collection of files or in memory data buffers asynchronously to a connected <see cref="ISocket"/> object.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object to use for this asynchronous socket operation.</param>
    /// <returns>true if the I/O operation is pending. The Completed event on the e parameter will be raised upon completion of the operation.false if the I/O operation completed synchronously.In this case, The Completed event on the e parameter will not be raised and the e object passed as a parameter may be examined immediately after the method call returns to retrieve the result of the operation.</returns>
    public bool SendPacketsAsync(SocketAsyncEventArgs e);

    /// <summary>
    /// Sends the specified number of bytes of data to the specified <see cref="EndPoint"/>, starting at the specified location in the buffer, and using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="offset">The position in the data buffer at which to begin sending data.</param>
    /// <param name="size">The number of bytes to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">The <see cref="EndPoint"/> that represents the destination location for the data.</param>
    /// <returns>The number of bytes sent.</returns>
    public int SendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP);

    /// <summary>
    /// Sends the specified number of bytes of data to the specified <see cref="EndPoint"/> using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="size">The number of bytes to send.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">The <see cref="EndPoint"/> that represents the destination location for the data.</param>
    /// <returns>The number of bytes sent.</returns>
    public int SendTo(byte[] buffer, int size, SocketFlags socketFlags, EndPoint remoteEP);

    /// <summary>
    /// Sends data to a specific <see cref="SocketAddress"/> using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">A <see cref="ReadOnlySpan{T}"> of <see cref="byte"/>s that contains the data to be sent.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="socketAddress">The <see cref="SocketAddress"/> that represents the destination for the data.</param>
    /// <returns>The number of bytes sent.</returns>
    public int SendTo(ReadOnlySpan<byte> buffer, SocketFlags socketFlags, SocketAddress socketAddress);

    /// <summary>
    /// Sends data to the specified <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">A <see cref="ReadOnlySpan{T}"> of <see cref="byte"/>s that contains the data to be sent.</param>
    /// <param name="remoteEP">The <see cref="EndPoint"/> that represents the destination location for the data.</param>
    /// <returns>The number of bytes sent.</returns>
    public int SendTo(ReadOnlySpan<byte> buffer, EndPoint remoteEP);

    /// <summary>
    /// Sends data to the specified <see cref="EndPoint"/> using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="socketFlags">A bitwise combination of the <see cref="SocketFlags"/> values.</param>
    /// <param name="remoteEP">The <see cref="EndPoint"/> that represents the destination location for the data.</param>
    /// <returns>The number of bytes sent.</returns>
    public int SendTo(byte[] buffer, SocketFlags socketFlags, EndPoint remoteEP);

    /// <summary>
    /// Sends data to the specified <see cref="EndPoint"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to be sent.</param>
    /// <param name="remoteEP">The <see cref="EndPoint"/> that represents the destination location for the data.</param>
    /// <returns>The number of bytes sent.</returns>
    public int SendTo(byte[] buffer, EndPoint remoteEP);

    /// <summary>
    /// Sends data asynchronously to a specific remote host.
    /// </summary>
    /// <param name="e">The <see cref="SocketAsyncEventArgs"/> object to use for this asynchronous socket operation.</param>
    /// <returns>true if the I/O operation is pending. The Completed event on the e parameter will be raised upon completion of the operation. false if the I/O operation completed synchronously. In this case, The Completed event on the e parameter will not be raised and the e object passed as a parameter may be examined immediately after the method call returns to retrieve the result of the operation.</returns>
    public bool SendToAsync(SocketAsyncEventArgs e);

    /// <summary>
    /// Sends data to the specified remote host.
    /// </summary>
    /// <param name="buffer">The buffer for the data to send.</param>
    /// <param name="remoteEP">The remote host to which to send the data.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public Task<int> SendToAsync(ArraySegment<byte> buffer, EndPoint remoteEP);

    /// <summary>
    /// Sends data to the specified remote host.
    /// </summary>
    /// <param name="buffer">The buffer for the data to send.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when sending the data.</param>
    /// <param name="remoteEP">The remote host to which to send the data.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent</returns>
    public Task<int> SendToAsync(ArraySegment<byte> buffer, SocketFlags socketFlags, EndPoint remoteEP);

    /// <summary>
    /// Sends data to the specified remote host.
    /// </summary>
    /// <param name="buffer">The buffer for the data to send.</param>
    /// <param name="remoteEP">The remote host to which to send the data.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, EndPoint remoteEP, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends data to the specified remote host.
    /// </summary>
    /// <param name="buffer">The buffer for the data to send.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when sending the data.</param>
    /// <param name="remoteEP">The remote host to which to send the data.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEP, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends data to a specific <see cref="SocketAddress"/> using the specified <see cref="SocketFlags"/>.
    /// </summary>
    /// <param name="buffer">The buffer for the data to send.</param>
    /// <param name="socketFlags">A bitwise combination of <see cref="SocketFlags"/> values that will be used when sending the data.</param>
    /// <param name="socketAddress">The <see cref="SocketAddress"/> that represents the destination for the data.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
    /// <returns>An asynchronous task that completes with the number of bytes sent.</returns>
    public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, SocketAddress socketAddress, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the IP protection level on a socket.
    /// </summary>
    /// <param name="level">The IP protection level to set on this socket.</param>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public void SetIPProtectionLevel(IPProtectionLevel level);

    /// <summary>
    /// Sets a socket option value using platform-specific level and name identifiers.
    /// </summary>
    /// <param name="optionLevel">The platform-defined option level.</param>
    /// <param name="optionName">The platform-defined option name.</param>
    /// <param name="optionValue">The value to which the option should be set.</param>
    public void SetRawSocketOption(int optionLevel, int optionName, ReadOnlySpan<byte> optionValue);

    /// <summary>
    /// Sets the specified Socket option to the specified Boolean value.
    /// </summary>
    /// <param name="optionLevel">One of the <see cref="SocketOptionLevel"/> values.</param>
    /// <param name="optionName">One of the <see cref="SocketOptionName"/> values.</param>
    /// <param name="optionValue">The value of the option, represented as a <see cref="bool"/>.</param>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue);

    /// <summary>
    /// Sets the specified Socket option to the specified value, represented as a byte array.
    /// </summary>
    /// <param name="optionLevel">One of the <see cref="SocketOptionLevel"/> values.</param>
    /// <param name="optionName">One of the <see cref="SocketOptionName"/> values.</param>
    /// <param name="optionValue">An array of type <see cref="byte"/> that represents the value of the option.</param>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue);

    /// <summary>
    /// Sets the specified Socket option to the specified integer value.
    /// </summary>
    /// <param name="optionLevel">One of the <see cref="SocketOptionLevel"/> values.</param>
    /// <param name="optionName">One of the <see cref="SocketOptionName"/> values.</param>
    /// <param name="optionValue">A value of the option.</param>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue);

    /// <summary>
    /// Sets the specified Socket option to the specified value, represented as an object.
    /// </summary>
    /// <param name="optionLevel">One of the <see cref="SocketOptionLevel"/> values.</param>
    /// <param name="optionName">One of the <see cref="SocketOptionName"/> values.</param>
    /// <param name="optionValue">A <see cref="LingerOption"/> or <see cref="MulticastOption"/> that contains the value of the option.</param>
    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, object optionValue);

    /// <summary>
    /// Disables sends and receives on an <see cref="ISocket"/>.
    /// </summary>
    /// <param name="how">One of the <see cref="SocketShutdown"/> values that specifies the operation that will no longer be allowed.</param>
    public void Shutdown(SocketShutdown how);
}

#pragma warning restore RCS1047 // Non-asynchronous method name should not end with 'Async'