using DDD.Practice.API.Application.Commands;
using DDD.Practice.API.Application.Queries;
using DDD.Practice.Domain.Aggregates.MessageAggregate;
using DDD.Practice.Infrastructure;
using DDD.Practice.Infrastructure.Repositories;
using DDD.Practice.Infrastructure.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(BaseCommand).GetTypeInfo().Assembly);

/*µù¥U AutoMapperªº profile*/
var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
var profileAssemblies = assemblyNames.Select(assenbly => Assembly.Load(assenbly)).ToList();
profileAssemblies.Add(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(profileAssemblies);

builder.Services.AddTransient<SimpleDBContext>();
/*µù¥U EF mySql Connection*/
builder.Services.AddDbContext<SimpleDBContext>(options =>
    options.UseMySql(configuration.GetSection("MYSqlConnection:Main").Value, ServerVersion.AutoDetect(configuration.GetSection("MYSqlConnection:Main").Value))
);
builder.Services.AddScoped<IUnitOfDapper>((context) =>
{
    Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    return new UnitOfWork(new MySqlConnection(configuration.GetSection("MYSqlConnection:Main").Value), new MySqlConnection(configuration.GetSection("MYSqlConnection:Secondary").Value));
});

builder.Services.AddScoped<IMessageRepository, MessageRepository>();

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
