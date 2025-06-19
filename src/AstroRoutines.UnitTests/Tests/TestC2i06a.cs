using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test C2i06a function.
        /// </summary>
        /// <remarks>
        /// Celestial-to-intermediate matrix, IAU 2006/2000A precession-nutation.
        /// </remarks>
        [Fact]
        public void TestC2i06a()
        {
            var status = 0;
            var rc2i = new double[3, 3];
			C2i06a(2400000.5, 53736.0, ref rc2i);

			Vvd(rc2i[0, 0], 0.9999998323037159379, 1e-12, "C2i06a", "11", ref status);
			Vvd(rc2i[0, 1], 0.5581121329587613787e-9, 1e-12, "C2i06a", "12", ref status);
			Vvd(rc2i[0, 2], -0.5791308487740529749e-3, 1e-12, "C2i06a", "13", ref status);

			Vvd(rc2i[1, 0], -0.2384253169452306581e-7, 1e-12, "C2i06a", "21", ref status);
			Vvd(rc2i[1, 1], 0.9999999991917467827, 1e-12, "C2i06a", "22", ref status);
			Vvd(rc2i[1, 2], -0.4020579392895682558e-4, 1e-12, "C2i06a", "23", ref status);

			Vvd(rc2i[2, 0], 0.5791308482835292617e-3, 1e-12, "C2i06a", "31", ref status);
			Vvd(rc2i[2, 1], 0.4020580099454020310e-4, 1e-12, "C2i06a", "32", ref status);
			Vvd(rc2i[2, 2], 0.9999998314954628695, 1e-12, "C2i06a", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
