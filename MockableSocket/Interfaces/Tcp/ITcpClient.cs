using MockableSocket.Interfaces.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MockableSocket.Interfaces.NetworkStream;

namespace MockableSocket.Interfaces.Tcp;

/// <summary>
/// An interface providing TCP services, compatible to <see cref="System.Net.Sockets.TcpClient"/>.
/// </summary>
public interface ITcpClient : IDisposable
{
    public bool Active { get; }

    /// <summary>
    /// Gets the connection state of the most recent operations.
    /// </summary>
    public bool Connected { get; }

    /// <summary>
    /// The underlying <see cref="ISocket"/>.
    /// </summary>
    public ISocket Client { get; set; }

    /// <summary>
    /// Gets or sets whether only one client is allowed to use a port.
    /// </summary>
    public bool ExclusiveAddressUse { get; set; }

    /// <summary>
    /// Gets or sets information about the linger state of the underlying <see cref="ISocket"/>.
    /// </summary>
    public LingerOption? LingerState { get; set; }

    /// <summary>
    /// Gets or sets whether a delay shall be disabled when the send or receive buffers are not full.
    /// </summary>
    public bool NoDelay { get; set; }

    /// <summary>
    /// Gets or sets the size of the receive buffer.
    /// </summary>
    public int ReceiveBufferSize { get; set; }

    /// <summary>
    /// Gets or sets the amount of time in milliseconds, the <see cref="ISocket"/> will wait to receive data once a receiving operation is initiated.
    /// </summary>
    public int ReceiveTimeout { get; set; }

    /// <summary>
    /// Gets or sets the size of the send buffer.
    /// </summary>
    public int SendBufferSize { get; set; }

    /// <summary>
    /// Gets or sets the amount of time in milliseconds, the <see cref="ISocket"/> will wait to send data once a sending operation is initiated.
    /// </summary>
    public int SendTimeout { get; set; }

    /// <summary>
    /// Begins an asynchronous request for a remote host connection. The remote host is specified by an <see cref="IPAddress"/> and a port number.
    /// </summary>
    /// <param name="address">The <see cref="IPAddress"/> of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <param name="requestCallback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
    /// <param name="state">A user-defined object that contains information about the connect operation. This object is passed to the requestCallback delegate when the operation is complete.</param>
    /// <returns>An <see cref="IAsyncResult"/> object that references the asynchronous connection.</returns>
    public IAsyncResult BeginConnect(IPAddress address, int port, AsyncCallback? requestCallback, object? state);

    /// <summary>
    /// Begins an asynchronous request for a remote host connection. The remote host is specified by an <see cref="IPAddress"/> array and a port number.
    /// </summary>
    /// <param name="addresses">At least one <see cref="IPAddress"/> that designates the remote hosts.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <param name="requestCallback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
    /// <param name="state">A user-defined object that contains information about the connect operation. This object is passed to the requestCallback delegate when the operation is complete.</param>
    public IAsyncResult BeginConnect(IPAddress[] addresses, int port, AsyncCallback? requestCallback, object? state);

    /// <summary>
    /// Begins an asynchronous request for a remote host connection. The remote host is specified by a host name and a port number.
    /// </summary>
    /// <param name="host">The name of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <param name="requestCallback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
    /// <param name="state">A user-defined object that contains information about the connect operation. This object is passed to the requestCallback delegate when the operation is complete.</param>
    public IAsyncResult BeginConnect(string host, int port, AsyncCallback? requestCallback, object? state);

    /// <summary>
    /// Disconnects the underlying socket and closes it.
    /// </summary>
    public void Close();

    /// <summary>
    /// Connects the client to a remote TCP host using the specified remote network <see cref="IPEndPoint"/>.
    /// </summary>
    /// <param name="remoteEndPoint">The <see cref="IPEndPoint"/> to which you intend to connect.</param>
    public void Connect(IPEndPoint remoteEndPoint);

    /// <summary>
    /// Connects the client to a remote TCP host using the specified <see cref="IPAddress"/> and port number.
    /// </summary>
    /// <param name="address">The <see cref="IPAddress"/> of the host to which you intend to connect.</param>
    /// <param name="port">The port number to which you intend to connect.</param>
    public void Connect(IPAddress address, int port);

    /// <summary>
    /// Connects the client to a remote TCP host using the specified <see cref="IPAddress"/>es and port number.
    /// </summary>
    /// <param name="addresses">The <see cref="IPAddress"/> array of the host to which you intend to connect.</param>
    /// <param name="port">The port number to which you intend to connect.</param>
    public void Connect(IPAddress[] addresses, int port);

    /// <summary>
    /// Connects the client to the specified port on the specified host.
    /// </summary>
    /// <param name="host">The DNS name of the remote host to which you intend to connect.</param>
    /// <param name="port">The port number of the remote host to which you intend to connect.</param>
    public void Connect(string host, int port);

    /// <summary>
    /// Connects the client to the specified TCP port on the specified host as an asynchronous operation.
    /// </summary>
    /// <param name="host">The DNS name of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to signal the asynchronous operation should be canceled.</param>
    /// <returns>A task that represents the asynchronous connection operation.</returns>
    public ValueTask ConnectAsync(string host, int port, CancellationToken cancellationToken);

    /// <summary>
    /// Connects the client to a remote TCP host using the specified IP addresses and port number as an asynchronous operation.
    /// </summary>
    /// <param name="addresses">The array of <see cref="IPAddress"/> of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to signal the asynchronous operation should be canceled.</param>
    /// <returns>A task that represents the asynchronous connection operation.</returns>
    public ValueTask ConnectAsync(IPAddress[] addresses, int port, CancellationToken cancellationToken);

    /// <summary>
    /// Connects the client to a remote TCP host using the specified <see cref="IPAddress"/> and port number as an asynchronous operation.
    /// </summary>
    /// <param name="address">The <see cref="IPAddress"/> of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to signal the asynchronous operation should be canceled.</param>
    /// <returns>A task that represents the asynchronous connection operation.</returns>
    public ValueTask ConnectAsync(IPAddress address, int port, CancellationToken cancellationToken);

    /// <summary>
    /// Connects the client to the specified TCP port on the specified host as an asynchronous operation.
    /// </summary>
    /// <param name="host">The DNS name of the remote host to which you intend to connect.</param>
    /// <param name="port">The port number of the remote host to which you intend to connect.</param>
    /// <returns>A task that represents the asynchronous connection operation.</returns>
    public Task ConnectAsync(string host, int port);

    /// <summary>
    /// Connects the client to a remote TCP host using the specified <see cref="IPEndPoint"/> as an asynchronous operation.
    /// </summary>
    /// <param name="remoteEP">The <see cref="IPEndPoint"/> to which you intend to connect.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to signal the asynchronous operation should be canceled.</param>
    /// <returns>A task that represents the asynchronous connection operation.</returns>
    public ValueTask ConnectAsync(IPEndPoint remoteEP, CancellationToken cancellationToken);

    /// <summary>
    /// Connects the client to a remote TCP host using the specified IP addresses and port number as an asynchronous operation.
    /// </summary>
    /// <param name="addresses">The array of <see cref="IPAddress"/> of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <returns>A task that represents the asynchronous connection operation.</returns>
    public Task ConnectAsync(IPAddress[] addresses, int port);

    /// <summary>
    /// Connects the client to a remote TCP host using the specified <see cref="IPAddress"/> and port number as an asynchronous operation.
    /// </summary>
    /// <param name="address">The <see cref="IPAddress"/> of the remote host.</param>
    /// <param name="port">The port number of the remote host.</param>
    /// <returns>A task that represents the asynchronous connection operation.</returns>
    public Task ConnectAsync(IPAddress address, int port);

    /// <summary>
    /// Ends a pending asynchronous connection attempt.
    /// </summary>
    /// <param name="asyncResult">An <see cref="IAsyncResult"/> object returned by a call to BeginConnect.</param>
    public void EndConnect(IAsyncResult asyncResult);

    /// <summary>
    /// Returns the <see cref="NetworkStream"/> used to send and receive data.
    /// </summary>
    /// <returns>The underlying <see cref="NetworkStream"/>.</returns>
    public INetworkStream GetStream();
}
