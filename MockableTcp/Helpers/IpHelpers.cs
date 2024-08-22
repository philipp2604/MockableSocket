using System.Net;
using System.Text.RegularExpressions;

namespace MockableTcp;

/// <summary>
/// Helpers around ip addresses.
/// </summary>
public static partial class IpHelpers
{
    [GeneratedRegex(@"(([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])")]
    private static partial Regex Ipv4Regex();

    [GeneratedRegex(@"((([0-9a-fA-F]){1,4})\:){7}([0-9a-fA-F]){1,4}")]
    private static partial Regex Ipv6Regex();

    /// <summary>
    /// Checks if a string is a valid ipv4 or ipv6 address.
    /// </summary>
    /// <param name="ip">The string to check for containing a valid ip address.</param>
    /// <returns>A bool, true if the string is a valid ip address, otherwise false.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool IsIpAddress(string ip)
    {
        ArgumentNullException.ThrowIfNull(ip, nameof(ip));

        var isIpv4 = Ipv4Regex().IsMatch(ip);
        var isIpv6 = Ipv6Regex().IsMatch(ip);

        return isIpv4 || isIpv6;
    }

    /// <summary>
    /// Creates an <see cref="IPEndPoint"></see> asynchronously.
    /// </summary>
    /// <param name="host">Host string.</param>
    /// <param name="port">Port number.</param>
    /// <returns>A task that represents the asynchronous operation.<br/>The task's result contains the created <see cref="IPEndPoint"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static async Task<IPEndPoint> CreateIPEndPointAsync(string host, int port)
    {
        ArgumentException.ThrowIfNullOrEmpty(host, nameof(host));
        ArgumentNullException.ThrowIfNull(port, nameof(port));
        ArgumentOutOfRangeException.ThrowIfNegative(port, nameof(port));

        IPAddress? ipAddress;
        if (IpHelpers.IsIpAddress(host))
        {
            ipAddress = IPAddress.Parse(host);
        }
        else
        {
            IPAddress[] addresses;
            try
            {
                addresses = await Dns.GetHostAddressesAsync(host);
            }
            catch
            {
                throw new ArgumentException("Could not resolve host.", nameof(host));
            }

            ipAddress = addresses == null || addresses.Length == 0
                ? throw new ArgumentException("Could not resolve host.", nameof(host))
                : addresses[0];
        }

        return ipAddress != null
            ? new IPEndPoint(ipAddress, port)
            : throw new ArgumentException("Could not identify parameter as valid ip address or hostname.", nameof(host));
    }

    /// <summary>
    /// Creates an <see cref="IPEndPoint"></see>.
    /// </summary>
    /// <param name="host">Host string.</param>
    /// <param name="port">Port number.</param>
    /// <returns>The created <see cref="IPEndPoint"/></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static IPEndPoint CreateIPEndPoint(string host, int port)
    {
        ArgumentException.ThrowIfNullOrEmpty(host, nameof(host));
        ArgumentNullException.ThrowIfNull(port, nameof(port));
        ArgumentOutOfRangeException.ThrowIfNegative(port, nameof(port));

        IPAddress? ipAddress;
        if (IpHelpers.IsIpAddress(host))
        {
            ipAddress = IPAddress.Parse(host);
        }
        else
        {
            IPAddress[] addresses;
            try
            {
                addresses = Dns.GetHostAddresses(host);
            }
            catch
            {
                throw new ArgumentException("Could not resolve host.", nameof(host));
            }

            ipAddress = addresses == null || addresses.Length == 0
                ? throw new ArgumentException("Could not resolve host.", nameof(host))
                : addresses[0];
        }

        return ipAddress != null
            ? new IPEndPoint(ipAddress, port)
            : throw new ArgumentException("Could not identify parameter as valid ip address or hostname.", nameof(host));
    }
}