using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Gst94 function.
        /// </summary>
        [Fact]
        public void TestGst94()
        {
            var status = 0;
            double theta = Gst94(2400000.5, 53736.0);

            Vvd(theta, 1.754166136020645203, 1e-12, "Gst94", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
