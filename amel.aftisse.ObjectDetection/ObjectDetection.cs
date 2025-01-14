using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjectDetection;

namespace amel.aftisse.ObjectDetection
{
    public class ObjectDetection
    {
        public async Task<IList<ObjectDetectionResult>> DetectObjectInScenesAsync(IList<byte[]> imagesSceneData)
        {
            var results = new List<ObjectDetectionResult>();
            var tinyYolo = new Yolo();

            var tasks = imagesSceneData.Select(imageData => Task.Run(() =>
            {
                var yoloOutput = tinyYolo.Detect(imageData);

                var detectionResult = new ObjectDetectionResult
                {
                    ImageData = imageData,
                    Box = new List<BoundingBox>()
                };

                if (yoloOutput?.Boxes != null)
                {
                    foreach (var box in yoloOutput.Boxes)
                    {
                        detectionResult.Box.Add(new BoundingBox
                        {
                            Confidence = box.Confidence,
                            Label = box.Label,
                            Dimensions = new BoundingBoxDimensions
                            {
                                X = box.Dimensions.X,
                                Y = box.Dimensions.Y,
                                Width = box.Dimensions.Width,
                                Height = box.Dimensions.Height
                            }
                        });
                    }
                }

                return detectionResult;
            }));

            var detectionResults = await Task.WhenAll(tasks);

            results.AddRange(detectionResults);

            return results;
        }

    }
}