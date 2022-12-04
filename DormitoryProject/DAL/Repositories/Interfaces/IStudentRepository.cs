﻿using DormitoryProject.Models;

namespace DormitoryProject.DAL.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<Student> AddAsync(Student student);
    Task<Student> UpdateAsync(Student student);
    Task<Student> DeleteAsync(int studentId);
    Task<Student> GetAsync(int studentId);
    Task<List<Student>> GetAsync();
}