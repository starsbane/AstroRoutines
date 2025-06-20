namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Nut06a function.
        /// </summary>
        [Fact]
        public void TestNut06a()
        {
            var status = 0;
            double dpsi, deps;

            Nut06a(2400000.5, 53736.0, out dpsi, out deps);

            Vvd(dpsi, -0.9630912025820308797e-5, 1e-13, "Nut06a", "dpsi", ref status);
            Vvd(deps, 0.4063238496887249798e-4, 1e-13, "Nut06a", "deps", ref status);

            Assert.Equal(0, status);
        }
    }
}
