using System.Net.Sockets;

namespace MockableTcp.Interfaces;

public interface ISocketFactory
{
    /// <summary>
    /// Creates a new socket.
    /// </summary>
    /// <param name="addressFamily">Optionally: the address family.</param>
    /// <param name="socketType">The socket type.</param>
    /// <param name="protocolType">The protocol type.</param>
    /// <returns>A new instance of SocketWrapper, implementing ISocket</returns>
    public ISocket CreateSocket(AddressFamily? addressFamily, SocketType socketType, ProtocolType protocolType);
}