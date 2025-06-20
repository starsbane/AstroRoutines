namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Nut00a function.
        /// </summary>
        [Fact]
        public void TestNut00a()
        {
            var status = 0;
            double dpsi, deps;

            Nut00a(2400000.5, 53736.0, out dpsi, out deps);

            Vvd(dpsi, -0.9630909107115518431e-5, 1e-13, "Nut00a", "dpsi", ref status);
            Vvd(deps, 0.4063239174001678710e-4, 1e-13, "Nut00a", "deps", ref status);

            Assert.Equal(0, status);
        }
    }
}
