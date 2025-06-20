namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Bp06 function.
        /// </summary>
        /// <remarks>
        /// Frame bias and precession, IAU 2006.
        /// </remarks>
        [Fact]
        public void TestBp06()
        {
            var status = 0;

            Bp06(2400000.5, 50123.9999, out var rb, out var rp, out var rbp);

            Vvd(rb[0, 0], 0.9999999999999942497, 1e-12, "Bp06", "rb11", ref status);
            Vvd(rb[0, 1], -0.7078368960971557145e-7, 1e-14, "Bp06", "rb12", ref status);
            Vvd(rb[0, 2], 0.8056213977613185606e-7, 1e-14, "Bp06", "rb13", ref status);
            Vvd(rb[1, 0], 0.7078368694637674333e-7, 1e-14, "Bp06", "rb21", ref status);
            Vvd(rb[1, 1], 0.9999999999999969484, 1e-12, "Bp06", "rb22", ref status);
            Vvd(rb[1, 2], 0.3305943742989134124e-7, 1e-14, "Bp06", "rb23", ref status);
            Vvd(rb[2, 0], -0.8056214211620056792e-7, 1e-14, "Bp06", "rb31", ref status);
            Vvd(rb[2, 1], -0.3305943172740586950e-7, 1e-14, "Bp06", "rb32", ref status);
            Vvd(rb[2, 2], 0.9999999999999962084, 1e-12, "Bp06", "rb33", ref status);

            Vvd(rp[0, 0], 0.9999995504864960278, 1e-12, "Bp06", "rp11", ref status);
            Vvd(rp[0, 1], 0.8696112578855404832e-3, 1e-14, "Bp06", "rp12", ref status);
            Vvd(rp[0, 2], 0.3778929293341390127e-3, 1e-14, "Bp06", "rp13", ref status);
            Vvd(rp[1, 0], -0.8696112560510186244e-3, 1e-14, "Bp06", "rp21", ref status);
            Vvd(rp[1, 1], 0.9999996218880458820, 1e-12, "Bp06", "rp22", ref status);
            Vvd(rp[1, 2], -0.1691646168941896285e-6, 1e-14, "Bp06", "rp23", ref status);
            Vvd(rp[2, 0], -0.3778929335557603418e-3, 1e-14, "Bp06", "rp31", ref status);
            Vvd(rp[2, 1], -0.1594554040786495076e-6, 1e-14, "Bp06", "rp32", ref status);
            Vvd(rp[2, 2], 0.9999999285984501222, 1e-12, "Bp06", "rp33", ref status);

            Vvd(rbp[0, 0], 0.9999995505176007047, 1e-12, "Bp06", "rbp11", ref status);
            Vvd(rbp[0, 1], 0.8695404617348208406e-3, 1e-14, "Bp06", "rbp12", ref status);
            Vvd(rbp[0, 2], 0.3779735201865589104e-3, 1e-14, "Bp06", "rbp13", ref status);
            Vvd(rbp[1, 0], -0.8695404723772031414e-3, 1e-14, "Bp06", "rbp21", ref status);
            Vvd(rbp[1, 1], 0.9999996219496027161, 1e-12, "Bp06", "rbp22", ref status);
            Vvd(rbp[1, 2], -0.1361752497080270143e-6, 1e-14, "Bp06", "rbp23", ref status);
            Vvd(rbp[2, 0], -0.3779734957034089490e-3, 1e-14, "Bp06", "rbp31", ref status);
            Vvd(rbp[2, 1], -0.1924880847894457113e-6, 1e-14, "Bp06", "rbp32", ref status);
            Vvd(rbp[2, 2], 0.9999999285679971958, 1e-12, "Bp06", "rbp33", ref status);

            Assert.Equal(0, status);
        }
    }
}
