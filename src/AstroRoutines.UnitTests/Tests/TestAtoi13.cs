using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Atoi13 function.
        /// </summary>
        /// <remarks>
        /// Transform observed place to CIRS RA,Dec using internal routine.
        /// </remarks>
        [Fact]
        public void TestAtoi13()
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
            double ri, di;

            var j = Atoi13("R", 2.710085107986886201, 0.1717653435758265198, 
                           utc1, utc2, dut1, elong, phi, hm, xp, yp, 
                           phpa, tc, rh, wl, out ri, out di);

            Vvd(ri, 2.710121574447540810, 1e-12, "Atoi13", "R/ri", ref status);
            Vvd(di, 0.1729371839116608778, 1e-12, "Atoi13", "R/di", ref status);
            Viv(j, 0, "Atoi13", "R/J", ref status);

            j = Atoi13("H", -0.09247619879782006106, 0.1717653435758265198, 
                       utc1, utc2, dut1, elong, phi, hm, xp, yp, 
                       phpa, tc, rh, wl, out ri, out di);

            Vvd(ri, 2.710121574448138676, 1e-12, "Atoi13", "H/ri", ref status);
            Vvd(di, 0.1729371839116608778, 1e-12, "Atoi13", "H/di", ref status);
            Viv(j, 0, "Atoi13", "H/J", ref status);

            j = Atoi13("A", 0.09233952224794989993, 1.407758704513722461, 
                       utc1, utc2, dut1, elong, phi, hm, xp, yp, 
                       phpa, tc, rh, wl, out ri, out di);

            Vvd(ri, 2.710121574448138676, 1e-12, "Atoi13", "A/ri", ref status);
            Vvd(di, 0.1729371839116608781, 1e-12, "Atoi13", "A/di", ref status);
            Viv(j, 0, "Atoi13", "A/J", ref status);

            Assert.Equal(0, status);
        }
    }
}
