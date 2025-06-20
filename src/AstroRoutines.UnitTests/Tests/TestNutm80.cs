using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Nutm80 function.
        /// </summary>
        [Fact]
        public void TestNutm80()
        {
            var status = 0;
            double[,] rmatn = new double[3, 3];

            Nutm80(2400000.5, 53736.0, out rmatn);

            Vvd(rmatn[0, 0], 0.9999999999534999268, 1e-12, "Nutm80", "11", ref status);
            Vvd(rmatn[0, 1], 0.8847935789636432161e-5, 1e-12, "Nutm80", "12", ref status);
            Vvd(rmatn[0, 2], 0.3835906502164019142e-5, 1e-12, "Nutm80", "13", ref status);

            Vvd(rmatn[1, 0], -0.8847780042583435924e-5, 1e-12, "Nutm80", "21", ref status);
            Vvd(rmatn[1, 1], 0.9999999991366569963, 1e-12, "Nutm80", "22", ref status);
            Vvd(rmatn[1, 2], -0.4060052702727130809e-4, 1e-12, "Nutm80", "23", ref status);

            Vvd(rmatn[2, 0], -0.3836265729708478796e-5, 1e-12, "Nutm80", "31", ref status);
            Vvd(rmatn[2, 1], 0.4060049308612638555e-4, 1e-12, "Nutm80", "32", ref status);
            Vvd(rmatn[2, 2], 0.9999999991684415129, 1e-12, "Nutm80", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
