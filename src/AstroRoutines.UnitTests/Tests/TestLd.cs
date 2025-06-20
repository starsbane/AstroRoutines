using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ld function.
        /// </summary>
        [Fact]
        public void TestLd()
        {
            var status = 0;
            double bm;
            double[] p = new double[3];
            double[] q = new double[3];
            double[] e = new double[3];
            double em;
            double dlim;
            double[] p1 = new double[3];
			
			bm = 0.00028574;
			p[0] = -0.763276255;
			p[1] = -0.608633767;
			p[2] = -0.216735543;
			q[0] = -0.763276255;
			q[1] = -0.608633767;
			q[2] = -0.216735543;
			e[0] = 0.76700421;
			e[1] = 0.605629598;
			e[2] = 0.211937094;
			em = 8.91276983;
			dlim = 3e-10;

            Ld(bm, p, q, e, em, dlim, ref p1);

            Vvd(p1[0], -0.7632762548968159627, 1e-12, "Ld", "1", ref status);
            Vvd(p1[1], -0.6086337670823762701, 1e-12, "Ld", "2", ref status);
            Vvd(p1[2], -0.2167355431320546947, 1e-12, "Ld", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
