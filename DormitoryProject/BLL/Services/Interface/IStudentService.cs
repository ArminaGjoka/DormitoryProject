using DormitoryProject.DAL.Entities;

namespace DormitoryProject.BLL.Services.Interface
{
    public interface IStudentService
    {
        Task<Student> AddAsync(string name, string surname);
        Task<List<Student>> GetAllAsync();
    }
}
