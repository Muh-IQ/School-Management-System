using Modules.School.Infrastructure;
using Modules.School.Infrastructure.Persistent;
using Modules.School.WebAPI.Extensions;
using SSM.Host.Common;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    string envName = "ConnectionStrings__DefaultConnection";
    string connString = "Server=.;Database=SchoolManagement;Integrated Security=SSPI;TrustServerCertificate=True;";

    if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(envName)))
    {
        Environment.SetEnvironmentVariable(envName, connString, EnvironmentVariableTarget.Process);
    }

    builder.SetIfNotExists("EmailSettings__SmtpServer", "smtp.gmail.com");
    builder.SetIfNotExists("EmailSettings__SmtpPort", "587");
    builder.SetIfNotExists("EmailSettings__SenderEmail", "mohamedajaj0007@gmail.com");
    builder.SetIfNotExists("EmailSettings__SenderName", "School System");
    builder.SetIfNotExists("EmailSettings__Password", "ybek fhsl tspb fpdq");
}
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Modules.School.WebAPI.Controllers.V1.SchoolController).Assembly);


builder.Services.AddSchoolModule(builder.Configuration); 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
    db.Database.EnsureCreated();
}

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

// Expose for WebApplicationFactory in integration tests
public partial class Program { }
