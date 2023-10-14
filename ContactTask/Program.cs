using ContactTask.Models;
using ContactTask.Services.Contract;
using ContactTask.Services.implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// configire SQL
builder.Services.AddDbContext<AppDbContext>
    (a => a.UseSqlServer(builder.Configuration.GetConnectionString("DefouitConection")));

// obj life cycle 
builder.Services.AddScoped<IContactService, ContactService>();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





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
    pattern: "{controller=Contact}/{action=login}/{id?}");

app.Run();
