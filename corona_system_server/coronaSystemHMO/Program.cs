using coronaSystemHMO_BL;
using coronaSystemHMO_DAL;
using coronaSystemHMO_DAL.Models;
using coronaSystemHMO_DTO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddScoped<IMemberDAL, MemberDAL>();
builder.Services.AddScoped<IMemberBL, MemberBL>();
builder.Services.AddScoped<IVaccineDAL, VaccineDAL>();
builder.Services.AddScoped<IVaccineBL, VaccineBL>();


builder.Services.AddDbContext<coronaSystemHMO_DBContext>(options =>
    options.UseSqlServer("Server=DESKTOP-H37566O\\MSSQLSERVER01;Database=coronaSystemHMO_DB;Trusted_Connection=True;"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyAllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
