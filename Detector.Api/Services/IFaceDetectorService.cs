using System;
using System.Threading.Tasks;
using DetectorApi.Models;

namespace FaceFinderApi.Services
{
    public interface IFaceDetectorService
    {
        public Task<DetectorResponse> DetectFace(string imageBase64);
    }
}
