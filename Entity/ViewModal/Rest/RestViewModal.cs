using Entity.Enum;
using System.Collections.Generic;


namespace Entity.ViewModal.Rest
{
   public  class RestViewModal
    {
        public string Url { get; set; }
        public Method Method { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public Dictionary<string, string> Header { get; set; } = new Dictionary<string, string>();
    }
}
