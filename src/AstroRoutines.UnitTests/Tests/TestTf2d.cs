namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tf2d function.
        /// </summary>
        [Fact]
        public void TestTf2d()
        {
            var status = 0;

            double d;
            int j;

            j = Tf2d(' ', 23, 55, 10.9, out d);

            Vvd(d, 0.9966539351851851852, 1e-12, "Tf2d", "d", ref status);
            Viv(j, 0, "Tf2d", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
