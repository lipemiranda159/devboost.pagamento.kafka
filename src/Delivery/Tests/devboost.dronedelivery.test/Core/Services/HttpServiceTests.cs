using devboost.dronedelivery.core.domain.Interfaces;
using devboost.dronedelivery.core.services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace devboost.dronedelivery.test.Core.Services
{
    public class HttpServiceTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var client = new HttpService();
            Assert.True(client != null);
            var client2 = new HttpService(true);
            Assert.True(client2 != null);

        }

        [Fact]
        public void SetBaseAddress()
        {
            var httpService = new HttpService();
            httpService.SetBaseAddress("http://www.api.com");
            Assert.True(httpService != null);
        }
    }
}
