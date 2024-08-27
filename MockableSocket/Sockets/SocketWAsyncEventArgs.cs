using MockableSocket.Interfaces.Sockets;
using System.Net;
using System.Net.Sockets;

namespace MockableSocket.Sockets;

/// <summary>
/// Wrapper for <see cref="SocketAsyncEventArgs"/> for use with <see cref="ISocket"/>.
/// </summary>
public class SocketWAsyncEventArgs : EventArgs, ISocketAsyncEventArgs
{
    private SocketW? _acceptSock;
    private SocketW? _connectSock;
    private bool _disposed;

    /// <summary>
    /// Creates a new instance of <see cref="SocketWAsyncEventArgs"/>.
    /// </summary>
    public SocketWAsyncEventArgs() : this(unsafeSuppressExecutionContextFlow: false)
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketWAsyncEventArgs"/> with an existing instance of <see cref="SocketAsyncEventArgs"/> to encapsulate.
    /// </summary>
    /// <param name="eventArgs">An instance of <see cref="SocketAsyncEventArgs"/> to encapsulate.</param>
    public SocketWAsyncEventArgs(SocketAsyncEventArgs eventArgs)
    {
        EventArgs = eventArgs;
        EventArgs.Completed += OnEncapsulatedCompleted;
    }

    /// <summary>
    /// Creates a new instance of <see cref="SocketWAsyncEventArgs"/>.
    /// </summary>
    /// <param name="unsafeSuppressExecutionContextFlow">
    /// Whether to disable the capturing and flow of ExecutionContext. ExecutionContext flow should only
    /// be disabled if it's going to be handled by higher layers.
    /// </param>
    public SocketWAsyncEventArgs(bool unsafeSuppressExecutionContextFlow)
    {
        EventArgs = new SocketAsyncEventArgs(unsafeSuppressExecutionContextFlow);
        EventArgs.Completed += OnEncapsulatedCompleted;
    }

    /// <inheritdoc/>
    public SocketAsyncEventArgs EventArgs { get; set; }

    /// <inheritdoc/>
    public SocketW? AcceptSocket
    {
        get
        {
            if (EventArgs.AcceptSocket != null)
            {
                if (_acceptSock?.Socket != EventArgs.AcceptSocket)
                    _acceptSock = new SocketW(EventArgs.AcceptSocket);
            }
            else
            {
                _acceptSock = null;
            }

            return _acceptSock;
        }
        set
        {
            _acceptSock = value;
            EventArgs.AcceptSocket = _acceptSock?.Socket;
        }
    }

    /// <inheritdoc/>
    public SocketW? ConnectSocket
    {
        get
        {
            if (EventArgs.ConnectSocket != null)
            {
                if (_connectSock?.Socket != EventArgs.ConnectSocket)
                    _connectSock = new SocketW(EventArgs.ConnectSocket);
            }
            else
            {
                _acceptSock = null;
            }

            return _acceptSock;
        }
    }

    /// <inheritdoc/>
    public byte[]? Buffer => EventArgs.Buffer;

    /// <inheritdoc/>
    public Memory<byte> MemoryBuffer => EventArgs.MemoryBuffer;

    /// <inheritdoc/>
    public int Offset => EventArgs.Offset;

    /// <inheritdoc/>
    public int Count => EventArgs.Count;

    /// <inheritdoc/>
    public TransmitFileOptions SendPacketsFlags { get => EventArgs.SendPacketsFlags; set => EventArgs.SendPacketsFlags = value; }

    /// <inheritdoc/>
    public IList<ArraySegment<byte>>? BufferList { get => EventArgs.BufferList; set => EventArgs.BufferList = value; }

    /// <inheritdoc/>
    public int BytesTransferred => EventArgs.BytesTransferred;

    /// <inheritdoc/>
    public event EventHandler<SocketWAsyncEventArgs>? Completed;

    /// <inheritdoc/>
    public bool DisconnectReuseSocket { get => EventArgs.DisconnectReuseSocket; set => EventArgs.DisconnectReuseSocket = value; }

    /// <inheritdoc/>
    public SocketAsyncOperation LastOperation => EventArgs.LastOperation;

    /// <inheritdoc/>
    public IPPacketInformation ReceiveMessageFromPacketInfo => EventArgs.ReceiveMessageFromPacketInfo;

    /// <inheritdoc/>
    public EndPoint? RemoteEndPoint { get => EventArgs.RemoteEndPoint; set => EventArgs.RemoteEndPoint = value; }

    /// <inheritdoc/>
    public SendPacketsElement[]? SendPacketsElements { get => EventArgs.SendPacketsElements; set => EventArgs.SendPacketsElements = value; }

    /// <inheritdoc/>
    public int SendPacketsSendSize { get => EventArgs.SendPacketsSendSize; set => EventArgs.SendPacketsSendSize = value; }

    /// <inheritdoc/>
    public SocketError SocketError { get => EventArgs.SocketError; set => EventArgs.SocketError = value; }

    /// <inheritdoc/>
    public Exception? ConnectByNameError => EventArgs.ConnectByNameError;

    /// <inheritdoc/>
    public SocketFlags SocketFlags { get => EventArgs.SocketFlags; set => EventArgs.SocketFlags = value; }

    /// <inheritdoc/>
    public object? UserToken { get => EventArgs.UserToken; set => EventArgs.UserToken = value; }

    /// <inheritdoc/>
    public void SetBuffer(int offset, int count)
    {
        EventArgs.SetBuffer(offset, count);
    }

    /// <inheritdoc/>
    public void SetBuffer(byte[]? buffer, int offset, int count)
    {
        EventArgs.SetBuffer(buffer, offset, count);
    }

    /// <inheritdoc/>
    public void SetBuffer(Memory<byte> buffer)
    {
        EventArgs.SetBuffer(buffer);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            EventArgs.Dispose();
            _connectSock?.Dispose();
            _acceptSock?.Dispose();

            _disposed = true;

            GC.SuppressFinalize(this);
        }
    }

    private void OnEncapsulatedCompleted(object? sender, SocketAsyncEventArgs e)
    {
        Completed?.Invoke(sender, new SocketWAsyncEventArgs(e));
    }

    ~SocketWAsyncEventArgs()
    {
        if (!Environment.HasShutdownStarted)
        {
            EventArgs.Dispose();
            _connectSock?.Dispose();
            _acceptSock?.Dispose();
        }
    }
}