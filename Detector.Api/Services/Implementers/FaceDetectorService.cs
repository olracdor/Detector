using System;
using System.Threading.Tasks;
using DetectorApi.Models;
using DetectorApi.Providers;
using Google.Cloud.Vision.V1;

namespace FaceFinderApi.Services.Implementers
{
    public class FaceDetectorService : IFaceDetectorService
    {
        ImageAnnotatorClientProvider _imageAnnotatorClientProvider;

        public FaceDetectorService(ImageAnnotatorClientProvider imageAnnotatorClientProvider)
        {
            _imageAnnotatorClientProvider = imageAnnotatorClientProvider;
        }

        public async Task<DetectorResponse> DetectFace(string imageBase64)
        {
            var response = new DetectorResponse();
            ImageAnnotatorClient client = _imageAnnotatorClientProvider.GetClient();
            var image = Image.FromBytes(Convert.FromBase64String(imageBase64));
            var results = await client.DetectFacesAsync(image);
            int faceCount = 0;
            foreach (FaceAnnotation result in results)
            {
                //Confidence score is in decimal - moving decimal place to the right to make it a whole number
                var score = (int)(result.DetectionConfidence * 100);
                if (score >= 70)
                    faceCount += 1;
            }
            response.Detected = faceCount > 0;
            response.Count = faceCount;
            return response;
        }
    }
}
