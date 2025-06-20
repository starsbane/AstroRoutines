using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Jd2cal function.
        /// </summary>
        [Fact]
        public void TestJd2cal()
        {
            var status = 0;
			double dj1, dj2, fd;
			int iy, im, id, j;

			dj1 = 2400000.5;
			dj2 = 50123.9999;

            j = Jd2cal(dj1, dj2, out iy, out im, out id, out fd);

            Viv(iy, 1996, "Jd2cal", "y", ref status);
            Viv(im, 2, "Jd2cal", "m", ref status);
            Viv(id, 10, "Jd2cal", "d", ref status);
            Vvd(fd, 0.9999, 1e-7, "Jd2cal", "fd", ref status);
			
            Viv(j, 0, "Jd2cal", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
