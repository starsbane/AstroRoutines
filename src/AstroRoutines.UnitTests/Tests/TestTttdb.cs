namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tttdb function.
        /// </summary>
        [Fact]
        public void TestTttdb()
        {
            var status = 0;

            double b1 = 0, b2 = 0;

            var j = Tttdb(2453750.5, 0.892855139, -0.000201, ref b1, ref b2);

            Vvd(b1, 2453750.5, 1e-6, "Tttdb", "b1", ref status);
            Vvd(b2, 0.8928551366736111111, 1e-12, "Tttdb", "b2", ref status);

            Viv(j, 0, "Tttdb", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
