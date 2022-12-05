using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Repositories.Interfaces;

namespace DormitoryProject.BLL.Services.Implementation
{
    public interface AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public AnnouncementService(IAnnouncementRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public async Task<Student> AddAsync(string name, string surname)
        {

            // TODO : Check if student exist
            if (await _studentRepository.ExistAsync(name, surname))
            {
                throw new Exception("This user already exist");
            }

            //TODO : Save user from database
            var student = new Student
            {
                Name = name,
                Surname = surname
            };
            var result = await _studentRepository.AddAsync(student);

            //TODO : Return saved user
            return result;

        }

    }
}
