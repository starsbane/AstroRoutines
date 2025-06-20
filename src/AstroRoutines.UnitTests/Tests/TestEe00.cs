using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ee00 function.
        /// </summary>
        [Fact]
        public void TestEe00()
        {
            var status = 0;
            var epsa = 0.4090789763356509900;
            var dpsi = -0.9630909107115582393e-5;

            var ee = Ee00(2400000.5, 53736.0, epsa, dpsi);

            Vvd(ee, -0.8834193235367965479e-5, 1e-18, "Ee00", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
