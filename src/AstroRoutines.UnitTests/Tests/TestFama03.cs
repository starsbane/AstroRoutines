using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Fama03 function.
        /// </summary>
        [Fact]
        public void TestFama03()
        {
            var status = 0;

            Vvd(Fama03(0.80), 3.275506840277781492, 1e-12, "Fama03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
