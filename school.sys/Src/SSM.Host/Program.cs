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


// register module's controllers in the host pipeline
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Modules.School.WebAPI.Controllers.V1.SchoolController).Assembly);




// regiseter module's DI services (application, infrastructure, etc) in the host's container
builder.Services.AddSchoolModule(builder.Configuration);
// here add module's DI


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// regiseter modules global exception handler middleware in the pipeline.
app.UseSchoolGlobalExceptionHandler();
// here add other GlobalException for each module





// Configure the HTTP requespipeline.
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
