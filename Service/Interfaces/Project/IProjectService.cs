using System;
using Entity.Projects;
using RepositoryCore.Interfaces;

namespace Service.Interfaces
{
    public interface IProjectService : IRepositoryCore<Project, string>
    {
        void AddNewProject(Project model, string userId);
    }
}
