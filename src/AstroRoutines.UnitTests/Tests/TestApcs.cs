using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Apcs function.
        /// </summary>
        /// <remarks>
        /// Prepare for ICRS to GCRS transformation, given position and velocity.
        /// </remarks>
        [Fact]
        public void TestApcs()
        {
            var status = 0;
            var date1 = 2456384.5;
            var date2 = 0.970031644;
            var pv = new double[2, 3];
            var ebpv = new double[2, 3];
            var ehp = new double[3];
            var astrom = new ASTROM();

            pv[0, 0] = -1836024.09;
            pv[0, 1] = 1056607.72;
            pv[0, 2] = -5998795.26;
            pv[1, 0] = -77.0361767;
            pv[1, 1] = -133.310856;
            pv[1, 2] = 0.0971855934;
            ebpv[0, 0] = -0.974170438;
            ebpv[0, 1] = -0.211520082;
            ebpv[0, 2] = -0.0917583024;
            ebpv[1, 0] = 0.00364365824;
            ebpv[1, 1] = -0.0154287319;
            ebpv[1, 2] = -0.00668922024;
            ehp[0] = -0.973458265;
            ehp[1] = -0.209215307;
            ehp[2] = -0.0906996477;

            Apcs(date1, date2, pv, ebpv, ehp, ref astrom);

            Vvd(astrom.pmt, 13.25248468622587269, 1e-11, "Apcs", "pmt", ref status);
            Vvd(astrom.eb[0], -0.9741827110629881886, 1e-12, "Apcs", "eb(1)", ref status);
            Vvd(astrom.eb[1], -0.2115130190136415986, 1e-12, "Apcs", "eb(2)", ref status);
            Vvd(astrom.eb[2], -0.09179840186954412099, 1e-12, "Apcs", "eb(3)", ref status);
            Vvd(astrom.eh[0], -0.9736425571689454706, 1e-12, "Apcs", "eh(1)", ref status);
            Vvd(astrom.eh[1], -0.2092452125850435930, 1e-12, "Apcs", "eh(2)", ref status);
            Vvd(astrom.eh[2], -0.09075578152248299218, 1e-12, "Apcs", "eh(3)", ref status);
            Vvd(astrom.em, 0.9998233241709796859, 1e-12, "Apcs", "em", ref status);
            Vvd(astrom.v[0], 0.2078704993282685510e-4, 1e-16, "Apcs", "v(1)", ref status);
            Vvd(astrom.v[1], -0.8955360106989405683e-4, 1e-16, "Apcs", "v(2)", ref status);
            Vvd(astrom.v[2], -0.3863338994289409097e-4, 1e-16, "Apcs", "v(3)", ref status);
            Vvd(astrom.bm1, 0.9999999950277561237, 1e-12, "Apcs", "bm1", ref status);
            
            // Checking BPN matrix
            Vvd(astrom.bpn[0, 0], 1, 0, "Apcs", "bpn(1,1)", ref status);
            Vvd(astrom.bpn[0, 1], 0, 0, "Apcs", "bpn(1,2)", ref status);
            Vvd(astrom.bpn[0, 2], 0, 0, "Apcs", "bpn(1,3)", ref status);
            Vvd(astrom.bpn[1, 0], 0, 0, "Apcs", "bpn(2,1)", ref status);
            Vvd(astrom.bpn[1, 1], 1, 0, "Apcs", "bpn(2,2)", ref status);
            Vvd(astrom.bpn[1, 2], 0, 0, "Apcs", "bpn(2,3)", ref status);
            Vvd(astrom.bpn[2, 0], 0, 0, "Apcs", "bpn(3,1)", ref status);
            Vvd(astrom.bpn[2, 1], 0, 0, "Apcs", "bpn(3,2)", ref status);
            Vvd(astrom.bpn[2, 2], 1, 0, "Apcs", "bpn(3,3)", ref status);

            Assert.Equal(0, status);
        }
    }
}
