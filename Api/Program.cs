using Api.configuration;
using Api.hub;
using Manager.implementation;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
var CorsPolicy = "_CorsPolicy";

// Add services to the container.
builder.Services.UseDataBaseConfig(builder.Configuration);
builder.Services.UseAutoMapperConfig();
builder.Services.UseDependecyInjection();
builder.Services.AddJwtConfuguration(builder.Configuration);
builder.Services.AddSignalR();
builder.Services.AddSingleton<IUserIdProvider, PersonagemProvider>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        //.AllowAnyOrigin()
        .AllowCredentials();
    });
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapHub<ChatHubManager>("/chat");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(CorsPolicy);

app.Run();
