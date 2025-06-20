namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pv2s function.
        /// </summary>
        [Fact]
        public void TestPv2s()
        {
            var status = 0;

            var pv = new double[2, 3];
            double theta, phi, r, td, pd, rd;

            pv[0, 0] = -0.4514964673880165;
            pv[0, 1] = 0.03093394277342585;
            pv[0, 2] = 0.05594668105108779;

            pv[1, 0] = 1.292270850663260e-5;
            pv[1, 1] = 2.652814182060692e-6;
            pv[1, 2] = 2.568431853930293e-6;

            Pv2s(pv, out theta, out phi, out r, out td, out pd, out rd);

            Vvd(theta, 3.073185307179586515, 1e-12, "Pv2s", "theta", ref status);
            Vvd(phi, 0.1229999999999999992, 1e-12, "Pv2s", "phi", ref status);
            Vvd(r, 0.4559999999999999757, 1e-12, "Pv2s", "r", ref status);
            Vvd(td, -0.7800000000000000364e-5, 1e-16, "Pv2s", "td", ref status);
            Vvd(pd, 0.9010000000000001639e-5, 1e-16, "Pv2s", "pd", ref status);
            Vvd(rd, -0.1229999999999999832e-4, 1e-16, "Pv2s", "rd", ref status);

            Assert.Equal(0, status);
        }
    }
}
