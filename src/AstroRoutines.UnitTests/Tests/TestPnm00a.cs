namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pnm00a function.
        /// </summary>
        [Fact]
        public void TestPnm00a()
        {
            var rbpn = new double[3, 3];
            var status = 0;

            Pnm00a(2400000.5, 50123.9999, out rbpn);

            Vvd(rbpn[0, 0], 0.9999995832793134257, 1e-12, "Pnm00a", "11", ref status);
            Vvd(rbpn[0, 1], 0.8372384254137809439e-3, 1e-14, "Pnm00a", "12", ref status);
            Vvd(rbpn[0, 2], 0.3639684306407150645e-3, 1e-14, "Pnm00a", "13", ref status);

            Vvd(rbpn[1, 0], -0.8372535226570394543e-3, 1e-14, "Pnm00a", "21", ref status);
            Vvd(rbpn[1, 1], 0.9999996486491582471, 1e-12, "Pnm00a", "22", ref status);
            Vvd(rbpn[1, 2], 0.4132915262664072381e-4, 1e-14, "Pnm00a", "23", ref status);

            Vvd(rbpn[2, 0], -0.3639337004054317729e-3, 1e-14, "Pnm00a", "31", ref status);
            Vvd(rbpn[2, 1], -0.4163386925461775873e-4, 1e-14, "Pnm00a", "32", ref status);
            Vvd(rbpn[2, 2], 0.9999999329094390695, 1e-12, "Pnm00a", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
