namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Zr function.
        /// </summary>
        [Fact]
        public void TestZr()
        {
            var status = 0;
            var r = new double[3, 3];

            r[0, 0] = 2.0;
            r[1, 0] = 3.0;
            r[2, 0] = 2.0;

            r[0, 1] = 3.0;
            r[1, 1] = 2.0;
            r[2, 1] = 3.0;

            r[0, 2] = 3.0;
            r[1, 2] = 4.0;
            r[2, 2] = 5.0;

            Zr(ref r);

            Vvd(r[0, 0], 0.0, 0.0, "Zr", "00", ref status);
            Vvd(r[1, 0], 0.0, 0.0, "Zr", "01", ref status);
            Vvd(r[2, 0], 0.0, 0.0, "Zr", "02", ref status);

            Vvd(r[0, 1], 0.0, 0.0, "Zr", "10", ref status);
            Vvd(r[1, 1], 0.0, 0.0, "Zr", "11", ref status);
            Vvd(r[2, 1], 0.0, 0.0, "Zr", "12", ref status);

            Vvd(r[0, 2], 0.0, 0.0, "Zr", "20", ref status);
            Vvd(r[1, 2], 0.0, 0.0, "Zr", "21", ref status);
            Vvd(r[2, 2], 0.0, 0.0, "Zr", "22", ref status);

            Assert.Equal(0, status);
        }
    }
}
