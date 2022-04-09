using Autofac;
using DetectorApi.Services;
using DetectorApi.Services.Implementers;
using FaceFinderApi.Services;
using FaceFinderApi.Services.Implementers;

namespace DetectorApi
{
    public class ProjectRegistrationModule : Module
    {
        /// <summary>
        /// Load the Project Dependancies
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IFaceDetectorService>().As<FaceDetectorService>();
            builder.RegisterType<IFaceDetectorValidationService>().As<FaceDetectorValidationService>();
        }
    }
}
