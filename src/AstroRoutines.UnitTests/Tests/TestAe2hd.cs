using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ae2hd function.
        /// </summary>
        /// <remarks>
        /// Converts azimuth and elevation to hour angle and declination.
        /// </remarks>
        [Fact]
        public void TestAe2hd()
        {
            int status = 0;
            double a, e, p, h, d;

            a = 5.5;
            e = 1.1;
            p = 0.7;

            Ae2hd(a, e, p, out h, out d);

            Vvd(h, 0.5933291115507309663, 1e-14, "Ae2hd", "h", ref status);
            Vvd(d, 0.9613934761647817620, 1e-14, "Ae2hd", "d", ref status);

            Assert.Equal(0, status);
        }
    }
}
