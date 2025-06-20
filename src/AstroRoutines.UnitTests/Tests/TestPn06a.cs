namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pn06a function.
        /// </summary>
        [Fact]
        public void TestPn06a()
        {
            var status = 0;

            Pn06a(2400000.5, 53736.0, out var dpsi, out var deps, out var epsa, out var rb, out var rp, out var rbp, out var rn, out var rbpn);

            Vvd(dpsi, -0.9630912025820308797e-5, 1e-12, "Pn06a", "dpsi", ref status);
            Vvd(deps, 0.4063238496887249798e-4, 1e-12, "Pn06a", "deps", ref status);
            Vvd(epsa, 0.4090789763356509926, 1e-12, "Pn06a", "epsa", ref status);

            Vvd(rb[0, 0], 0.9999999999999942497, 1e-12, "Pn06a", "rb11", ref status);
            Vvd(rb[0, 1], -0.7078368960971557145e-7, 1e-14, "Pn06a", "rb12", ref status);
            Vvd(rb[0, 2], 0.8056213977613185606e-7, 1e-14, "Pn06a", "rb13", ref status);

            Vvd(rb[1, 0], 0.7078368694637674333e-7, 1e-14, "Pn06a", "rb21", ref status);
            Vvd(rb[1, 1], 0.9999999999999969484, 1e-12, "Pn06a", "rb22", ref status);
            Vvd(rb[1, 2], 0.3305943742989134124e-7, 1e-14, "Pn06a", "rb23", ref status);

            Vvd(rb[2, 0], -0.8056214211620056792e-7, 1e-14, "Pn06a", "rb31", ref status);
            Vvd(rb[2, 1], -0.3305943172740586950e-7, 1e-14, "Pn06a", "rb32", ref status);
            Vvd(rb[2, 2], 0.9999999999999962084, 1e-12, "Pn06a", "rb33", ref status);

            Vvd(rp[0, 0], 0.9999989300536854831, 1e-12, "Pn06a", "rp11", ref status);
            Vvd(rp[0, 1], -0.1341646886204443795e-2, 1e-14, "Pn06a", "rp12", ref status);
            Vvd(rp[0, 2], -0.5829880933488627759e-3, 1e-14, "Pn06a", "rp13", ref status);

            Vvd(rp[1, 0], 0.1341646890569782183e-2, 1e-14, "Pn06a", "rp21", ref status);
            Vvd(rp[1, 1], 0.9999990999913319321, 1e-12, "Pn06a", "rp22", ref status);
            Vvd(rp[1, 2], -0.3835944216374477457e-6, 1e-14, "Pn06a", "rp23", ref status);

            Vvd(rp[2, 0], 0.5829880833027867368e-3, 1e-14, "Pn06a", "rp31", ref status);
            Vvd(rp[2, 1], -0.3985701514686976112e-6, 1e-14, "Pn06a", "rp32", ref status);
            Vvd(rp[2, 2], 0.9999998300623534950, 1e-12, "Pn06a", "rp33", ref status);

            Vvd(rbp[0, 0], 0.9999989300056797893, 1e-12, "Pn06a", "rbp11", ref status);
            Vvd(rbp[0, 1], -0.1341717650545059598e-2, 1e-14, "Pn06a", "rbp12", ref status);
            Vvd(rbp[0, 2], -0.5829075756493728856e-3, 1e-14, "Pn06a", "rbp13", ref status);

            Vvd(rbp[1, 0], 0.1341717674223918101e-2, 1e-14, "Pn06a", "rbp21", ref status);
            Vvd(rbp[1, 1], 0.9999990998963748448, 1e-12, "Pn06a", "rbp22", ref status);
            Vvd(rbp[1, 2], -0.3504269280170069029e-6, 1e-14, "Pn06a", "rbp23", ref status);

            Vvd(rbp[2, 0], 0.5829075211461454599e-3, 1e-14, "Pn06a", "rbp31", ref status);
            Vvd(rbp[2, 1], -0.4316708436255949093e-6, 1e-14, "Pn06a", "rbp32", ref status);
            Vvd(rbp[2, 2], 0.9999998301093032943, 1e-12, "Pn06a", "rbp33", ref status);

            Vvd(rn[0, 0], 0.9999999999536227668, 1e-12, "Pn06a", "rn11", ref status);
            Vvd(rn[0, 1], 0.8836241998111535233e-5, 1e-14, "Pn06a", "rn12", ref status);
            Vvd(rn[0, 2], 0.3830834608415287707e-5, 1e-14, "Pn06a", "rn13", ref status);

            Vvd(rn[1, 0], -0.8836086334870740138e-5, 1e-14, "Pn06a", "rn21", ref status);
            Vvd(rn[1, 1], 0.9999999991354657474, 1e-12, "Pn06a", "rn22", ref status);
            Vvd(rn[1, 2], -0.4063240188248455065e-4, 1e-14, "Pn06a", "rn23", ref status);

            Vvd(rn[2, 0], -0.3831193642839398128e-5, 1e-14, "Pn06a", "rn31", ref status);
            Vvd(rn[2, 1], 0.4063236803101479770e-4, 1e-14, "Pn06a", "rn32", ref status);
            Vvd(rn[2, 2], 0.9999999991671663114, 1e-12, "Pn06a", "rn33", ref status);

            Vvd(rbpn[0, 0], 0.9999989440480669738, 1e-12, "Pn06a", "rbpn11", ref status);
            Vvd(rbpn[0, 1], -0.1332881418091915973e-2, 1e-14, "Pn06a", "rbpn12", ref status);
            Vvd(rbpn[0, 2], -0.5790767447612042565e-3, 1e-14, "Pn06a", "rbpn13", ref status);

            Vvd(rbpn[1, 0], 0.1332857911250989133e-2, 1e-14, "Pn06a", "rbpn21", ref status);
            Vvd(rbpn[1, 1], 0.9999991109049141908, 1e-12, "Pn06a", "rbpn22", ref status);
            Vvd(rbpn[1, 2], -0.4097767128546784878e-4, 1e-14, "Pn06a", "rbpn23", ref status);

            Vvd(rbpn[2, 0], 0.5791308482835292617e-3, 1e-14, "Pn06a", "rbpn31", ref status);
            Vvd(rbpn[2, 1], 0.4020580099454020310e-4, 1e-14, "Pn06a", "rbpn32", ref status);
            Vvd(rbpn[2, 2], 0.9999998314954628695, 1e-12, "Pn06a", "rbpn33", ref status);

            Assert.Equal(0, status);
        }
    }
}
