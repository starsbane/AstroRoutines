namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Rxp function.
        /// </summary>
        [Fact]
        public void TestRxp()
        {
            var status = 0;

            var r = new double[3, 3];
            var p = new double[3];
            var rp = new double[3];

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

            Rxp(r, p, ref rp);

            Vvd(rp[0], 5.1, 1e-12, "Rxp", "1", ref status);
            Vvd(rp[1], 3.9, 1e-12, "Rxp", "2", ref status);
            Vvd(rp[2], 7.1, 1e-12, "Rxp", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
