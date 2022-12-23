using AM.ApplicationCore.Interfaces;
using AM.Infrastructure;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddControllersWithViews();
//Injection Depondances
builder.Services.AddDbContext<DbContext, AMContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICagnotteService, CagnotteService>();
builder.Services.AddScoped<IEntrepriseService, EntrepriseService>();
//builder.Services.AddScoped<IParticipantService, IParticipantService>();

builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));
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
