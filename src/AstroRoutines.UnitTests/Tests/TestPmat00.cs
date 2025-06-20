namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Pmat00 function.
        /// </summary>
        [Fact]
        public void TestPmat00()
        {
            var rbp = new double[3, 3];
            var status = 0;

            Pmat00(2400000.5, 50123.9999, ref rbp);

            Vvd(rbp[0, 0], 0.9999995505175087260, 1e-12, "Pmat00", "11", ref status);
            Vvd(rbp[0, 1], 0.8695405883617884705e-3, 1e-14, "Pmat00", "12", ref status);
            Vvd(rbp[0, 2], 0.3779734722239007105e-3, 1e-14, "Pmat00", "13", ref status);

            Vvd(rbp[1, 0], -0.8695405990410863719e-3, 1e-14, "Pmat00", "21", ref status);
            Vvd(rbp[1, 1], 0.9999996219494925900, 1e-12, "Pmat00", "22", ref status);
            Vvd(rbp[1, 2], -0.1360775820404982209e-6, 1e-14, "Pmat00", "23", ref status);

            Vvd(rbp[2, 0], -0.3779734476558184991e-3, 1e-14, "Pmat00", "31", ref status);
            Vvd(rbp[2, 1], -0.1925857585832024058e-6, 1e-14, "Pmat00", "32", ref status);
            Vvd(rbp[2, 2], 0.9999999285680153377, 1e-12, "Pmat00", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
