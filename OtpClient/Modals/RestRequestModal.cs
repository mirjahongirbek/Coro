using Newtonsoft.Json;
using OtpClient.Enums;
using System;
using System.Collections.Generic;

namespace OtpClient.Modals
{
    public class RestRequestModal
    {
        public static RestRequestModal Create(string url, Method method= Method.Get, object data= null)
        {
            RestRequestModal modal = new RestRequestModal();
            modal.Url = url;
            modal.Method = method;
            try
            {
                if (data != null)
                {
                    var serialize = JsonConvert.SerializeObject(data);
                    modal.Data= JsonConvert.DeserializeObject<Dictionary<string, object>>(serialize);

                }
            }catch(Exception ext)
            {

            }
            return modal;
            
        }
        public string Url { get; set; }
        public Method Method { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public Dictionary<string, string> Header { get; set; }
    }

}
