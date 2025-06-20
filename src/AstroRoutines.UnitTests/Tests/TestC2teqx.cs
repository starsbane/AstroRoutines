namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test C2teqx function.
        /// </summary>
        [Fact]
        public void TestC2teqx()
        {
            var rbpn = new double[3, 3];
            var gst = 1.754166138040730516;
            var rpom = new double[3, 3];
            var rc2t = new double[3, 3];
            var status = 0;

            rbpn[0, 0] = 0.9999989440476103608;
            rbpn[0, 1] = -0.1332881761240011518e-2;
            rbpn[0, 2] = -0.5790767434730085097e-3;

            rbpn[1, 0] = 0.1332858254308954453e-2;
            rbpn[1, 1] = 0.9999991109044505944;
            rbpn[1, 2] = -0.4097782710401555759e-4;

            rbpn[2, 0] = 0.5791308472168153320e-3;
            rbpn[2, 1] = 0.4020595661593994396e-4;
            rbpn[2, 2] = 0.9999998314954572365;

            rpom[0, 0] = 0.9999999999999674705;
            rpom[0, 1] = -0.1367174580728847031e-10;
            rpom[0, 2] = 0.2550602379999972723e-6;

            rpom[1, 0] = 0.1414624947957029721e-10;
            rpom[1, 1] = 0.9999999999982694954;
            rpom[1, 2] = -0.1860359246998866338e-5;

            rpom[2, 0] = -0.2550602379741215275e-6;
            rpom[2, 1] = 0.1860359247002413923e-5;
            rpom[2, 2] = 0.9999999999982369658;

            C2teqx(rbpn, gst, rpom, out rc2t);

            Vvd(rc2t[0, 0], -0.1810332128528685730, 1e-12, "C2teqx", "11", ref status);
            Vvd(rc2t[0, 1], 0.9834769806897685071, 1e-12, "C2teqx", "12", ref status);
            Vvd(rc2t[0, 2], 0.6555535639982634449e-4, 1e-12, "C2teqx", "13", ref status);

            Vvd(rc2t[1, 0], -0.9834768134095211257, 1e-12, "C2teqx", "21", ref status);
            Vvd(rc2t[1, 1], -0.1810332203871023800, 1e-12, "C2teqx", "22", ref status);
            Vvd(rc2t[1, 2], 0.5749801116126438962e-3, 1e-12, "C2teqx", "23", ref status);

            Vvd(rc2t[2, 0], 0.5773474014081539467e-3, 1e-12, "C2teqx", "31", ref status);
            Vvd(rc2t[2, 1], 0.3961832391768640871e-4, 1e-12, "C2teqx", "32", ref status);
            Vvd(rc2t[2, 2], 0.9999998325501691969, 1e-12, "C2teqx", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
