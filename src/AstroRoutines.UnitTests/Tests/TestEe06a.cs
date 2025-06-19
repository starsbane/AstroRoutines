using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Ee06a function.
        /// </summary>
        [Fact]
        public void TestEe06a()
        {
            var status = 0;
            var ee = Ee06a(2400000.5, 53736.0);

            Vvd(ee, -0.8834195072043790156e-5, 1e-15, "Ee06a", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
