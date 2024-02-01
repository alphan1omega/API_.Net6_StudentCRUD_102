using APIEntryDtls.Controllers;
using APIEntryDtls.Helper;
using APIEntryDtls.AppData;
using APIEntryDtls.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IEntry, EntryService>();
//builder.Services.AddScoped<IEntry, EntryService>();
builder.Services.AddDbContext<DummyContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Connection1")));
builder.Services.AddAutoMapper(typeof(AutoMapperProf).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

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
