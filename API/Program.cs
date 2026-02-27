using BromieBot.API;
using DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<RepositoryUserApi>();
builder.Services.AddScoped<ServiceUserApi>();
builder.Services.AddScoped<TelegramBotContext>();
var app = builder.Build();
app.MapControllers();
app.Run();