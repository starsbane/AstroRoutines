using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Hd2pa function.
        /// </summary>
        [Fact]
        public void TestHd2pa()
        {
            var status = 0;
			double h, d, p, q;
			h = 1.1;
			d = 1.2;
			p = 0.3;
			
            q = Hd2pa(h, d, p);

            Vvd(q, 1.906227428001995580, 1e-13, "Hd2pa", "q", ref status);

            Assert.Equal(0, status);
        }
    }
}
