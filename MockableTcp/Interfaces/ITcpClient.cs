using System.Net;

namespace MockableTcp.Interfaces;

public interface ITcpClient : IDisposable
{
    /// <summary>
    /// Event being invoked when the client successfully connected to the remote host.
    /// </summary>
    public event EventHandler? Connected;

    /// <summary>
    /// Event being invoked when the client is disconnected.
    /// </summary>
    public event EventHandler? Disconnected;

    /// <summary>
    /// Gets if the client is connected.
    /// </summary>
    public bool IsConnected { get; }

    /// <summary>
    /// The underlying <see cref="ISocket"/>.
    /// </summary>
    public ISocket? Socket { get; }

    /// <summary>
    /// Gets or sets the size of the receive buffer.<br/>Default value is 8192 bytes.
    /// </summary>
    public int ReceiveBufferSize { get; set; }

    /// <summary>
    /// Gets or sets the size of the send buffer.<br/>Default value is 8192 bytes.
    /// </summary>
    public int SendBufferSize { get; set; }

    /// <summary>
    /// Gets or sets the size of the receive timeout.<br/>Default value is 1 second.
    /// </summary>
    public TimeSpan ReceiveTimeout { get; set; }

    /// <summary>
    /// Gets or sets the size of the send timeout.<br/>Default value is 1 second.
    /// </summary>
    public TimeSpan SendTimeout { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="IPEndPoint"/> to connect to.
    /// </summary>
    public IPEndPoint? IPEndPoint { get; set; }

    /// <summary>
    /// Initializes the underlying socket.
    /// </summary>
    /// <param name="ipEndPoint">Optionally a new remote <see cref="IPEndPoint"/>, will override the class property.</param>
    public void Initialize(IPEndPoint? ipEndPoint = null);

    /// <summary>
    /// Connects to the specified <see cref="IPEndPoint"/>.
    /// </summary>
    /// <exception cref="NullReferenceException"></exception>
    public void Connect();

    /// <summary>
    /// Connects asynchronously to the specified <see cref="IPEndPoint"/>.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="NullReferenceException"></exception>
    public Task ConnectAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends data to the remote host using the underlying <see cref="ISocket"/>.
    /// </summary>
    /// <param name="buffer">A buffer containing the data to send.</param>
    /// <returns>An integer with the number of successfully sent bytes.</returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public int Send(List<byte> buffer);

    /// <summary>
    /// Asynchronously sends data to the remote host using the underlying <see cref="ISocket"/>.
    /// </summary>
    /// <param name="buffer">A buffer containing the data to send.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.<br/>The task's result contains the number of successfully sent bytes.</returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public Task<int> SendAsync(List<byte> buffer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives data from the remote host using the underlying <see cref="ISocket"/>.
    /// </summary>
    /// <returns>A <see cref="List{byte}"></see> containing the received bytes.</returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public List<byte> Receive();

    /// <summary>
    /// Asynchronously receives data from the remote host using the underlying <see cref="ISocket"/>.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.<br/>The task's result contains a <see cref="List{byte}"/> containg the received bytes.</returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public Task<List<byte>> ReceiveAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Closes the connection aswell as the underlying <see cref="ISocket"/>.
    /// </summary>
    public void Disconnect();
}