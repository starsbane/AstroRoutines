namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Tpstv function.
        /// </summary>
        [Fact]
        public void TestTpstv()
        {
            var status = 0;

            double xi, eta, raz, decz;
            var vz = new double[3];
            var v = new double[3];

            xi = -0.03;
            eta = 0.07;
            raz = 2.3;
            decz = 1.5;
            
            S2c(raz, decz, ref vz);

            Tpstv(xi, eta, vz, ref v);

            Vvd(v[0], 0.02170030454907376677, 1e-15, "Tpstv", "x", ref status);
            Vvd(v[1], 0.02060909590535367447, 1e-15, "Tpstv", "y", ref status);
            Vvd(v[2], 0.9995520806583523804, 1e-14, "Tpstv", "z", ref status);

            Assert.Equal(0, status);
        }
    }
}
