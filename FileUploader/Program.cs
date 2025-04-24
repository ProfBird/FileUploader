
#define SQLITE // use SQLSERVER, MySQL or SQLITE
// After changing the database provider:
// drop the db, remove old migrations and add a new migration, update the db

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

/* Add services to the container. */
// Set up a database
#if SQLSERVER 
var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
#elif MYSQL
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#elif SQLITE
var connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
#endif

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// create a file upload folder in the web root if it doesn't already exist
var fileUploadFolder = Path.Combine(app.Environment.WebRootPath, FileHelpers.UPLOAD_FOLDER);
if (!Directory.Exists(fileUploadFolder))
{
    Directory.CreateDirectory(fileUploadFolder);
}

app.Run();
