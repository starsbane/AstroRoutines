namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test P2s function.
        /// </summary>
        [Fact]
        public void TestP2s()
        {
            var status = 0;
            var p = new double[3];

            p[0] = 100.0;
			p[1] = -50.0;
			p[2] =  25.0;

            P2s(p, out var theta, out var phi, out var r);

            Vvd(theta, -0.4636476090008061162, 1e-12, "P2s", "theta", ref status);
            Vvd(phi, 0.2199879773954594463, 1e-12, "P2s", "phi", ref status);
            Vvd(r, 114.5643923738960002, 1e-9, "P2s", "r", ref status);

            Assert.Equal(0, status);
        }
    }
}
