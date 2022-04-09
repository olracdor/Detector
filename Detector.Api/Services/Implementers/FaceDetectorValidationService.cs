using System;
using Common.Exceptions;
using DetectorApi.Models;

namespace DetectorApi.Services.Implementers
{
    public class FaceDetectorValidationService : IFaceDetectorValidationService
    {
        public FaceDetectorValidationService()
        {
        }
        public void ValidateRequestPayload(DetectorRequest request)
        {
            if ("".Equals(request.ImageBase64) || request.ImageBase64 == null)
                throw new BadRequestException("Missing Image");
        }
    }
}
