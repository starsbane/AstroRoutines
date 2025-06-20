namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Bp00 function.
        /// </summary>
        /// <remarks>
        /// Frame bias and precession, IAU 2000.
        /// </remarks>
        [Fact]
        public void TestBp00()
        {
            var status = 0;
            var rb = new double[3, 3];
            var rp = new double[3, 3];
            var rbp = new double[3, 3];

            Bp00(2400000.5, 50123.9999, out rb, out rp, out rbp);

            Vvd(rb[0, 0], 0.9999999999999942498, 1e-12, "Bp00", "rb11", ref status);
            Vvd(rb[0, 1], -0.7078279744199196626e-7, 1e-16, "Bp00", "rb12", ref status);
            Vvd(rb[0, 2], 0.8056217146976134152e-7, 1e-16, "Bp00", "rb13", ref status);
            Vvd(rb[1, 0], 0.7078279477857337206e-7, 1e-16, "Bp00", "rb21", ref status);
            Vvd(rb[1, 1], 0.9999999999999969484, 1e-12, "Bp00", "rb22", ref status);
            Vvd(rb[1, 2], 0.3306041454222136517e-7, 1e-16, "Bp00", "rb23", ref status);
            Vvd(rb[2, 0], -0.8056217380986972157e-7, 1e-16, "Bp00", "rb31", ref status);
            Vvd(rb[2, 1], -0.3306040883980552500e-7, 1e-16, "Bp00", "rb32", ref status);
            Vvd(rb[2, 2], 0.9999999999999962084, 1e-12, "Bp00", "rb33", ref status);

            Vvd(rp[0, 0], 0.9999995504864048241, 1e-12, "Bp00", "rp11", ref status);
            Vvd(rp[0, 1], 0.8696113836207084411e-3, 1e-14, "Bp00", "rp12", ref status);
            Vvd(rp[0, 2], 0.3778928813389333402e-3, 1e-14, "Bp00", "rp13", ref status);
            Vvd(rp[1, 0], -0.8696113818227265968e-3, 1e-14, "Bp00", "rp21", ref status);
            Vvd(rp[1, 1], 0.9999996218879365258, 1e-12, "Bp00", "rp22", ref status);
            Vvd(rp[1, 2], -0.1690679263009242066e-6, 1e-14, "Bp00", "rp23", ref status);
            Vvd(rp[2, 0], -0.3778928854764695214e-3, 1e-14, "Bp00", "rp31", ref status);
            Vvd(rp[2, 1], -0.1595521004195286491e-6, 1e-14, "Bp00", "rp32", ref status);
            Vvd(rp[2, 2], 0.9999999285984682756, 1e-12, "Bp00", "rp33", ref status);

            Vvd(rbp[0, 0], 0.9999995505175087260, 1e-12, "Bp00", "rbp11", ref status);
            Vvd(rbp[0, 1], 0.8695405883617884705e-3, 1e-14, "Bp00", "rbp12", ref status);
            Vvd(rbp[0, 2], 0.3779734722239007105e-3, 1e-14, "Bp00", "rbp13", ref status);
            Vvd(rbp[1, 0], -0.8695405990410863719e-3, 1e-14, "Bp00", "rbp21", ref status);
            Vvd(rbp[1, 1], 0.9999996219494925900, 1e-12, "Bp00", "rbp22", ref status);
            Vvd(rbp[1, 2], -0.1360775820404982209e-6, 1e-14, "Bp00", "rbp23", ref status);
            Vvd(rbp[2, 0], -0.3779734476558184991e-3, 1e-14, "Bp00", "rbp31", ref status);
            Vvd(rbp[2, 1], -0.1925857585832024058e-6, 1e-14, "Bp00", "rbp32", ref status);
            Vvd(rbp[2, 2], 0.9999999285680153377, 1e-12, "Bp00", "rbp33", ref status);

            Assert.Equal(0, status);
        }
    }
}
