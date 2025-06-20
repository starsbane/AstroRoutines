namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Rz function.
        /// </summary>
        [Fact]
        public void TestRz()
        {
            var status = 0;

            var psi = 0.3456789;
            var r = new double[3, 3];

            r[0, 0] = 2.0;
            r[0, 1] = 3.0;
            r[0, 2] = 2.0;

            r[1, 0] = 3.0;
            r[1, 1] = 2.0;
            r[1, 2] = 3.0;

            r[2, 0] = 3.0;
            r[2, 1] = 4.0;
            r[2, 2] = 5.0;

            Rz(psi, ref r);

            Vvd(r[0, 0], 2.898197754208926769, 1e-12, "Rz", "11", ref status);
            Vvd(r[0, 1], 3.500207892850427330, 1e-12, "Rz", "12", ref status);
            Vvd(r[0, 2], 2.898197754208926769, 1e-12, "Rz", "13", ref status);

            Vvd(r[1, 0], 2.144865911309686813, 1e-12, "Rz", "21", ref status);
            Vvd(r[1, 1], 0.865184781897815993, 1e-12, "Rz", "22", ref status);
            Vvd(r[1, 2], 2.144865911309686813, 1e-12, "Rz", "23", ref status);

            Vvd(r[2, 0], 3.0, 1e-12, "Rz", "31", ref status);
            Vvd(r[2, 1], 4.0, 1e-12, "Rz", "32", ref status);
            Vvd(r[2, 2], 5.0, 1e-12, "Rz", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
