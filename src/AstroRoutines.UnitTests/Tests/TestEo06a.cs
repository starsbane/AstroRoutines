namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Eo06a function.
        /// </summary>
        [Fact]
        public void TestEo06a()
        {
            var status = 0;
            var eo = Eo06a(2400000.5, 53736.0);

            Vvd(eo, -0.1332882371941833644e-2, 1e-15, "Eo06a", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
