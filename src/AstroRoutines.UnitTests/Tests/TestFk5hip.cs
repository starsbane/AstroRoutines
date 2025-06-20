namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fk5hip function.
        /// </summary>
        [Fact]
        public void TestFk5hip()
        {
            var status = 0;

            Fk5hip(out var r5h, out var s5h);

            Vvd(r5h[0, 0], 0.9999999999999928638, 1e-14, "Fk5hip", "11", ref status);
            Vvd(r5h[0, 1], 0.1110223351022919694e-6, 1e-17, "Fk5hip", "12", ref status);
            Vvd(r5h[0, 2], 0.4411803962536558154e-7, 1e-17, "Fk5hip", "13", ref status);
            Vvd(r5h[1, 0], -0.1110223308458746430e-6, 1e-17, "Fk5hip", "21", ref status);
            Vvd(r5h[1, 1], 0.9999999999999891830, 1e-14, "Fk5hip", "22", ref status);
            Vvd(r5h[1, 2], -0.9647792498984142358e-7, 1e-17, "Fk5hip", "23", ref status);
            Vvd(r5h[2, 0], -0.4411805033656962252e-7, 1e-17, "Fk5hip", "31", ref status);
            Vvd(r5h[2, 1], 0.9647792009175314354e-7, 1e-17, "Fk5hip", "32", ref status);
            Vvd(r5h[2, 2], 0.9999999999999943728, 1e-14, "Fk5hip", "33", ref status);
            Vvd(s5h[0], -0.1454441043328607981e-8, 1e-17, "Fk5hip", "s1", ref status);
            Vvd(s5h[1], 0.2908882086657215962e-8, 1e-17, "Fk5hip", "s2", ref status);
            Vvd(s5h[2], 0.3393695767766751955e-8, 1e-17, "Fk5hip", "s3", ref status);

            Assert.Equal(0, status);
        }
    }
}
