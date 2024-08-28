using MockableSocket.Interfaces.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockableSocket.Interfaces.NetworkStream;

/// <summary>
/// Provides the underlying stream of data for network access, based on <see cref="NetworkStream"/>
/// </summary>
public interface INetworkStream : IDisposable
{

    /// <summary>
    /// Gets a value that indicates whether the <see cref="INetworkStream"/> supports reading.
    /// </summary>
    public abstract bool CanRead { get; }

    /// <summary>
    /// Gets a value that indicates whether the stream supports seeking. This property is not currently supported. This property always returns false.
    /// </summary>
    public abstract bool CanSeek { get; }

    /// <summary>
    /// Indicates whether timeout properties are usable for <see cref="INetworkStream"/>.
    /// </summary>
    public bool CanTimeout { get; }

    /// <summary>
    /// Gets a value that indicates whether the <see cref="INetworkStream"/> supports writing.
    /// </summary>
    public abstract bool CanWrite { get; }

    /// <summary>
    /// Gets a value that indicates whether data is available on the <see cref="INetworkStream"/> to be immediately read.
    /// </summary>
    public abstract bool DataAvailable { get; }

    /// <summary>
    /// Gets the length of the data available on the stream. This property is not currently supported and always throws a <see cref="NotSupportedException">.
    /// </summary>
    public long Length { get; }

    /// <summary>
    /// Gets or sets the encapsulated <see cref="NetworkStream"/>.
    /// </summary>
    public System.Net.Sockets.NetworkStream NetworkStream { get; }

    /// <summary>
    /// Gets or sets the current position in the stream. This property is not currently supported and always throws a <see cref="NotSupportedException"/>.
    /// </summary>
    public long Position { get; }

    /// <summary>
    /// Gets or sets a value that indicates whether the <see cref="INetworkStream"/> can be read.
    /// </summary>
    public bool Readable { get; set; }

    /// <summary>
    /// Gets or sets the amount of time that a read operation blocks waiting for data.
    /// </summary>
    public int ReadTimeout { get; set; }

    /// <summary>
    /// Gets the underlying <see cref="ISocket"/>.
    /// </summary>
    public ISocket Socket { get; }

    /// <summary>
    /// Gets a value that indicates whether the <see cref="INetworkStream"/> is writable.
    /// </summary>
    public bool Writeable { get; set;}

    /// <summary>
    /// Gets or sets the amount of time that a write operation blocks waiting for data.
    /// </summary>
    public int WriteTimeout { get; set; }

    /// <summary>
    /// Begins an asynchronous read from the <see cref="INetworkStream"/>.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the location in memory to store data read from the <see cref="INetworkStream"/>.</param>
    /// <param name="offset">The location in buffer to begin storing the data.</param>
    /// <param name="count">The number of bytes to read from the <see cref="INetworkStream"/>.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate that is executed when the function completes.</param>
    /// <param name="state">An object that contains any additional user-defined data.</param>
    /// <returns>An <see cref="IAsyncResult"/> that represents the asynchronous call.</returns>
    public IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);

    /// <summary>
    /// Begins an asynchronous write to a stream.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to write to the <see cref="INetworkStream"/>.</param>
    /// <param name="offset">The location in buffer to begin sending the data.</param>
    /// <param name="count">The number of bytes to write to the <see cref="INetworkStream"/>.</param>
    /// <param name="callback">The <see cref="AsyncCallback"/> delegate that is executed when the function completes.</param>
    /// <param name="state">An object that contains any additional user-defined data.</param>
    /// <returns>An <see cref="IAsyncResult"/> that represents the asynchronous call.</returns>
    public IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state);

    /// <summary>
    /// Closes the <see cref="INetworkStream"/> after waiting the specified time to allow data to be sent.
    /// </summary>
    /// <param name="timeout">The number of milliseconds to wait to send any remaining data before closing.</param>
    public void Close(int timeout);

    /// <summary>
    /// Closes the <see cref="INetworkStream"/> after waiting the specified amount of time to allow data to be sent.
    /// </summary>
    /// <param name="timeout">The amount of time to wait to send any remaining data before closing.</param>
    public void Close(TimeSpan timeout);

    /// <summary>
    /// Reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.
    /// </summary>
    /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
    public void CopyTo(Stream destination);

    /// <summary>
    /// Reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.
    /// </summary>
    /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
    /// <param name="bufferSize">The size of the buffer. This value must be greater than zero. The default size is 81920.</param>
    public void CopyTo(Stream destination, int bufferSize);

    /// <summary>
    /// Asynchronously reads the bytes from the current stream and writes them to another stream. Both streams positions are advanced by the number of bytes copied.
    /// </summary>
    /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
    /// <returns>A task that represents the asynchronous copy operation.</returns>
    public Task CopyToAsync(Stream destination);

    /// <summary>
    /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified cancellation token. Both streams positions are advanced by the number of bytes copied.
    /// </summary>
    /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous copy operation.</returns>
    public Task CopyToAsync(Stream destination, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size. Both streams positions are advanced by the number of bytes copied.
    /// </summary>
    /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
    /// <param name="bufferSize">The size of the buffer. This value must be greater than zero. The default size is 81920.</param>
    /// <returns>A task that represents the asynchronous copy operation.</returns>
    public Task CopyToAsync(Stream destination, int bufferSize);

    /// <summary>
    /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token. Both streams positions are advanced by the number of bytes copied.
    /// </summary>
    /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
    /// <param name="bufferSize">The size of the buffer. This value must be greater than zero. The default size is 81920.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous copy operation.</returns>
    public Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken);

}
