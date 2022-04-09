using NUnit.Framework;

namespace DetectorApi.Test
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