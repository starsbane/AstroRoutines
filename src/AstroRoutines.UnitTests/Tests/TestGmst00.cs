using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Gmst00 function.
        /// </summary>
        [Fact]
        public void TestGmst00()
        {
            var status = 0;
            double theta = Gmst00(2400000.5, 53736.0, 2400000.5, 53736.0);

            Vvd(theta, 1.754174972210740592, 1e-12, "Gmst00", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
