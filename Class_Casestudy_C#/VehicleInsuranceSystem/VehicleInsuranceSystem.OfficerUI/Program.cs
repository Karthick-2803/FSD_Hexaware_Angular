using VehicleInsuranceSystem.OfficerUI.Controllers;
using VehicleInsuranceSystem.OfficerUI.Models;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddControllersWithViews();

// Cookie-based authentication
builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", options =>
    {
        options.LoginPath = "/Officer/Login";
        options.AccessDeniedPath = "/Officer/Login";
    });

// Register HttpClient for API calls
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Authentication before Authorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Officer}/{action=Login}/{id?}");

app.Run();
