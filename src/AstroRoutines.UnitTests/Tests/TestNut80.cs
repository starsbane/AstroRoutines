namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Nut80 function.
        /// </summary>
        [Fact]
        public void TestNut80()
        {
            var status = 0;
            double dpsi, deps;

            Nut80(2400000.5, 53736.0, out dpsi, out deps);

            Vvd(dpsi, -0.9643658353226563966e-5, 1e-13, "Nut80", "dpsi", ref status);
            Vvd(deps, 0.4060051006879713322e-4, 1e-13, "Nut80", "deps", ref status);

            Assert.Equal(0, status);
        }
    }
}
