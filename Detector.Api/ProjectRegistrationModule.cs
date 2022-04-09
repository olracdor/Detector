using Autofac;
using Detector.Api.Services;
using Detector.Api.Services.Implementers;

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
        }
    }
}
