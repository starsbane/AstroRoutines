namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test H2fk5 function.
        /// </summary>
        [Fact]
        public void TestH2fk5()
        {
            var status = 0;

            var rh = 1.767794352;
            var dh = -0.2917512594;
            var drh = -2.76413026e-6;
            var ddh = -5.92994449e-6;
            var pxh = 0.379210;
            var rvh = -7.6;

            H2fk5(rh, dh, drh, ddh, pxh, rvh, out var r5, out var d5, out var dr5, out var dd5, out var px5, out var rv5);

            Vvd(r5, 1.767794455700065506, 1e-13, "H2fk5", "ra", ref status);
            Vvd(d5, -0.2917513626469638890, 1e-13, "H2fk5", "dec", ref status);
            Vvd(dr5, -0.27597945024511204e-5, 1e-18, "H2fk5", "dr5", ref status);
            Vvd(dd5, -0.59308014093262838e-5, 1e-18, "H2fk5", "dd5", ref status);
            Vvd(px5, 0.37921, 1e-13, "H2fk5", "px", ref status);
            Vvd(rv5, -7.6000001309071126, 1e-11, "H2fk5", "rv", ref status);

            Assert.Equal(0, status);
        }
    }
}
