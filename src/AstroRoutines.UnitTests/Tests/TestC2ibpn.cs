using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test C2ibpn function.
        /// </summary>
        /// <remarks>
        /// Celestial-to-intermediate matrix, given classical NPB matrix.
        /// </remarks>
        [Fact]
        public void TestC2ibpn()
        {
            var status = 0;
            var rbpn = new double[3, 3];
            var rc2i = new double[3, 3];

			rbpn[0, 0] =  9.999962358680738e-1;
			rbpn[0, 1] = -2.516417057665452e-3;
			rbpn[0, 2] = -1.093569785342370e-3;

			rbpn[1, 0] =  2.516462370370876e-3;
			rbpn[1, 1] =  9.999968329010883e-1;
			rbpn[1, 2] =  4.006159587358310e-5;

			rbpn[2, 0] =  1.093465510215479e-3;
			rbpn[2, 1] = -4.281337229063151e-5;
			rbpn[2, 2] =  9.999994012499173e-1;

			C2ibpn(2400000.5, 50123.9999, rbpn, ref rc2i);

			Vvd(rc2i[0, 0], 0.9999994021664089977, 1e-12, "C2ibpn", "11", ref status);
			Vvd(rc2i[0, 1], -0.3869195948017503664e-8, 1e-12, "C2ibpn", "12", ref status);
			Vvd(rc2i[0, 2], -0.1093465511383285076e-2, 1e-12, "C2ibpn", "13", ref status);

			Vvd(rc2i[1, 0], 0.5068413965715446111e-7, 1e-12, "C2ibpn", "21", ref status);
			Vvd(rc2i[1, 1], 0.9999999990835075686, 1e-12, "C2ibpn", "22", ref status);
			Vvd(rc2i[1, 2], 0.4281334246452708915e-4, 1e-12, "C2ibpn", "23", ref status);

			Vvd(rc2i[2, 0], 0.1093465510215479000e-2, 1e-12, "C2ibpn", "31", ref status);
			Vvd(rc2i[2, 1], -0.4281337229063151000e-4, 1e-12, "C2ibpn", "32", ref status);
			Vvd(rc2i[2, 2], 0.9999994012499173103, 1e-12, "C2ibpn", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
