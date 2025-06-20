namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Dtf2d function.
        /// </summary>
        [Fact]
        public void TestDtf2d()
        {
            var status = 0;
            double u1 = 0, u2 = 0;
            var j = Dtf2d("UTC", 1994, 6, 30, 23, 59, 60.13599, ref u1, ref u2);

            Vvd(u1 + u2, 2449534.49999, 1e-6, "Dtf2d", "u", ref status);
            Viv(j, 0, "Dtf2d", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
