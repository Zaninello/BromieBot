using BromieBot.API;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

builder.Services.AddScoped<IUsuario, RepositoryUserApi>();

app.Run();