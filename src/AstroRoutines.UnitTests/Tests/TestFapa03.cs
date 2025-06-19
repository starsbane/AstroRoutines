using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Fapa03 function.
        /// </summary>
        [Fact]
        public void TestFapa03()
        {
            var status = 0;

            Vvd(Fapa03(0.80), 0.1950884762240000000e-1, 1e-12, "Fapa03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
