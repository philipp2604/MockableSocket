using MockableSocket.Interfaces.Sockets;
using MockableSocket.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MockableSocket.Tcp;

namespace MockableSocket.Test.Tcp;
public class TcpClientTests
{
    [Fact]
    public void TcpClient_NoArgs_Successful()
    {
        //Arrange & Act
        var client = new MockableSocket.Tcp.TcpClient();

        //Assert
        Assert.NotNull(client.Client);
        Assert.Equal(System.Net.Sockets.SocketType.Stream, client.Client.SocketType);
        Assert.Equal(System.Net.Sockets.ProtocolType.Tcp, client.Client.ProtocolType);
    }

    [Fact]
    public void TcpClient_LocalEndPoint_Successful()
    {
        //Arrange
        var called = false;
        var endpoint = IpHelpers.CreateIPEndPoint("localhost", 1234);
        var socket = new Mock<ISocket>();
        socket.Setup(x => x.Bind(endpoint))
            .Callback(() => called = true);

        //Act
        var client = new TcpClient(endpoint, socket.Object);

        //Assert
        Assert.NotNull(client.Client);
        Assert.True(called);
    }

    [Fact]
    public void TcpClient_AddressFamily_Successful()
    {
        //Act & Assert
        var client = new TcpClient(System.Net.Sockets.AddressFamily.InterNetworkV6);

        //Assert
        Assert.NotNull(client.Client);
        Assert.Equal(System.Net.Sockets.AddressFamily.InterNetworkV6, client.Client.AddressFamily);
    }

    [Fact]
    public void TcpClient_HostnamePort_Successful()
    {
        //Arrange
        var called = false;
        var endpoint = IpHelpers.CreateIPEndPoint("127.0.0.1", 1234);
        var socket = new Mock<ISocket>();
        socket.Setup(x => x.Bind(endpoint))
            .Callback(() => called = true);

        //Act
        var client = new TcpClient(endpoint, socket.Object);

        //Assert
        Assert.NotNull(client.Client);
        Assert.True(called);
    }

    [Fact]
    public void BeginConnect_AddressPortCallbackState_Successful()
    {
        //Arrange
        var ipAddress = IPAddress.Loopback;
        var port = 1234;
        var callback = new AsyncCallback(async x => await Task.CompletedTask);
        object? obj = null;

        var called = false;

        var socket = new Mock<ISocket>();
        var client = new TcpClient(socket.Object);
        socket.Setup(x => x.BeginConnect(ipAddress, port, callback, obj))
        .Callback(() => called = true);

        //Act
        client.BeginConnect(ipAddress, port, callback, obj);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public void BeginConnect_AddressesPortCallbackState_Successful()
    {
        //Arrange
        IPAddress[] ipAddresses = { IPAddress.Loopback, IPAddress.IPv6Any };
        var port = 1234;
        var callback = new AsyncCallback(async x => await Task.CompletedTask);
        object? obj = null;

        var called = false;

        var socket = new Mock<ISocket>();
        var client = new TcpClient(socket.Object);
        socket.Setup(x => x.BeginConnect(ipAddresses, port, callback, obj))
        .Callback(() => called = true);

        //Act
        client.BeginConnect(ipAddresses, port, callback, obj);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public void BeginConnect_HostPortCallbackState_Successful()
    {
        //Arrange
        var host = "localhost";
        var port = 1234;
        var callback = new AsyncCallback(async x => await Task.CompletedTask);
        object? obj = null;

        var called = false;

        var socket = new Mock<ISocket>();
        var client = new TcpClient(socket.Object);
        socket.Setup(x => x.BeginConnect(host, port, callback, obj))
        .Callback(() => called = true);

        //Act
        client.BeginConnect(host, port, callback, obj);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public void Close_Successful()
    {
        //Arrange
        var host = "localhost";
        var port = 1234;

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.Close())
            .Callback(() => called = true);

        var client = new TcpClient(host, port, socket.Object);

        Assert.True(client.Active);

        //Act
        client.Close();
        Assert.False(client.Active);
        Assert.True(called);
    }

    [Fact]
    public void Connect_EndPoint_Successful()
    {
        //Arrange
        var endpoint = IpHelpers.CreateIPEndPoint("127.0.0.1", 1234);

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.Connect(endpoint))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        client.Connect(endpoint);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public void Connect_AddressPort_Successful()
    {
        //Arrange
        var ipAddress = IPAddress.Loopback;
        var port = 1234;

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.Connect(ipAddress, port))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        client.Connect(ipAddress, port);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public void Connect_AddressesPort_Successful()
    {
        //Arrange
        IPAddress[] ipAddresses = { IPAddress.Loopback, IPAddress.IPv6Any };
        var port = 1234;

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.Connect(ipAddresses, port))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        client.Connect(ipAddresses, port);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public void Connect_HostPort_Successful()
    {
        //Arrange
        var host = "localhost";
        var port = 1234;

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.Connect(host, port))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        client.Connect(host, port);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public async Task ConnectAsync_HostPortCancellationToken_Successful()
    {
        //Arrange
        var host = "localhost";
        var port = 1234;
        var ct = new CancellationToken();

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.ConnectAsync(host, port, ct))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        await client.ConnectAsync(host, port, ct);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public async Task ConnectAsync_AddressesPortCancellationToken_Successful()
    {
        //Arrange
        IPAddress[] ipAddresses = { IPAddress.Loopback, IPAddress.IPv6Any };
        var port = 1234;
        var ct = new CancellationToken();

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.ConnectAsync(ipAddresses, port, ct))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        await client.ConnectAsync(ipAddresses, port, ct);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public async Task ConnectAsync_AddressPortCancellationToken_Successful()
    {
        //Arrange
        var ipAddress = IPAddress.Loopback;
        var port = 1234;
        var ct = new CancellationToken();

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.ConnectAsync(ipAddress, port, ct))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        await client.ConnectAsync(ipAddress, port, ct);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public async Task ConnectAsync_HostPort_Successful()
    {
        //Arrange
        var host = "localhost";
        var port = 1234;

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.ConnectAsync(host, port))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        await client.ConnectAsync(host, port);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public async Task ConnectAsync_EndPointCancellationToken_Successful()
    {
        //Arrange
        var endpoint = IpHelpers.CreateIPEndPoint("127.0.0.1", 1234);
        var ct = new CancellationToken();

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.ConnectAsync(endpoint, ct))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        await client.ConnectAsync(endpoint, ct);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public async Task ConnectAsync_AddressesPort_Successful()
    {
        //Arrange
        IPAddress[] ipAddresses = { IPAddress.Loopback, IPAddress.IPv6Any };
        var port = 1234;

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.ConnectAsync(ipAddresses, port))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        await client.ConnectAsync(ipAddresses, port);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public async Task ConnectAsync_AddressPort_Successful()
    {
        //Arrange
        var ipAddress = IPAddress.Loopback;
        var port = 1234;

        var called = false;

        var socket = new Mock<ISocket>();
        socket.Setup(x => x.ConnectAsync(ipAddress, port))
            .Callback(() => called = true);

        var client = new TcpClient(socket.Object);

        //Act
        await client.ConnectAsync(ipAddress, port);

        //Assert
        Assert.True(called);
    }

    [Fact]
    public void EndConnect_AsyncResult_Successful()
    {
        //Arrange
        var result = new Mock<IAsyncResult>();
        object? obj = null;

        var called = false;

        var socket = new Mock<ISocket>();
        var client = new TcpClient(socket.Object);
        socket.Setup(x => x.EndConnect(result.Object))
        .Callback(() => called = true);

        //Act
        client.EndConnect(result.Object);

        //Assert
        Assert.True(called);
        Assert.True(client.Active);
    }

    //Needs custom NetworkStream
    /*
    [Fact]
    public void GetStream_Successful()
    {
    }
    */
}
