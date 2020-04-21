using Entity;
using Entity.Configs;
using Entity.Projects;
using Entity.Sms;
using Entity.ViewModal.Rest;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SendRequest
{
    public class RequestService : IRequestService
    {
        public async Task<IRestResponse> Send(string url, RestViewModal model = null)
        {
            var client = CreateClient(url, model);
            RestRequest request = CreateRequest(model);
            var result = client.Execute(request);
            return result;

        }
        public async Task<IRestResponse> Send(Config config, RestViewModal model)
        {
            var client = CreateClient(config.RequestUrl, model);
            ParseClient(config,model, client);
            var request = CreateRequest(model);
            return client.Execute(request);
        }
        public async Task<IRestResponse> Send(RestViewModal model)
        {
            RestClient client = new RestClient(model.Url);
            AddHeaders(client, model.Header);
            var request = CreateRequest(model);
            return client.Execute(request);
        }
        public async Task<IRestResponse> Send(ProjectServer server, RestViewModal model)
        {
            var client = CreateClient(server.Url, model);
            ParseServer(server, model, client);
            var request = CreateRequest(model);
            return client.Execute(request);

        }
        public async Task<IRestResponse> Send(ProjectServer server, RestViewModal model, SendModal sms)
        {
            var client = CreateClient(server.Url, model);
            ParseServer(server,  model, client);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(sms);
            return client.Execute(request);

        }
        public void ParseServer(ProjectServer server, RestViewModal model, RestClient client)
        {


        }
        public void ParseClient(Config config, RestViewModal model, RestClient client)
        {

        }
        public void AddHeaders(RestClient client, Dictionary<string, string> headers)
        {
            foreach (var i in headers)
            {
                client.AddDefaultHeader(i.Key, i.Value);
            }
        }
        public RestClient CreateClient(string url, RestViewModal viewModal)
        {
            RestClient client = new RestClient(url);
            client.Timeout = 20000;
            AddHeaders(client, viewModal.Header);
            return client;
        }
        public RestRequest CreateRequest(RestViewModal model)
        {
            RestSharp.Method method = Method.GET;
            switch (model.Method)
            {
                case Entity.Enum.Method.Post: { method = Method.POST; } break;
                case Entity.Enum.Method.Put: { method = Method.PUT; } break;
                case Entity.Enum.Method.Delete: { method = Method.DELETE; } break;
            }
            RestRequest request = new RestRequest(method);
            if (model.Data != null)
            {
               // request.AddJsonBody(model.Data);
                var postData = JsonConvert.SerializeObject(model.Data);
                byte[] data = Encoding.GetEncoding("UTF-8").GetBytes(postData);
                request.AddHeader("cache-control", "no-cache");
                request.AddParameter("application/json; charset=utf-8", data, ParameterType.RequestBody);
                request.AddJsonBody(data);
            }
            return request;
        }

    }
}
