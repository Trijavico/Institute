using Institute.BLL.Contracts;
using Institute.BLL.Services;
using Institute.DAL.Context;
using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Context

builder.Services.AddDbContext<InstituteContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("InstituteContext")));

builder.Services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));


// Repositories

builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

// Services

builder.Services.AddTransient<IProfessorService, ProfessorService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();