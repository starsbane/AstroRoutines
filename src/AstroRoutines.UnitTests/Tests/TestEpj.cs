using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Epj function.
        /// </summary>
        [Fact]
        public void TestEpj()
        {
            var status = 0;
            var epj = Epj(2451545, -7392.5);

            Vvd(epj, 1979.760438056125941, 1e-12, "Epj", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
