using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fk45z function.
        /// </summary>
        [Fact]
        public void TestFk45z()
        {
            var status = 0;
            double r1950, d1950, bepoch, r2000, d2000;

            r1950 = 0.01602284975382960982;
            d1950 = -0.1164347929099906024;
            bepoch = 1954.677617625256806;

            Fk45z(r1950, d1950, bepoch, out r2000, out d2000);

            Vvd(r2000, 0.02719295911606862303, 1e-15, "Fk45z", "r2000", ref status);
            Vvd(d2000, -0.1115766001565926892, 1e-13, "Fk45z", "d2000", ref status);

            Assert.Equal(0, status);
        }
    }
}
