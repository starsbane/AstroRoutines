namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Taiutc function.
        /// </summary>
        [Fact]
        public void TestTaiutc()
        {
            var status = 0;

            double u1, u2;
            int j;

            j = Taiutc(2453750.5, 0.892482639, out u1, out u2);

            Vvd(u1, 2453750.5, 1e-6, "Taiutc", "u1", ref status);
            Vvd(u2, 0.8921006945555555556, 1e-12, "Taiutc", "u2", ref status);
            Viv(j, 0, "Taiutc", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
