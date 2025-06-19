using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Aticqn function.
        /// </summary>
        /// <remarks>
        /// Quick transformation of CIRS RA,Dec to ICRS RA,Dec with light deflection.
        /// </remarks>
        [Fact]
        public void TestAticqn()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var eo = 0.0;
            var ri = 2.709994899247599271;
            var di = 0.1728740720983623469;
            var astrom = new ASTROM();
            var b = new LDBODY[3];
            double rc, dc;

            Apci13(date1, date2, ref astrom, out eo);

            b[0].bm = 0.00028574;
            b[0].dl = 3e-10;
            b[0].pv = new double[2, 3];
            b[0].pv[0, 0] = -7.81014427;
            b[0].pv[0, 1] = -5.60956681;
            b[0].pv[0, 2] = -1.98079819;
            b[0].pv[1, 0] = 0.0030723249;
            b[0].pv[1, 1] = -0.00406995477;
            b[0].pv[1, 2] = -0.00181335842;
            b[1].pv = new double[2, 3];
            b[1].bm = 0.00095435;
            b[1].dl = 3e-9;
            b[1].pv[0, 0] = 0.738098796;
            b[1].pv[0, 1] = 4.63658692;
            b[1].pv[0, 2] = 1.9693136;
            b[1].pv[1, 0] = -0.00755816922;
            b[1].pv[1, 1] = 0.00126913722;
            b[1].pv[1, 2] = 0.000727999001;
            b[2].pv = new double[2, 3];
            b[2].bm = 1.0;
            b[2].dl = 6e-6;
            b[2].pv[0, 0] = -0.000712174377;
            b[2].pv[0, 1] = -0.00230478303;
            b[2].pv[0, 2] = -0.00105865966;
            b[2].pv[1, 0] = 6.29235213e-6;
            b[2].pv[1, 1] = -3.30888387e-7;
            b[2].pv[1, 2] = -2.96486623e-7;

            Aticqn(ri, di, ref astrom, 3, b, out rc, out dc);

            Vvd(rc, 2.709999575033027333, 1e-12, "Aticqn", "rc", ref status);
            Vvd(dc, 0.1739999656316469990, 1e-12, "Aticqn", "dc", ref status);

            Assert.Equal(0, status);
        }
    }
}
