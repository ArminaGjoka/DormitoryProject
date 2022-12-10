using DormitoryProject.BLL.Services.Implementation;
using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Context;
using DormitoryProject.DAL.Entities;
using DormitoryProject.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DormitoryProject.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    public RoomController(IRoomService roomService)
    {
        _roomService = roomService ??
            throw new ArgumentNullException(nameof(roomService));
    }

    [HttpGet("Get")] 
    public async Task<IActionResult> GetRooms()
    {
        return Ok(await _roomService.GetAllAsync());

    }

    [HttpPost("Add")]
    public async Task<IActionResult> Create(string code, int capacity, int dormitoryid)

    {
        var result1 = await _roomService.AddAsync(code, capacity, dormitoryid);

        return Ok(result1);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync(int roomId)
    {
        if (roomId <= 0)
        {
            return BadRequest("Provide a valid ID");
        }
        var deletedRoom = await _roomService.DeleteAsync(roomId);
        return Ok(deletedRoom);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(int roomId, string code, int capacity, int dormitoryId, bool status)
    {
        var updatedRoom = await _roomService.UpdateAsync(roomId, code, capacity, dormitoryId, status);
        return Ok(updatedRoom);
    }
}



