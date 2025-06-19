using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Ltpecl function.
        /// </summary>
        [Fact]
        public void TestLtpecl()
        {
            var status = 0;
            double epj;
            double[] vec = new double[3];
			
			epj = -1500.0;
			
            Ltpecl(epj, ref vec);

            Vvd(vec[0], 0.4768625676477096525e-3, 1e-14, "Ltpecl", "vec1", ref status);
            Vvd(vec[1], -0.4052259533091875112, 1e-14, "Ltpecl", "vec2", ref status);
            Vvd(vec[2], 0.9142164401096448012, 1e-14, "Ltpecl", "vec3", ref status);

            Assert.Equal(0, status);
        }
    }
}
