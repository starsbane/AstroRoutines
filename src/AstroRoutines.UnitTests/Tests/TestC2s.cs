namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test C2s function.
        /// </summary>
        [Fact]
        public void TestC2s()
        {
            var p = new double[3];
            var theta = 0.0;
            var phi = 0.0;
            var status = 0;

            p[0] = 100.0;
            p[1] = -50.0;
            p[2] = 25.0;

            C2s(p, out theta, out phi);

            Vvd(theta, -0.4636476090008061162, 1e-14, "C2s", "theta", ref status);
            Vvd(phi, 0.2199879773954594463, 1e-14, "C2s", "phi", ref status);

            Assert.Equal(0, status);
        }
    }
}
