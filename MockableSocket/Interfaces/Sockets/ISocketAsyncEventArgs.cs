using MockableSocket.Sockets;
using System.Net;
using System.Net.Sockets;

namespace MockableSocket.Interfaces.Sockets;

public interface ISocketAsyncEventArgs : IDisposable
{
    /// <summary>
    /// The encapsulated <see cref="SocketAsyncEventArgs"/> instance.
    /// </summary>
    public SocketAsyncEventArgs EventArgs { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="AcceptSocket"/>.
    /// </summary>
    public SocketW? AcceptSocket { get; set; }

    /// <summary>
    /// Gets the <see cref="ConnectSocket"/>.
    /// </summary>
    public SocketW? ConnectSocket { get; }

    /// <summary>
    /// Gets the <see cref="Buffer"/>.
    /// </summary>
    public byte[]? Buffer { get; }

    /// <summary>
    /// Gets the <see cref="MemoryBuffer"/>.
    /// </summary>
    public Memory<byte> MemoryBuffer { get; }

    /// <summary>
    /// Gets the <see cref="Offset"/>.
    /// </summary>
    public int Offset { get; }

    /// <summary>
    /// Gets the <see cref="Count"/>.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Gets or sets the <see cref="SendPacketsFlags"/>.
    /// </summary>
    public TransmitFileOptions SendPacketsFlags { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="BufferList"/>.
    /// </summary>
    public IList<ArraySegment<byte>>? BufferList { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="BytesTransferred"/>.
    /// </summary>
    public int BytesTransferred { get; }

    /// <summary>
    /// The event used to complete an asynchronous operation.
    /// </summary>
    public event EventHandler<SocketWAsyncEventArgs>? Completed;

    /// <summary>
    /// Gets or sets the <see cref="DisconnectReuseSocket"/>.
    /// </summary>
    public bool DisconnectReuseSocket { get; set; }

    /// <summary>
    /// Gets the <see cref="LastOperation"/>.
    /// </summary>
    public SocketAsyncOperation LastOperation { get; }

    /// <summary>
    /// Gets the <see cref="ReceiveMessageFromPacketInfo"/>.
    /// </summary>
    public IPPacketInformation ReceiveMessageFromPacketInfo { get; }

    /// <summary>
    /// Gets or sets the <see cref="RemoteEndPoint"/>.
    /// </summary>
    public EndPoint? RemoteEndPoint { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="SendPacketsElements"/>.
    /// </summary>
    public SendPacketsElement[]? SendPacketsElements { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="SendPacketsSendSize"/>.
    /// </summary>
    public int SendPacketsSendSize { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="SocketError"/>.
    /// </summary>
    public SocketError SocketError { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="ConnectByNameError"/>.
    /// </summary>
    public Exception? ConnectByNameError { get; }

    /// <summary>
    /// Gets or sets the <see cref="SocketFlags"/>.
    /// </summary>
    public SocketFlags SocketFlags { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="UserToken"/>.
    /// </summary>
    public object? UserToken { get; set; }

    /// <summary>
    /// Initializes the data buffer to use with an asynchronous socket method.
    /// </summary>
    /// <param name="offset">The offset, in bytes, in the data buffer where the operation starts.</param>
    /// <param name="count">The maximum amount of data, in bytes, to send or receive in the buffer.</param>
    public void SetBuffer(int offset, int count);

    /// <summary>
    /// Initializes the data buffer to use with an asynchronous socket method.
    /// </summary>
    /// <param name="buffer">The data buffer to use with an asynchronous socket method.</param>
    /// <param name="offset">The offset, in bytes, in the data buffer where the operation starts.</param>
    /// <param name="count">The maximum amount of data, in bytes, to send or receive in the buffer.</param>
    public void SetBuffer(byte[]? buffer, int offset, int count);

    /// <summary>
    /// Initializes the data buffer to use with an asynchronous socket method.
    /// </summary>
    /// <param name="buffer">The region of memory to use as a buffer with an asynchronous socket method.</param>
    public void SetBuffer(Memory<byte> buffer);
}