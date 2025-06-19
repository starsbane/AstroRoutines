using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Aticq function.
        /// </summary>
        /// <remarks>
        /// Quick transformation of CIRS RA,Dec to ICRS RA,Dec.
        /// </remarks>
        [Fact]
        public void TestAticq()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var eo = 0.0;
            var ri = 2.710121572969038991;
            var di = 0.1729371367218230438;
            var astrom = new ASTROM();
            double rc, dc;

            Apci13(date1, date2, ref astrom, out eo);

            Aticq(ri, di, ref astrom, out rc, out dc);

            Vvd(rc, 2.710126504531716819, 1e-12, "Aticq", "rc", ref status);
            Vvd(dc, 0.1740632537627034482, 1e-12, "Aticq", "dc", ref status);

            Assert.Equal(0, status);
        }
    }
}
