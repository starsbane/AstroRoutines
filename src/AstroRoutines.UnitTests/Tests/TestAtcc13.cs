namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Atcc13 function.
        /// </summary>
        /// <remarks>
        /// Transform ICRS RA,Dec to CIRS RA,Dec using internal routine.
        /// </remarks>
        [Fact]
        public void TestAtcc13()
        {
            var status = 0;
            var rc = 2.71;
            var dc = 0.174;
            var pr = 1e-5;
            var pd = 5e-6;
            var px = 0.1;
            var rv = 55.0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            double ra = 0, da = 0;

            Atcc13(rc, dc, pr, pd, px, rv, date1, date2, ref ra, ref da);

            Vvd(ra, 2.710126504531372384, 1e-12, "Atcc13", "ra", ref status);
            Vvd(da, 0.1740632537628350152, 1e-12, "Atcc13", "da", ref status);

            Assert.Equal(0, status);
        }
    }
}
