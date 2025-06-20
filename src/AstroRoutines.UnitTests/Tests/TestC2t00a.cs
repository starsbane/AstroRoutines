namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test C2t00a function.
        /// </summary>
        [Fact]
        public void TestC2t00a()
        {
            var rc2t = new double[3, 3];
            var status = 0;

            var tta = 2400000.5;
            var ttb = 53736.0;
            var uta = 2400000.5;
            var utb = 53736.0;
            var xp = 2.55060238e-7;
            var yp = 1.860359247e-6;

            C2t00a(tta, ttb, uta, utb, xp, yp, out rc2t);

            Vvd(rc2t[0, 0], -0.1810332128307182668, 1e-12, "C2t00a", "11", ref status);
            Vvd(rc2t[0, 1], 0.9834769806938457836, 1e-12, "C2t00a", "12", ref status);
            Vvd(rc2t[0, 2], 0.6555535638688341725e-4, 1e-12, "C2t00a", "13", ref status);

            Vvd(rc2t[1, 0], -0.9834768134135984552, 1e-12, "C2t00a", "21", ref status);
            Vvd(rc2t[1, 1], -0.1810332203649520727, 1e-12, "C2t00a", "22", ref status);
            Vvd(rc2t[1, 2], 0.5749801116141056317e-3, 1e-12, "C2t00a", "23", ref status);

            Vvd(rc2t[2, 0], 0.5773474014081406921e-3, 1e-12, "C2t00a", "31", ref status);
            Vvd(rc2t[2, 1], 0.3961832391770163647e-4, 1e-12, "C2t00a", "32", ref status);
            Vvd(rc2t[2, 2], 0.9999998325501692289, 1e-12, "C2t00a", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
