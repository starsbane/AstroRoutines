namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Gd2gce function.
        /// </summary>
        [Fact]
        public void TestGd2gce()
        {
            var status = 0;
            double a = 6378136.0, f = 0.0033528;
            double e = 3.1, p = -0.5, h = 2500.0;
            var xyz = new double[3];

            var j = Gd2gce(a, f, e, p, h, out xyz);
            Viv(j, 0, "Gd2gce", "j", ref status);
            Vvd(xyz[0], -5598999.6665116328, 1e-7, "Gd2gce", "1", ref status);
            Vvd(xyz[1], 233011.6351463057189, 1e-7, "Gd2gce", "2", ref status);
            Vvd(xyz[2], -3040909.0517314132, 1e-7, "Gd2gce", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
