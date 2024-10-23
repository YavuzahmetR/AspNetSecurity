using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration["ConnectionStrings:SqlConString"]!; // Complete ConString can be stored in secrets.json

var sqlBuilder = new SqlConnectionStringBuilder(connectionString);  //only password(specified variables) stored in secrets.json

sqlBuilder.Password = builder.Configuration["Passwords:SqlPassword"];  //only password(specified variables) stored in secrets.json

string conString = sqlBuilder.ConnectionString; //only password(specified variables) stored in secrets.json


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
