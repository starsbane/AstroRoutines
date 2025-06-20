namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Zpv function.
        /// </summary>
        [Fact]
        public void TestZpv()
        {
            var status = 0;

            var pv = new double[2, 3];

            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = -0.5;
            pv[1, 1] = 3.1;
            pv[1, 2] = 0.9;

            Zpv(ref pv);

            Vvd(pv[0, 0], 0.0, 0.0, "Zpv", "p1", ref status);
            Vvd(pv[0, 1], 0.0, 0.0, "Zpv", "p2", ref status);
            Vvd(pv[0, 2], 0.0, 0.0, "Zpv", "p3", ref status);

            Vvd(pv[1, 0], 0.0, 0.0, "Zpv", "v1", ref status);
            Vvd(pv[1, 1], 0.0, 0.0, "Zpv", "v2", ref status);
            Vvd(pv[1, 2], 0.0, 0.0, "Zpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
