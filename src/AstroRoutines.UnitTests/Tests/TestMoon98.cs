using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Moon98 function.
        /// </summary>
        [Fact]
        public void TestMoon98()
        {
            var status = 0;
            double[,] pv = new double[2, 3];

            Moon98(2400000.5, 43999.9, ref pv);

            Vvd(pv[0, 0], -0.2601295959971044180e-2, 1e-11, "Moon98", "x 4", ref status);
            Vvd(pv[0, 1], 0.6139750944302742189e-3, 1e-11, "Moon98", "y 4", ref status);
            Vvd(pv[0, 2], 0.2640794528229828909e-3, 1e-11, "Moon98", "z 4", ref status);

            Vvd(pv[1, 0], -0.1244321506649895021e-3, 1e-11, "Moon98", "xd 4", ref status);
            Vvd(pv[1, 1], -0.5219076942678119398e-3, 1e-11, "Moon98", "yd 4", ref status);
            Vvd(pv[1, 2], -0.1716132214378462047e-3, 1e-11, "Moon98", "zd 4", ref status);

            Assert.Equal(0, status);
        }
    }
}
