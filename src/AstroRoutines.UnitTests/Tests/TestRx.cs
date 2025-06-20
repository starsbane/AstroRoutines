namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Rx function.
        /// </summary>
        [Fact]
        public void TestRx()
        {
            var status = 0;

            var phi = 0.3456789;
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

            Rx(phi, ref r);

            Vvd(r[0, 0], 2.0, 0.0, "Rx", "11", ref status);
            Vvd(r[0, 1], 3.0, 0.0, "Rx", "12", ref status);
            Vvd(r[0, 2], 2.0, 0.0, "Rx", "13", ref status);

            Vvd(r[1, 0], 3.839043388235612460, 1e-12, "Rx", "21", ref status);
            Vvd(r[1, 1], 3.237033249594111899, 1e-12, "Rx", "22", ref status);
            Vvd(r[1, 2], 4.516714379005982719, 1e-12, "Rx", "23", ref status);

            Vvd(r[2, 0], 1.806030415924501684, 1e-12, "Rx", "31", ref status);
            Vvd(r[2, 1], 3.085711545336372503, 1e-12, "Rx", "32", ref status);
            Vvd(r[2, 2], 3.687721683977873065, 1e-12, "Rx", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
