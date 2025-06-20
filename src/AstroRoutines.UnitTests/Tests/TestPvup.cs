namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pvup function.
        /// </summary>
        [Fact]
        public void TestPvup()
        {
            var status = 0;

            var pv = new double[2, 3];
            var p = new double[3];

            pv[0, 0] = 126668.5912743160734;
            pv[0, 1] = 2136.792716839935565;
            pv[0, 2] = -245251.2339876830229;

            pv[1, 0] = -0.4051854035740713039e-2;
            pv[1, 1] = -0.6253919754866175788e-2;
            pv[1, 2] = 0.1189353719774107615e-1;

            Pvup(2920.0, pv, ref p);

            Vvd(p[0], 126656.7598605317105, 1e-6, "Pvup", "1", ref status);
            Vvd(p[1], 2118.531271155726332, 1e-8, "Pvup", "2", ref status);
            Vvd(p[2], -245216.5048590656190, 1e-6, "Pvup", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
