namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Tpsts function.
        /// </summary>
        [Fact]
        public void TestTpsts()
        {
            var status = 0;

            double xi, eta, raz, decz, ra = 0, dec = 0;

            xi = -0.03;
            eta = 0.07;
            raz = 2.3;
            decz = 1.5;

            Tpsts(xi, eta, raz, decz, ref ra, ref dec);

            Vvd(ra, 0.7596127167359629775, 1e-14, "Tpsts", "ra", ref status);
            Vvd(dec, 1.540864645109263028, 1e-13, "Tpsts", "dec", ref status);

            Assert.Equal(0, status);
        }
    }
}
