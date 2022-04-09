using DetectorApi.Models;

namespace DetectorApi.Services
{
    public interface IFaceDetectorValidationService
    {
        public void ValidateRequestPayload(DetectorRequest request);
    }
}
