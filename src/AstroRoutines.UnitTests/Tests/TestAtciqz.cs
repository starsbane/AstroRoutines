using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Atciqz function.
        /// </summary>
        /// <remarks>
        /// Quick transformation of ICRS RA,Dec to CIRS RA,Dec (no proper motion or parallax).
        /// </remarks>
        [Fact]
        public void TestAtciqz()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var eo = 0.0;
            var rc = 2.71;
            var dc = 0.174;
            var astrom = new ASTROM();
            double ri, di;

            Apci13(date1, date2, ref astrom, out eo);

            Atciqz(rc, dc, ref astrom, out ri, out di);

            Vvd(ri, 2.709994899247256984, 1e-12, "Atciqz", "ri", ref status);
            Vvd(di, 0.1728740720984931891, 1e-12, "Atciqz", "di", ref status);

            Assert.Equal(0, status);
        }
    }
}
