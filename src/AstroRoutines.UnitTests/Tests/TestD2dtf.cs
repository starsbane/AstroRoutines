using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test D2dtf function.
        /// </summary>
        [Fact]
        public void TestD2dtf()
        {
            var status = 0;
            var ihmsf = new int[4];
            int j, iy = 0, im = 0, id = 0;

            // Call the D2dtf function with test values
            j = D2dtf("UTC", 5, 2400000.5, 49533.99999, ref iy, ref im, ref id, ref ihmsf);

            // Check the year
            Viv(iy, 1994, "D2dtf", "y", ref status);
            // Check the month
            Viv(im, 6, "D2dtf", "mo", ref status);
            // Check the day
            Viv(id, 30, "D2dtf", "d", ref status);
            // Check the hours
            Viv(ihmsf[0], 23, "D2dtf", "h", ref status);
            // Check the minutes
            Viv(ihmsf[1], 59, "D2dtf", "m", ref status);
            // Check the seconds
            Viv(ihmsf[2], 60, "D2dtf", "s", ref status);
            // Check the fractions
            Viv(ihmsf[3], 13599, "D2dtf", "f", ref status);
            // Check the return status
            Viv(j, 0, "D2dtf", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}