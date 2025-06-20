using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Gst00b function.
        /// </summary>
        [Fact]
        public void TestGst00b()
        {
            var status = 0;
            var theta = Gst00b(2400000.5, 53736.0);

            Vvd(theta, 1.754166136510680589, 1e-12, "Gst00b", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
