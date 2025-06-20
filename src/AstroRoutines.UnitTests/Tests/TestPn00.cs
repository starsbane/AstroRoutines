namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pn00 function.
        /// </summary>
        [Fact]
        public void TestPn00()
        {
            var status = 0;

            var dpsi = -0.9632552291149335877e-5;
            var deps = 0.4063197106621141414e-4;

            Pn00(2400000.5, 53736.0, dpsi, deps, out var epsa, out var rb, out var rp, out var rbp, out var rn, out var rbpn);

            Vvd(epsa, 0.4090791789404229916, 1e-12, "Pn00", "epsa", ref status);

            Vvd(rb[0, 0], 0.9999999999999942498, 1e-12, "Pn00", "rb11", ref status);
            Vvd(rb[0, 1], -0.7078279744199196626e-7, 1e-18, "Pn00", "rb12", ref status);
            Vvd(rb[0, 2], 0.8056217146976134152e-7, 1e-18, "Pn00", "rb13", ref status);

            Vvd(rb[1, 0], 0.7078279477857337206e-7, 1e-18, "Pn00", "rb21", ref status);
            Vvd(rb[1, 1], 0.9999999999999969484, 1e-12, "Pn00", "rb22", ref status);
            Vvd(rb[1, 2], 0.3306041454222136517e-7, 1e-18, "Pn00", "rb23", ref status);

            Vvd(rb[2, 0], -0.8056217380986972157e-7, 1e-18, "Pn00", "rb31", ref status);
            Vvd(rb[2, 1], -0.3306040883980552500e-7, 1e-18, "Pn00", "rb32", ref status);
            Vvd(rb[2, 2], 0.9999999999999962084, 1e-12, "Pn00", "rb33", ref status);

            Vvd(rp[0, 0], 0.9999989300532289018, 1e-12, "Pn00", "rp11", ref status);
            Vvd(rp[0, 1], -0.1341647226791824349e-2, 1e-14, "Pn00", "rp12", ref status);
            Vvd(rp[0, 2], -0.5829880927190296547e-3, 1e-14, "Pn00", "rp13", ref status);

            Vvd(rp[1, 0], 0.1341647231069759008e-2, 1e-14, "Pn00", "rp21", ref status);
            Vvd(rp[1, 1], 0.9999990999908750433, 1e-12, "Pn00", "rp22", ref status);
            Vvd(rp[1, 2], -0.3837444441583715468e-6, 1e-14, "Pn00", "rp23", ref status);

            Vvd(rp[2, 0], 0.5829880828740957684e-3, 1e-14, "Pn00", "rp31", ref status);
            Vvd(rp[2, 1], -0.3984203267708834759e-6, 1e-14, "Pn00", "rp32", ref status);
            Vvd(rp[2, 2], 0.9999998300623538046, 1e-12, "Pn00", "rp33", ref status);

            Vvd(rbp[0, 0], 0.9999989300052243993, 1e-12, "Pn00", "rbp11", ref status);
            Vvd(rbp[0, 1], -0.1341717990239703727e-2, 1e-14, "Pn00", "rbp12", ref status);
            Vvd(rbp[0, 2], -0.5829075749891684053e-3, 1e-14, "Pn00", "rbp13", ref status);

            Vvd(rbp[1, 0], 0.1341718013831739992e-2, 1e-14, "Pn00", "rbp21", ref status);
            Vvd(rbp[1, 1], 0.9999990998959191343, 1e-12, "Pn00", "rbp22", ref status);
            Vvd(rbp[1, 2], -0.3505759733565421170e-6, 1e-14, "Pn00", "rbp23", ref status);

            Vvd(rbp[2, 0], 0.5829075206857717883e-3, 1e-14, "Pn00", "rbp31", ref status);
            Vvd(rbp[2, 1], -0.4315219955198608970e-6, 1e-14, "Pn00", "rbp32", ref status);
            Vvd(rbp[2, 2], 0.9999998301093036269, 1e-12, "Pn00", "rbp33", ref status);

            Vvd(rn[0, 0], 0.9999999999536069682, 1e-12, "Pn00", "rn11", ref status);
            Vvd(rn[0, 1], 0.8837746144872140812e-5, 1e-16, "Pn00", "rn12", ref status);
            Vvd(rn[0, 2], 0.3831488838252590008e-5, 1e-16, "Pn00", "rn13", ref status);

            Vvd(rn[1, 0], -0.8837590456633197506e-5, 1e-16, "Pn00", "rn21", ref status);
            Vvd(rn[1, 1], 0.9999999991354692733, 1e-12, "Pn00", "rn22", ref status);
            Vvd(rn[1, 2], -0.4063198798559573702e-4, 1e-16, "Pn00", "rn23", ref status);

            Vvd(rn[2, 0], -0.3831847930135328368e-5, 1e-16, "Pn00", "rn31", ref status);
            Vvd(rn[2, 1], 0.4063195412258150427e-4, 1e-16, "Pn00", "rn32", ref status);
            Vvd(rn[2, 2], 0.9999999991671806225, 1e-12, "Pn00", "rn33", ref status);

            Vvd(rbpn[0, 0], 0.9999989440499982806, 1e-12, "Pn00", "rbpn11", ref status);
            Vvd(rbpn[0, 1], -0.1332880253640848301e-2, 1e-14, "Pn00", "rbpn12", ref status);
            Vvd(rbpn[0, 2], -0.5790760898731087295e-3, 1e-14, "Pn00", "rbpn13", ref status);

            Vvd(rbpn[1, 0], 0.1332856746979948745e-2, 1e-14, "Pn00", "rbpn21", ref status);
            Vvd(rbpn[1, 1], 0.9999991109064768883, 1e-12, "Pn00", "rbpn22", ref status);
            Vvd(rbpn[1, 2], -0.4097740555723063806e-4, 1e-14, "Pn00", "rbpn23", ref status);

            Vvd(rbpn[2, 0], 0.5791301929950205000e-3, 1e-14, "Pn00", "rbpn31", ref status);
            Vvd(rbpn[2, 1], 0.4020553681373702931e-4, 1e-14, "Pn00", "rbpn32", ref status);
            Vvd(rbpn[2, 2], 0.9999998314958529887, 1e-12, "Pn00", "rbpn33", ref status);

            Assert.Equal(0, status);
        }
    }
}
