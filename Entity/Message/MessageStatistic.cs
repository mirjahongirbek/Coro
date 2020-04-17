using RepositoryCore.Interfaces;
using System.Collections.Generic;

namespace Entity.Message
{
    public class MessageStatistic:IEntity<string>
    {
        public string Id { get; set; }
        public string Day { get; set; }
        public List<PartnerStatistic> PartnerStatistics { get; set; }
        
    }

   
}
