namespace AstroRoutines.Structs
{
    /* Star-independent astrometry parameters */
    public class ASTROM
    {
        public double pmt;        /* PM time interval (SSB, Julian years) */
        public double[] eb;       /* SSB to observer (vector, au) */
        public double[] eh;       /* Sun to observer (unit vector) */
        public double em;         /* distance from Sun to observer (au) */
        public double[] v;        /* barycentric observer velocity (vector, c) */
        public double bm1;        /* sqrt(1-|v|^2): reciprocal of Lorenz factor */
        public double[,] bpn;     /* bias-precession-nutation matrix */
        public double along;      /* longitude + s' + dERA(DUT) (radians) */
        public double phi;        /* geodetic latitude (radians) */
        public double xpl;        /* polar motion xp wrt local meridian (radians) */
        public double ypl;        /* polar motion yp wrt local meridian (radians) */
        public double sphi;       /* sine of geodetic latitude */
        public double cphi;       /* cosine of geodetic latitude */
        public double diurab;     /* magnitude of diurnal aberration vector */
        public double eral;       /* "local" Earth rotation angle (radians) */
        public double refa;       /* refraction constant A (radians) */
        public double refb;       /* refraction constant B (radians) */

        public ASTROM()
        {
            pmt = 0.0;
            eb = new double[3];
            eh = new double[3];
            em = 0.0;
            v = new double[3];
            bm1 = 0.0;
            bpn = new double[3, 3];
            along = 0.0;
            phi = 0.0;
            xpl = 0.0;
            ypl = 0.0;
            sphi = 0.0;
            cphi = 0.0;
            diurab = 0.0;
            eral = 0.0;
            refa = 0.0;
            refb = 0.0;
        }
    }

    /* Body parameters for light deflection */
    public class LDBODY
    {
        public double bm;         /* mass of the body (solar masses) */
        public double dl;         /* deflection limiter (radians^2/2) */
        public double[,] pv;      /* barycentric PV of the body (au, au/day) */

        public LDBODY()
        {
            bm = 0.0;
            dl = 0.0;
            pv = new double[2, 3];
        }
    }
}
