using AccessDataLayer;
using AccessDataLayer.Repository;
using BusinessLayer.UserLogic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var AllowOrigins = "_allowOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(config => config.UseSqlServer(builder.Configuration.GetConnectionString("UsersConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserLogic, UserLogic>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowOrigins, policy =>
    {
        policy.WithOrigins("*");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
