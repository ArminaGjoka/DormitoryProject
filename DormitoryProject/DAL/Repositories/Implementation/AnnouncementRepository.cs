using DormitoryProject.DAL.Context;
using DormitoryProject.DAL.Entities;
using DormitoryProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DormitoryProject.DAL.Repositories.Implementation
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        protected DormitoryContext _context;

        public AnnouncementRepository(DormitoryContext context) //kjo vjen nga Database Dependency tek Program.cs
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Announcement> AddAsync(Announcement announcement)
        {
            var result = await _context.Announcements.AddAsync(announcement);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> ExistAsync(int announcementId)
        {
            var result = await _context.Announcements
                 .AnyAsync(s => s.Id==announcementId && s.IsActive == true);
      
            return result;
        }

        //Listo te gjithe announcements aktive:
        public async Task<List<Announcement>> GetAsync()
        {
            var result = await _context.Announcements
                .Where(s => s.IsActive == true)
                .ToListAsync();
            return result;
        }

        public async Task<List<Announcement>> GetIdAsync(int roomId)
        {
            var result = await _context.Announcements
                .Where(s => s.RoomId == roomId && s.IsActive == true)
                .ToListAsync();

            return result;
        }


    }
}
