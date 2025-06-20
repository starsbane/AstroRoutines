namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Refco function.
        /// </summary>
        [Fact]
        public void TestRefco()
        {
            var status = 0;

            var phpa = 800.0;
            var tc = 10.0;
            var rh = 0.9;
            var wl = 0.4;

            Refco(phpa, tc, rh, wl, out var refa, out var refb);

            Vvd(refa, 0.2264949956241415009e-3, 1e-15, "Refco", "refa", ref status);
            Vvd(refb, -0.2598658261729343970e-6, 1e-18, "Refco", "refb", ref status);

            Assert.Equal(0, status);
        }
    }
}
