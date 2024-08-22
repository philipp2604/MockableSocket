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

    /// <inheritdoc/>
    public AddressFamily AddressFamily { get => _socket.AddressFamily; }

    /// <inheritdoc/>
    public SocketType SocketType { get => _socket.SocketType; }

    /// <inheritdoc/>
    public ProtocolType ProtocolType { get => _socket.ProtocolType; }

    /// <inheritdoc/>
    public int ReceiveBufferSize { get => _socket.ReceiveBufferSize; set => _socket.ReceiveBufferSize = value; }

    /// <inheritdoc/>
    public int SendBufferSize { get => _socket.SendBufferSize; set => _socket.SendBufferSize = value; }

    /// <inheritdoc/>
    public int ReceiveTimeout { get => _socket.ReceiveTimeout; set => _socket.ReceiveTimeout = value; }

    /// <inheritdoc/>
    public int SendTimeout { get => _socket.SendTimeout; set => _socket.SendTimeout = value; }

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