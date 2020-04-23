using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ViewModal.Project
{
 public   class RestQueryModal
    {
        public string ProjectId { get; set; }
        public string ServiceId { get; set; }
        public DateTime From { get; set; }
        public DateTime End { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
    public class RestQueryResponse<T>
    {
        public int Count { get; set; }
        public int Limit { get; set; }
        public List<T> List { get; set; }
    }
}
