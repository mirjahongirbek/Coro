using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OtpClient
{

    public class ClientData
    {
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public static HttpClient BeforeSend(ClientData clientData)
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            HttpClient client = new HttpClient(handler);
            AddHaeader(clientData, client);

            return client;
        }
        public static void AddHaeader(ClientData clientData, HttpClient client)
        {
            clientData.AddHeader(clientData.Headers, client);
        }
        public void AddHeader(Dictionary<string, string> header, HttpClient client)
        {
            foreach (var i in header)
            {
                client.DefaultRequestHeaders.Add(i.Key, i.Value);
            }

        }
        public string BaseUrl()
        {
            return "";
        }
        public string Url { get; set; }
        public static string ParseUrl(params string[] url)
        {

        }
        #region
        public static async Task<HttpResponseMessage> DeleteAsync(HttpClient client, string url)
        {
            var response = await client.DeleteAsync(url);
            return response;
        }
        public static async Task<HttpResponseMessage> GetAsync(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            return response;
        }
        public static async Task<HttpResponseMessage> PostAsync(HttpClient client, string url, object model = null)
        {
            if (model == null)
            {

            }
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
            return result;
        }
        #endregion
    }
    public class Client : IClient
    {
        private ClientData _clientData;
        public Client(string url, string projectName, string password)
        {
            _clientData = new ClientData();


        }
        public OtpIndex Message { get; }

        public void AddHeader(string key, string value)
        {
            _clientData.Headers.Add(key, value);
        }

        public int Timer { get; set; } = 20000;

    }
    public interface IClient
    {
        void AddHeader(string key, string value);
        int Timer { get; set; }
    }
}
