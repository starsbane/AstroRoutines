namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fk54z function.
        /// </summary>
        [Fact]
        public void TestFk54z()
        {
            var status = 0;
            double r2000, d2000, bepoch, r1950, d1950, dr1950, dd1950;

            r2000 = 0.02719026625066316119;
            d2000 = -0.1115815170738754813;
            bepoch = 1954.677308160316374;

            Fk54z(r2000, d2000, bepoch, out r1950, out d1950, out dr1950, out dd1950);

            Vvd(r1950, 0.01602015588390065476, 1e-14, "Fk54z", "r1950", ref status);
            Vvd(d1950, -0.1164397101110765346, 1e-13, "Fk54z", "d1950", ref status);
            Vvd(dr1950, -0.1175712648471090704e-7, 1e-20, "Fk54z", "dr1950", ref status);
            Vvd(dd1950, 0.2108109051316431056e-7, 1e-20, "Fk54z", "dd1950", ref status);

            Assert.Equal(0, status);
        }
    }
}
