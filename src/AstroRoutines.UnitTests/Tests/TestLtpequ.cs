using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ltpequ function.
        /// </summary>
        [Fact]
        public void TestLtpequ()
        {
            var status = 0;
            double epj;
            var veq = new double[3];
			
			epj = -2500.0;
			
            Ltpequ(epj, ref veq);

            Vvd(veq[0], -0.3586652560237326659, 1e-14, "Ltpequ", "veq1", ref status);
            Vvd(veq[1], -0.1996978910771128475, 1e-14, "Ltpequ", "veq2", ref status);
            Vvd(veq[2], 0.9118552442250819624, 1e-14, "Ltpequ", "veq3", ref status);

            Assert.Equal(0, status);
        }
    }
}
