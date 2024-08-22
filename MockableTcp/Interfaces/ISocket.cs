using System.Net;
using System.Net.Sockets;

namespace MockableTcp.Interfaces;

public interface ISocket : IDisposable
{
    public int ReceiveBufferSize { get; set; }
    public int SendBufferSize { get; set; }
    public int ReceiveTimeout { get; set; }
    public int SendTimeout { get; set; }

    public void Connect(EndPoint remoteEndpoint);

    public Task ConnectAsync(IPEndPoint remoteEndpoint, CancellationToken cancellationToken = default);

    public int Send(byte[] buffer, SocketFlags socketFlags, out SocketError errorCode);

    public Task<int> SendAsync(byte[] buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default);

    public int Receive(byte[] buffer, SocketFlags socketFlags, out SocketError errorCode);

    public Task<int> ReceiveAsync(byte[] buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default);

    public void Close();
}