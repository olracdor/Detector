using DetectorApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FaceFinderApi.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using DetectorApi.Services;
using System;
using Common.Exceptions;
using Common.Models;
using Microsoft.AspNetCore.Authorization;

namespace DetectorApi.Controllers
{
    [ApiController]
    [Route("Detector")]
    public class DetectorController : ControllerBase
    {

        private readonly ILogger<DetectorController> _logger;
        private IFaceDetectorService _faceDetectorService;
        private IFaceDetectorValidationService _faceDetectorValidationService;

        public DetectorController(ILogger<DetectorController> logger, IFaceDetectorService faceDetectorService
            , IFaceDetectorValidationService faceDetectorValidationService)
        {
            _logger = logger;
            _faceDetectorService = faceDetectorService;
            _faceDetectorValidationService = faceDetectorValidationService;
        }

        /// <summary>
        /// Health Check
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Health")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        public ActionResult HealthCheck(DetectorRequest request)
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
                _faceDetectorValidationService.ValidateRequestPayload(request);
                var response = await _faceDetectorService.DetectFace(request.ImageBase64);
                _logger.LogInformation($"Done Processing image with Id {request.Id}");
                return Ok(response);
            }catch(BadRequestException ex)
            {
                string message = $"Missing required field {ex.Message}";
                _logger.LogInformation($"Invalid request encountered for request with Id {request.Id} {message}");
                BadRequestResponse response = new BadRequestResponse("E01", message);

                return BadRequest(response);
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
