using DormitoryProject.BLL.Services.Implementation;
using DormitoryProject.BLL.Services.Interface;
using DormitoryProject.DAL.Context;
using DormitoryProject.DAL.Repositories.Implementation;
using DormitoryProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DormitoryProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add database dependency
            _ = builder.Services.AddDbContext<DormitoryContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("Group1Connection")));

            //zevendeso interface-in me implementimin 
            builder.Services.AddScoped<IStudentRepository,StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();
          
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();  
            builder.Services.AddScoped<IRoomService, RoomService>();

           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}