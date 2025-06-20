using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ldsun function.
        /// </summary>
        [Fact]
        public void TestLdsun()
        {
            var status = 0;
            var p = new double[3];
            var e = new double[3];
			double em;
            var p1 = new double[3];

			p[0] = -0.763276255;
			p[1] = -0.608633767;
			p[2] = -0.216735543;
			e[0] = -0.973644023;
			e[1] = -0.20925523;
			e[2] = -0.0907169552;
			em = 0.999809214;
			
            Ldsun(p, e, em, ref p1);

            Vvd(p1[0], -0.7632762580731413169, 1e-12, "Ldsun", "1", ref status);
            Vvd(p1[1], -0.6086337635262647900, 1e-12, "Ldsun", "2", ref status);
            Vvd(p1[2], -0.2167355419322321302, 1e-12, "Ldsun", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
