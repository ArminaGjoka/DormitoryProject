using DormitoryProject.DAL.Entities;

namespace DormitoryProject.BLL.Services.Interface
{
    public interface IApplicationService
    {
        //The user should be able to apply to an announcement by providing
        //the announcement id and the user id
        Task<Application> AddAsync(int announcementid, int studentid);
    }
}
