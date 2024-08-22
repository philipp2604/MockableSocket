using System.Net;

namespace MockableTcp.Test.Helpers;

public class IpHelpersTests
{
    [Fact]
    public void IsIpAddress_ValidIpv4Address_ReturnsTrue()
    {
        //Arrange
        var addresses = new List<string>
        {
            "01.102.103.104",
            "1.2.3.4"
        };

        //Act
        foreach (var address in addresses)
        {
            var isValid = IpHelpers.IsIpAddress(address);
            //Assert
            Assert.True(isValid);
        }

    }

    [Fact]
    public void IsIpAddress_ValidIpv6Address_ReturnsTrue()
    {
        //Arrange
        var addresses = new List<string>
        {
            "2001:db8:3333:4444:5555:6666:7777:8888",
            "2001:db8:3333:4444:CCCC:DDDD:EEEE:FFFF",
            "2001:0db8:0001:0000:0000:0ab9:C0A8:0102"
        };

        //Act
        foreach (var address in addresses)
        {
            var isValid = IpHelpers.IsIpAddress(address);
            //Assert
            Assert.True(isValid);
        }
    }

    [Fact]
    public void IsIpAddress_ArgumentIsNull_Throws()
    {
        //Arrange
        string? address = null;

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => { IpHelpers.IsIpAddress(address!); });
    }

    [Fact]
    public void IsIpAddress_InValidAddress_ReturnsFalse()
    {
        //Arrange
        var addresses = new List<string>
        {
            "1.2.3",
            "3333:4444:CCCC:DDDD:EEEE:FFFF",
            "hello"
        };

        //Act
        foreach (var address in addresses)
        {
            var isValid = IpHelpers.IsIpAddress(address);
            //Assert
            Assert.False(isValid);
        }
    }

    [Fact]
    public void CreateIPEndPoint_ValidArguments_ReturnsEndpoint()
    {
        //Arrange
        var address = "127.0.0.1";
        var port = 123;

        //Act
        var endpoint = IpHelpers.CreateIPEndPoint(address, port);

        //Assert
        Assert.NotNull(endpoint);
        Assert.Equal(endpoint.Port, port);
        Assert.Equal(endpoint.Address.ToString(), address);
    }

    [Fact]
    public void CreateIPEndPoint_HostIsNull_Throws()
    {
        //Arrange
        string? address = null;
        var port = 123;

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() =>  IpHelpers.CreateIPEndPoint(address!, port));
    }

    [Fact]
    public void CreateIPEndPoint_HostIsEmpty_Throws()
    {
        //Arrange
        var address = "";
        var port = 123;

        //Act & Assert
        Assert.Throws<ArgumentException>(() => IpHelpers.CreateIPEndPoint(address!, port));
    }

    [Fact]
    public void CreateIPEndPoint_PortIsInvalid_Throws()
    {
        //Arrange
        var address = "127.0.0.1";
        var port = -1;

        //Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => IpHelpers.CreateIPEndPoint(address, port));
    }

    [Fact]
    public void CreateIPEndPoint_HostIsInvalid_Throws()
    {
        //Arrange
        var address = "hello";
        var port = 123;

        //Act & Assert
        Assert.Throws<ArgumentException>(() => IpHelpers.CreateIPEndPoint(address, port));
    }
}