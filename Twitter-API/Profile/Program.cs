using AutoMapper;
using DTO;
using TimelineRepo;
using TimelineService;
using TimelineService.DTOs;
using TimelineService.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region automapper
var mapper = new MapperConfiguration(config =>
{
    config.CreateMap<AddPostToTimelineDTO, Timeline>();
    config.CreateMap<CreateTimelineDTO, Timeline>();
    
}).CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region DependencyInjection
builder.Services.AddDbContext<TimelineDbContext>();
builder.Services.AddScoped<ITimelineRepo, TimelineRepo.TimelineRepo>();
builder.Services.AddScoped<ITimelineService, TimelineService.TimelineService>();
#endregion
builder.Services.AddHostedService<AddPostToTimelineHandler>();

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
