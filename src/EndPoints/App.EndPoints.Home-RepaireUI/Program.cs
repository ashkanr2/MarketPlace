using App.Domain.Core.DataAccess;
using App.Infrastructures.Data.Repositories.AutoMapper;
using App.Infrastructures.Data.Repositories.DataAccess.Ripository;
using App.Infrastructures.Db.SqlServer.Ef.DataBase;
using App.Domain.AppService.Admins;
using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using App.Domain.Core.Entities;
using Microsoft.CodeAnalysis.Options;
using App.Domain.Core.AppServices.Admin;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarketPlaceDb>(option =>
{
    option.UseSqlServer("Data Source=ASHKANR2-PC2017\\ASHKAN_MAKTAB;Initial Catalog=MarketPlaceDb;TrustServerCertificate=True;Integrated Security=True;");
});
// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<MarketPlaceDb>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddIdentityCore<AppUser>()
//    .AddUserManager<UserManager<AppUser>>()
//    .AddEntityFrameworkStores<MarketPlaceDb>();


//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddIdentity<AppUser, IdentityRole<int>>(
    Options =>
    {
        Options.SignIn.RequireConfirmedAccount = false;
        Options.SignIn.RequireConfirmedEmail = false;
        Options.SignIn.RequireConfirmedPhoneNumber = false;
       

        Options.Password.RequireDigit = false;
        Options.Password.RequireLowercase = false;
        Options.Password.RequireNonAlphanumeric = false;
        Options.Password.RequireUppercase = false;
        Options.Password.RequiredLength = 5;
        Options.Password.RequiredUniqueChars = 1;


    })
    .AddEntityFrameworkStores<MarketPlaceDb>();



builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();



builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapping)));

builder.Services.AddScoped<IAppUserRipositry, AppUserRipository>();
builder.Services.AddScoped<IBoothAppservice, BoothAppservice>();
builder.Services.AddScoped<IBoothRipository, BoothRipository>();
builder.Services.AddScoped<ICommentRipository, CommentRipository>();
builder.Services.AddScoped<ICommentAppservice, CommentAppservice>();
builder.Services.AddScoped<IAllProductRepository, AllProductRepository>();
builder.Services.AddScoped<IALLProductAppservice, ALLProductAppservice>();
builder.Services.AddScoped<IProductRipository, ProductRipository>();
builder.Services.AddScoped<IProductAppservice, ProductAppservice>();
builder.Services.AddScoped<IAuctionRipository,AuctionRepository>();
builder.Services.AddScoped<IAuctionAppservice, AuctionAppservice>();
builder.Services.AddScoped<IOrderRipository, OrderRipository>();
builder.Services.AddScoped<IOrderAppservice, OrderAppservice>();
builder.Services.AddRazorPages(); 
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Seller",
    pattern: "Seller/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
