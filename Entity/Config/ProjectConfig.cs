using Entity.Projects;
using RepositoryCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Entity.Configs
{
    public class ProjectConfig:IEntity<string>
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public DateTime DateTime { get; set; }
        public List<ProjectServer> ProjectServers { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
}
