namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Ut1tt function.
        /// </summary>
        [Fact]
        public void TestUt1tt()
        {
            var status = 0;

            double t1 = 0, t2 = 0;
            int j;

            j = Ut1tt(2453750.5, 0.892104561, 64.8499, ref t1, ref t2);

            Vvd(t1, 2453750.5, 1e-6, "Ut1tt", "t1", ref status);
            Vvd(t2, 0.8928551385462962963, 1e-12, "Ut1tt", "t2", ref status);

            Viv(j, 0, "Ut1tt", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
