using DormitoryProject.DAL.Context;
using DormitoryProject.DAL.Entities;
using DormitoryProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DormitoryProject.DAL.Repositories.Implementation;

public class RoomRepository : IRoomRepository
{
    protected DormitoryContext _context;

    public RoomRepository(DormitoryContext context) 
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Room> AddAsync(Room room)
    {
        var result = await _context.Rooms.AddAsync(room);
        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }
    public async Task<Room> DeleteAsync(int roomId)
    {
        var entity = await GetAsync(roomId);

        var result = _context.Rooms.Remove(entity);

        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> ExistAsync(int Id)
    {
        var result = await _context.Rooms.AnyAsync(s => s.Id == Id);

        return result;
    }

    public async Task<Room> GetAsync(int roomId)
    {
        var result = await _context.Rooms.FirstOrDefaultAsync(s => s.Id == roomId);
        return result;
    }

    public async Task<List<Room>> GetAsync()
    {
        var result = await _context.Rooms.ToListAsync();
        return result;
    }

    public async Task<Room> UpdateAsync(Room room)
    {
        var result = _context.Rooms.Update(room);
        _ = await _context.SaveChangesAsync();
        return result.Entity;
    }
}
