namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fk425 function.
        /// </summary>
        [Fact]
        public void TestFk425()
        {
            var status = 0;
            double r1950, d1950, dr1950, dd1950, p1950, v1950,
                r2000, d2000, dr2000, dd2000, p2000, v2000;

            r1950 = 0.07626899753879587532;
            d1950 = -1.137405378399605780;
            dr1950 = 0.1973749217849087460e-4;
            dd1950 = 0.5659714913272723189e-5;
            p1950 = 0.134;
            v1950 = 8.7;

            Fk425(r1950, d1950, dr1950, dd1950, p1950, v1950,
                out r2000, out d2000, out dr2000, out dd2000, out p2000, out v2000);

            Vvd(r2000, 0.08757989933556446040, 1e-14, "Fk425", "r2000", ref status);
            Vvd(d2000, -1.132279113042091895, 1e-12, "Fk425", "d2000", ref status);
            Vvd(dr2000, 0.1953670614474396139e-4, 1e-17, "Fk425", "dr2000", ref status);
            Vvd(dd2000, 0.5637686678659640164e-5, 1e-18, "Fk425", "dd2000", ref status);
            Vvd(p2000, 0.1339919950582767871, 1e-13, "Fk425", "p2000", ref status);
            Vvd(v2000, 8.736999669183529069, 1e-12, "Fk425", "v2000", ref status);

            Assert.Equal(0, status);
        }
    }
}