namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test S2xpv function.
        /// </summary>
        [Fact]
        public void TestS2xpv()
        {
            var status = 0;

            var s1 = 2.0;
            var s2 = 3.0;
            var pv = new double[2, 3];
            var spv = new double[2, 3];

            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = 0.5;
            pv[1, 1] = 2.3;
            pv[1, 2] = -0.4;

            S2xpv(s1, s2, pv, ref spv);

            Vvd(spv[0, 0], 0.6, 1e-12, "S2xpv", "p1", ref status);
            Vvd(spv[0, 1], 2.4, 1e-12, "S2xpv", "p2", ref status);
            Vvd(spv[0, 2], -5.0, 1e-12, "S2xpv", "p3", ref status);

            Vvd(spv[1, 0], 1.5, 1e-12, "S2xpv", "v1", ref status);
            Vvd(spv[1, 1], 6.9, 1e-12, "S2xpv", "v2", ref status);
            Vvd(spv[1, 2], -1.2, 1e-12, "S2xpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
