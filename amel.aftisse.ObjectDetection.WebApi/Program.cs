using Microsoft.AspNetCore.Mvc;
using ObjectDetection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/ObjectDetection", async ([FromForm] IFormFileCollection files) =>
{
    if (files.Count < 1)
        return Results.BadRequest("Aucun fichier n'a été téléchargé.");

    using var sceneSourceStream = files[0].OpenReadStream();
    using var sceneMemoryStream = new MemoryStream();
    sceneSourceStream.CopyTo(sceneMemoryStream);
    var imageSceneData = sceneMemoryStream.ToArray();
    var yolo = new Yolo();
    var result = yolo.Detect(imageSceneData);

    return Results.File(result.ImageData, "image/jpg");
    
}).DisableAntiforgery();

app.Run();