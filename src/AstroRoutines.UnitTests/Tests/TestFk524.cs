using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fk524 function.
        /// </summary>
        [Fact]
        public void TestFk524()
        {
            var status = 0;
            double r2000, d2000, dr2000, dd2000, p2000, v2000,
                   r1950, d1950, dr1950, dd1950, p1950, v1950;

            r2000 = 0.8723503576487275595;
            d2000 = -0.7517076365138887672;
            dr2000 = 0.2019447755430472323e-4;
            dd2000 = 0.3541563940505160433e-5;
            p2000 = 0.1559;
            v2000 = 86.87;

            Fk524(r2000, d2000, dr2000, dd2000, p2000, v2000,
                   out r1950, out d1950, out dr1950, out dd1950, out p1950, out v1950);

            Vvd(r1950, 0.8636359659799603487, 1e-13, "Fk524", "r1950", ref status);
            Vvd(d1950, -0.7550281733160843059, 1e-13, "Fk524", "d1950", ref status);
            Vvd(dr1950, 0.2023628192747172486e-4, 1e-17, "Fk524", "dr1950", ref status);
            Vvd(dd1950, 0.3624459754935334718e-5, 1e-18, "Fk524", "dd1950", ref status);
            Vvd(p1950, 0.1560079963299390241, 1e-13, "Fk524", "p1950", ref status);
            Vvd(v1950, 86.79606353469163751, 1e-11, "Fk524", "v1950", ref status);

            Assert.Equal(0, status);
        }
    }
}
