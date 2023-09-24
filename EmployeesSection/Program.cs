using EmployeesSection.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();

app.Run();
