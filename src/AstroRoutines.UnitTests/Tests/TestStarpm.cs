namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Starpm function.
        /// </summary>
        [Fact]
        public void TestStarpm()
        {
            var status = 0;

            var ra1 = 0.01686756;
            var dec1 = -1.093989828;
            var pmr1 = -1.78323516e-5;
            var pmd1 = 2.336024047e-6;
            var px1 = 0.74723;
            var rv1 = -21.6;

            double ra2, dec2, pmr2, pmd2, px2, rv2;

            var j = Starpm(ra1, dec1, pmr1, pmd1, px1, rv1,
                           2400000.5, 50083.0, 2400000.5, 53736.0,
                           out ra2, out dec2, out pmr2, out pmd2, out px2, out rv2);

            Vvd(ra2, 0.01668919069414256149, 1e-13, "Starpm", "ra", ref status);
            Vvd(dec2, -1.093966454217127897, 1e-13, "Starpm", "dec", ref status);
            Vvd(pmr2, -0.1783662682153176524e-4, 1e-17, "Starpm", "pmr", ref status);
            Vvd(pmd2, 0.2338092915983989595e-5, 1e-17, "Starpm", "pmd", ref status);
            Vvd(px2, 0.7473533835317719243, 1e-13, "Starpm", "px", ref status);
            Vvd(rv2, -21.59905170476417175, 1e-11, "Starpm", "rv", ref status);

            Viv(j, 0, "Starpm", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
