using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ee00b function.
        /// </summary>
        [Fact]
        public void TestEe00b()
        {
            var status = 0;
            var ee = Ee00b(2400000.5, 53736.0);

            Vvd(ee, -0.8835700060003032831e-5, 1e-18, "Ee00b", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
