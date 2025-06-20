namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Tttcg function.
        /// </summary>
        [Fact]
        public void TestTttcg()
        {
            var status = 0;

            double g1 = 0, g2 = 0;
            int j;

            j = Tttcg(2453750.5, 0.892482639, ref g1, ref g2);

            Vvd(g1, 2453750.5, 1e-6, "Tttcg", "g1", ref status);
            Vvd(g2, 0.8924900312508587113, 1e-12, "Tttcg", "g2", ref status);

            Viv(j, 0, "Tttcg", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
