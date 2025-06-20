namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Sp00 function.
        /// </summary>
        [Fact]
        public void TestSp00()
        {
            var status = 0;

            var s = Sp00(2400000.5, 52541.0);

            Vvd(s, -0.6216698469981019309e-11, 1e-12, "Sp00", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
