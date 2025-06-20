using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test C2txy function.
        /// </summary>
        [Fact]
        public void TestC2txy()
        {
            var status = 0;
            var tta = 2400000.5;
            var uta = 2400000.5;
            var ttb = 53736.0;
            var utb = 53736.0;
            var x = 0.5791308486706011000e-3;
            var y = 0.4020579816732961219e-4;
            var xp = 2.55060238e-7;
            var yp = 1.860359247e-6;
            var rc2t = new double[3, 3];

            C2txy(tta, ttb, uta, utb, x, y, xp, yp, out rc2t);

            Vvd(rc2t[0, 0], -0.1810332128306279253, 1e-12, "C2txy", "11", ref status);
            Vvd(rc2t[0, 1], 0.9834769806938520084, 1e-12, "C2txy", "12", ref status);
            Vvd(rc2t[0, 2], 0.6555551248057665829e-4, 1e-12, "C2txy", "13", ref status);

            Vvd(rc2t[1, 0], -0.9834768134136142314, 1e-12, "C2txy", "21", ref status);
            Vvd(rc2t[1, 1], -0.1810332203649529312, 1e-12, "C2txy", "22", ref status);
            Vvd(rc2t[1, 2], 0.5749800843594139912e-3, 1e-12, "C2txy", "23", ref status);

            Vvd(rc2t[2, 0], 0.5773474028619264494e-3, 1e-12, "C2txy", "31", ref status);
            Vvd(rc2t[2, 1], 0.3961816546911624260e-4, 1e-12, "C2txy", "32", ref status);
            Vvd(rc2t[2, 2], 0.9999998325501746670, 1e-12, "C2txy", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
