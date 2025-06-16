var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
//builder.Services.AddControllersWithViews();

var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //To enable attribute based routing
    endpoints.MapControllers();
});
app.Run();
