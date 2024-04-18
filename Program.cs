using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBinaryTreeService, BinaryTreeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/mirror-binarytree", ([FromBody] BinaryTree binaryTree, IBinaryTreeService binaryTreeService) =>
{
    var mirroredBineryTree = binaryTreeService.Mirror(binaryTree);

    return mirroredBineryTree;
})
.WithName("MirrorBinaryTree")
.WithOpenApi();

app.Run();
