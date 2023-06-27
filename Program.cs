using JsonPlaceHolder.DataInitializer;
using JsonPlaceHolder.MiddleWares;
using JsonPlaceHolder.Models;
using JsonPlaceHolder.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPlaceHolderService, PlaceHolderService>();
builder.Services.Configure<Connection>(builder.Configuration.GetSection("Connection"));
builder.Services.AddOptions();
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.MapControllers();


app.Run();

