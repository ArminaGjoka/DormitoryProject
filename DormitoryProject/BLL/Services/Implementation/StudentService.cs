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
      
        //Check if student exist
        if( await _studentRepository.ExistAsync(name, surname))
        {
            throw new Exception("This user already exist");
        }

        //Save user from database
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
        // Get existing student
        var existingStudent = await _studentRepository.GetAsync(studentId);

        if (existingStudent == null)
        {
            throw new Exception("Student do not exist");
        }

        existingStudent.Name = name;
        existingStudent.Surname = surname;

        var result = await _studentRepository.UpdateAsync(existingStudent);

        //Return saved user
        return result;
     
    }

}
