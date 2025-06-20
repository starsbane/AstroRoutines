namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tr function.
        /// </summary>
        [Fact]
        public void TestTr()
        {
            var status = 0;
			
            var r = new double[3, 3];
            var rt = new double[3, 3];

            r[0, 0] = 2.0;
            r[0, 1] = 3.0;
            r[0, 2] = 2.0;

            r[1, 0] = 3.0;
            r[1, 1] = 2.0;
            r[1, 2] = 3.0;

            r[2, 0] = 3.0;
            r[2, 1] = 4.0;
            r[2, 2] = 5.0;

            Tr(r, ref rt);

            Vvd(rt[0, 0], 2.0, 0.0, "Tr", "11", ref status);
            Vvd(rt[0, 1], 3.0, 0.0, "Tr", "12", ref status);
            Vvd(rt[0, 2], 3.0, 0.0, "Tr", "13", ref status);

            Vvd(rt[1, 0], 3.0, 0.0, "Tr", "21", ref status);
            Vvd(rt[1, 1], 2.0, 0.0, "Tr", "22", ref status);
            Vvd(rt[1, 2], 4.0, 0.0, "Tr", "23", ref status);

            Vvd(rt[2, 0], 2.0, 0.0, "Tr", "31", ref status);
            Vvd(rt[2, 1], 3.0, 0.0, "Tr", "32", ref status);
            Vvd(rt[2, 2], 5.0, 0.0, "Tr", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
