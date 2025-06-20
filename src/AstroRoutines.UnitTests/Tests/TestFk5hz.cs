using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fk5hz function.
        /// </summary>
        [Fact]
        public void TestFk5hz()
        {
            var status = 0;
            double r5 = 1.76779433;
            double d5 = -0.2917517103;
            double rh, dh;

            Fk5hz(r5, d5, 2400000.5, 54479.0, out rh, out dh);

            Vvd(rh, 1.767794191464423978, 1e-12, "Fk5hz", "ra", ref status);
            Vvd(dh, -0.2917516001679884419, 1e-12, "Fk5hz", "dec", ref status);

            Assert.Equal(0, status);
        }
    }
}
