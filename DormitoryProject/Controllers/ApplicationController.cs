using DormitoryProject.BLL.Services.Interface;
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

        [HttpPost("Add a new application")]
        public async Task<IActionResult> Create(int announcementid, int studentid)

        {
            if (announcementid == null || studentid == null)
            {
                return BadRequest("Please provide the announcement id and the student id for the application");
            }


            var createdApplication = await _applicationService.AddAsync(announcementid, studentid);

            return Ok(createdApplication);
        }






    }
}
