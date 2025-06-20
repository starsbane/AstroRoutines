using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fal03 function.
        /// </summary>
        [Fact]
        public void TestFal03()
        {
            var status = 0;

            Vvd(Fal03(0.80), 5.132369751108684150, 1e-12, "Fal03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
