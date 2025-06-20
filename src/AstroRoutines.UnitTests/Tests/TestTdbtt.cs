namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Tdbtt function.
        /// </summary>
        [Fact]
        public void TestTdbtt()
        {
            var status = 0;

            double t1, t2;
            int j;

            j = Tdbtt(2453750.5, 0.892855137, -0.000201, out t1, out t2);

            Vvd(t1, 2453750.5, 1e-6, "Tdbtt", "t1", ref status);
            Vvd(t2, 0.8928551393263888889, 1e-12, "Tdbtt", "t2", ref status);
            Viv(j, 0, "Tdbtt", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
