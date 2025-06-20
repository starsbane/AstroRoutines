namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test S2pv function.
        /// </summary>
        [Fact]
        public void TestS2pv()
        {
            var status = 0;

            var pv = new double[2, 3];

            S2pv(-3.21, 0.123, 0.456, -7.8e-6, 9.01e-6, -1.23e-5, ref pv);

            Vvd(pv[0, 0], -0.4514964673880165228, 1e-12, "S2pv", "x", ref status);
            Vvd(pv[0, 1], 0.0309339427734258688, 1e-12, "S2pv", "y", ref status);
            Vvd(pv[0, 2], 0.0559466810510877933, 1e-12, "S2pv", "z", ref status);

            Vvd(pv[1, 0], 0.1292270850663260170e-4, 1e-16, "S2pv", "vx", ref status);
            Vvd(pv[1, 1], 0.2652814182060691422e-5, 1e-16, "S2pv", "vy", ref status);
            Vvd(pv[1, 2], 0.2568431853930292259e-5, 1e-16, "S2pv", "vz", ref status);

            Assert.Equal(0, status);
        }
    }
}
