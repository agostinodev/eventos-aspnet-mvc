using Eventos.Data.Db;
using Microsoft.EntityFrameworkCore;
using Eventos.Data.Repositorios;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("EventosWebContext") 
    ?? throw new InvalidOperationException("Connection string 'EventosWebContext' not found.");

builder.Services.AddDbContext<EventosContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IEventoRepository, EventoRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
