using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Entities;
using DormitoryProject.DAL.Repositories.Interfaces;

namespace DormitoryProject.BLL.Services.Implementation
{
    public class ApplicationService : IApplicationService
    {

        private readonly IApplicationRepository _applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository ?? throw new ArgumentNullException(nameof(applicationRepository));
        }


        /*  Do not allow more than one active announcement per dormitory => If exist in database (Check) */
        public async Task<Application> AddAsync(int announcementid, int studentid)
        {
            //TO-DO  as part of the task, the user should ensure appropriate validation
            //The announcement id is required and it exits
            //The user id is required and it exits
            //The user should be able to apply for a certain announcement only once
            // The user should not be possible to apply to a disabled announcement

            if (await _applicationRepository.ExistAsync(announcementid, studentid))

            { throw new Exception("This announcement already exists!"); }

            //TODO : Save application in database
            var application = new Application
            {
                AnnouncementId = announcementid,
                StudentId = studentid,
                ApplicationDate = DateTime.Now,
                IsActive = true

            };
            var result = await _applicationRepository.AddAsync(application);

            //TODO : Return saved application
            return result;
        }
    }
}
