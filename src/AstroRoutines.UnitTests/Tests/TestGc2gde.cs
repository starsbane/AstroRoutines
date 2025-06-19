using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Gc2gde function.
        /// </summary>
        [Fact]
        public void TestGc2gde()
        {
            var status = 0;
            double a = 6378136.0, f = 0.0033528;
            double[] xyz = { 2e6, 3e6, 5.244e6 };
            double e, p, h;
            int j;

            j = Gc2gde(a, f, xyz, out e, out p, out h);
            Viv(j, 0, "Gc2gde", "j", ref status);
            Vvd(e, 0.9827937232473290680, 1e-14, "Gc2gde", "e", ref status);
            Vvd(p, 0.9716018377570411532, 1e-14, "Gc2gde", "p", ref status);
            Vvd(h, 332.36862495764397, 1e-8, "Gc2gde", "h", ref status);

            Assert.Equal(0, status);
        }
    }
}
