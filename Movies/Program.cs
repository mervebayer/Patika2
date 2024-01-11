using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Movies.DbOperations;
using Movies.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "MovieStoreDb"));

var app = builder.Build();
using(var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider; 
    DataGenerator.Initialize(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMovie();
app.GlobalLogging();
//app.UseCustomExceptionMiddle();
app.UseAuthorization();


app.MapControllers();

app.Run();
