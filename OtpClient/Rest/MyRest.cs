using OtpClient.Enums;
using OtpClient.Modals;

namespace OtpClient.Rest
{
    public class MyRest
    {
        public string BaseUrl { get; set; }
        public MyRest()
        {

        } 
        public MyRest(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
       public void Request(Method method, object data=null)
        {
            //var requestModal = RestRequestModal.Create(BaseUrl, data: data);
            //var client = ClientData.BeforeSend(_client);
            //_client.AddHeader(headers, client);
        }
        public void Request(string url, Method method, object data = null)
        {

        }

        
    }
}
