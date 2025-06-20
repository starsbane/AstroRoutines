using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pap function.
        /// </summary>
        [Fact]
        public void TestPap()
        {
            var status = 0;
            double[] a = new double[3];
            double[] b = new double[3];
            double theta;
			
			a[0] =  1.0;
			a[1] =  0.1;
			a[2] =  0.2;

			b[0] = -3.0;
			b[1] = 1e-3;
			b[2] =  0.2;
			
            theta = Pap(a, b);

            Vvd(theta, 0.3671514267841113674, 1e-12, "Pap", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
