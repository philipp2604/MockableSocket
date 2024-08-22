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
}