namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Atciqn function.
        /// </summary>
        /// <remarks>
        /// Quick transformation of ICRS RA,Dec to CIRS RA,Dec with light deflection.
        /// </remarks>
        [Fact]
        public void TestAtciqn()
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
            var b = new LDBODY[3];
            double ri, di;

            Apci13(date1, date2, ref astrom, out eo);

            // resolve NullReferenceException
            for (var i = 0; i < b.Length; i++)
            {
                b[i] = new LDBODY();
            }

            b[0].bm = 0.00028574;
            b[0].dl = 3e-10;
            b[0].pv = new double[2, 3];
            b[0].pv[0, 0] = -7.81014427;
            b[0].pv[0, 1] = -5.60956681;
            b[0].pv[0, 2] = -1.98079819;
            b[0].pv[1, 0] = 0.0030723249;
            b[0].pv[1, 1] = -0.00406995477;
            b[0].pv[1, 2] = -0.00181335842;
            b[1].bm = 0.00095435;
            b[1].dl = 3e-9;
            b[1].pv = new double[2, 3];
            b[1].pv[0, 0] = 0.738098796;
            b[1].pv[0, 1] = 4.63658692;
            b[1].pv[0, 2] = 1.9693136;
            b[1].pv[1, 0] = -0.00755816922;
            b[1].pv[1, 1] = 0.00126913722;
            b[1].pv[1, 2] = 0.000727999001;
            b[2].bm = 1.0;
            b[2].dl = 6e-6;
            b[2].pv = new double[2, 3];
            b[2].pv[0, 0] = -0.000712174377;
            b[2].pv[0, 1] = -0.00230478303;
            b[2].pv[0, 2] = -0.00105865966;
            b[2].pv[1, 0] = 6.29235213e-6;
            b[2].pv[1, 1] = -3.30888387e-7;
            b[2].pv[1, 2] = -2.96486623e-7;

            Atciqn(rc, dc, pr, pd, px, rv, ref astrom, 3, b, out ri, out di);

            Vvd(ri, 2.710122008104983335, 1e-12, "Atciqn", "ri", ref status);
            Vvd(di, 0.1729371916492767821, 1e-12, "Atciqn", "di", ref status);

            Assert.Equal(0, status);
        }
    }
}
