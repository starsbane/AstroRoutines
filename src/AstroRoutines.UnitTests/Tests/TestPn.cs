namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pn function.
        /// </summary>
        [Fact]
        public void TestPn()
        {
            var p = new double[3];
            var status = 0;

            p[0] = 0.3;
            p[1] = 1.2;
            p[2] = -2.5;

            Pn(p, out var r, out var u);

            Vvd(r, 2.789265136196270604, 1e-12, "Pn", "r", ref status);
            Vvd(u[0], 0.1075552109073112058, 1e-12, "Pn", "u1", ref status);
            Vvd(u[1], 0.4302208436292448232, 1e-12, "Pn", "u2", ref status);
            Vvd(u[2], -0.8962934242275933816, 1e-12, "Pn", "u3", ref status);

            Assert.Equal(0, status);
        }
    }
}
