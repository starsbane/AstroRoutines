namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tcgtt function.
        /// </summary>
        [Fact]
        public void TestTcgtt()
        {
            var status = 0;

            double t1, t2;
            int j;

            j = Tcgtt(2453750.5, 0.892862531, out t1, out t2);

            Vvd(t1, 2453750.5, 1e-6, "Tcgtt", "t1", ref status);
            Vvd(t2, 0.8928551387488816828, 1e-12, "Tcgtt", "t2", ref status);
            Viv(j, 0, "Tcgtt", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
