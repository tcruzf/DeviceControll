using ControllRR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ControllRR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ControllRR.Application.Interfaces;
using ControllRR.Application.Services;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Repositories;
using ControllRR.Infrastructure.Data.Seeding;
using ControllRR.Infrastructure.Services;



var builder = WebApplication.CreateBuilder(args);

// Adicionar o DbContext com MySQL
builder.Services.AddDbContext<ControllRRContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("stringconn"),
        new MySqlServerVersion(new Version(8, 0, 32)))); // Versão do  MySQL

// Injeção de Mapper
builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddAutoMapper(typeof(DeviceMappingProfile));
builder.Services.AddAutoMapper(typeof(MaintenanceMappingProfile));
builder.Services.AddAutoMapper(typeof(SectorMappingProfile));
builder.Services.AddAutoMapper(typeof(DocumentMappingProfile));
// Injeção de dependencias
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();
builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();


//optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedingService.Initialize(services);
}

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
