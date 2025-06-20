namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Starpv function.
        /// </summary>
        [Fact]
        public void TestStarpv()
        {
            var status = 0;

            var ra = 0.01686756;
            var dec = -1.093989828;
            var pmr = -1.78323516e-5;
            var pmd = 2.336024047e-6;
            var px = 0.74723;
            var rv = -21.6;

            var pv = new double[2, 3];

            var j = Starpv(ra, dec, pmr, pmd, px, rv, ref pv);

            Vvd(pv[0, 0], 126668.5912743160601, 1e-10, "Starpv", "11", ref status);
            Vvd(pv[0, 1], 2136.792716839935195, 1e-12, "Starpv", "12", ref status);
            Vvd(pv[0, 2], -245251.2339876830091, 1e-10, "Starpv", "13", ref status);

            Vvd(pv[1, 0], -0.4051854008955659551e-2, 1e-13, "Starpv", "21", ref status);
            Vvd(pv[1, 1], -0.6253919754414777970e-2, 1e-15, "Starpv", "22", ref status);
            Vvd(pv[1, 2], 0.1189353714588109341e-1, 1e-13, "Starpv", "23", ref status);

            Viv(j, 0, "Starpv", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
