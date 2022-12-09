using DormitoryProject.DAL.Context;
using DormitoryProject.DAL.Entities;
using DormitoryProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DormitoryProject.DAL.Repositories.Implementation
{
    public class ApplicationRepository : IApplicationRepository

    {
        protected DormitoryContext _context;
        public ApplicationRepository(DormitoryContext context) //kjo vjen nga Database Dependency tek Program.cs
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //The user should be able to apply to an announcement by
        //providing the announcement id and the user id
        public async Task<Application> AddAsync(Application application)
        {
            var result = await _context.Applications.AddAsync(application);
            _ = await _context.SaveChangesAsync();

            return result.Entity;

        }

        //TO-DO  as part of the task, the user should ensure appropriate validation
        //The announcement id is required and it exits
        //The user id is required and it exits
      
        // The user should not be possible to apply to a disabled announcement
        public async Task<bool> ExistAsync(int announcementid, int studentid)
        {
            var result = await _context.Applications.AnyAsync(s => s.AnnouncementId == announcementid
                && s.StudentId == studentid);

            return result;
        }
        //The user should be able to apply for a certain announcement only once

        //public async Task<bool> StudentExistAsync(int announcementid, int studentid)
        //{
        //    var result = await _context.Applications.ContainsAsync(s => s.AnnouncementId == announcementid
        //        && s.StudentId == studentid);

        //    return result;
        //}

    }
}
