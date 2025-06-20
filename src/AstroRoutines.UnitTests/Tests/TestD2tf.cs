namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test D2tf function.
        /// </summary>
        [Fact]
        public void TestD2tf()
        {
            var status = 0;
            var ihmsf = new int[4];
            var s = ' ';

            D2tf(4, -0.987654321, out s, ref ihmsf);

            Viv((int)s, '-', "D2tf", "s", ref status);
            Viv(ihmsf[0], 23, "D2tf", "0", ref status);
            Viv(ihmsf[1], 42, "D2tf", "1", ref status);
            Viv(ihmsf[2], 13, "D2tf", "2", ref status);
            Viv(ihmsf[3], 3333, "D2tf", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
