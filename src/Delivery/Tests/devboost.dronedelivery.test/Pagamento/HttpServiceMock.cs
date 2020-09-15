using devboost.dronedelivery.core.services;
using System.Net.Http;
using System.Threading.Tasks;

namespace devboost.dronedelivery.test
{
    public class HttpServiceMock : HttpService
    {
        public override async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }

        public override void SetBaseAddress(string url)
        {
        }
    }
}
