using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Cpv function.
        /// </summary>
        [Fact]
        public void TestCpv()
        {
            var status = 0;
            var pv = new double[2, 3];
            var c = new double[2, 3];

            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = -0.5;
            pv[1, 1] = 3.1;
            pv[1, 2] = 0.9;

            Cpv(pv, c);

            Vvd(c[0, 0], 0.3, 0.0, "Cpv", "p1", ref status);
            Vvd(c[0, 1], 1.2, 0.0, "Cpv", "p2", ref status);
            Vvd(c[0, 2], -2.5, 0.0, "Cpv", "p3", ref status);

            Vvd(c[1, 0], -0.5, 0.0, "Cpv", "v1", ref status);
            Vvd(c[1, 1], 3.1, 0.0, "Cpv", "v2", ref status);
            Vvd(c[1, 2], 0.9, 0.0, "Cpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
