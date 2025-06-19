using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Fasa03 function.
        /// </summary>
        [Fact]
        public void TestFasa03()
        {
            var status = 0;

            Vvd(Fasa03(0.80), 5.371574539440827046, 1e-12, "Fasa03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
