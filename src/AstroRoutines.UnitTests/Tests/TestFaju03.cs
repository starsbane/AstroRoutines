using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Faju03 function.
        /// </summary>
        [Fact]
        public void TestFaju03()
        {
            var status = 0;

            Vvd(Faju03(0.80), 5.275711665202481138, 1e-12, "Faju03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
