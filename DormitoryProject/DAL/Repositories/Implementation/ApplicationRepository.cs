using DormitoryProject.DAL.Context;
using DormitoryProject.DAL.Entities;
using DormitoryProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DormitoryProject.DAL.Repositories.Implementation
{
    public class ApplicationRepository : IApplicationRepository

    {
        protected DormitoryContext _context;
        public ApplicationRepository(DormitoryContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Application> AddAsync(Application application)
        {
            var result = await _context.Applications.AddAsync(application);
            _ = await _context.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<bool> ExistAsync(int announcementid, int studentid)
        {
            var result = await _context.Applications
                .AnyAsync(s => s.AnnouncementId == announcementid
                && s.StudentId == studentid);

            return result;
        }       
        public async Task<List<Application>> GetAsync()
        {
            var result = await _context.Applications.Where(s => s.IsActive == true).ToListAsync();
            return result;

        }

    }
}
