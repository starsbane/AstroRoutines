using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Cr function.
        /// </summary>
        [Fact]
        public void TestCr()
        {
            var status = 0;
            var r = new double[3, 3];
            var c = new double[3, 3];

            r[0, 0] = 2.0;
            r[0, 1] = 3.0;
            r[0, 2] = 2.0;

            r[1, 0] = 3.0;
            r[1, 1] = 2.0;
            r[1, 2] = 3.0;

            r[2, 0] = 3.0;
            r[2, 1] = 4.0;
            r[2, 2] = 5.0;

            Cr(r, ref c);

            Vvd(c[0, 0], 2.0, 0.0, "Cr", "11", ref status);
            Vvd(c[0, 1], 3.0, 0.0, "Cr", "12", ref status);
            Vvd(c[0, 2], 2.0, 0.0, "Cr", "13", ref status);

            Vvd(c[1, 0], 3.0, 0.0, "Cr", "21", ref status);
            Vvd(c[1, 1], 2.0, 0.0, "Cr", "22", ref status);
            Vvd(c[1, 2], 3.0, 0.0, "Cr", "23", ref status);

            Vvd(c[2, 0], 3.0, 0.0, "Cr", "31", ref status);
            Vvd(c[2, 1], 4.0, 0.0, "Cr", "32", ref status);
            Vvd(c[2, 2], 5.0, 0.0, "Cr", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
