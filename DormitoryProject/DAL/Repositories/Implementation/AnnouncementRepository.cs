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

    }
}
