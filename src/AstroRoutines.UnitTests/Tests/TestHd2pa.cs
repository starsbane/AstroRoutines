namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Hd2pa function.
        /// </summary>
        [Fact]
        public void TestHd2pa()
        {
            var status = 0;
            var h = 1.1;
			var d = 1.2;
			var p = 0.3;
			
            var q = Hd2pa(h, d, p);

            Vvd(q, 1.906227428001995580, 1e-13, "Hd2pa", "q", ref status);

            Assert.Equal(0, status);
        }
    }
}
