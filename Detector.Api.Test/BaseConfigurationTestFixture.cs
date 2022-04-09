using NUnit.Framework;

namespace Detector.Api.Test
{
    [Parallelizable(ParallelScope.Fixtures)]
    public abstract class BaseConfigurationTestFixture
    {
       
        [OneTimeSetUp]
        public void OneTimeSetUpBase()
        {
            
        }
    }
}