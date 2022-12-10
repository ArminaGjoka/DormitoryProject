using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Repositories.Interfaces;
using DormitoryProject.DAL.Entities;

namespace DormitoryProject.BLL.Services.Implementation
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository ?? throw new ArgumentNullException(nameof(announcementRepository));
        }


        /*  Do not allow more than one active announcement per dormitory => If exist in database (Check) */
        public async Task<Announcement> AddAsync(string title, string description, int roomid)
        {
            // TODO : Check if announcement exist
            //if (await _announcementRepository.ExistAsync(title, description))
            // {
            //     throw new Exception("This announcement already exist");
            // }

            //TODO : Save announcement in database
            var announcement = new Announcement
            {
                Title = title,
                Description = description,
                PublishedDate = DateTime.Now,
                RoomId = roomid,
                IsActive = true

            };
            var result = await _announcementRepository.AddAsync(announcement);

            //TODO : Return saved user
            return result;
        }

        public async Task<List<Announcement>> GetAllAsync()
        {
            var result = await _announcementRepository.GetAsync();
            return result;
        }

        public async Task<List<Announcement>> GetIdAsync(int roomId)
        {
            var result = await _announcementRepository.GetIdAsync(roomId);

            return result;
        }

    }
}
