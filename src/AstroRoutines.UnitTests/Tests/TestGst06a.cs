using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Gst06a function.
        /// </summary>
        [Fact]
        public void TestGst06a()
        {
            var status = 0;
            var theta = Gst06a(2400000.5, 53736.0, 2400000.5, 53736.0);

            Vvd(theta, 1.754166137675019159, 1e-12, "Gst06a", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
