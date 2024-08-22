using MockableTcp.Interfaces;
using System.Net.Sockets;

namespace MockableTcp.Sockets;

/// <summary>
/// Implements ISocketFactory.
/// </summary>
public class SocketFactory : ISocketFactory
{
    /// <inheritdoc/>
    public ISocket CreateSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
    {
        return new SocketWrapper(addressFamily, socketType, protocolType);
    }

    /// <inheritdoc/>
    public ISocket CreateSocket(SocketType socketType, ProtocolType protocolType)
    {
        return new SocketWrapper(socketType, protocolType);
    }
}