namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Sxp function.
        /// </summary>
        [Fact]
        public void TestSxp()
        {
            var status = 0;

            var s = 2.0;

            var p = new double[3];
            var sp = new double[3];

            p[0] = 0.3;
            p[1] = 1.2;
            p[2] = -2.5;

            Sxp(s, p, ref sp);

            Vvd(sp[0], 0.6, 0.0, "Sxp", "1", ref status);
            Vvd(sp[1], 2.4, 0.0, "Sxp", "2", ref status);
            Vvd(sp[2], -5.0, 0.0, "Sxp", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
