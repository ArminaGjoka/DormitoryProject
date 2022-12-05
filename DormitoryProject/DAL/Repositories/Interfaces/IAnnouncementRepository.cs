using DormitoryProject.DAL.Entities;

namespace DormitoryProject.DAL.Repositories.Interfaces
{
    public interface IAnnouncementRepository 
    {
        Task<Announcement> AddAsync(Announcement announcement);



    }
}
