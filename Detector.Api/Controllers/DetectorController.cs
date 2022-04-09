using Detector.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Detector.Api.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System;
using Microsoft.AspNetCore.Authorization;
using Detector.Api.Validators;

namespace Detector.Api.Controllers
{
    [ApiController]
    [Route("Detector")]
    public class DetectorController : ControllerBase
    {

        private readonly ILogger<DetectorController> _logger;
        private IFaceDetectorService _faceDetectorService;
        private FaceDetectorValidator _faceDetectorValidator;

        public DetectorController(ILogger<DetectorController> logger, IFaceDetectorService faceDetectorService, FaceDetectorValidator faceDetectorValidator)
        {
            _logger = logger;
            _faceDetectorService = faceDetectorService;
            _faceDetectorValidator = faceDetectorValidator;
        }

        /// <summary>
        /// Health Check
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Health")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        public ActionResult HealthCheck()
        {
            return Ok();
        }

        /// <summary>
        /// Detect faces in image
        /// </summary>
        /// <returns>DetectorResponse</returns>
        [HttpPost]
        [Authorize]
        [Route("Face")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DetectorResponse))]
        public async Task<ActionResult<DetectorResponse>> DetectFace(DetectorRequest request)
        {
            try
            {
                _logger.LogInformation($"Processing image with Id {request.Id}");
                //Validations
                var result = _faceDetectorValidator.ValidateAsync(request);
                if (!result.Result.IsValid)
                    return BadRequest(result.Result.Errors);

                //Process request
                var response = await _faceDetectorService.DetectFace(request.ImageBase64);
                _logger.LogInformation($"Done Processing image with Id {request.Id}");
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error encountered for request with Id {request.Id}");
                _logger.LogError($"Error with Id {request.Id} error description: {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
