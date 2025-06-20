namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Apio13 function.
        /// </summary>
        /// <remarks>
        /// Prepare for CIRS to observed transformation using internal routine.
        /// </remarks>
        [Fact]
        public void TestApio13()
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
            var astrom = new ASTROM();

            var j = Apio13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                           phpa, tc, rh, wl, ref astrom);

            Vvd(astrom.along, -0.5278008060295995733, 1e-12, "Apio13", "along", ref status);
            Vvd(astrom.xpl, 0.1133427418130752958e-5, 1e-17, "Apio13", "xpl", ref status);
            Vvd(astrom.ypl, 0.1453347595780646207e-5, 1e-17, "Apio13", "ypl", ref status);
            Vvd(astrom.sphi, -0.9440115679003211329, 1e-12, "Apio13", "sphi", ref status);
            Vvd(astrom.cphi, 0.3299123514971474711, 1e-12, "Apio13", "cphi", ref status);
            Vvd(astrom.diurab, 0.5135843661699913529e-6, 1e-12, "Apio13", "diurab", ref status);
            Vvd(astrom.eral, 2.617608909189664000, 1e-12, "Apio13", "eral", ref status);
            Vvd(astrom.refa, 0.2014187785940396921e-3, 1e-15, "Apio13", "refa", ref status);
            Vvd(astrom.refb, -0.2361408314943696227e-6, 1e-18, "Apio13", "refb", ref status);
            Viv(j, 0, "Apio13", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
