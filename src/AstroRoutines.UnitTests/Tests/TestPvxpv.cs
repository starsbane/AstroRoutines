namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Pvxpv function.
        /// </summary>
        [Fact]
        public void TestPvxpv()
        {
            var status = 0;

            var a = new double[2, 3];
            var b = new double[2, 3];
            var axb = new double[2, 3];

            a[0, 0] = 2.0;
            a[0, 1] = 2.0;
            a[0, 2] = 3.0;

            a[1, 0] = 6.0;
            a[1, 1] = 0.0;
            a[1, 2] = 4.0;

            b[0, 0] = 1.0;
            b[0, 1] = 3.0;
            b[0, 2] = 4.0;

            b[1, 0] = 0.0;
            b[1, 1] = 2.0;
            b[1, 2] = 8.0;

            Pvxpv(a, b, axb);

            Vvd(axb[0, 0], -1.0, 1e-12, "Pvxpv", "p1", ref status);
            Vvd(axb[0, 1], -5.0, 1e-12, "Pvxpv", "p2", ref status);
            Vvd(axb[0, 2], 4.0, 1e-12, "Pvxpv", "p3", ref status);

            Vvd(axb[1, 0], -2.0, 1e-12, "Pvxpv", "v1", ref status);
            Vvd(axb[1, 1], -36.0, 1e-12, "Pvxpv", "v2", ref status);
            Vvd(axb[1, 2], 22.0, 1e-12, "Pvxpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
