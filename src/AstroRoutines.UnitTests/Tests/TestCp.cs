namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Cp function.
        /// </summary>
        [Fact]
        public void TestCp()
        {
            var status = 0;
            var p = new double[3];
            var c = new double[3];

            p[0] = 0.3;
            p[1] = 1.2;
            p[2] = -2.5;

            Cp(p, ref c);

            Vvd(c[0], 0.3, 0.0, "Cp", "1", ref status);
            Vvd(c[1], 1.2, 0.0, "Cp", "2", ref status);
            Vvd(c[2], -2.5, 0.0, "Cp", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
