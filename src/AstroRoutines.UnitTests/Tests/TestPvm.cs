namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Pvm function.
        /// </summary>
        [Fact]
        public void TestPvm()
        {
            var status = 0;

            var pv = new double[2, 3];
            double r, s;

            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = 0.45;
            pv[1, 1] = -0.25;
            pv[1, 2] = 1.1;

            Pvm(pv, out r, out s);

            Vvd(r, 2.789265136196270604, 1e-12, "Pvm", "r", ref status);
            Vvd(s, 1.214495780149111922, 1e-12, "Pvm", "s", ref status);

            Assert.Equal(0, status);
        }
    }
}
