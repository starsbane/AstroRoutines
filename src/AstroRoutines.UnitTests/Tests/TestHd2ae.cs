namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Hd2ae function.
        /// </summary>
        [Fact]
        public void TestHd2ae()
        {
            var status = 0;
			double h, d, p, a, e;
			h = 1.1;
			d = 1.2;
			p = 0.3;

            Hd2ae(h, d, p, out a, out e);

            Vvd(a, 5.916889243730066194, 1e-13, "Hd2ae", "a", ref status);
            Vvd(e, 0.4472186304990486228, 1e-14, "Hd2ae", "e", ref status);

            Assert.Equal(0, status);
        }
    }
}
