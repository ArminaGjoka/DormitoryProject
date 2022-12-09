using DormitoryProject.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {



        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService ??
                    throw new ArgumentNullException(nameof(announcementService));
        }

        //shtimi i nje announcement ne databaze

        [HttpPost("Add a new announcement")]
        public async Task<IActionResult> Create(string title, string description, int roomid)

        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                return BadRequest("Please provide the title and description for the announcement");
            }


            var createdAnnouncement = await _announcementService.AddAsync(title, description, roomid);

            return Ok(createdAnnouncement);
        }

        [HttpGet("List all active announcements")]
        public async Task<IActionResult> Get()
        {
            var result = await _announcementService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("List all active announecement for room id")]
        public async Task<IActionResult> Read(int roomId)
        {
            var result = await _announcementService.GetIdAsync(roomId);

            return Ok(result);
        }


    }
}
