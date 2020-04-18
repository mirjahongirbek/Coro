using System;
using System.Collections.Generic;
using Entity.Projects;
using RepositoryCore.Interfaces;

namespace Service.Interfaces
{
    public interface IProjectService : IRepositoryCore<Project, string>
    {
        void AddNewProject(Project model, string userId);
        Project AddUnauthorizePartner(KeyValuePair<string, string>? pair);
    }
}
