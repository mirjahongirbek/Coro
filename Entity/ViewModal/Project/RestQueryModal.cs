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
    }
}
