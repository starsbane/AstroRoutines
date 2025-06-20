using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test iauApco13 function.
        /// </summary>
        /// <remarks>
        /// Prepare for CIRS to observed transformation, using internal routine.
        /// </remarks>
        [Fact]
        public void TestApco13()
        {
            var status = 0;

            double utc1, utc2, dut1, elong, phi, hm, xp, yp,
                phpa, tc, rh, wl, eo = 0;
            var astrom = new ASTROM();
            int j;

            utc1 = 2456384.5;
            utc2 = 0.969254051;
            dut1 = 0.1550675;
            elong = -0.527800806;
            phi = -1.2345856;
            hm = 2738.0;
            xp = 2.47230737e-7;
            yp = 1.82640464e-6;
            phpa = 731.0;
            tc = 12.8;
            rh = 0.59;
            wl = 0.55;

            j = Apco13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                           phpa, tc, rh, wl, ref astrom, ref eo);

            Vvd(astrom.pmt, 13.25248468622475727, 1e-11, "Apco13", "pmt", ref status);
            Vvd(astrom.eb[0], -0.9741827107320875162, 1e-12, "Apco13", "eb(1)", ref status);
            Vvd(astrom.eb[1], -0.2115130190489716682, 1e-12, "Apco13", "eb(2)", ref status);
            Vvd(astrom.eb[2], -0.09179840189496755339, 1e-12, "Apco13", "eb(3)", ref status);
            Vvd(astrom.eh[0], -0.9736425572586935247, 1e-12, "Apco13", "eh(1)", ref status);
            Vvd(astrom.eh[1], -0.2092452121603336166, 1e-12, "Apco13", "eh(2)", ref status);
            Vvd(astrom.eh[2], -0.09075578153885665295, 1e-12, "Apco13", "eh(3)", ref status);
            Vvd(astrom.em, 0.9998233240913898141, 1e-12, "Apco13", "em", ref status);
            Vvd(astrom.v[0], 0.2078704994520489246e-4, 1e-16, "Apco13", "v(1)", ref status);
            Vvd(astrom.v[1], -0.8955360133238868938e-4, 1e-16, "Apco13", "v(2)", ref status);
            Vvd(astrom.v[2], -0.3863338993055887398e-4, 1e-16, "Apco13", "v(3)", ref status);
            Vvd(astrom.bm1, 0.9999999950277561004, 1e-12, "Apco13", "bm1", ref status);
            Vvd(astrom.bpn[0, 0], 0.9999991390295147999, 1e-12, "Apco13", "bpn(1,1)", ref status);
            Vvd(astrom.bpn[1, 0], 0.4978650075315529277e-7, 1e-12, "Apco13", "bpn(2,1)", ref status);
            Vvd(astrom.bpn[2, 0], 0.001312227200850293372, 1e-12, "Apco13", "bpn(3,1)", ref status);
            Vvd(astrom.bpn[0, 1], -0.1136336652812486604e-7, 1e-12, "Apco13", "bpn(1,2)", ref status);
            Vvd(astrom.bpn[1, 1], 0.9999999995713154865, 1e-12, "Apco13", "bpn(2,2)", ref status);
            Vvd(astrom.bpn[2, 1], -0.2928086230975367296e-4, 1e-12, "Apco13", "bpn(3,2)", ref status);
            Vvd(astrom.bpn[0, 2], -0.001312227201745553566, 1e-12, "Apco13", "bpn(1,3)", ref status);
            Vvd(astrom.bpn[1, 2], 0.2928082218847679162e-4, 1e-12, "Apco13", "bpn(2,3)", ref status);
            Vvd(astrom.bpn[2, 2], 0.9999991386008312212, 1e-12, "Apco13", "bpn(3,3)", ref status);
            Vvd(astrom.along, -0.5278008060295995733, 1e-12, "Apco13", "along", ref status);
            Vvd(astrom.xpl, 0.1133427418130752958e-5, 1e-17, "Apco13", "xpl", ref status);
            Vvd(astrom.ypl, 0.1453347595780646207e-5, 1e-17, "Apco13", "ypl", ref status);
            Vvd(astrom.sphi, -0.9440115679003211329, 1e-12, "Apco13", "sphi", ref status);
            Vvd(astrom.cphi, 0.3299123514971474711, 1e-12, "Apco13", "cphi", ref status);
            Vvd(astrom.diurab, 0, 0, "Apco13", "diurab", ref status);
            Vvd(astrom.eral, 2.617608909189664000, 1e-12, "Apco13", "eral", ref status);
            Vvd(astrom.refa, 0.2014187785940396921e-3, 1e-15, "Apco13", "refa", ref status);
            Vvd(astrom.refb, -0.2361408314943696227e-6, 1e-18, "Apco13", "refb", ref status);
            Vvd(eo, -0.003020548354802412839, 1e-14, "Apco13", "eo", ref status);
            Viv(j, 0, "Apco13", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
