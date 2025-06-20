namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Prec76 function.
        /// </summary>
        [Fact]
        public void TestPrec76()
        {
            var status = 0;

            var ep01 = 2400000.5;
            var ep02 = 33282.0;
            var ep11 = 2400000.5;
            var ep12 = 51544.0;

            Prec76(ep01, ep02, ep11, ep12, out var zeta, out var z, out var theta);

            Vvd(zeta, 0.5588961642000161243e-2, 1e-12, "Prec76", "zeta", ref status);
            Vvd(z, 0.5589922365870680624e-2, 1e-12, "Prec76", "z", ref status);
            Vvd(theta, 0.4858945471687296760e-2, 1e-12, "Prec76", "theta", ref status);

            Assert.Equal(0, status);
        }
    }
}
