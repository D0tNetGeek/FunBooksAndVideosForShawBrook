using FunBooksAndVideosForShawBrook;
using FunBooksAndVideosForShawBrook.BusinessRules;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);

builder.Services.AddSingleton<IBusinessRule, MembershipActivationRule>();
builder.Services.AddSingleton<IBusinessRule, ShippingSlipGenerationRule>();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FunBooksAndVideosForShawBrook API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }