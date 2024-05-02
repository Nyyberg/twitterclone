using AutoMapper;
using DTO;
using EasyNetQ;
using MessagingService;
using PostRepo;
using PostService;
using PostService.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var mapper = new MapperConfiguration(config =>
{
    config.CreateMap<AddPostDTO, Post>();
    config.CreateMap<UpdatePostDTO, Post>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);
#region dependencyinjection
builder.Services.AddScoped<IPostRepo, PostRepo.PostRepo>();
builder.Services.AddScoped<IPostService, PostService.PostService>();
builder.Services.AddDbContext<RepoDbContext>();
#endregion
builder.Services.AddSingleton(new MessagingClient(RabbitHutch.CreateBus("host=rabbitmq;port=5672;virtualHost=/;username=guest;password=guest")));

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
