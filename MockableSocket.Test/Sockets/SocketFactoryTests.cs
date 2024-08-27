using MockableSocket.Interfaces;
using MockableSocket.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MockableSocket.Test.Sockets;
public class SocketFactoryTests
{
    [Fact]
    public void CreateSocket_WithFamily_ValidParameters_NoThrow()
    {
        //Arrange
        var addressFamily = AddressFamily.InterNetwork;
        var socketType = SocketType.Stream;
        var protocolType = ProtocolType.Tcp;

        var socketFactory = new SocketFactory();

        //Act
        var socket = socketFactory.CreateSocket(addressFamily, socketType, protocolType);


        //Assert
        Assert.NotNull(socket);
        Assert.Equal(socket.AddressFamily, addressFamily);
        Assert.Equal(socket.SocketType, socketType);
        Assert.Equal(socket.ProtocolType, protocolType);

        socket.Close();
    }


    [Fact]
    public void CreateSocket_WithoutFamily_ValidParameters_NoThrow()
    {
        //Arrange
        var socketType = SocketType.Stream;
        var protocolType = ProtocolType.Tcp;


        var socketFactory = new SocketFactory();

        //Act
        var socket = socketFactory.CreateSocket(null, socketType, protocolType);


        //Assert
        Assert.NotNull(socket);
        Assert.Equal(socket.SocketType, socketType);
        Assert.Equal(socket.ProtocolType, protocolType);

        socket.Close();
    }
}