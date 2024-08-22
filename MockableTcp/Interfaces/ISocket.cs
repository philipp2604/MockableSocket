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