using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ee00a function.
        /// </summary>
        [Fact]
        public void TestEe00a()
        {
            var status = 0;
            var ee = Ee00a(2400000.5, 53736.0);

            Vvd(ee, -0.8834192459222588227e-5, 1e-18, "Ee00a", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
