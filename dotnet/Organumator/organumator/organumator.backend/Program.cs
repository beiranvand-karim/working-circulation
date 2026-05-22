using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using organumator.Data;
using organumator.Interfaces;
using organumator.Messaging;
using organumator.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAroundBrushingRepository, AroundBrushingRepository>();
builder.Services.AddScoped<IFaceHydrationRepository, FaceHydrationRepository>();
builder.Services.AddScoped<ISilvermanPillTakingRepository, SilvermanPillTakingRepository>();
builder.Services.AddScoped<ILivergolPillTakingRepository, LivergolPillTakingRepository>();
builder.Services.AddScoped<IBetweenTeethBrushingRepository, BetweenTeethBrushingRepository>();
builder.Services.AddScoped<ICalciferolTakingRepository, CalciferolTakingRepository>();
builder.Services.AddScoped<IVacuumCleaningsRepository, VacuumCleaningsRepository>();

builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();
builder.Services.AddHostedService<RabbitMqConsumer>();
builder.Services.AddHostedService<VacuumCleaningsCommandConsumer>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();