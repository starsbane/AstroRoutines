using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fw2xy function.
        /// </summary>
        [Fact]
        public void TestFw2xy()
        {
            var status = 0;
            double gamb = -0.2243387670997992368e-5;
            double phib = 0.4091014602391312982;
            double psi = -0.9501954178013015092e-3;
            double eps = 0.4091014316587367472;
            double x, y;

            Fw2xy(gamb, phib, psi, eps, out x, out y);

            Vvd(x, -0.3779734957034082790e-3, 1e-14, "Fw2xy", "x", ref status);
            Vvd(y, -0.1924880848087615651e-6, 1e-14, "Fw2xy", "y", ref status);

            Assert.Equal(0, status);
        }
    }
}
