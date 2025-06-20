using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Apci function.
        /// </summary>
        /// <remarks>
        /// Prepare for ICRS to CIRS transformation, given classical catalog and J2000.0 epoch.
        /// </remarks>
        [Fact]
        public void TestApci()
        {
            var status = 0;

            double date1, date2, x, y, s;
            var ebpv = new double[2, 3];
            var ehp = new double[3];
            var astrom = new ASTROM();

            date1 = 2456165.5;
            date2 = 0.401182685;
            ebpv[0, 0] = 0.901310875;
            ebpv[0, 1] = -0.417402664;
            ebpv[0, 2] = -0.180982288;
            ebpv[1, 0] = 0.00742727954;
            ebpv[1, 1] = 0.0140507459;
            ebpv[1, 2] = 0.00609045792;
            ehp[0] = 0.903358544;
            ehp[1] = -0.415395237;
            ehp[2] = -0.180084014;
            x = 0.0013122272;
            y = -2.92808623e-5;
            s = 3.05749468e-8;

            Apci(date1, date2, ebpv, ehp, x, y, s, ref astrom);

            Vvd(astrom.pmt, 12.65133794027378508, 1e-11, "Apci", "pmt", ref status);
            Vvd(astrom.eb[0], 0.901310875, 1e-12, "Apci", "eb(1)", ref status);
            Vvd(astrom.eb[1], -0.417402664, 1e-12, "Apci", "eb(2)", ref status);
            Vvd(astrom.eb[2], -0.180982288, 1e-12, "Apci", "eb(3)", ref status);
            Vvd(astrom.eh[0], 0.8940025429324143045, 1e-12, "Apci", "eh(1)", ref status);
            Vvd(astrom.eh[1], -0.4110930268679817955, 1e-12, "Apci", "eh(2)", ref status);
            Vvd(astrom.eh[2], -0.1782189004872870264, 1e-12, "Apci", "eh(3)", ref status);
            Vvd(astrom.em, 1.010465295811013146, 1e-12, "Apci", "em", ref status);
            Vvd(astrom.v[0], 0.4289638913597693554e-4, 1e-16, "Apci", "v(1)", ref status);
            Vvd(astrom.v[1], 0.8115034051581320575e-4, 1e-16, "Apci", "v(2)", ref status);
            Vvd(astrom.v[2], 0.3517555136380563427e-4, 1e-16, "Apci", "v(3)", ref status);
            Vvd(astrom.bm1, 0.9999999951686012981, 1e-12, "Apci", "bm1", ref status);
            Vvd(astrom.bpn[0, 0], 0.9999991390295159156, 1e-12, "Apci", "bpn(1,1)", ref status);
            Vvd(astrom.bpn[1, 0], 0.4978650072505016932e-7, 1e-12, "Apci", "bpn(2,1)", ref status);
            Vvd(astrom.bpn[2, 0], 0.1312227200000000000e-2, 1e-12, "Apci", "bpn(3,1)", ref status);
            Vvd(astrom.bpn[0, 1], -0.1136336653771609630e-7, 1e-12, "Apci", "bpn(1,2)", ref status);
            Vvd(astrom.bpn[1, 1], 0.9999999995713154868, 1e-12, "Apci", "bpn(2,2)", ref status);
            Vvd(astrom.bpn[2, 1], -0.2928086230000000000e-4, 1e-12, "Apci", "bpn(3,2)", ref status);
            Vvd(astrom.bpn[0, 2], -0.1312227200895260194e-2, 1e-12, "Apci", "bpn(1,3)", ref status);
            Vvd(astrom.bpn[1, 2], 0.2928082217872315680e-4, 1e-12, "Apci", "bpn(2,3)", ref status);
            Vvd(astrom.bpn[2, 2], 0.9999991386008323373, 1e-12, "Apci", "bpn(3,3)", ref status);

            Assert.Equal(0, status);
        }
    }
}
