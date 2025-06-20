namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test S2p function.
        /// </summary>
        [Fact]
        public void TestS2p()
        {
            var status = 0;

            var p = new double[3];

            S2p(-3.21, 0.123, 0.456, ref p);

            Vvd(p[0], -0.4514964673880165228, 1e-12, "S2p", "x", ref status);
            Vvd(p[1], 0.0309339427734258688, 1e-12, "S2p", "y", ref status);
            Vvd(p[2], 0.0559466810510877933, 1e-12, "S2p", "z", ref status);

            Assert.Equal(0, status);
        }
    }
}
