namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ut1tai function.
        /// </summary>
        [Fact]
        public void TestUt1tai()
        {
            var status = 0;

            double a1 = 0, a2 = 0;
            int j;

            j = Ut1tai(2453750.5, 0.892104561, -32.6659, ref a1, ref a2);

            Vvd(a1, 2453750.5, 1e-6, "Ut1tai", "a1", ref status);
            Vvd(a2, 0.8924826385462962963, 1e-12, "Ut1tai", "a2", ref status);

            Viv(j, 0, "Ut1tai", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
