using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Eqeq94 function.
        /// </summary>
        [Fact]
        public void TestEqeq94()
        {
            var status = 0;
            double eqeq = Eqeq94(2400000.5, 41234.0);

            Vvd(eqeq, 0.5357758254609256894e-4, 1e-17, "Eqeq94", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
