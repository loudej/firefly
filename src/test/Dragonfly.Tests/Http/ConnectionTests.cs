﻿using Xunit;

namespace Dragonfly.Tests.Http
{
    public class ConnectionTests : ConnectionTestsBase
    {
        [Fact]
        public void ConnectionClassCanBeTested()
        {
            Connection.Execute();

            Assert.Equal(true, Socket.ReceivePaused);
            Socket.Add("GET / HTTP/1.1\r\n");
            Socket.Add("Host: localhost\r\n");
            Socket.Add("Connection: close\r\n");
            Socket.Add("\r\n");

            Assert.Equal("HTTP/1.1 200 OK\r\n\r\n", Socket.Output);
        }
    }
}
