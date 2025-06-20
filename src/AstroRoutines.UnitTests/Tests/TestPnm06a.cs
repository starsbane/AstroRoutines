namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pnm06a function.
        /// </summary>
        [Fact]
        public void TestPnm06a()
        {
            var rbpn = new double[3, 3];
            var status = 0;

            Pnm06a(2400000.5, 50123.9999, ref rbpn);

            Vvd(rbpn[0, 0], 0.9999995832794205484, 1e-12, "Pnm06a", "11", ref status);
            Vvd(rbpn[0, 1], 0.8372382772630962111e-3, 1e-14, "Pnm06a", "12", ref status);
            Vvd(rbpn[0, 2], 0.3639684771140623099e-3, 1e-14, "Pnm06a", "13", ref status);

            Vvd(rbpn[1, 0], -0.8372533744743683605e-3, 1e-14, "Pnm06a", "21", ref status);
            Vvd(rbpn[1, 1], 0.9999996486492861646, 1e-12, "Pnm06a", "22", ref status);
            Vvd(rbpn[1, 2], 0.4132905944611019498e-4, 1e-14, "Pnm06a", "23", ref status);

            Vvd(rbpn[2, 0], -0.3639337469629464969e-3, 1e-14, "Pnm06a", "31", ref status);
            Vvd(rbpn[2, 1], -0.4163377605910663999e-4, 1e-14, "Pnm06a", "32", ref status);
            Vvd(rbpn[2, 2], 0.9999999329094260057, 1e-12, "Pnm06a", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
