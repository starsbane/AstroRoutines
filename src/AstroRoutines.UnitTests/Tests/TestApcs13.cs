namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Apcs13 function.
        /// </summary>
        /// <remarks>
        /// Prepare for ICRS to GCRS transformation, using internal routine.
        /// </remarks>
        [Fact]
        public void TestApcs13()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var pv = new double[2, 3];
            var astrom = new ASTROM();

            pv[0, 0] = -6241497.16;
            pv[0, 1] = 401346.896;
            pv[0, 2] = -1251136.04;
            pv[1, 0] = -29.264597;
            pv[1, 1] = -455.021831;
            pv[1, 2] = 0.0266151194;

            Apcs13(date1, date2, pv, ref astrom);

            Vvd(astrom.pmt, 12.65133794027378508, 1e-11, "Apcs13", "pmt", ref status);
            Vvd(astrom.eb[0], 0.9012691529025250644, 1e-12, "Apcs13", "eb(1)", ref status);
            Vvd(astrom.eb[1], -0.4173999812023194317, 1e-12, "Apcs13", "eb(2)", ref status);
            Vvd(astrom.eb[2], -0.1809906511146429670, 1e-12, "Apcs13", "eb(3)", ref status);
            Vvd(astrom.eh[0], 0.8939939101760130792, 1e-12, "Apcs13", "eh(1)", ref status);
            Vvd(astrom.eh[1], -0.4111053891734021478, 1e-12, "Apcs13", "eh(2)", ref status);
            Vvd(astrom.eh[2], -0.1782336880636997374, 1e-12, "Apcs13", "eh(3)", ref status);
            Vvd(astrom.em, 1.010428384373491095, 1e-12, "Apcs13", "em", ref status);
            Vvd(astrom.v[0], 0.4279877294121697570e-4, 1e-16, "Apcs13", "v(1)", ref status);
            Vvd(astrom.v[1], 0.7963255087052120678e-4, 1e-16, "Apcs13", "v(2)", ref status);
            Vvd(astrom.v[2], 0.3517564013384691531e-4, 1e-16, "Apcs13", "v(3)", ref status);
            Vvd(astrom.bm1, 0.9999999952947980978, 1e-12, "Apcs13", "bm1", ref status);
            
            // Checking BPN matrix
            Vvd(astrom.bpn[0, 0], 1, 0, "Apcs13", "bpn(1,1)", ref status);
            Vvd(astrom.bpn[0, 1], 0, 0, "Apcs13", "bpn(1,2)", ref status);
            Vvd(astrom.bpn[0, 2], 0, 0, "Apcs13", "bpn(1,3)", ref status);
            Vvd(astrom.bpn[1, 0], 0, 0, "Apcs13", "bpn(2,1)", ref status);
            Vvd(astrom.bpn[1, 1], 1, 0, "Apcs13", "bpn(2,2)", ref status);
            Vvd(astrom.bpn[1, 2], 0, 0, "Apcs13", "bpn(2,3)", ref status);
            Vvd(astrom.bpn[2, 0], 0, 0, "Apcs13", "bpn(3,1)", ref status);
            Vvd(astrom.bpn[2, 1], 0, 0, "Apcs13", "bpn(3,2)", ref status);
            Vvd(astrom.bpn[2, 2], 1, 0, "Apcs13", "bpn(3,3)", ref status);

            Assert.Equal(0, status);
        }
    }
}
