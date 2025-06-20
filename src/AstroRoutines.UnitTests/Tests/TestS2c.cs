namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test S2c function.
        /// </summary>
        [Fact]
        public void TestS2c()
        {
            var status = 0;

            var c = new double[3];

            S2c(3.0123, -0.999, ref c);

            Vvd(c[0], -0.5366267667260523906, 1e-12, "S2c", "1", ref status);
            Vvd(c[1], 0.0697711109765145365, 1e-12, "S2c", "2", ref status);
            Vvd(c[2], -0.8409302618566214041, 1e-12, "S2c", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
