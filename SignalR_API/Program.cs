
using Microsoft.EntityFrameworkCore;
using SignalR_API.DAL;
using SignalR_API.Hubs;
using SignalR_API.Model;

namespace SignalR_API
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt =>
            opt.UseNpgsql(Configuration.ConnectionString));
            builder.Services.AddControllers();
            builder.Services.AddScoped<VisitorService>();
            builder.Services.AddSignalR();
            builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .SetIsOriginAllowed((host) => true)
                           .AllowCredentials();
                }));
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
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
       
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<VisitorHub>("/VisitorHub");
            });

            app.MapControllers();

            app.Run();
        }
    }
}
