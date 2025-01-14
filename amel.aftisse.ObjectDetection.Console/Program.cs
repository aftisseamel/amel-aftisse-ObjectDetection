// See https://aka.ms/new-console-template for more information

using System.Text.Json;

Console.WriteLine("Hello ! ");

string scenesDirectory = args[0];

string[] imageSceneFiles = Directory.GetFiles(scenesDirectory, "*.jpg");

//vérifier que le nombre d'image est correct
Console.WriteLine($"Found {imageSceneFiles.Length} images");

var imagesSceneData = imageSceneFiles.Select(file => File.ReadAllBytes(file)).ToList();
var objectDetection = new amel.aftisse.ObjectDetection.ObjectDetection();

var detectObjectInScenesResults = await objectDetection.DetectObjectInScenesAsync(imagesSceneData);

foreach (var objectDetectionResult in detectObjectInScenesResults) 
{ 
    Console.WriteLine($"Box: {JsonSerializer.Serialize(objectDetectionResult.Box)}"); 
} 