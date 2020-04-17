using OtpClient.Enums;
using OtpClient.Modals;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OtpClient.Rest
{
    public class RestIndex
    {
        public RestIndex()
        {

        }
        ClientData _client;
        public RestIndex(ClientData client)
        {
            _client = client;

        }
        public void RestRequest<T>(string url, object data = null)
        {
            var nexUrl = ClientData.ParseUrl(_client.Url, url);
            var requestModal = RestRequestModal.Create(nexUrl, data: data);
            var client = ClientData.BeforeSend(_client);
            _client.AddHeader(headers, client);
        }
        public void RestRequest<T>(Method method, object data = null)
        {
            var requestModal = RestRequestModal.Create(_client.Url, method, data);
            var client = ClientData.BeforeSend(_client);
            _client.AddHeader(headers, client);
        }
        public void RestRequest(string url, Method method, object data = null)
        {
            var nexUrl = ClientData.ParseUrl(_client.Url, url);
            var requestModal = RestRequestModal.Create(nexUrl, method, data);
            var client = ClientData.BeforeSend(_client);
            _client.AddHeader(headers, client);


        }
        private Dictionary<string, string> headers { get; set; } = new Dictionary<string, string>();
        public void AddHeader(string key, string value)
        {
            headers.Add(key, value);
        }
        private async Task SendRequest(HttpClient client, RestRequestModal model)
        {
           await ClientData.PostAsync(client, _client.BaseUrl() + "/api/rest/FromRequest", model);
        }
    }
}
