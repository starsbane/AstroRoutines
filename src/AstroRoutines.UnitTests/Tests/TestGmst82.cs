using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Gmst82 function.
        /// </summary>
        [Fact]
        public void TestGmst82()
        {
            var status = 0;
            double theta = Gmst82(2400000.5, 53736.0);

            Vvd(theta, 1.754174981860675096, 1e-12, "Gmst82", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
