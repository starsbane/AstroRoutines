using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Atoc13 function.
        /// </summary>
        /// <remarks>
        /// Transform observed place to ICRS RA,Dec using internal routine.
        /// </remarks>
        [Fact]
        public void TestAtoc13()
        {
            var status = 0;
            var utc1 = 2456384.5;
            var utc2 = 0.969254051;
            var dut1 = 0.1550675;
            var elong = -0.527800806;
            var phi = -1.2345856;
            var hm = 2738.0;
            var xp = 2.47230737e-7;
            var yp = 1.82640464e-6;
            var phpa = 731.0;
            var tc = 12.8;
            var rh = 0.59;
            var wl = 0.55;
            double rc, dc;

            var j = Atoc13("R", 2.710085107986886201, 0.1717653435758265198, 
                           utc1, utc2, dut1, elong, phi, hm, xp, yp, 
                           phpa, tc, rh, wl, out rc, out dc);

            Vvd(rc, 2.709956744659136129, 1e-12, "Atoc13", "R/rc", ref status);
            Vvd(dc, 0.1741696500898471362, 1e-12, "Atoc13", "R/dc", ref status);
            Viv(j, 0, "Atoc13", "R/j", ref status);

            j = Atoc13("H", -0.09247619879782006106, 0.1717653435758265198, 
                       utc1, utc2, dut1, elong, phi, hm, xp, yp, 
                       phpa, tc, rh, wl, out rc, out dc);

            Vvd(rc, 2.709956744659734086, 1e-12, "Atoc13", "H/rc", ref status);
            Vvd(dc, 0.1741696500898471362, 1e-12, "Atoc13", "H/dc", ref status);
            Viv(j, 0, "Atoc13", "H/j", ref status);

            j = Atoc13("A", 0.09233952224794989993, 1.407758704513722461, 
                       utc1, utc2, dut1, elong, phi, hm, xp, yp, 
                       phpa, tc, rh, wl, out rc, out dc);

            Vvd(rc, 2.709956744659734086, 1e-12, "Atoc13", "A/rc", ref status);
            Vvd(dc, 0.1741696500898471366, 1e-12, "Atoc13", "A/dc", ref status);
            Viv(j, 0, "Atoc13", "A/j", ref status);

            Assert.Equal(0, status);
        }
    }
}
