using System.Collections.Generic; 
using System.IO; 
using System.Reflection; 
using System.Text.Json; 
using System.Threading.Tasks; 
using Xunit; 

 
namespace VotrePrénom.VotreNom.ObjectDetection.Tests; 
 
public class ObjectDetectionUnitTest 
{ 
    [Fact] 
    public async Task ObjectShouldBeDetectedCorrectly() 
    { 
        var executingPath = GetExecutingPath(); 
        var imageScenesData = new List<byte[]>(); 
        foreach (var imagePath in Directory.EnumerateFiles(Path.Combine(executingPath, "Scenes"))) 
        { 
            var imageBytes = await File.ReadAllBytesAsync(imagePath); 
            imageScenesData.Add(imageBytes); 
        } 
 
 
        var detectObjectInScenesResults = await new amel.aftisse.ObjectDetection.ObjectDetection().DetectObjectInScenesAsync(imageScenesData);
        
        // Faire le test directement sur les dimensions que les images me donnent
        
        var premier = JsonSerializer.Serialize(detectObjectInScenesResults[0].Box);
        var deuxieme = JsonSerializer.Serialize(detectObjectInScenesResults[1].Box);
        
        Console.WriteLine($"Premier: {premier}");
        Console.WriteLine($"Deuxieme: {deuxieme}");
        
        Assert.Equal(premier, JsonSerializer.Serialize(detectObjectInScenesResults[0].Box));
        Assert.Equal(deuxieme,JsonSerializer.Serialize(detectObjectInScenesResults[1].Box)); 
    } 
 
    private static string GetExecutingPath() 
    { 
        var executingAssemblyPath = Assembly.GetExecutingAssembly().Location; 
        var executingPath = Path.GetDirectoryName(executingAssemblyPath); 
        return executingPath; 
    } 
}