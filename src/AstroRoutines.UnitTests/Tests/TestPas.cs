namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pas function.
        /// </summary>
        [Fact]
        public void TestPas()
        {
            var status = 0;
            var al = 1.0;
			var ap = 0.1;
			var bl = 0.2;
			var bp = -1.0;

            var theta = Pas(al, ap, bl, bp);

            Vvd(theta, -2.724544922932270424, 1e-12, "Pas", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
