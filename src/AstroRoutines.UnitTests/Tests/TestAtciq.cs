namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Atciq function.
        /// </summary>
        /// <remarks>
        /// Quick transformation of ICRS RA,Dec to CIRS RA,Dec.
        /// </remarks>
        [Fact]
        public void TestAtciq()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var eo = 0.0;
            var rc = 2.71;
            var dc = 0.174;
            var pr = 1e-5;
            var pd = 5e-6;
            var px = 0.1;
            var rv = 55.0;
            var astrom = new ASTROM();
            double ri, di;

            Apci13(date1, date2, ref astrom, out eo);

            Atciq(rc, dc, pr, pd, px, rv, ref astrom, out ri, out di);

            Vvd(ri, 2.710121572968696744, 1e-12, "Atciq", "ri", ref status);
            Vvd(di, 0.1729371367219539137, 1e-12, "Atciq", "di", ref status);

            Assert.Equal(0, status);
        }
    }
}
