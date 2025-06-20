namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pn00b function.
        /// </summary>
        [Fact]
        public void TestPn00b()
        {
            var status = 0;

            Pn00b(2400000.5, 53736.0, out var dpsi, out var deps, out var epsa, out var rb, out var rp, out var rbp, out var rn, out var rbpn);

            Vvd(dpsi, -0.9632552291148362783e-5, 1e-12, "Pn00b", "dpsi", ref status);
            Vvd(deps, 0.4063197106621159367e-4, 1e-12, "Pn00b", "deps", ref status);
            Vvd(epsa, 0.4090791789404229916, 1e-12, "Pn00b", "epsa", ref status);

            Vvd(rb[0, 0], 0.9999999999999942498, 1e-12, "Pn00b", "rb11", ref status);
            Vvd(rb[0, 1], -0.7078279744199196626e-7, 1e-16, "Pn00b", "rb12", ref status);
            Vvd(rb[0, 2], 0.8056217146976134152e-7, 1e-16, "Pn00b", "rb13", ref status);

            Vvd(rb[1, 0], 0.7078279477857337206e-7, 1e-16, "Pn00b", "rb21", ref status);
            Vvd(rb[1, 1], 0.9999999999999969484, 1e-12, "Pn00b", "rb22", ref status);
            Vvd(rb[1, 2], 0.3306041454222136517e-7, 1e-16, "Pn00b", "rb23", ref status);

            Vvd(rb[2, 0], -0.8056217380986972157e-7, 1e-16, "Pn00b", "rb31", ref status);
            Vvd(rb[2, 1], -0.3306040883980552500e-7, 1e-16, "Pn00b", "rb32", ref status);
            Vvd(rb[2, 2], 0.9999999999999962084, 1e-12, "Pn00b", "rb33", ref status);

            Vvd(rp[0, 0], 0.9999989300532289018, 1e-12, "Pn00b", "rp11", ref status);
            Vvd(rp[0, 1], -0.1341647226791824349e-2, 1e-14, "Pn00b", "rp12", ref status);
            Vvd(rp[0, 2], -0.5829880927190296547e-3, 1e-14, "Pn00b", "rp13", ref status);

            Vvd(rp[1, 0], 0.1341647231069759008e-2, 1e-14, "Pn00b", "rp21", ref status);
            Vvd(rp[1, 1], 0.9999990999908750433, 1e-12, "Pn00b", "rp22", ref status);
            Vvd(rp[1, 2], -0.3837444441583715468e-6, 1e-14, "Pn00b", "rp23", ref status);

            Vvd(rp[2, 0], 0.5829880828740957684e-3, 1e-14, "Pn00b", "rp31", ref status);
            Vvd(rp[2, 1], -0.3984203267708834759e-6, 1e-14, "Pn00b", "rp32", ref status);
            Vvd(rp[2, 2], 0.9999998300623538046, 1e-12, "Pn00b", "rp33", ref status);

            Vvd(rbp[0, 0], 0.9999989300052243993, 1e-12, "Pn00b", "rbp11", ref status);
            Vvd(rbp[0, 1], -0.1341717990239703727e-2, 1e-14, "Pn00b", "rbp12", ref status);
            Vvd(rbp[0, 2], -0.5829075749891684053e-3, 1e-14, "Pn00b", "rbp13", ref status);

            Vvd(rbp[1, 0], 0.1341718013831739992e-2, 1e-14, "Pn00b", "rbp21", ref status);
            Vvd(rbp[1, 1], 0.9999990998959191343, 1e-12, "Pn00b", "rbp22", ref status);
            Vvd(rbp[1, 2], -0.3505759733565421170e-6, 1e-14, "Pn00b", "rbp23", ref status);

            Vvd(rbp[2, 0], 0.5829075206857717883e-3, 1e-14, "Pn00b", "rbp31", ref status);
            Vvd(rbp[2, 1], -0.4315219955198608970e-6, 1e-14, "Pn00b", "rbp32", ref status);
            Vvd(rbp[2, 2], 0.9999998301093036269, 1e-12, "Pn00b", "rbp33", ref status);

            Vvd(rn[0, 0], 0.9999999999536069682, 1e-12, "Pn00b", "rn11", ref status);
            Vvd(rn[0, 1], 0.8837746144871248011e-5, 1e-14, "Pn00b", "rn12", ref status);
            Vvd(rn[0, 2], 0.3831488838252202945e-5, 1e-14, "Pn00b", "rn13", ref status);

            Vvd(rn[1, 0], -0.8837590456632304720e-5, 1e-14, "Pn00b", "rn21", ref status);
            Vvd(rn[1, 1], 0.9999999991354692733, 1e-12, "Pn00b", "rn22", ref status);
            Vvd(rn[1, 2], -0.4063198798559591654e-4, 1e-14, "Pn00b", "rn23", ref status);

            Vvd(rn[2, 0], -0.3831847930134941271e-5, 1e-14, "Pn00b", "rn31", ref status);
            Vvd(rn[2, 1], 0.4063195412258168380e-4, 1e-14, "Pn00b", "rn32", ref status);
            Vvd(rn[2, 2], 0.9999999991671806225, 1e-12, "Pn00b", "rn33", ref status);

            Vvd(rbpn[0, 0], 0.9999989440499982806, 1e-12, "Pn00b", "rbpn11", ref status);
            Vvd(rbpn[0, 1], -0.1332880253640849194e-2, 1e-14, "Pn00b", "rbpn12", ref status);
            Vvd(rbpn[0, 2], -0.5790760898731091166e-3, 1e-14, "Pn00b", "rbpn13", ref status);

            Vvd(rbpn[1, 0], 0.1332856746979949638e-2, 1e-14, "Pn00b", "rbpn21", ref status);
            Vvd(rbpn[1, 1], 0.9999991109064768883, 1e-12, "Pn00b", "rbpn22", ref status);
            Vvd(rbpn[1, 2], -0.4097740555723081811e-4, 1e-14, "Pn00b", "rbpn23", ref status);

            Vvd(rbpn[2, 0], 0.5791301929950208873e-3, 1e-14, "Pn00b", "rbpn31", ref status);
            Vvd(rbpn[2, 1], 0.4020553681373720832e-4, 1e-14, "Pn00b", "rbpn32", ref status);
            Vvd(rbpn[2, 2], 0.9999998314958529887, 1e-12, "Pn00b", "rbpn33", ref status);

            Assert.Equal(0, status);
        }
    }
}
