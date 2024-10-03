using Microsoft.EntityFrameworkCore;
using MouseTracker.Models;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Mouse/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mouse}/{action=Index}/{id?}");


app.Run();