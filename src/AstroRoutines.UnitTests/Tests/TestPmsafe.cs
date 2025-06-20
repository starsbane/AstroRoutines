namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pmsafe function.
        /// </summary>
        [Fact]
        public void TestPmsafe()
        {
            var ra1 = 1.234;
            var dec1 = 0.789;
            var pmr1 = 1e-5;
            var pmd1 = -2e-5;
            var px1 = 1e-2;
            var rv1 = 10.0;
            var ep1a = 2400000.5;
            var ep1b = 48348.5625;
            var ep2a = 2400000.5;
            var ep2b = 51544.5;
            var ra2 = 0.0;
            var dec2 = 0.0;
            var pmr2 = 0.0;
            var pmd2 = 0.0;
            var px2 = 0.0;
            var rv2 = 0.0;
            var j = 0;
            var status = 0;

            j = Pmsafe(ra1, dec1, pmr1, pmd1, px1, rv1, ep1a, ep1b, ep2a, ep2b, ref ra2, ref dec2, ref pmr2, ref pmd2, ref px2, ref rv2);

            Vvd(ra2, 1.234087484501017061, 1e-12, "Pmsafe", "ra2", ref status);
            Vvd(dec2, 0.7888249982450468567, 1e-12, "Pmsafe", "dec2", ref status);
            Vvd(pmr2, 0.9996457663586073988e-5, 1e-12, "Pmsafe", "pmr2", ref status);
            Vvd(pmd2, -0.2000040085106754565e-4, 1e-16, "Pmsafe", "pmd2", ref status);
            Vvd(px2, 0.9999997295356830666e-2, 1e-12, "Pmsafe", "px2", ref status);
            Vvd(rv2, 10.38468380293920069, 1e-10, "Pmsafe", "rv2", ref status);
            Viv(j, 0, "Pmsafe", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
