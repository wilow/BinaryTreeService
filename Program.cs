using BinaryTreeService.Model;
using BinaryTreeService.Services;
using Microsoft.AspNetCore.Mvc;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBinaryTreeProcessor, BinaryTreeProcessor>();

builder.Logging.AddOpenTelemetry(options =>
{
    options.SetResourceBuilder(ResourceBuilder.CreateDefault()
    .AddService(builder.Environment.ApplicationName))
    .AddConsoleExporter();
});
builder.Services.AddOpenTelemetry()
.ConfigureResource((resourceBuilder) => resourceBuilder.AddService(builder.Environment.ApplicationName))
.WithTracing(tracing => tracing.AddAspNetCoreInstrumentation().AddConsoleExporter())
.WithMetrics(metrics => metrics.AddAspNetCoreInstrumentation().AddConsoleExporter());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/mirror-binarytree", ([FromBody] BinaryTree binaryTree, IBinaryTreeProcessor processor, ILogger<Program> logger) =>
{
    logger.LogInformation("MirrorBinaryTree method is called");

    if (binaryTree == null)
    {
        logger.LogError("Binary tree is required");
        return Results.BadRequest("Binary tree is required");
    }

    if (!binaryTree.IsValid())
    {
        logger.LogError("Binary tree structure is improper");
        return Results.BadRequest("Binary tree structure is improper");
    }

    var mirroredBineryTree = processor.Mirror(binaryTree);

    return Results.Ok(mirroredBineryTree);
})
.WithName("MirrorBinaryTree")
.WithOpenApi();

app.Run();
