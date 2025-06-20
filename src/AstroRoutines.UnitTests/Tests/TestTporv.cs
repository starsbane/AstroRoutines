namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tporv function.
        /// </summary>
        [Fact]
        public void TestTporv()
        {
            var status = 0;

            double xi, eta, ra, dec;
            var v = new double[3];
            var vz1 = new double[3];
            var vz2 = new double[3];
            int n;

            xi = -0.03;
            eta = 0.07;
            ra = 1.3;
            dec = 1.5;

            S2c(ra, dec, ref v);

            n = Tporv(xi, eta, v, ref vz1, ref vz2);

            Vvd(vz1[0], -0.02206252822366888610, 1e-15, "Tporv", "x1", ref status);
            Vvd(vz1[1], 0.1318251060359645016, 1e-14, "Tporv", "y1", ref status);
            Vvd(vz1[2], 0.9910274397144543895, 1e-14, "Tporv", "z1", ref status);

            Vvd(vz2[0], -0.003712211763801968173, 1e-16, "Tporv", "x2", ref status);
            Vvd(vz2[1], -0.004341519956299836813, 1e-16, "Tporv", "y2", ref status);
            Vvd(vz2[2], 0.9999836852110587012, 1e-14, "Tporv", "z2", ref status);
            Viv(n, 2, "Tporv", "n", ref status);

            Assert.Equal(0, status);
        }
    }
}
