using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder de configuracao do database com SQLITE
builder.Services.AddDbContext<AppDataContext>(options => 
    options.UseSqlite("Data Source=ApiDataBase.db;Cache=shared"));
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

