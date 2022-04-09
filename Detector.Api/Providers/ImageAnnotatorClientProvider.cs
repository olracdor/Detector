using Google.Cloud.Vision.V1;

namespace DetectorApi.Providers
{
    public class ImageAnnotatorClientProvider
    {
        public ImageAnnotatorClientProvider()
        {
        }

        public ImageAnnotatorClient GetClient()
        {
            //Authenticate using Assigned Account in GCP
            return ImageAnnotatorClient.Create();
        }
    }
}
