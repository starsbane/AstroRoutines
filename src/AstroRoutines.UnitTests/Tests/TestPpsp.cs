namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ppsp function.
        /// </summary>
        [Fact]
        public void TestPpsp()
        {
            var status = 0;

            var a = new double[3];
            var b = new double[3];

            a[0] = 2.0;
			a[1] = 2.0;
			a[2] = 3.0;
			
			var s = 5.0;
		
			b[0] = 1.0;
			b[1] = 3.0;
			b[2] = 4.0;
   
            Ppsp(a, s, b, out var apsb);

            Vvd(apsb[0], 7.0, 1e-12, "Ppsp", "0", ref status);
            Vvd(apsb[1], 17.0, 1e-12, "Ppsp", "1", ref status);
            Vvd(apsb[2], 23.0, 1e-12, "Ppsp", "2", ref status);

            Assert.Equal(0, status);
        }
    }
}
