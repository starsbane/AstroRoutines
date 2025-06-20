namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Seps function.
        /// </summary>
        [Fact]
        public void TestSeps()
        {
            var status = 0;

            var al = 1.0;
            var ap = 0.1;

            var bl = 0.2;
            var bp = -3.0;

            var s = Seps(al, ap, bl, bp);

            Vvd(s, 2.346722016996998842, 1e-14, "Seps", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
