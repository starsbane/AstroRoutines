using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Faf03 function.
        /// </summary>
        [Fact]
        public void TestFaf03()
        {
            var status = 0;

            Vvd(Faf03(0.80), 0.2597711366745499518, 1e-12, "Faf03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
