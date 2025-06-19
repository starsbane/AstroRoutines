using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Hfk5z function.
        /// </summary>
        [Fact]
        public void TestHfk5z()
        {
            var status = 0;
			double rh, dh, r5, d5, dr5, dd5;
			rh =  1.767794352;
			dh = -0.2917512594;

            Hfk5z(rh, dh, 2400000.5, 54479.0, out r5, out d5, out dr5, out dd5);

            Vvd(r5, 1.767794490535581026, 1e-13, "Hfk5z", "ra", ref status);
            Vvd(d5, -0.2917513695320114258, 1e-14, "Hfk5z", "dec", ref status);
            Vvd(dr5, 0.4335890983539243029e-8, 1e-22, "Hfk5z", "dr5", ref status);
            Vvd(dd5, -0.8569648841237745902e-9, 1e-23, "Hfk5z", "dd5", ref status);

            Assert.Equal(0, status);
        }
    }
}
