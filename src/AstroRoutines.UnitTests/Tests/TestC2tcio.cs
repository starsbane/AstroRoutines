namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test C2tcio function.
        /// </summary>
        [Fact]
        public void TestC2tcio()
        {
            var rc2i = new double[3, 3];
            var era = 1.75283325530307;
            var rpom = new double[3, 3];
            var status = 0;

            rc2i[0, 0] = 0.9999998323037164738;
            rc2i[0, 1] = 0.5581526271714303683e-9;
            rc2i[0, 2] = -0.5791308477073443903e-3;

            rc2i[1, 0] = -0.2384266227524722273e-7;
            rc2i[1, 1] = 0.9999999991917404296;
            rc2i[1, 2] = -0.4020594955030704125e-4;

            rc2i[2, 0] = 0.5791308472168153320e-3;
            rc2i[2, 1] = 0.4020595661593994396e-4;
            rc2i[2, 2] = 0.9999998314954572365;

            era = 1.75283325530307;

            rpom[0, 0] = 0.9999999999999674705;
            rpom[0, 1] = -0.1367174580728847031e-10;
            rpom[0, 2] = 0.2550602379999972723e-6;

            rpom[1, 0] = 0.1414624947957029721e-10;
            rpom[1, 1] = 0.9999999999982694954;
            rpom[1, 2] = -0.1860359246998866338e-5;

            rpom[2, 0] = -0.2550602379741215275e-6;
            rpom[2, 1] = 0.1860359247002413923e-5;
            rpom[2, 2] = 0.9999999999982369658;

            C2tcio(rc2i, era, rpom, out var rc2t);

            Vvd(rc2t[0, 0], -0.1810332128307110439, 1e-12, "C2tcio", "11", ref status);
            Vvd(rc2t[0, 1], 0.9834769806938470149, 1e-12, "C2tcio", "12", ref status);
            Vvd(rc2t[0, 2], 0.6555535638685466874e-4, 1e-12, "C2tcio", "13", ref status);

            Vvd(rc2t[1, 0], -0.9834768134135996657, 1e-12, "C2tcio", "21", ref status);
            Vvd(rc2t[1, 1], -0.1810332203649448367, 1e-12, "C2tcio", "22", ref status);
            Vvd(rc2t[1, 2], 0.5749801116141106528e-3, 1e-12, "C2tcio", "23", ref status);

            Vvd(rc2t[2, 0], 0.5773474014081407076e-3, 1e-12, "C2tcio", "31", ref status);
            Vvd(rc2t[2, 1], 0.3961832391772658944e-4, 1e-12, "C2tcio", "32", ref status);
            Vvd(rc2t[2, 2], 0.9999998325501691969, 1e-12, "C2tcio", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
