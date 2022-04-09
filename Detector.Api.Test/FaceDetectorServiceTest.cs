using System;
using DetectorApi.Models;
using DetectorApi.Providers;
using FaceFinderApi.Services.Implementers;
using Google.Cloud.Vision.V1;
using Moq;
using NUnit.Framework;

namespace Detector.Api.Test
{
    public class ImageAnnotatorClientImpl : ImageAnnotatorClient{}
    public class FaceDetectorServiceTest
    {
        private Mock<ImageAnnotatorClientProvider> _imageAnnotatorClientProviderMock;
        private Mock<ImageAnnotatorClientImpl> _imageAnnotatorClientImplMock;
        private ImageAnnotatorClientImpl _imageAnnotatorClientImpl;
        private FaceDetectorService _target;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _imageAnnotatorClientImplMock = new Mock<ImageAnnotatorClientImpl>(MockBehavior.Strict);
            _imageAnnotatorClientProviderMock = new Mock<ImageAnnotatorClientProvider>(MockBehavior.Strict);
            _target = new FaceDetectorService(_imageAnnotatorClientProviderMock.Object);
            _imageAnnotatorClientImpl = _imageAnnotatorClientImplMock.Object;
        }

        [Test]
        public async void ValidateFaceValidationTest()
        {
            DetectorRequest request = new DetectorRequest();
            var image = Image.FromBytes(Convert.FromBase64String(""));
            //_imageAnnotatorClientImplMock.Setup(q => q.DetectFacesAsync(image)).Returns(null);
            _imageAnnotatorClientProviderMock.Setup(q => q.GetClient()).Returns(_imageAnnotatorClientImpl);
            try
            {
                await _target.DetectFace(request.ImageBase64);
            }catch(Exception ex)
            {

            }
        }
    }
}
