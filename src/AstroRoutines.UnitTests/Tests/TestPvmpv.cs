namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pvmpv function.
        /// </summary>
        [Fact]
        public void TestPvmpv()
        {
            var status = 0;

            var a = new double[2, 3];
            var b = new double[2, 3];
            var amb = new double[2, 3];

            a[0, 0] = 2.0;
            a[0, 1] = 2.0;
            a[0, 2] = 3.0;

            a[1, 0] = 5.0;
            a[1, 1] = 6.0;
            a[1, 2] = 3.0;

            b[0, 0] = 1.0;
            b[0, 1] = 3.0;
            b[0, 2] = 4.0;

            b[1, 0] = 3.0;
            b[1, 1] = 2.0;
            b[1, 2] = 1.0;

            Pvmpv(a, b, ref amb);

            Vvd(amb[0, 0], 1.0, 1e-12, "Pvmpv", "11", ref status);
            Vvd(amb[0, 1], -1.0, 1e-12, "Pvmpv", "21", ref status);
            Vvd(amb[0, 2], -1.0, 1e-12, "Pvmpv", "31", ref status);

            Vvd(amb[1, 0], 2.0, 1e-12, "Pvmpv", "12", ref status);
            Vvd(amb[1, 1], 4.0, 1e-12, "Pvmpv", "22", ref status);
            Vvd(amb[1, 2], 2.0, 1e-12, "Pvmpv", "32", ref status);

            Assert.Equal(0, status);
        }
    }
}
