using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Entities;
using DormitoryProject.DAL.Repositories.Interfaces;

namespace DormitoryProject.BLL.Services.Implementation
{
    public class ApplicationService : IApplicationService
    {

        private readonly IApplicationRepository _applicationRepository;
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IStudentRepository _studentRepository;
        public ApplicationService(IApplicationRepository applicationRepository, IAnnouncementRepository announcementRepository, IStudentRepository studentRepository)
        {
            _applicationRepository = applicationRepository ?? throw new ArgumentNullException(nameof(applicationRepository));
            _announcementRepository = announcementRepository ?? throw new ArgumentNullException(nameof(announcementRepository));
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }


        /*  Do not allow more than one active announcement per dormitory => If exist in database (Check) */
        public async Task<Application> AddAsync(int announcementid, int studentid)
        {

            bool studentExist = await _studentRepository.ExistAsync(studentid);
            if (!studentExist)
            {
                throw new Exception("Student dont exist");
            }

            bool announcementExist = await _announcementRepository.ExistAsync(announcementid);
            if (!announcementExist)
            {
                throw new Exception("Announcement dont exist or is not active");
            }

            if (await _applicationRepository.ExistAsync(announcementid, studentid))

            { throw new Exception("An application for this student already exists!"); }

            // Save application in database
            var application = new Application
            {
                AnnouncementId = announcementid,
                StudentId = studentid,
                ApplicationDate = DateTime.Now,
                IsActive = true

            };
            var result = await _applicationRepository.AddAsync(application);

            // Return saved application
            return result;
        }

        public async Task<List<Application>> GetAsync()
        {
            var result = await _applicationRepository.GetAsync();
            return result;
        }
    }
}
