namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Zp function.
        /// </summary>
        [Fact]
        public void TestZp()
        {
            var status = 0;

            var p = new double[3];

            p[0] = 0.3;
            p[1] = 1.2;
            p[2] = -2.5;

            Zp(ref p);

            Vvd(p[0], 0.0, 0.0, "Zp", "1", ref status);
            Vvd(p[1], 0.0, 0.0, "Zp", "2", ref status);
            Vvd(p[2], 0.0, 0.0, "Zp", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
