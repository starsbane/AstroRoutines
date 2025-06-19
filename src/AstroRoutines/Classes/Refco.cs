namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Determine the constants A and B in the atmospheric refraction model.
    /// </summary>
    /// <param name="phpa">Pressure at the observer (hPa = millibar)</param>
    /// <param name="tc">Ambient temperature at the observer (deg C)</param>
    /// <param name="rh">Relative humidity at the observer (range 0-1)</param>
    /// <param name="wl">Wavelength (micrometers)</param>
    /// <param name="refa">Tan Z coefficient (radians)</param>
    /// <param name="refb">Tan^3 Z coefficient (radians)</param>
    public static void Refco(double phpa, double tc, double rh, double wl,
                              out double refa, out double refb)
    {
        int optic;
        double p, t, r, w, ps, pw, tk, wlsq, gamma, beta;

        // Decide whether optical/IR or radio case: switch at 100 microns
        optic = (wl <= 100.0) ? 1 : 0;

        // Restrict parameters to safe values
        t = Max(tc, -150.0);
        t = Min(t, 200.0);
        p = Max(phpa, 0.0);
        p = Min(p, 10000.0);
        r = Max(rh, 0.0);
        r = Min(r, 1.0);
        w = Max(wl, 0.1);
        w = Min(w, 1e6);

        // Water vapour pressure at the observer
        if (p > 0.0)
        {
            ps = Pow(10.0, (0.7859 + 0.03477 * t) / (1.0 + 0.00412 * t)) *
                 (1.0 + p * (4.5e-6 + 6e-10 * t * t));
            pw = r * ps / (1.0 - (1.0 - r) * ps / p);
        }
        else
        {
            pw = 0.0;
        }

        // Refractive index minus 1 at the observer
        tk = t + 273.15;
        if (optic == 1)
        {
            wlsq = w * w;
            gamma = ((77.53484e-6 +
                     (4.39108e-7 + 3.666e-9 / wlsq) / wlsq) * p
                        - 11.2684e-6 * pw) / tk;
        }
        else
        {
            gamma = (77.6890e-6 * p - (6.3938e-6 - 0.375463 / tk) * pw) / tk;
        }

        // Formula for beta from Stone, with empirical adjustments
        beta = 4.4474e-6 * tk;
        if (optic == 0) beta -= 0.0074 * pw * beta;

        // Refraction constants from Green
        refa = gamma * (1.0 - beta);
        refb = -gamma * (beta - gamma / 2.0);
    }
}
