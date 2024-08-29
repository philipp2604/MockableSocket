using MockableSocket.Interfaces.Sockets;

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
    public bool Readable { get; }

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
    public bool Writeable { get; }

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

    /// <summary>
    /// Handles the end of an asynchronous read.
    /// </summary>
    /// <param name="asyncResult">The <see cref="IAsyncResult"/> that represents the asynchronous call.</param>
    /// <returns>The number of bytes read from the <see cref="INetworkStream"/>.</returns>
    public int EndRead(IAsyncResult asyncResult);

    /// <summary>
    /// Handles the end of an asynchronous write.
    /// </summary>
    /// <param name="asyncResult">The <see cref="IAsyncResult"/> that represents the asynchronous call.</param>
    public void EndWrite(IAsyncResult asyncResult);

    /// <summary>
    /// Flushes data from the stream. This method is reserved for future use.
    /// </summary>
    public void Flush();

    /// <summary>
    /// Flushes data from the stream as an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public Task FlushAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Reads data from the <see cref="INetworkStream"/> and stores it to a byte array.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that is the location in memory to store data read from the <see cref="INetworkStream"/>.</param>
    /// <param name="offset">The location in buffer to begin storing the data to.</param>
    /// <param name="count">The number of bytes to read from the <see cref="INetworkStream"/>.</param>
    /// <returns>The number of bytes read from the <see cref="INetworkStream"/>.</returns>
    public int Read(byte[] buffer, int offset, int count);

    /// <summary>
    /// Reads data from the <see cref="INetworkStream"/> and stores it to a span of bytes in memory.
    /// </summary>
    /// <param name="buffer">A region of memory to store data read from the <see cref="INetworkStream"/>.</param>
    /// <returns>The number of bytes read from the <see cref="INetworkStream"/>.</returns>
    public int Read(Span<byte> buffer);

    /// <summary>
    /// Reads data from the <see cref="INetworkStream"/> and stores it to a specified range of a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="buffer">The buffer to write the data into.</param>
    /// <param name="offset">The location in buffer to begin storing the data to.</param>
    /// <param name="count">The number of bytes to read from the <see cref="INetworkStream"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);

    /// <summary>
    /// Reads data from the <see cref="INetworkStream"/> and stores it in a byte memory range as an asynchronous operation.
    /// </summary>
    /// <param name="buffer">The buffer to write the data to.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Reads a <see cref="byte"/> from the <see cref="INetworkStream"/> and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
    /// </summary>
    /// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
    public unsafe int ReadByte();

    /// <summary>
    /// Sets the current position of the stream to the given value. This method is not currently supported and always throws a <see cref="NotSupportedException"/>.
    /// </summary>
    /// <param name="offset">This parameter is not used.</param>
    /// <param name="origin">This parameter is not used.</param>
    /// <returns>The position in the stream.</returns>
    public long Seek(long offset, SeekOrigin origin);

    /// <summary>
    /// Sets the length of the stream. This method always throws a <see cref="NotSupportedException"/>.
    /// </summary>
    /// <param name="value">This parameter is not used.</param>
    public void SetLength(long value);

    /// <summary>
    /// Writes data to the <see cref="INetworkStream"/> from a specified range of a byte array.
    /// </summary>
    /// <param name="buffer">An array of type <see cref="byte"/> that contains the data to write to the <see cref="INetworkStream"/>.</param>
    /// <param name="offset">The location in buffer from which to start writing data.</param>
    /// <param name="count">The number of bytes to write to the <see cref="INetworkStream"/>.</param>
    public void Write(byte[] buffer, int offset, int count);

    /// <summary>
    /// Writes data to the <see cref="INetworkStream"/> from a read-only byte span.
    /// </summary>
    /// <param name="buffer">The data to write to the <see cref="INetworkStream"/>.</param>
    public void Write(ReadOnlySpan<byte> buffer);

    /// <summary>
    /// Writes data to the <see cref="INetworkStream"/> from the specified range of a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="buffer">A <see cref="byte"/> array that contains the data to write to the <see cref="INetworkStream"/>.</param>
    /// <param name="offset">The location in buffer from which to start writing data.</param>
    /// <param name="count">The number of bytes to write to the <see cref="INetworkStream"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);

    /// <summary>
    /// Writes data to the <see cref="INetworkStream"/> from a read-only memory byte memory range as an asynchronous operation.
    /// </summary>
    /// <param name="buffer">The region of memory to write data from.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Writes a byte to the current position in the stream and advances the position within the stream by one byte.
    /// </summary>
    /// <param name="value">The byte to write to the stream.</param>
    public unsafe void WriteByte(byte value);
}