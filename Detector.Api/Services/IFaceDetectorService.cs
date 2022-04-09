using System.Threading.Tasks;
using Detector.Api.Models;

namespace Detector.Api.Services
{
    public interface IFaceDetectorService
    {
        public Task<DetectorResponse> DetectFace(string imageBase64);
    }
}
