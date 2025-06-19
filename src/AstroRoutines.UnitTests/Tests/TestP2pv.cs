using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test P2pv function.
        /// </summary>
        [Fact]
        public void TestP2pv()
        {
            var status = 0;
            double[] p = new double[3];
            double[,] pv = new double[2, 3];

            p[0] = 0.25;
            p[1] = 1.2;
            p[2] = 3.0;

            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = -0.5;
            pv[1, 1] = 3.1;
            pv[1, 2] = 0.9;

            P2pv(p, ref pv);

            Vvd(pv[0, 0], 0.25, 0.0, "P2pv", "p1", ref status);
            Vvd(pv[0, 1], 1.2, 0.0, "P2pv", "p2", ref status);
            Vvd(pv[0, 2], 3.0, 0.0, "P2pv", "p3", ref status);

            Vvd(pv[1, 0], 0.0, 0.0, "P2pv", "v1", ref status);
            Vvd(pv[1, 1], 0.0, 0.0, "P2pv", "v2", ref status);
            Vvd(pv[1, 2], 0.0, 0.0, "P2pv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
