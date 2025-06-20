namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Ry function.
        /// </summary>
        [Fact]
        public void TestRy()
        {
            var status = 0;

            var theta = 0.3456789;
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

            Ry(theta, ref r);

            Vvd(r[0, 0], 0.8651847818978159930, 1e-12, "Ry", "11", ref status);
            Vvd(r[0, 1], 1.467194920539316554, 1e-12, "Ry", "12", ref status);
            Vvd(r[0, 2], 0.1875137911274457342, 1e-12, "Ry", "13", ref status);

            Vvd(r[1, 0], 3, 1e-12, "Ry", "21", ref status);
            Vvd(r[1, 1], 2, 1e-12, "Ry", "22", ref status);
            Vvd(r[1, 2], 3, 1e-12, "Ry", "23", ref status);

            Vvd(r[2, 0], 3.500207892850427330, 1e-12, "Ry", "31", ref status);
            Vvd(r[2, 1], 4.779889022262298150, 1e-12, "Ry", "32", ref status);
            Vvd(r[2, 2], 5.381899160903798712, 1e-12, "Ry", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
