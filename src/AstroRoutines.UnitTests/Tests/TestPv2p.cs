namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pv2p function.
        /// </summary>
        [Fact]
        public void TestPv2p()
        {
            var status = 0;

            var pv = new double[2, 3];
            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = -0.5;
            pv[1, 1] = 3.1;
            pv[1, 2] = 0.9;

            var p = new double[3];

            Pv2p(pv, ref p);

            Vvd(p[0], 0.3, 0.0, "Pv2p", "1", ref status);
            Vvd(p[1], 1.2, 0.0, "Pv2p", "2", ref status);
            Vvd(p[2], -2.5, 0.0, "Pv2p", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
