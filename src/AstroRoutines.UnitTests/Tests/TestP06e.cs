namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test P06e function.
        /// </summary>
        [Fact]
        public void TestP06e()
        {
            var status = 0;
            double eps0, psia, oma, bpa, bqa, pia, bpia,
                   epsa, chia, za, zetaa, thetaa, pa, gam, phi, psi;

            P06e(2400000.5, 52541.0, out eps0, out psia, out oma, out bpa,
                out bqa, out pia, out bpia, out epsa, out chia, out za,
                out zetaa, out thetaa, out pa, out gam, out phi, out psi);

            Vvd(eps0, 0.4090926006005828715, 1e-14, "P06e", "eps0", ref status);
            Vvd(psia, 0.6664369630191613431e-3, 1e-14, "P06e", "psia", ref status);
            Vvd(oma, 0.4090925973783255982, 1e-14, "P06e", "oma", ref status);
            Vvd(bpa, 0.5561149371265209445e-6, 1e-14, "P06e", "bpa", ref status);
            Vvd(bqa, -0.6191517193290621270e-5, 1e-14, "P06e", "bqa", ref status);
            Vvd(pia, 0.6216441751884382923e-5, 1e-14, "P06e", "pia", ref status);
            Vvd(bpia, 3.052014180023779882, 1e-14, "P06e", "bpia", ref status);
            Vvd(epsa, 0.4090864054922431688, 1e-14, "P06e", "epsa", ref status);
            Vvd(chia, 0.1387703379530915364e-5, 1e-14, "P06e", "chia", ref status);
            Vvd(za, 0.2921789846651790546e-3, 1e-14, "P06e", "za", ref status);
            Vvd(zetaa, 0.3178773290332009310e-3, 1e-14, "P06e", "zetaa", ref status);
            Vvd(thetaa, 0.2650932701657497181e-3, 1e-14, "P06e", "thetaa", ref status);
            Vvd(pa, 0.6651637681381016288e-3, 1e-14, "P06e", "pa", ref status);
            Vvd(gam, 0.1398077115963754987e-5, 1e-14, "P06e", "gam", ref status);
            Vvd(phi, 0.4090864090837462602, 1e-14, "P06e", "phi", ref status);
            Vvd(psi, 0.6664464807480920325e-3, 1e-14, "P06e", "psi", ref status);

            Assert.Equal(0, status);
        }
    }
}
