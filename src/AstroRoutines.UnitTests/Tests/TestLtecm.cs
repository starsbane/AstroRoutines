namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Ltecm function.
        /// </summary>
        [Fact]
        public void TestLtecm()
        {
			var status = 0;
            var epj = -3000.0;
            var rm = new double[3, 3];

            Ltecm(epj, rm);

            Vvd(rm[0, 0], 0.3564105644859788825, 1e-14, "Ltecm", "rm11", ref status);
            Vvd(rm[0, 1], 0.8530575738617682284, 1e-14, "Ltecm", "rm12", ref status);
            Vvd(rm[0, 2], 0.3811355207795060435, 1e-14, "Ltecm", "rm13", ref status);
            Vvd(rm[1, 0], -0.9343283469640709942, 1e-14, "Ltecm", "rm21", ref status);
            Vvd(rm[1, 1], 0.3247830597681745976, 1e-14, "Ltecm", "rm22", ref status);
            Vvd(rm[1, 2], 0.1467872751535940865, 1e-14, "Ltecm", "rm23", ref status);
            Vvd(rm[2, 0], 0.1431636191201167793e-2, 1e-14, "Ltecm", "rm31", ref status);
            Vvd(rm[2, 1], -0.4084222566960599342, 1e-14, "Ltecm", "rm32", ref status);
            Vvd(rm[2, 2], 0.9127919865189030899, 1e-14, "Ltecm", "rm33", ref status);

            Assert.Equal(0, status);
        }
    }
}
