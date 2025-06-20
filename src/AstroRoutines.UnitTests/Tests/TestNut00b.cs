using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Nut00b function.
        /// </summary>
        [Fact]
        public void TestNut00b()
        {
            var status = 0;
            double dpsi, deps;

            Nut00b(2400000.5, 53736.0, out dpsi, out deps);

            Vvd(dpsi, -0.9632552291148362783e-5, 1e-13, "Nut00b", "dpsi", ref status);
            Vvd(deps, 0.4063197106621159367e-4, 1e-13, "Nut00b", "deps", ref status);

            Assert.Equal(0, status);
        }
    }
}
