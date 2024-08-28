using MockableSocket.Interfaces.NetworkStream;
using MockableSocket.Interfaces.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MockableSocket.NetworkStream;

/// <summary>
/// Wraps <see cref="NetworkStream"/> to implement <see cref="INetworkStream"/> and to support <see cref="ISocket"/>
/// </summary>
public class NetworkStreamW : INetworkStream
{
    private bool _disposed;

    /// <summary>
    /// Creates a new instance of the <see cref="NetworkStreamW"/> class for the specified <see cref="ISocket"/>.
    /// </summary>
    /// <param name="socket">The <see cref="ISocket"/> that the <see cref="NetworkStreamW"/> will use to send and receive data.</param>
    public NetworkStreamW(ISocket socket) : this(socket, FileAccess.ReadWrite, false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NetworkStreamW"/> class for the specified <see cref="ISocket"/> with the specified Socket ownership.
    /// </summary>
    /// <param name="socket">The <see cref="ISocket"/> that the <see cref="NetworkStreamW"/> will use to send and receive data.</param>
    /// <param name="ownsSocket">Set to true to indicate that the <see cref="NetworkStreamW"/> will take ownership of the <see cref="ISocket"/>; otherwise, false.</param>
    public NetworkStreamW(ISocket socket, bool ownsSocket) : this (socket, FileAccess.ReadWrite, ownsSocket)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="NetworkStreamW"/> class for the specified <see cref="ISocket"/> with the specified access rights.
    /// </summary>
    /// <param name="socket">The <see cref="ISocket"/> that the <see cref="NetworkStreamW"/> will use to send and receive data.</param>
    /// <param name="access">A bitwise combination of the <see cref="FileAccess"/> values that specify the type of access given to the <see cref="NetworkStreamW"/> over the provided <see cref="ISocket"/>.</param>
    public NetworkStreamW(ISocket socket, FileAccess access) : this (socket, access, false)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="NetworkStreamW"/> class for the specified <see cref="ISocket"/> with the specified access rights and the specified <see cref="ISocket"/> ownership.
    /// </summary>
    /// <param name="socket">The <see cref="ISocket"/> that the <see cref="NetworkStreamW"/> will use to send and receive data.</param>
    /// <param name="access">A bitwise combination of the <see cref="FileAccess"/> values that specify the type of access given to the <see cref="NetworkStreamW"/> over the provided <see cref="ISocket"/>.</param>
    /// <param name="ownsSocket">Set to true to indicate that the <see cref="NetworkStreamW"/> will take ownership of the <see cref="ISocket"/>; otherwise, false.</param>
    public NetworkStreamW(ISocket socket, FileAccess access, bool ownsSocket)
    {
        Socket = socket;
        NetworkStream = new System.Net.Sockets.NetworkStream(socket.Socket, access, ownsSocket);
    }

    /// <inheritdoc/>v
    public bool CanRead { get; }

    /// <inheritdoc/>
    public bool CanSeek { get; }

    /// <inheritdoc/>
    public bool CanTimeout { get; }

    /// <inheritdoc/>
    public bool CanWrite { get; }

    /// <inheritdoc/>
    public bool DataAvailable { get; }

    /// <inheritdoc/>
    public long Length { get; }

    /// <inheritdoc/>
    public System.Net.Sockets.NetworkStream NetworkStream { get; }

    /// <inheritdoc/>
    public long Position { get; }

    /// <inheritdoc/>
    public bool Readable { get; set; }

    /// <inheritdoc/>
    public int ReadTimeout { get; set; }

    /// <inheritdoc/>
    public ISocket Socket { get; }

    /// <inheritdoc/>
    public bool Writeable { get; set; }

    /// <inheritdoc/>
    public int WriteTimeout { get; set; }


    /// <inheritdoc/>
    public IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
    {
        return NetworkStream.BeginRead(buffer, offset, count, callback, state);
    }

    /// <inheritdoc/>
    public IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
    {
        return NetworkStream.BeginWrite(buffer, offset, count, callback, state);
    }

    /// <inheritdoc/>
    public void Close(int timeout)
    {
        NetworkStream.Close(timeout);
    }

    /// <inheritdoc/>
    public void Close(TimeSpan timeout)
    {
        NetworkStream.Close(timeout);
    }

    public void CopyTo(Stream destination)
    {
        NetworkStream.CopyTo(destination);
    }

    /// <inheritdoc/>
    public void CopyTo(Stream destination, int bufferSize)
    {
        NetworkStream.CopyTo(destination, bufferSize);
    }

    /// <inheritdoc/>
    public Task CopyToAsync(Stream destination)
    {
        return NetworkStream.CopyToAsync(destination);
    }

    /// <inheritdoc/>
    public Task CopyToAsync(Stream destination, CancellationToken cancellationToken)
    {
        return NetworkStream.CopyToAsync(destination, cancellationToken);
    }

    /// <inheritdoc/>
    public Task CopyToAsync(Stream destination, int bufferSize)
    {
        return NetworkStream.CopyToAsync(destination, bufferSize);
    }

    /// <inheritdoc/>
    public Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
    {
        return NetworkStream.CopyToAsync(destination, bufferSize, cancellationToken);
    }

    protected void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        NetworkStream.Dispose();

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual ValueTask DisposeAsync()
    {
        return NetworkStream.DisposeAsync();
    }

    ~NetworkStreamW()
    {
        Dispose(false);
    }
}
