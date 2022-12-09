using DormitoryProject.DAL.Entities;

namespace DormitoryProject.DAL.Repositories.Interfaces
{
    public interface IApplicationRepository 
    {

        Task<Application> AddAsync(Application application);

        Task<bool> ExistAsync(int announcementid, int studentid);
    }
}
