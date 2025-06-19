using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Gst00a function.
        /// </summary>
        [Fact]
        public void TestGst00a()
        {
            var status = 0;
            double theta = Gst00a(2400000.5, 53736.0, 2400000.5, 53736.0);

            Vvd(theta, 1.754166138018281369, 1e-12, "Gst00a", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
