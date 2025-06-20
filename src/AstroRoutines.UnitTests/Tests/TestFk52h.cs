namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fk52h function.
        /// </summary>
        [Fact]
        public void TestFk52h()
        {
            var status = 0;

            var r5 = 1.76779433;
            var d5 = -0.2917517103;
            var dr5 = -1.91851572e-7;
            var dd5 = -5.8468475e-6;
            var px5 = 0.379210;
            var rv5 = -7.6;

            Fk52h(r5, d5, dr5, dd5, px5, rv5, out var rh, out var dh, out var drh, out var ddh, out var pxh, out var rvh);

            Vvd(rh, 1.767794226299947632, 1e-14, "Fk52h", "ra", ref status);
            Vvd(dh, -0.2917516070530391757, 1e-14, "Fk52h", "dec", ref status);
            Vvd(drh, -0.1961874125605721270e-6, 1e-19, "Fk52h", "dr5", ref status);
            Vvd(ddh, -0.58459905176693911e-5, 1e-19, "Fk52h", "dd5", ref status);
            Vvd(pxh, 0.37921, 1e-14, "Fk52h", "px", ref status);
            Vvd(rvh, -7.6000000940000254, 1e-11, "Fk52h", "rv", ref status);

            Assert.Equal(0, status);
        }
    }
}
