namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tpors function.
        /// </summary>
        [Fact]
        public void TestTpors()
        {
            var status = 0;

            var xi = -0.03;
            var eta = 0.07;
            var ra = 1.3;
            var dec = 1.5;

            var n = Tpors(xi, eta, ra, dec, out var az1, out var bz1, out var az2, out var bz2);

            Vvd(az1, 1.736621577783208748, 1e-13, "Tpors", "az1", ref status);
            Vvd(bz1, 1.436736561844090323, 1e-13, "Tpors", "bz1", ref status);

            Vvd(az2, 4.004971075806584490, 1e-13, "Tpors", "az2", ref status);
            Vvd(bz2, 1.565084088476417917, 1e-13, "Tpors", "bz2", ref status);

            Viv(n, 2, "Tpors", "n", ref status);

            Assert.Equal(0, status);
        }
    }
}
