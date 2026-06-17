using LiquidLabsDemo.API.Helpers;
using LiquidLabsDemo.ApiManager.Service;
using LiquidLabsDemo.BL.DependencyServices;
using LiquidLabsDemo.Repository.DBServices;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IHttpService, HttpService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ExternalUrl:PostApiUrl"]?? "");
});

builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>(sp =>
{
    var connectionString =builder.Configuration.GetConnectionString("DefaultConnection");
    return new DbConnectionFactory(connectionString);

});

builder.Services.AddPostInfrastructureServices();
var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
