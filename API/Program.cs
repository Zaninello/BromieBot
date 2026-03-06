using API;
using BromieBot.API;
using DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<TelegramBotContext>();
builder.Services.AddScoped<RepositoryUserApi>();
builder.Services.AddScoped<ServiceUserApi>();
builder.Services.AddScoped<RepositoryTodoApi>();
builder.Services.AddScoped<ServiceTodoApi>();
var app = builder.Build();
app.MapControllers();
app.Run();