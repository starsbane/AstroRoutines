namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Pn06 function.
        /// </summary>
        [Fact]
        public void TestPn06()
        {
            var dpsi = -0.9632552291149335877e-5;
            var deps = 0.4063197106621141414e-4;
            double epsa;
            var rb = new double[3, 3];
            var rp = new double[3, 3];
            var rbp = new double[3, 3];
            var rn = new double[3, 3];
            var rbpn = new double[3, 3];
            var status = 0;

            Pn06(2400000.5, 53736.0, dpsi, deps, out epsa, out rb, out rp, out rbp, out rn, out rbpn);

            Vvd(epsa, 0.4090789763356509926, 1e-12, "Pn06", "epsa", ref status);

            Vvd(rb[0, 0], 0.9999999999999942497, 1e-12, "Pn06", "rb11", ref status);
            Vvd(rb[0, 1], -0.7078368960971557145e-7, 1e-14, "Pn06", "rb12", ref status);
            Vvd(rb[0, 2], 0.8056213977613185606e-7, 1e-14, "Pn06", "rb13", ref status);

            Vvd(rb[1, 0], 0.7078368694637674333e-7, 1e-14, "Pn06", "rb21", ref status);
            Vvd(rb[1, 1], 0.9999999999999969484, 1e-12, "Pn06", "rb22", ref status);
            Vvd(rb[1, 2], 0.3305943742989134124e-7, 1e-14, "Pn06", "rb23", ref status);

            Vvd(rb[2, 0], -0.8056214211620056792e-7, 1e-14, "Pn06", "rb31", ref status);
            Vvd(rb[2, 1], -0.3305943172740586950e-7, 1e-14, "Pn06", "rb32", ref status);
            Vvd(rb[2, 2], 0.9999999999999962084, 1e-12, "Pn06", "rb33", ref status);

            Vvd(rp[0, 0], 0.9999989300536854831, 1e-12, "Pn06", "rp11", ref status);
            Vvd(rp[0, 1], -0.1341646886204443795e-2, 1e-14, "Pn06", "rp12", ref status);
            Vvd(rp[0, 2], -0.5829880933488627759e-3, 1e-14, "Pn06", "rp13", ref status);

            Vvd(rp[1, 0], 0.1341646890569782183e-2, 1e-14, "Pn06", "rp21", ref status);
            Vvd(rp[1, 1], 0.9999990999913319321, 1e-12, "Pn06", "rp22", ref status);
            Vvd(rp[1, 2], -0.3835944216374477457e-6, 1e-14, "Pn06", "rp23", ref status);

            Vvd(rp[2, 0], 0.5829880833027867368e-3, 1e-14, "Pn06", "rp31", ref status);
            Vvd(rp[2, 1], -0.3985701514686976112e-6, 1e-14, "Pn06", "rp32", ref status);
            Vvd(rp[2, 2], 0.9999998300623534950, 1e-12, "Pn06", "rp33", ref status);

            Vvd(rbp[0, 0], 0.9999989300056797893, 1e-12, "Pn06", "rbp11", ref status);
            Vvd(rbp[0, 1], -0.1341717650545059598e-2, 1e-14, "Pn06", "rbp12", ref status);
            Vvd(rbp[0, 2], -0.5829075756493728856e-3, 1e-14, "Pn06", "rbp13", ref status);

            Vvd(rbp[1, 0], 0.1341717674223918101e-2, 1e-14, "Pn06", "rbp21", ref status);
            Vvd(rbp[1, 1], 0.9999990998963748448, 1e-12, "Pn06", "rbp22", ref status);
            Vvd(rbp[1, 2], -0.3504269280170069029e-6, 1e-14, "Pn06", "rbp23", ref status);

            Vvd(rbp[2, 0], 0.5829075211461454599e-3, 1e-14, "Pn06", "rbp31", ref status);
            Vvd(rbp[2, 1], -0.4316708436255949093e-6, 1e-14, "Pn06", "rbp32", ref status);
            Vvd(rbp[2, 2], 0.9999998301093032943, 1e-12, "Pn06", "rbp33", ref status);

            Vvd(rn[0, 0], 0.9999999999536069682, 1e-12, "Pn06", "rn11", ref status);
            Vvd(rn[0, 1], 0.8837746921149881914e-5, 1e-14, "Pn06", "rn12", ref status);
            Vvd(rn[0, 2], 0.3831487047682968703e-5, 1e-14, "Pn06", "rn13", ref status);

            Vvd(rn[1, 0], -0.8837591232983692340e-5, 1e-14, "Pn06", "rn21", ref status);
            Vvd(rn[1, 1], 0.9999999991354692664, 1e-12, "Pn06", "rn22", ref status);
            Vvd(rn[1, 2], -0.4063198798558931215e-4, 1e-14, "Pn06", "rn23", ref status);

            Vvd(rn[2, 0], -0.3831846139597250235e-5, 1e-14, "Pn06", "rn31", ref status);
            Vvd(rn[2, 1], 0.4063195412258792914e-4, 1e-14, "Pn06", "rn32", ref status);
            Vvd(rn[2, 2], 0.9999999991671806293, 1e-12, "Pn06", "rn33", ref status);

            Vvd(rbpn[0, 0], 0.9999989440504506688, 1e-12, "Pn06", "rbpn11", ref status);
            Vvd(rbpn[0, 1], -0.1332879913170492655e-2, 1e-14, "Pn06", "rbpn12", ref status);
            Vvd(rbpn[0, 2], -0.5790760923225655753e-3, 1e-14, "Pn06", "rbpn13", ref status);

            Vvd(rbpn[1, 0], 0.1332856406595754748e-2, 1e-14, "Pn06", "rbpn21", ref status);
            Vvd(rbpn[1, 1], 0.9999991109069366795, 1e-12, "Pn06", "rbpn22", ref status);
            Vvd(rbpn[1, 2], -0.4097725651142641812e-4, 1e-14, "Pn06", "rbpn23", ref status);

            Vvd(rbpn[2, 0], 0.5791301952321296716e-3, 1e-14, "Pn06", "rbpn31", ref status);
            Vvd(rbpn[2, 1], 0.4020538796195230577e-4, 1e-14, "Pn06", "rbpn32", ref status);
            Vvd(rbpn[2, 2], 0.9999998314958576778, 1e-12, "Pn06", "rbpn33", ref status);

            Assert.Equal(0, status);
        }
    }
}
