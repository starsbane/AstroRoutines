using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test H2fk5 function.
        /// </summary>
        [Fact]
        public void TestH2fk5()
        {
            var status = 0;
			
			double rh, dh, drh, ddh, pxh, rvh, r5, d5, dr5, dd5, px5, rv5;
            
			rh = 1.767794352;
            dh = -0.2917512594;
            drh = -2.76413026e-6;
            ddh = -5.92994449e-6;
            pxh = 0.379210;
            rvh = -7.6;

            H2fk5(rh, dh, drh, ddh, pxh, rvh, out r5, out d5, out dr5, out dd5, out px5, out rv5);

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
