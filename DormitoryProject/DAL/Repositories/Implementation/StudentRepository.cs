using DormitoryProject.DAL.Context;
using DormitoryProject.DAL.Entities;
using DormitoryProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DormitoryProject.DAL.Repositories.Implementation;
public class StudentRepository : IStudentRepository
{
    protected DormitoryContext _context;

    public StudentRepository(DormitoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Student> AddAsync(Student student)
    {
        var result = await _context.Students.AddAsync(student);
        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }
    public async Task<Student> UpdateAsync(Student student)
    {
        
        var result = _context.Students.Update(student);

        _ = await _context.SaveChangesAsync();

        return result.Entity;

    }
    public async Task<Student> DeleteAsync(int studentId)
    {
        
        var entity = await GetAsync(studentId);

        var result = _context.Students.Remove(entity);

        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }
    public async Task<bool> ExistAsync(string name, string surname)
    {
        var result = await _context.Students.AnyAsync(s => s.Name == name
            && s.Surname == surname);

        return result;
    }
    public async Task<bool> ExistAsync(int studentId)
    {
        var result = await _context.Students.AnyAsync(s => s.Id == studentId);

        return result;
    }

    public async Task<Student> GetAsync(int studentId)
    {
        var result = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
        return result;
    }
    public async Task<List<Student>> GetAsync()
    {
        var result = await _context.Students.ToListAsync();
        return result;
    }
}