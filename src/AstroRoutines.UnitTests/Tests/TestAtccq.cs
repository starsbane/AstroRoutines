using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Atccq function.
        /// </summary>
        /// <remarks>
        /// Quick transformation of ICRS RA,Dec to CIRS RA,Dec.
        /// </remarks>
        [Fact]
        public void TestAtccq()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var eo = 0.0;
            var rc = 2.71;
            var dc = 0.174;
            var pr = 1e-5;
            var pd = 5e-6;
            var px = 0.1;
            var rv = 55.0;
            var astrom = new ASTROM();
            double ra = 0, da = 0;

            Apci13(date1, date2, ref astrom, out eo);

            Atccq(rc, dc, pr, pd, px, rv, ref astrom, ref ra, ref da);

            Vvd(ra, 2.710126504531372384, 1e-12, "Atccq", "ra", ref status);
            Vvd(da, 0.1740632537628350152, 1e-12, "Atccq", "da", ref status);

            Assert.Equal(0, status);
        }
    }
}
