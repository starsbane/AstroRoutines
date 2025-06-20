namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Rxpv function.
        /// </summary>
        [Fact]
        public void TestRxpv()
        {
            var status = 0;

            var r = new double[3, 3];
            var pv = new double[2, 3];
            var rpv = new double[2, 3];

            r[0, 0] = 2.0;
            r[0, 1] = 3.0;
            r[0, 2] = 2.0;

            r[1, 0] = 3.0;
            r[1, 1] = 2.0;
            r[1, 2] = 3.0;

            r[2, 0] = 3.0;
            r[2, 1] = 4.0;
            r[2, 2] = 5.0;

            pv[0, 0] = 0.2;
            pv[0, 1] = 1.5;
            pv[0, 2] = 0.1;

            pv[1, 0] = 1.5;
            pv[1, 1] = 0.2;
            pv[1, 2] = 0.1;

            Rxpv(r, pv, ref rpv);

            Vvd(rpv[0, 0], 5.1, 1e-12, "Rxpv", "p1", ref status);
            Vvd(rpv[1, 0], 3.8, 1e-12, "Rxpv", "v1", ref status);

            Vvd(rpv[0, 1], 3.9, 1e-12, "Rxpv", "p2", ref status);
            Vvd(rpv[1, 1], 5.2, 1e-12, "Rxpv", "v2", ref status);

            Vvd(rpv[0, 2], 7.1, 1e-12, "Rxpv", "p3", ref status);
            Vvd(rpv[1, 2], 5.8, 1e-12, "Rxpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
