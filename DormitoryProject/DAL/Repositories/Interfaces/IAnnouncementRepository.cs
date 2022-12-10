using DormitoryProject.DAL.Entities;

namespace DormitoryProject.DAL.Repositories.Interfaces
{
    public interface IAnnouncementRepository 
    {
        Task<Announcement> AddAsync(Announcement announcement);

        Task<List<Announcement>> GetAsync();

        Task<List<Announcement>> GetIdAsync(int roomId);

    }
}
