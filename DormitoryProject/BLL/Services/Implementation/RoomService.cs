using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Entities;
using DormitoryProject.DAL.Repositories.Implementation;
using DormitoryProject.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DormitoryProject.BLL.Services.Implementation;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

    public async Task<Room> AddAsync(string code, int capacity, int dormitoryId)
    {

        var room = new Room
        {
            Code = code,
            Capacity = capacity,
            DormitoryId = dormitoryId,
            Status = true

        };
        var result = await _roomRepository.AddAsync(room);

        return result;
    }

    public async Task<List<Room>> GetAllAsync()
    {
        var result = await _roomRepository.GetAsync();
        return result;
    }

    public async Task<Room> DeleteAsync(int roomId)
    {
        var roomDelete = await _roomRepository.DeleteAsync(roomId);

        return roomDelete;

    }
    public async Task<Room> UpdateAsync(int roomId, string code, int capacity, int dormitoryId, bool status)
    {
        var roomUpdate = new Room
        {
            Id = roomId,
            Code = code,
            Capacity = capacity,
            DormitoryId = dormitoryId,
            Status = status

        };

        var result = await _roomRepository.UpdateAsync(roomUpdate);

        //TODO : Return saved user
        return result;
    }
}
