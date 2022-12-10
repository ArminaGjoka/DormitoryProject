using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Context;
using DormitoryProject.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Xml.Linq;

namespace DormitoryProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService ??
            throw new ArgumentNullException(nameof(studentService));
    }

    //shtimi i nje studenti ne databaze

    [HttpPost("Add")]
    public async Task<IActionResult> Create(string name, string surname)

    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
        {
            return BadRequest("Please provide all information for student");
        }


        var createdStudent = await _studentService.AddAsync(name, surname);

        return Ok(createdStudent);
    }

    [HttpGet("List")]
    public async Task<IActionResult> Get()
    {
        var result = await _studentService.GetAllAsync();

        return Ok(result);
    }

    [HttpDelete("Delete Student")]
    public async Task<IActionResult> DeleteAsync(int studentId)
    {
        if (studentId != 0)
        {
            var deletedStudents = await _studentService.DeleteAsync(studentId);
            return Ok(deletedStudents);
        }
        return BadRequest("Provide a valid ID");
    }

    [HttpPut("Update Student")]
    public async Task<IActionResult> UpdateAsync(int studentId,string name, string surname)
    {
            var updatedStudent = await _studentService.UpdateAsync(studentId,name,surname);
            return Ok(updatedStudent);
    }
}
