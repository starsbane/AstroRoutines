using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ir function.
        /// </summary>
        [Fact]
        public void TestIr()
        {
            var status = 0;
            var r = new double[3, 3];

            r[0, 0] = 2.0;
            r[0, 1] = 3.0;
            r[0, 2] = 2.0;
			
            r[1, 0] = 3.0;
            r[1, 1] = 2.0;
            r[1, 2] = 3.0;
			
            r[2, 0] = 3.0;
            r[2, 1] = 4.0;
            r[2, 2] = 5.0;

            Ir(ref r);

            Vvd(r[0, 0], 1.0, 0.0, "Ir", "11", ref status);
            Vvd(r[0, 1], 0.0, 0.0, "Ir", "12", ref status);
            Vvd(r[0, 2], 0.0, 0.0, "Ir", "13", ref status);
			
            Vvd(r[1, 0], 0.0, 0.0, "Ir", "21", ref status);
            Vvd(r[1, 1], 1.0, 0.0, "Ir", "22", ref status);
            Vvd(r[1, 2], 0.0, 0.0, "Ir", "23", ref status);
			
            Vvd(r[2, 0], 0.0, 0.0, "Ir", "31", ref status);
            Vvd(r[2, 1], 0.0, 0.0, "Ir", "32", ref status);
            Vvd(r[2, 2], 1.0, 0.0, "Ir", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
