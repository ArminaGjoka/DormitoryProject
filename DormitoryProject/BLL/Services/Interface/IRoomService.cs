using DormitoryProject.DAL.Entities;

namespace DormitoryProject.BLL.Services.Interface;

public interface IRoomService
{
    Task<Room> AddAsync(string code, int capacity, int dormitoryId);
    Task<List<Room>> GetAllAsync();
    Task<Room> UpdateAsync(int roomId, string code, int capacity,int dormitoryId,bool status);
    Task<Room> DeleteAsync(int roomId);
   

}
