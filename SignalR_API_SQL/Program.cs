using Microsoft.EntityFrameworkCore;
using SignalR_API_SQL.DAL;
using SignalR_API_SQL.Hubs;
using SignalR_API_SQL.Model;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer(connectionString);
});
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

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<VisitorHub>("/VisitorHub");
});

app.MapControllers();

app.Run();
