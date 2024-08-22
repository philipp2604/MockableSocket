using System.Net;
using System.Net.Sockets;

namespace MockableTcp.Interfaces;

public interface ISocket : IDisposable
{
    /// <summary>
    /// Gets the AddressFamily.
    /// </summary>
    public AddressFamily AddressFamily { get; }

    /// <summary>
    /// Gets the SocketType.
    /// </summary>
    public SocketType SocketType { get; }

    /// <summary>
    /// Gets the ProtocolType
    /// </summary>
    public ProtocolType ProtocolType { get; }

    /// <summary>
    /// Gets or sets the receive buffer size.
    /// </summary>
    public int ReceiveBufferSize { get; set; }

    /// <summary>
    /// Gets or sets the send buffer size.
    /// </summary>
    public int SendBufferSize { get; set; }

    /// <summary>
    /// Gets or sets the receive timeout.
    /// </summary>
    public int ReceiveTimeout { get; set; }

    /// <summary>
    /// Gets or sets the send timeout.
    /// </summary>
    public int SendTimeout { get; set; }

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