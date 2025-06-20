namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Rv2m function.
        /// </summary>
        [Fact]
        public void TestRv2m()
        {
            var status = 0;

            var w = new double[3];
            var r = new double[3, 3];

            w[0] = 0.0;
            w[1] = 1.41371669;
            w[2] = -1.88495559;

            Rv2m(w, ref r);

            Vvd(r[0, 0], -0.7071067782221119905, 1e-14, "Rv2m", "11", ref status);
            Vvd(r[0, 1], -0.5656854276809129651, 1e-14, "Rv2m", "12", ref status);
            Vvd(r[0, 2], -0.4242640700104211225, 1e-14, "Rv2m", "13", ref status);

            Vvd(r[1, 0], 0.5656854276809129651, 1e-14, "Rv2m", "21", ref status);
            Vvd(r[1, 1], -0.0925483394532274246, 1e-14, "Rv2m", "22", ref status);
            Vvd(r[1, 2], -0.8194112531408833269, 1e-14, "Rv2m", "23", ref status);

            Vvd(r[2, 0], 0.4242640700104211225, 1e-14, "Rv2m", "31", ref status);
            Vvd(r[2, 1], -0.8194112531408833269, 1e-14, "Rv2m", "32", ref status);
            Vvd(r[2, 2], 0.3854415612311154341, 1e-14, "Rv2m", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
