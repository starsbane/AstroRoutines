using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Atco13 function.
        /// </summary>
        /// <remarks>
        /// Transform ICRS RA,Dec to observed place using internal routine.
        /// </remarks>
        [Fact]
        public void TestAtco13()
        {
            var status = 0;
            var rc = 2.71;
            var dc = 0.174;
            var pr = 1e-5;
            var pd = 5e-6;
            var px = 0.1;
            var rv = 55.0;
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
            double aob = 0, zob = 0, hob = 0, dob = 0, rob = 0, eo = 0;

            var j = Atco13(rc, dc, pr, pd, px, rv,
                           utc1, utc2, dut1, elong, phi, hm, xp, yp,
                           phpa, tc, rh, wl,
                           ref aob, ref zob, ref hob, ref dob, ref rob, ref eo);

            Vvd(aob, 0.9251774485485515207e-1, 1e-12, "Atco13", "aob", ref status);
            Vvd(zob, 1.407661405256499357, 1e-12, "Atco13", "zob", ref status);
            Vvd(hob, -0.9265154431529724692e-1, 1e-12, "Atco13", "hob", ref status);
            Vvd(dob, 0.1716626560072526200, 1e-12, "Atco13", "dob", ref status);
            Vvd(rob, 2.710260453504961012, 1e-12, "Atco13", "rob", ref status);
            Vvd(eo, -0.003020548354802412839, 1e-14, "Atco13", "eo", ref status);
            Viv(j, 0, "Atco13", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
