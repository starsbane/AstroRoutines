using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Faur03 function.
        /// </summary>
        [Fact]
        public void TestFaur03()
        {
            var status = 0;

            Vvd(Faur03(0.80), 5.180636450180413523, 1e-12, "Faur03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
