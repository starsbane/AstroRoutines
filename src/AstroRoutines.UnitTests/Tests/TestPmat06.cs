namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pmat06 function.
        /// </summary>
        [Fact]
        public void TestPmat06()
        {
            var rbp = new double[3, 3];
            var status = 0;

            Pmat06(2400000.5, 50123.9999, ref rbp);

            Vvd(rbp[0, 0], 0.9999995505176007047, 1e-12, "Pmat06", "11", ref status);
            Vvd(rbp[0, 1], 0.8695404617348208406e-3, 1e-14, "Pmat06", "12", ref status);
            Vvd(rbp[0, 2], 0.3779735201865589104e-3, 1e-14, "Pmat06", "13", ref status);

            Vvd(rbp[1, 0], -0.8695404723772031414e-3, 1e-14, "Pmat06", "21", ref status);
            Vvd(rbp[1, 1], 0.9999996219496027161, 1e-12, "Pmat06", "22", ref status);
            Vvd(rbp[1, 2], -0.1361752497080270143e-6, 1e-14, "Pmat06", "23", ref status);

            Vvd(rbp[2, 0], -0.3779734957034089490e-3, 1e-14, "Pmat06", "31", ref status);
            Vvd(rbp[2, 1], -0.1924880847894457113e-6, 1e-14, "Pmat06", "32", ref status);
            Vvd(rbp[2, 2], 0.9999999285679971958, 1e-12, "Pmat06", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
