using DormitoryProject.Models;

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

            /*   Adding
               The user should be able to add an announcement to the database.Additionally, 
               as part of the task, the user should ensure appropriate validation 
              -The title is required
              - The description is required
              - Do not allow more than one active announcement per dormitory
           If incorrect data are entered, the user should be notified via an appropriate message*/

            using (DormitoryContext context = new DormitoryContext())
            {

                var std = new Student()
                {
                    Name = "Bill"
                };

                context.Students.Add(std);
                context.SaveChanges();
            }


        }
    }
}       
