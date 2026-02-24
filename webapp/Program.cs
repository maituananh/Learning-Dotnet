using API.Configurations.DI;
using Infra.Configuration;

var builder = WebApplication.CreateBuilder(args);


IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; });

builder.Services.AddOpenApi();

builder.Services.InstallServices(configuration, typeof(IServiceInstaller).Assembly);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
