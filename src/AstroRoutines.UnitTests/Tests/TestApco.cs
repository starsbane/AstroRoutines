namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Apco function.
        /// </summary>
        /// <remarks>
        /// Prepare for CIRS to observed transformation.
        /// </remarks>
        [Fact]
        public void TestApco()
        {
            var status = 0;
            
            double date1, date2, x, y, s, theta, elong, phi, hm, xp, yp, sp, refa, refb;
            var ehp = new double[3];
            var ebpv = new double[2, 3];
            var astrom = new ASTROM();

            date1 = 2456384.5;
            date2 = 0.970031644;
            ebpv[0, 0] = -0.974170438;
            ebpv[0, 1] = -0.211520082;
            ebpv[0, 2] = -0.0917583024;
            ebpv[1, 0] = 0.00364365824;
            ebpv[1, 1] = -0.0154287319;
            ebpv[1, 2] = -0.00668922024;
            ehp[0] = -0.973458265;
            ehp[1] = -0.209215307;
            ehp[2] = -0.0906996477;
            x = 0.0013122272;
            y = -2.92808623e-5;
            s = 3.05749468e-8;
            theta = 3.14540971;
            elong = -0.527800806;
            phi = -1.2345856;
            hm = 2738.0;
            xp = 2.47230737e-7;
            yp = 1.82640464e-6;
            sp = -3.01974337e-11;
            refa = 0.000201418779;
            refb = -2.36140831e-7;

            Apco(date1, date2, ebpv, ehp, x, y, s, theta, elong, phi, hm, xp, yp, sp, refa, refb, ref astrom);

            Vvd(astrom.pmt, 13.25248468622587269, 1e-11, "Apco", "pmt", ref status);
            Vvd(astrom.eb[0], -0.9741827110630322720, 1e-12, "Apco", "eb(1)", ref status);
            Vvd(astrom.eb[1], -0.2115130190135344832, 1e-12, "Apco", "eb(2)", ref status);
            Vvd(astrom.eb[2], -0.09179840186949532298, 1e-12, "Apco", "eb(3)", ref status);
            Vvd(astrom.eh[0], -0.9736425571689739035, 1e-12, "Apco", "eh(1)", ref status);
            Vvd(astrom.eh[1], -0.2092452125849330936, 1e-12, "Apco", "eh(2)", ref status);
            Vvd(astrom.eh[2], -0.09075578152243272599, 1e-12, "Apco", "eh(3)", ref status);
            Vvd(astrom.em, 0.9998233241709957653, 1e-12, "Apco", "em", ref status);
            Vvd(astrom.v[0], 0.2078704992916728762e-4, 1e-16, "Apco", "v(1)", ref status);
            Vvd(astrom.v[1], -0.8955360107151952319e-4, 1e-16, "Apco", "v(2)", ref status);
            Vvd(astrom.v[2], -0.3863338994288951082e-4, 1e-16, "Apco", "v(3)", ref status);
            Vvd(astrom.bm1, 0.9999999950277561236, 1e-12, "Apco", "bm1", ref status);
            Vvd(astrom.bpn[0, 0], 0.9999991390295159156, 1e-12, "Apco", "bpn(1,1)", ref status);
            Vvd(astrom.bpn[1, 0], 0.4978650072505016932e-7, 1e-12, "Apco", "bpn(2,1)", ref status);
            Vvd(astrom.bpn[2, 0], 0.1312227200000000000e-2, 1e-12, "Apco", "bpn(3,1)", ref status);
            Vvd(astrom.bpn[0, 1], -0.1136336653771609630e-7, 1e-12, "Apco", "bpn(1,2)", ref status);
            Vvd(astrom.bpn[1, 1], 0.9999999995713154868, 1e-12, "Apco", "bpn(2,2)", ref status);
            Vvd(astrom.bpn[2, 1], -0.2928086230000000000e-4, 1e-12, "Apco", "bpn(3,2)", ref status);
            Vvd(astrom.bpn[0, 2], -0.1312227200895260194e-2, 1e-12, "Apco", "bpn(1,3)", ref status);
            Vvd(astrom.bpn[1, 2], 0.2928082217872315680e-4, 1e-12, "Apco", "bpn(2,3)", ref status);
            Vvd(astrom.bpn[2, 2], 0.9999991386008323373, 1e-12, "Apco", "bpn(3,3)", ref status);
            Vvd(astrom.along, -0.5278008060295995734, 1e-12, "Apco", "along", ref status);
            Vvd(astrom.xpl, 0.1133427418130752958e-5, 1e-17, "Apco", "xpl", ref status);
            Vvd(astrom.ypl, 0.1453347595780646207e-5, 1e-17, "Apco", "ypl", ref status);
            Vvd(astrom.sphi, -0.9440115679003211329, 1e-12, "Apco", "sphi", ref status);
            Vvd(astrom.cphi, 0.3299123514971474711, 1e-12, "Apco", "cphi", ref status);
            Vvd(astrom.diurab, 0, 0, "Apco", "diurab", ref status);
            Vvd(astrom.eral, 2.617608903970400427, 1e-12, "Apco", "eral", ref status);
            Vvd(astrom.refa, 0.2014187790000000000e-3, 1e-15, "Apco", "refa", ref status);
            Vvd(astrom.refb, -0.2361408310000000000e-6, 1e-18, "Apco", "refb", ref status);

            Assert.Equal(0, status);
        }
    }
}
