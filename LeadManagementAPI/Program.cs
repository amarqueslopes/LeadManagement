using LeadManagementAPI.Context;
using LeadManagementAPI.Repositories.Interfaces;
using LeadManagementAPI.Repositories;
using LeadManagementAPI.Services.Interfaces;
using LeadManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddDbContext<LeadContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
