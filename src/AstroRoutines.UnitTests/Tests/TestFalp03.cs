using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Falp03 function.
        /// </summary>
        [Fact]
        public void TestFalp03()
        {
            var status = 0;

            Vvd(Falp03(0.80), 6.226797973505507345, 1e-12, "Falp03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
