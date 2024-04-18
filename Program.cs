using BinaryTreeService.Model;
using BinaryTreeService.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBinaryTreeProcessor, BinaryTreeProcessor>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/mirror-binarytree", ([FromBody] BinaryTree binaryTree, IBinaryTreeProcessor processor) =>
{
    if (binaryTree == null)
    {
        return Results.BadRequest("Binary tree is required");
    }

    if (!binaryTree.IsValid())
    {
        return Results.BadRequest("Binary tree structure is improper");
    }

    var mirroredBineryTree = processor.Mirror(binaryTree);

    return Results.Ok(mirroredBineryTree);
})
.WithName("MirrorBinaryTree")
.WithOpenApi();

app.Run();
