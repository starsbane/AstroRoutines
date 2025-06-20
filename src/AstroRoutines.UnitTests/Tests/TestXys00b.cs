namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Xys00b function.
        /// </summary>
        [Fact]
        public void TestXys00b()
        {
            var status = 0;

            double x = 0, y = 0, s = 0;

            Xys00b(2400000.5, 53736.0, ref x, ref y, ref s);

            Vvd(x, 0.5791301929950208873e-3, 1e-14, "Xys00b", "x", ref status);
            Vvd(y, 0.4020553681373720832e-4, 1e-15, "Xys00b", "y", ref status);
            Vvd(s, -0.1220027377285083189e-7, 1e-18, "Xys00b", "s", ref status);

            Assert.Equal(0, status);
        }
    }
}
