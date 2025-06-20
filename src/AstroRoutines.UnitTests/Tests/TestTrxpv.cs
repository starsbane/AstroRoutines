namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Trxpv function.
        /// </summary>
        [Fact]
        public void TestTrxpv()
        {
            var status = 0;

            var r = new double[3, 3];
            var pv = new double[2, 3];
            var trpv = new double[2, 3];

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

            Trxpv(r, pv, ref trpv);

            Vvd(trpv[0, 0], 5.2, 1e-12, "Trxpv", "p1", ref status);
            Vvd(trpv[0, 1], 4.0, 1e-12, "Trxpv", "p1", ref status);
            Vvd(trpv[0, 2], 5.4, 1e-12, "Trxpv", "p1", ref status);

            Vvd(trpv[1, 0], 3.9, 1e-12, "Trxpv", "v1", ref status);
            Vvd(trpv[1, 1], 5.3, 1e-12, "Trxpv", "v2", ref status);
            Vvd(trpv[1, 2], 4.1, 1e-12, "Trxpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
