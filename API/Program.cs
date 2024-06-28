using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder de configuracao do database com SQLITE
builder.Services.AddDbContext<AppDataContext>(options => 
    options.UseSqlite("Data Source=ApiDataBase.db;Cache=shared"));
builder.Services.AddControllers();
//CORS
builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();


app.Run();

