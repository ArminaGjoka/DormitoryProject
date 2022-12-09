using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Entities;
using DormitoryProject.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DormitoryProject.BLL.Services.Implementation;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
    }

    public async Task<Student> AddAsync(string name, string surname)
    {
      
        // TODO : Check if student exist
        if( await _studentRepository.ExistAsync(name, surname))
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

    public async Task<List<Student>> GetAllAsync()
    {
        var result = await _studentRepository.GetAsync();
        return result;
    }

    public async Task<Student> DeleteAsync(int studentId)
    {
        var studentDelete = await _studentRepository.DeleteAsync(studentId);
      
        return studentDelete;

    }
    public async Task<Student> UpdateAsync(int studentId, string name, string surname)
    {
        var studentUpdate = new Student
        {
            Id= studentId,
            Name = name,
            Surname = surname
        };

        var result = await _studentRepository.UpdateAsync(studentUpdate);

        //TODO : Return saved user
        return result;
     
    }

}
