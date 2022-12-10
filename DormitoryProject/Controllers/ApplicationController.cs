using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {

        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService ??
                        throw new ArgumentNullException(nameof(applicationService));
        }

        //shtimi i nje application ne databaze

        [HttpPost("Add")]
        public async Task<IActionResult> Create(int announcementid, int studentid)
        {
            if (announcementid <= 0)
            {
                return BadRequest("Please provide the announcement id and the student id for the application");
            }
            if (studentid <= 0) // ne kontroller kontrollohet a eshte shkruar mire, ne Service kontrollohet a ekziston
            {
                return BadRequest("Please provide the student id and the student id for the application");
            }

            var createdApplication = await _applicationService.AddAsync(announcementid, studentid);

            return Ok(createdApplication);
        }

        [HttpGet("List")]
        public async Task<IActionResult> Get()
        {
            var result = await _applicationService.GetAsync();

            return Ok(result);
        }







    }
}
