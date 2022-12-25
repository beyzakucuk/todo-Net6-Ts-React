using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using toDoApi.DataAccess;
using toDoApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Add services to the container.

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<PostgreContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(y => y.AddPolicy("my-policy", y => y.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

builder.Services.AddScoped<IDataAccessProvider<Todo>, TodoAccessProvider>();
builder.Services.AddScoped<IDataAccessProvider<User>, UserAccessProvider>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("my-policy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();