namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Trxp function.
        /// </summary>
        [Fact]
        public void TestTrxp()
        {
            var status = 0;
            var r = new double[3, 3];
            var p = new double[3];
            var trp = new double[3];

            r[0, 0] = 2.0;
            r[0, 1] = 3.0;
            r[0, 2] = 2.0;

            r[1, 0] = 3.0;
            r[1, 1] = 2.0;
            r[1, 2] = 3.0;

            r[2, 0] = 3.0;
            r[2, 1] = 4.0;
            r[2, 2] = 5.0;

            p[0] = 0.2;
            p[1] = 1.5;
            p[2] = 0.1;

            Trxp(r, p, ref trp);

            Vvd(trp[0], 5.2, 1e-12, "Trxp", "1", ref status);
            Vvd(trp[1], 4.0, 1e-12, "Trxp", "2", ref status);
            Vvd(trp[2], 5.4, 1e-12, "Trxp", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
