namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pvtob function.
        /// </summary>
        [Fact]
        public void TestPvtob()
        {
            var status = 0;

            var pv = new double[2, 3];

            var elong = 2.0;
            var phi = 0.5;
            var hm = 3000.0;
            var xp = 1e-6;
            var yp = -0.5e-6;
            var sp = 1e-8;
            var theta = 5.0;

            Pvtob(elong, phi, hm, xp, yp, sp, theta, ref pv);

            Vvd(pv[0, 0], 4225081.367071159207, 1e-5, "Pvtob", "p(1)", ref status);
            Vvd(pv[0, 1], 3681943.215856198144, 1e-5, "Pvtob", "p(2)", ref status);
            Vvd(pv[0, 2], 3041149.399241260785, 1e-5, "Pvtob", "p(3)", ref status);
            Vvd(pv[1, 0], -268.4915389365998787, 1e-9, "Pvtob", "v(1)", ref status);
            Vvd(pv[1, 1], 308.0977983288903123, 1e-9, "Pvtob", "v(2)", ref status);
            Vvd(pv[1, 2], 0, 0, "Pvtob", "v(3)", ref status);

            Assert.Equal(0, status);
        }
    }
}
