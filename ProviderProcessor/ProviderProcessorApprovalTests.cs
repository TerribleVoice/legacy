using ApprovalTests.Reporters;
using NUnit.Framework;
using ProviderProcessing.ProviderDatas;

namespace ProviderProcessing
{
    [TestFixture]
    [UseReporter(typeof(KDiff3Reporter))]
    public class ProviderProcessorApprovalTests
    {
        private ProductData[] ProductDatas;
        private ProviderData ProviderData;
        public void SetUp()
        {
            
        }

        [Test]
        public void TestForTest()
        {
            
        }
    }
}