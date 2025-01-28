using Microsoft.EntityFrameworkCore;
using WishComeTrue.Common.Entity;
using WishComeTrue.DAL;
using WishComeTrue.DAL.Interfaces;
using WishComeTrue.DAL.Repositories;
using WishComeTrue.Service.Implementations;
using WishComeTrue.Service.Interfaces;

var builder = WebApplication.CreateBuilder();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IBaseRepository<WishEntity>, WishesRepository>();
builder.Services.AddScoped<IWishService, WishService>();
builder.Services.AddScoped<IBaseRepository<CategoryEntity>, CategoriesRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
