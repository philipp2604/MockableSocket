using System.Net;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

}