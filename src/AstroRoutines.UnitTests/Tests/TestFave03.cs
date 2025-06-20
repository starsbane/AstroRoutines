using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fave03 function.
        /// </summary>
        [Fact]
        public void TestFave03()
        {
            var status = 0;

            Vvd(Fave03(0.80), 3.424900460533758000, 1e-12, "Fave03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
