using MediatR;
using Microsoft.Extensions.Configuration;
using Modules.Communication.Infrastructure.Subscriber;
using Modules.Communication.WebAPI.Extensions;
using Modules.School.Application.Subscriber;
using Modules.School.WebAPI.Extensions;
using Modules.User.WebAPI.Extensions;
using SharedKernel;
using SSM.Host.Common;
using SSM.Host.DependencyInjection;
using SSM.Host.MessageEngine;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InMemoryMessageQueue>();

builder.Services.AddSingleton<IEventBus, EventBus>();

builder.Services.AddHostedService<IntegrationEventProcessorJob>();


builder.Services.RegisterSubscriptions();


//you need to add EmailSetting__Key to your Enironment variables in the section User
if (builder.Environment.IsDevelopment())
{

   builder.SetIfNotExists("EmailSettings__Key", "ybek fhsl tspb fpdq");

}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
// Add services to the container. (School module: controllers, validation filter, DI)
builder.Services.AddControllers();
builder.Services.AddSchoolModule(builder.Configuration);
builder.Services.AddUserModule();
builder.Services.AddCommunicationModule();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// regiseter modules global exception handler middleware in the pipeline.
// here add other GlobalException for each module

app.UseSchoolGlobalExceptionHandler();



// Configure the HTTP requespipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseCors("AllowAll");      


app.UseAuthorization();

app.MapControllers();

app.Run();

// Expose for WebApplicationFactory in integration tests
public partial class Program { }
