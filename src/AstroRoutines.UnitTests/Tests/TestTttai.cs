namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tttai function.
        /// </summary>
        [Fact]
        public void TestTttai()
        {
            var status = 0;

            double a1 = 0, a2 = 0;

            var j = Tttai(2453750.5, 0.892482639, ref a1, ref a2);

            Vvd(a1, 2453750.5, 1e-6, "Tttai", "a1", ref status);
            Vvd(a2, 0.892110139, 1e-12, "Tttai", "a2", ref status);

            Viv(j, 0, "Tttai", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
