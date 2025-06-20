namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pb06 function.
        /// </summary>
        [Fact]
        public void TestPb06()
        {
            var status = 0;
            double bzeta, bz, btheta;

            Pb06(2400000.5, 50123.9999, out bzeta, out bz, out btheta);

            Vvd(bzeta, -0.5092634016326478238e-3, 1e-12, "Pb06", "bzeta", ref status);
            Vvd(bz, -0.3602772060566044413e-3, 1e-12, "Pb06", "bz", ref status);
            Vvd(btheta, -0.3779735537167811177e-3, 1e-12, "Pb06", "btheta", ref status);

            Assert.Equal(0, status);
        }
    }
}
