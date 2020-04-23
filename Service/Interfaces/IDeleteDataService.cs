
using Entity.Db;
using RepositoryCore.Interfaces;

namespace Service.Interfaces
{
    public interface IDeleteDataService: IRepositoryCore<DeleteData, string>
    {
        void DeleteData(object data, Entity.Enum.Services service);
    }
}
