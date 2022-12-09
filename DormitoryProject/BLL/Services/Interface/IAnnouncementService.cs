using DormitoryProject.DAL.Entities;

namespace DormitoryProject.BLL.Services.Interface
{
    public interface IAnnouncementService
    {
        Task<Announcement> AddAsync(string title, string description, int roomId);

        Task<List<Announcement>> GetAllAsync();

        Task<List<Announcement>> GetIdAsync(int roomId);

    }
}
