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
    /// Creates a new instance of <see cref="SocketWrapper"/>.
    /// </summary>
    /// <param name="addressFamily">The address family.</param>
    /// <param name="socketType">The socket type.</param>
    /// <param name="protocolType">The protocol type.</param>
    public SocketWrapper(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
    {
        _socket = new Socket(addressFamily, socketType, protocolType);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketWrapper"/>.
    /// </summary>
    /// <param name="socketType">The socket type.</param>
    /// <param name="protocolType">The protocol type.</param>
    public SocketWrapper(SocketType socketType, ProtocolType protocolType)
    {
        _socket = new Socket(socketType, protocolType);
    }

    /// <summary>
    /// Gets or sets the receive buffer size.
    /// </summary>
    public int ReceiveBufferSize { get => _socket.ReceiveBufferSize; set => _socket.ReceiveBufferSize = value; }

    /// <summary>
    /// Gets or sets the send buffer size.
    /// </summary>
    public int SendBufferSize { get => _socket.SendBufferSize; set => _socket.SendBufferSize = value; }

    /// <summary>
    /// Gets or sets the receive timeout.
    /// </summary>
    public int ReceiveTimeout { get => _socket.ReceiveTimeout; set => _socket.ReceiveTimeout = value; }

    /// <summary>
    /// Gets or sets the send timeout.
    /// </summary>
    public int SendTimeout { get => _socket.SendTimeout; set => _socket.SendTimeout = value; }

    /// <summary>
    /// Connects to a remote endpoint.
    /// </summary>
    /// <param name="remoteEndpoint">The remote endpoint to connect to.</param>
    public void Connect(EndPoint remoteEndpoint)
    {
        _socket.Connect(remoteEndpoint);
    }

    /// <summary>
    /// Connects asynchronously to the remote <see cref="IPEndPoint"></see>.
    /// </summary>
    /// <param name="remoteEndpoint">The remote <see cref="IPEndPoint"></see> to connect to.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task"> that represents the asynchronous operation.</returns>
    public async Task ConnectAsync(IPEndPoint remoteEndpoint, CancellationToken cancellationToken = default)
    {
        await _socket.ConnectAsync(remoteEndpoint, cancellationToken);
    }

    /// <summary>
    /// Send data to the remote endpoint.
    /// </summary>
    /// <param name="buffer">Buffer containing the data to be sent.</param>
    /// <param name="socketFlags">Socket flags.</param>
    /// <param name="errorCode">Error code.</param>
    /// <returns>An <see cref="int"/> representing the number of sent bytes.</returns>
    public int Send(byte[] buffer, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Send(buffer, socketFlags, out errorCode);
    }

    /// <summary>
    /// Asynchronously sends data to the remote endpoint.
    /// </summary>
    /// <param name="buffer">Buffer containing the data to be sent.</param>
    /// <param name="socketFlags">Socket flags.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.<br/>The task's result contains the number of successfully sent bytes.</returns>
    public async Task<int> SendAsync(byte[] buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default)
    {
        return await _socket.SendAsync(buffer, socketFlags, cancellationToken);
    }

    /// <summary>
    /// Receives data from the remote endpoint.
    /// </summary>
    /// <param name="buffer">Buffer to store the received data.</param>
    /// <param name="socketFlags">Socket flags.</param>
    /// <param name="errorCode">Error code.</param>
    /// <returns>An <see cref="int"/> representing the number of received bytes.</returns>
    public int Receive(byte[] buffer, SocketFlags socketFlags, out SocketError errorCode)
    {
        return _socket.Receive(buffer, socketFlags, out errorCode);
    }

    /// <summary>
    /// Asynchronously receives data from the remote endpoint.
    /// </summary>
    /// <param name="buffer">Buffer to store the received data.</param>
    /// <param name="socketFlags">Socket flags.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.<br/>The task's result contains the number of successfully received bytes.</returns>
    public async Task<int> ReceiveAsync(byte[] buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default)
    {
        return await _socket.ReceiveAsync(buffer, SocketFlags.None, cancellationToken);
    }

    /// <summary>
    /// Closes the socket.
    /// </summary>
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