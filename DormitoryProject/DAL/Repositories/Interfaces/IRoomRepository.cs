﻿using DormitoryProject.DAL.Entities;

namespace DormitoryProject.DAL.Repositories.Interfaces;

public interface IRoomRepository
{
    Task<Room> AddAsync(Room room);
    Task<Room> UpdateAsync(Room room);
    Task<Room> DeleteAsync(int roomId);
    Task<Room> GetAsync(int roomId);
    Task<List<Room>> GetAsync();
    Task<bool> ExistAsync(int Id);
}
