using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

    options.AddPolicy("AllowSpecifiedSites", builder =>
    {
        builder.WithOrigins("https://localhost:7001/","https://www.mysite.com").AllowAnyHeader().
        AllowAnyMethod();
    });
    
    options.AddPolicy("AllowSitesWithSpecifiedHeader", builder =>
    {
        builder.WithOrigins("https://www.mysite.com").WithHeaders(HeaderNames.ContentType, "x-custom-header");
    });

    options.AddPolicy("AllowSubDomains", builder =>
    {
        builder.WithOrigins("https://*example.com").SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyHeader().AllowAnyMethod();
    });


    options.AddPolicy("AllowMethods", builder =>
    {
        builder.WithOrigins("https://localhost:7001").WithMethods("GET", "POST").AllowAnyHeader();
        //Cors method property must be empty if policies defined for methods and controllers
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(); //AllowSubDomains - AllowSitesWithSpecifiedHeader - AllowSpecifiedSites

app.UseAuthorization();

app.MapControllers();

app.Run();
