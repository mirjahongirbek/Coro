using RestSharp;
using System;

namespace SendRequest
{
    public interface IRequestService
    {
        IRestResponse Send(string url, object obj = null, Method methd = Method.GET);
    }
    public class RequestService : IRequestService
    {
        public IRestResponse Send(string url, object obj = null, Method methd = Method.GET)
        {
            RestClient client = new RestClient(url);
            client.Timeout = 20000;
            RestRequest request = null;
            if (methd == Method.GET || methd == Method.POST)
            {
               request= GetQuery(obj, methd) ;
            }
            else
            {
                request = PostRequest(obj, methd);
            }
           var result= client.Execute(request);
            return result;

        }
        public RestRequest GetQuery(object obj = null, Method methd = Method.GET)
        {
            RestRequest request = new RestRequest(Method.GET);
            return request;

        }
        public RestRequest PostRequest(object obj = null, Method method = Method.POST)
        {
            RestRequest request = new RestRequest(method);

            if (obj != null)
            {
                request.AddJsonBody(obj);
            }
            return request;
        }

    }
}
