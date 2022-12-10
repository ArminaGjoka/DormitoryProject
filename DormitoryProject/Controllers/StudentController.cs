using DormitoryProject.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

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

    [HttpDelete("Delete/{studentId}")]
    public async Task<IActionResult> DeleteAsync(int studentId)
    {
        if (studentId <= 0)
        {
            return BadRequest("Provide a valid ID");
        }

        var deletedStudents = await _studentService.DeleteAsync(studentId);
        return Ok(deletedStudents);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(int studentId,string name, string surname)
    {
            var updatedStudent = await _studentService.UpdateAsync(studentId,name,surname);
            return Ok(updatedStudent);
    }
}
