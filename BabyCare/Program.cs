using BabyCare.DataAccess.Settings;
using BabyCare.Services.AboutServices;
using BabyCare.Services.ContactServices;
using BabyCare.Services.EventServices;
using BabyCare.Services.IHeroServices;
using BabyCare.Services.IImageServices;
using BabyCare.Services.InstructorServices;
using BabyCare.Services.ProductServices;
using BabyCare.Services.ServiceServices;
using BabyCare.Services.TestimonialServices;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().
    AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IServiceServices, ServiceServices>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();

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
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
