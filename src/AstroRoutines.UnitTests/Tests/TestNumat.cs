using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Numat function.
        /// </summary>
        [Fact]
        public void TestNumat()
        {
            var status = 0;
            double epsa = 0.4090789763356509900;
            double dpsi = -0.9630909107115582393e-5;
            double deps = 0.4063239174001678826e-4;
            double[,] rmatn = new double[3, 3];

            Numat(epsa, dpsi, deps, out rmatn);

            Vvd(rmatn[0, 0], 0.9999999999536227949, 1e-12, "Numat", "11", ref status);
            Vvd(rmatn[0, 1], 0.8836239320236250577e-5, 1e-12, "Numat", "12", ref status);
            Vvd(rmatn[0, 2], 0.3830833447458251908e-5, 1e-12, "Numat", "13", ref status);

            Vvd(rmatn[1, 0], -0.8836083657016688588e-5, 1e-12, "Numat", "21", ref status);
            Vvd(rmatn[1, 1], 0.9999999991354654959, 1e-12, "Numat", "22", ref status);
            Vvd(rmatn[1, 2], -0.4063240865362499850e-4, 1e-12, "Numat", "23", ref status);

            Vvd(rmatn[2, 0], -0.3831192481833385226e-5, 1e-12, "Numat", "31", ref status);
            Vvd(rmatn[2, 1], 0.4063237480216934159e-4, 1e-12, "Numat", "32", ref status);
            Vvd(rmatn[2, 2], 0.9999999991671660407, 1e-12, "Numat", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
