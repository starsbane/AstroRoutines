using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Atic13 function.
        /// </summary>
        /// <remarks>
        /// Transform CIRS RA,Dec to ICRS RA,Dec using internal routine.
        /// </remarks>
        [Fact]
        public void TestAtic13()
        {
            var status = 0;
            var ri = 2.710121572969038991;
            var di = 0.1729371367218230438;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            double rc, dc, eo;

            Atic13(ri, di, date1, date2, out rc, out dc, out eo);

            Vvd(rc, 2.710126504531716819, 1e-12, "Atic13", "rc", ref status);
            Vvd(dc, 0.1740632537627034482, 1e-12, "Atic13", "dc", ref status);
            Vvd(eo, -0.002900618712657375647, 1e-14, "Atic13", "eo", ref status);

            Assert.Equal(0, status);
        }
    }
}
