using Xunit;

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
            double al, ap, bl, bp, theta;
			al =  1.0;
			ap =  0.1;
			bl =  0.2;
			bp = -1.0;

            theta = Pas(al, ap, bl, bp);

            Vvd(theta, -2.724544922932270424, 1e-12, "Pas", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
