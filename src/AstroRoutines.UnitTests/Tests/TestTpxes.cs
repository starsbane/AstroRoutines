namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Tpxes function.
        /// </summary>
        [Fact]
        public void TestTpxes()
        {
            var status = 0;

            double ra, dec, raz, decz, xi = 0, eta = 0;
            int j;

            ra = 1.3;
            dec = 1.55;
            raz = 2.3;
            decz = 1.5;

            j = Tpxes(ra, dec, raz, decz, ref xi, ref eta);

            Vvd(xi, -0.01753200983236980595, 1e-15, "Tpxes", "xi", ref status);
            Vvd(eta, 0.05962940005778712891, 1e-15, "Tpxes", "eta", ref status);

            Viv(j, 0, "Tpxes", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
