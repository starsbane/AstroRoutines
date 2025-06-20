namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tdbtcb function.
        /// </summary>
        [Fact]
        public void TestTdbtcb()
        {
            var status = 0;

            double b1, b2;
            int j;

            j = Tdbtcb(2453750.5, 0.892855137, out b1, out b2);

            Vvd(b1, 2453750.5, 1e-6, "Tdbtcb", "b1", ref status);
            Vvd(b2, 0.8930195997253656716, 1e-12, "Tdbtcb", "b2", ref status);
            Viv(j, 0, "Tdbtcb", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
