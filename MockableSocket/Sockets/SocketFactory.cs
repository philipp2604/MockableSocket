using MockableSocket.Interfaces.Sockets;
using System.Net.Sockets;

namespace MockableSocket.Sockets;

/// <summary>
/// Implements ISocketFactory.
/// </summary>
public class SocketFactory : ISocketFactory
{
    /// <inheritdoc/>
    public ISocket CreateSocket(AddressFamily? addressFamily, SocketType socketType, ProtocolType protocolType)
    {
        ArgumentNullException.ThrowIfNull(socketType, nameof(socketType));
        ArgumentNullException.ThrowIfNull(protocolType, nameof(protocolType));

        return addressFamily != null ? new SocketW((AddressFamily)addressFamily, socketType, protocolType) : new SocketW(socketType, protocolType);
    }
}