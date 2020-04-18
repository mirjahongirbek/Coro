using Newtonsoft.Json;
using OtpClient.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ProjectConfig Config
        {
            get; set;
        }
        public string BaseUrl()
        {
            var proto = Url.Split(new string[] { "://" }, 2, StringSplitOptions.None)[0];
            if (Url.Contains(@"://"))
                Url = Url.Split(new string[] { "://" }, 2, StringSplitOptions.None)[1];

            return proto + "://" + Url.Split('/')[0] + "/";
        }
        public string Url { get; set; }
        public static string parse(string Url)
        {
            var proto = Url.Split(new string[] { "://" }, 2, StringSplitOptions.None)[0];
            if (Url.Contains(@"://"))
                Url = Url.Split(new string[] { "://" }, 2, StringSplitOptions.None)[1];

            return proto + "://" + Url.Split('/')[0]+"/";
        }
        public static string ParseUrl(params string[] url)
        {
            string result = "";
            
            if (!url[0].Contains("://"))
            {
            //TODO do in future
            }
           return string.Join("", url.ToArray());
           
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
}
