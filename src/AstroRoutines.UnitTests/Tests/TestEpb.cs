namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Epb function.
        /// </summary>
        [Fact]
        public void TestEpb()
        {
            var status = 0;
            var epb = Epb(2415019.8135, 30103.18648);

            Vvd(epb, 1982.418424159278580, 1e-12, "Epb", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
