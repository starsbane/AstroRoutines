using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test C2i00a function.
        /// </summary>
        /// <remarks>
        /// Celestial-to-intermediate matrix, IAU 2000A precession-nutation.
        /// </remarks>
        [Fact]
        public void TestC2i00a()
        {
            var status = 0;
            var rc2i = new double[3, 3];
			C2i00a(2400000.5, 53736.0, ref rc2i);

            Vvd(rc2i[0, 0], 0.9999998323037165557, 1e-12, "C2i00a", "11", ref status);
            Vvd(rc2i[0, 1], 0.5581526348992140183e-9, 1e-12, "C2i00a", "12", ref status);
            Vvd(rc2i[0, 2], -0.5791308477073443415e-3, 1e-12, "C2i00a", "13", ref status);

            Vvd(rc2i[1, 0], -0.2384266227870752452e-7, 1e-12, "C2i00a", "21", ref status);
            Vvd(rc2i[1, 1], 0.9999999991917405258, 1e-12, "C2i00a", "22", ref status);
            Vvd(rc2i[1, 2], -0.4020594955028209745e-4, 1e-12, "C2i00a", "23", ref status);

            Vvd(rc2i[2, 0], 0.5791308472168152904e-3, 1e-12, "C2i00a", "31", ref status);
            Vvd(rc2i[2, 1], 0.4020595661591500259e-4, 1e-12, "C2i00a", "32", ref status);
            Vvd(rc2i[2, 2], 0.9999998314954572304, 1e-12, "C2i00a", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
