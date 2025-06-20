namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Sxpv function.
        /// </summary>
        [Fact]
        public void TestSxpv()
        {
            var status = 0;

            var s = 2.0;
            var pv = new double[2, 3];
            var spv = new double[2, 3];

            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = 0.5;
            pv[1, 1] = 3.2;
            pv[1, 2] = -0.7;

            Sxpv(s, pv, ref spv);

            Vvd(spv[0, 0], 0.6, 0.0, "Sxpv", "p1", ref status);
            Vvd(spv[0, 1], 2.4, 0.0, "Sxpv", "p2", ref status);
            Vvd(spv[0, 2], -5.0, 0.0, "Sxpv", "p3", ref status);

            Vvd(spv[1, 0], 1.0, 0.0, "Sxpv", "v1", ref status);
            Vvd(spv[1, 1], 6.4, 0.0, "Sxpv", "v2", ref status);
            Vvd(spv[1, 2], -1.4, 0.0, "Sxpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
