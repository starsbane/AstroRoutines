namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Atioq function.
        /// </summary>
        /// <remarks>
        /// Quick transformation of CIRS RA,Dec to observed place.
        /// </remarks>
        [Fact]
        public void TestAtioq()
        {
            var status = 0;
            var utc1 = 2456384.5;
            var utc2 = 0.969254051;
            var dut1 = 0.1550675;
            var elong = -0.527800806;
            var phi = -1.2345856;
            var hm = 2738.0;
            var xp = 2.47230737e-7;
            var yp = 1.82640464e-6;
            var phpa = 731.0;
            var tc = 12.8;
            var rh = 0.59;
            var wl = 0.55;
            var ri = 2.710121572969038991;
            var di = 0.1729371367218230438;
            var astrom = new ASTROM();
            double aob, zob, hob, dob, rob;

            Apio13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                   phpa, tc, rh, wl, ref astrom);

            Atioq(ri, di, ref astrom, out aob, out zob, out hob, out dob, out rob);

            Vvd(aob, 0.9233952224895122499e-1, 1e-12, "Atioq", "aob", ref status);
            Vvd(zob, 1.407758704513549991, 1e-12, "Atioq", "zob", ref status);
            Vvd(hob, -0.9247619879881698140e-1, 1e-12, "Atioq", "hob", ref status);
            Vvd(dob, 0.1717653435756234676, 1e-12, "Atioq", "dob", ref status);
            Vvd(rob, 2.710085107988480746, 1e-12, "Atioq", "rob", ref status);

            Assert.Equal(0, status);
        }
    }
}
