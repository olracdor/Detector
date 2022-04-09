using Detector.Api.Models;
using FluentValidation;

namespace Detector.Api.Validators
{
    public class FaceDetectorValidator : AbstractValidator<DetectorRequest>
    {
        public FaceDetectorValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is null");
            RuleFor(x => x.ImageBase64).NotNull().WithMessage("Image is null"); ;
            RuleFor(x => x.ImageBase64).NotEqual("").WithMessage("Image is empty");
        }
    }
}
