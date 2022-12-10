
using DormitoryProject.DAL.Entities;

namespace DormitoryProject.DAL.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<Student> AddAsync(Student student);
    Task<Student> DeleteAsync(int studentId);
    Task<Student> GetAsync(int studentId);
    Task<List<Student>> GetAsync();
    Task<bool> ExistAsync(string name, string surname);
    Task<Student> UpdateAsync(Student student);
   
}
