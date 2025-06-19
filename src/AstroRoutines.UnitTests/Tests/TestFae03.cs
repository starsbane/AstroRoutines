using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Fae03 function.
        /// </summary>
        [Fact]
        public void TestFae03()
        {
            var status = 0;

            Vvd(Fae03(0.80), 1.744713738913081846, 1e-12, "Fae03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
