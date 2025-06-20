namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Tpors function.
        /// </summary>
        [Fact]
        public void TestTpors()
        {
            var status = 0;

            double xi, eta, ra, dec, az1, bz1, az2, bz2;
            int n;

            xi = -0.03;
            eta = 0.07;
            ra = 1.3;
            dec = 1.5;

            n = Tpors(xi, eta, ra, dec, out az1, out bz1, out az2, out bz2);

            Vvd(az1, 1.736621577783208748, 1e-13, "Tpors", "az1", ref status);
            Vvd(bz1, 1.436736561844090323, 1e-13, "Tpors", "bz1", ref status);

            Vvd(az2, 4.004971075806584490, 1e-13, "Tpors", "az2", ref status);
            Vvd(bz2, 1.565084088476417917, 1e-13, "Tpors", "bz2", ref status);

            Viv(n, 2, "Tpors", "n", ref status);

            Assert.Equal(0, status);
        }
    }
}
