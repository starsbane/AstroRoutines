using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Num00b function.
        /// </summary>
        [Fact]
        public void TestNum00b()
        {
            var status = 0;
            var rmatn = new double[3, 3];

            Num00b(2400000.5, 53736, ref rmatn);

            Vvd(rmatn[0, 0], 0.9999999999536069682, 1e-12, "Num00b", "11", ref status);
            Vvd(rmatn[0, 1], 0.8837746144871248011e-5, 1e-12, "Num00b", "12", ref status);
            Vvd(rmatn[0, 2], 0.3831488838252202945e-5, 1e-12, "Num00b", "13", ref status);

            Vvd(rmatn[1, 0], -0.8837590456632304720e-5, 1e-12, "Num00b", "21", ref status);
            Vvd(rmatn[1, 1], 0.9999999991354692733, 1e-12, "Num00b", "22", ref status);
            Vvd(rmatn[1, 2], -0.4063198798559591654e-4, 1e-12, "Num00b", "23", ref status);

            Vvd(rmatn[2, 0], -0.3831847930134941271e-5, 1e-12, "Num00b", "31", ref status);
            Vvd(rmatn[2, 1], 0.4063195412258168380e-4, 1e-12, "Num00b", "32", ref status);
            Vvd(rmatn[2, 2], 0.9999999991671806225, 1e-12, "Num00b", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
