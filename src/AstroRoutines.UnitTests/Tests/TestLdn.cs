using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ldn function.
        /// </summary>
        [Fact]
        public void TestLdn()
        {
            var status = 0;
            int n = 3;
            LDBODY[] b = new LDBODY[n];
            double[] ob = new double[3];
            double[] sc = new double[3];
            double[] sn = new double[3];

            // Initialize bodies
            b[0] = new LDBODY();
            b[0].bm = 0.00028574;
            b[0].dl = 3e-10;
            b[0].pv[0, 0] = -7.81014427;
            b[0].pv[0, 1] = -5.60956681;
            b[0].pv[0, 2] = -1.98079819;
            b[0].pv[1, 0] = 0.0030723249;
            b[0].pv[1, 1] = -0.00406995477;
            b[0].pv[1, 2] = -0.00181335842;

            b[1] = new LDBODY();
            b[1].bm = 0.00095435;
            b[1].dl = 3e-9;
            b[1].pv[0, 0] = 0.738098796;
            b[1].pv[0, 1] = 4.63658692;
            b[1].pv[0, 2] = 1.9693136;
            b[1].pv[1, 0] = -0.00755816922;
            b[1].pv[1, 1] = 0.00126913722;
            b[1].pv[1, 2] = 0.000727999001;

            b[2] = new LDBODY();
            b[2].bm = 1.0;
            b[2].dl = 6e-6;
            b[2].pv[0, 0] = -0.000712174377;
            b[2].pv[0, 1] = -0.00230478303;
            b[2].pv[0, 2] = -0.00105865966;
            b[2].pv[1, 0] = 6.29235213e-6;
            b[2].pv[1, 1] = -3.30888387e-7;
            b[2].pv[1, 2] = -2.96486623e-7;

            ob[0] = -0.974170437;
            ob[1] = -0.2115201;
            ob[2] = -0.0917583114;
            sc[0] = -0.763276255;
            sc[1] = -0.608633767;
            sc[2] = -0.216735543;

            Ldn(n, b, ob, sc, ref sn);

            Vvd(sn[0], -0.7632762579693333866, 1e-12, "Ldn", "1", ref status);
            Vvd(sn[1], -0.6086337636093002660, 1e-12, "Ldn", "2", ref status);
            Vvd(sn[2], -0.2167355420646328159, 1e-12, "Ldn", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
