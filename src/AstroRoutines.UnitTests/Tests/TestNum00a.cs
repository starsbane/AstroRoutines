using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Num00a function.
        /// </summary>
        [Fact]
        public void TestNum00a()
        {
            var status = 0;
            double[,] rmatn = new double[3, 3];

            Num00a(2400000.5, 53736.0, ref rmatn);

            Vvd(rmatn[0, 0], 0.9999999999536227949, 1e-12, "Num00a", "11", ref status);
            Vvd(rmatn[0, 1], 0.8836238544090873336e-5, 1e-12, "Num00a", "12", ref status);
            Vvd(rmatn[0, 2], 0.3830835237722400669e-5, 1e-12, "Num00a", "13", ref status);

            Vvd(rmatn[1, 0], -0.8836082880798569274e-5, 1e-12, "Num00a", "21", ref status);
            Vvd(rmatn[1, 1], 0.9999999991354655028, 1e-12, "Num00a", "22", ref status);
            Vvd(rmatn[1, 2], -0.4063240865362499850e-4, 1e-12, "Num00a", "23", ref status);

            Vvd(rmatn[2, 0], -0.3831194272065995866e-5, 1e-12, "Num00a", "31", ref status);
            Vvd(rmatn[2, 1], 0.4063237480216291775e-4, 1e-12, "Num00a", "32", ref status);
            Vvd(rmatn[2, 2], 0.9999999991671660338, 1e-12, "Num00a", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
