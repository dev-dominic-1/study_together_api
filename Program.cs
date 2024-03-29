using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using study_together_api.Data;
using Microsoft.Extensions.DependencyInjection;
using study_together_api.Filters;

var builder = WebApplication.CreateBuilder(args);
var CorsOrigins = "_CorsOrigins";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(config => 
{
    config.Filters.Add(typeof(ExceptionHandler));
}).AddJsonOptions(options => 
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsOrigins, policy => policy.WithOrigins("http://localhost:8080"));
});

builder.Services.AddDbContext<DataContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(CorsOrigins);

// app.UseAuthorization();

app.MapControllers();

app.Run();
