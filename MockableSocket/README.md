# MockableSocket
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) [![build and test](https://github.com/philipp2604/MockableSocket/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/philipp2604/MockableSocket/actions/workflows/build-and-test.yml) ![GitHub Release](https://img.shields.io/github/v/release/philipp2604/MockableSocket) [![NuGet Version](https://img.shields.io/nuget/v/philipp2604.MockableSocket)](https://www.nuget.org/packages/philipp2604.MockableSocket/)




## Description 
This library aims to provide mockable classes for socket communication in .Net Core.

**This library is still WIP and not complete yet.**

**A lot of the functionality has not been tested yet!**

## Implementations
Right now, the following interfaces and classes are implemented:
* `INetworkStream` with `NetworkStreamW` as a replacement for `NetworkStream`
* `ISocket` with `SocketW` as a replacement for `Socket`
* `ISocketAsyncEventArgs` as a replacement for `SocketAsyncEventArgs`

Additional wrappers:
* `ITcpClient` with `TcpClient` as a replacement for the standard .Net `TcpClient`

## Download
You can acquire this library either directly via the NuGet package manager or by downloading it from the [NuGet Gallery](https://www.nuget.org/packages/philipp2604.MockableSocket/).

## Questions? Problems?
**Feel free to reach out!**

## Ideas / TODO
* Wrappers, like TcpClient... ?

## Credit
This library is using a lot of code from Microsoft's `System.Net.Sockets` namespace, it's sole purpose is to enable easier mocking.

## License
This library is [MIT licensed](https://github.com/philipp2604/MockableSocket/blob/master/LICENSE.txt).