namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Apcg13 function.
        /// </summary>
        /// <remarks>
        /// Prepare for ICRS to GCRS transformation, using internal routine.
        /// </remarks>
        [Fact]
        public void TestApcg13()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var astrom = new ASTROM();

            Apcg13(date1, date2, ref astrom);

            Vvd(astrom.pmt, 12.65133794027378508, 1e-11, "Apcg13", "pmt", ref status);
            Vvd(astrom.eb[0], 0.9013108747340644755, 1e-12, "Apcg13", "eb(1)", ref status);
            Vvd(astrom.eb[1], -0.4174026640406119957, 1e-12, "Apcg13", "eb(2)", ref status);
            Vvd(astrom.eb[2], -0.1809822877867817771, 1e-12, "Apcg13", "eb(3)", ref status);
            Vvd(astrom.eh[0], 0.8940025429255499549, 1e-12, "Apcg13", "eh(1)", ref status);
            Vvd(astrom.eh[1], -0.4110930268331896318, 1e-12, "Apcg13", "eh(2)", ref status);
            Vvd(astrom.eh[2], -0.1782189006019749850, 1e-12, "Apcg13", "eh(3)", ref status);
            Vvd(astrom.em, 1.010465295964664178, 1e-12, "Apcg13", "em", ref status);
            Vvd(astrom.v[0], 0.4289638912941341125e-4, 1e-16, "Apcg13", "v(1)", ref status);
            Vvd(astrom.v[1], 0.8115034032405042132e-4, 1e-16, "Apcg13", "v(2)", ref status);
            Vvd(astrom.v[2], 0.3517555135536470279e-4, 1e-16, "Apcg13", "v(3)", ref status);
            Vvd(astrom.bm1, 0.9999999951686013142, 1e-12, "Apcg13", "bm1", ref status);

            // Checking BPN matrix
            Vvd(astrom.bpn[0, 0], 1.0, 0.0, "Apcg13", "bpn(1,1)", ref status);
            Vvd(astrom.bpn[0, 1], 0.0, 0.0, "Apcg13", "bpn(1,2)", ref status);
            Vvd(astrom.bpn[0, 2], 0.0, 0.0, "Apcg13", "bpn(1,3)", ref status);
            Vvd(astrom.bpn[1, 0], 0.0, 0.0, "Apcg13", "bpn(2,1)", ref status);
            Vvd(astrom.bpn[1, 1], 1.0, 0.0, "Apcg13", "bpn(2,2)", ref status);
            Vvd(astrom.bpn[1, 2], 0.0, 0.0, "Apcg13", "bpn(2,3)", ref status);
            Vvd(astrom.bpn[2, 0], 0.0, 0.0, "Apcg13", "bpn(3,1)", ref status);
            Vvd(astrom.bpn[2, 1], 0.0, 0.0, "Apcg13", "bpn(3,2)", ref status);
            Vvd(astrom.bpn[2, 2], 1.0, 0.0, "Apcg13", "bpn(3,3)", ref status);

            Assert.Equal(0, status);
        }
    }
}
