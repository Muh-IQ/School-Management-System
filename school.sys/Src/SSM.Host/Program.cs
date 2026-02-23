using Microsoft.Extensions.Configuration;
using Modules.School.Infrastructure;
using Modules.School.Infrastructure.Persistent;
using Modules.School.WebAPI.Extensions;
using SSM.Host.Common;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{

    builder.SetIfNotExists("EmailSettings__SmtpServer", "smtp.gmail.com");
    builder.SetIfNotExists("EmailSettings__SmtpPort", "587");
    builder.SetIfNotExists("EmailSettings__SenderEmail", "mohamedajaj0007@gmail.com");
    builder.SetIfNotExists("EmailSettings__SenderName", "School System");
    builder.SetIfNotExists("EmailSettings__Password", "ybek fhsl tspb fpdq");
}

// Add services to the container. (School module: controllers, validation filter, DI)
builder.Services.AddControllers().AddSchoolModule(builder.Configuration);


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
