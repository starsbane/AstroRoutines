namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Ut1utc function.
        /// </summary>
        [Fact]
        public void TestUt1utc()
        {
            var status = 0;

            double u1 = 0, u2 = 0;
            int j;

            j = Ut1utc(2453750.5, 0.892104561, 0.3341, ref u1, ref u2);

            Vvd(u1, 2453750.5, 1e-6, "Ut1utc", "u1", ref status);
            Vvd(u2, 0.8921006941018518519, 1e-12, "Ut1utc", "u2", ref status);

            Viv(j, 0, "Ut1utc", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
