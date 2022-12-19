using JobAPI;
using JobAPI.Services;
using JobAPI.Entities;
using JobAPI.Repository;
using JobAPI.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring Mongo at https://learn.microsoft.com/es-es/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio
builder.Services.Configure<KANBANDatabaseSettings>(builder.Configuration.GetSection("KANBANDatabase"));

builder.Services.AddSingleton<JobRepository>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureJobService();

app.Run();

