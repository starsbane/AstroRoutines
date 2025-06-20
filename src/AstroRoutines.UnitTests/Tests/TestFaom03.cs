using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Faom03 function.
        /// </summary>
        [Fact]
        public void TestFaom03()
        {
            var status = 0;

            Vvd(Faom03(0.80), -5.973618440951302183, 1e-12, "Faom03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
