namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Subtract one pv-vector from another.
        /// 
        /// This function is part of the International Astronomical Union's
        /// SOFA (Standards of Fundamental Astronomy) software collection.
        /// 
        /// Status:  vector/matrix support function.
        /// </summary>
        /// <param name="a">first pv-vector</param>
        /// <param name="b">second pv-vector</param>
        /// <param name="amb">a - b</param>
        public static void Pvmpv(double[,] a, double[,] b, ref double[,] amb)
        {
            double[] ambRow0 = new double[3];
            double[] ambRow1 = new double[3];

            Pmp(a.GetRow(0), b.GetRow(0), ref ambRow0);
            Pmp(a.GetRow(1), b.GetRow(1), ref ambRow1);

            amb.SetRow(0, ambRow0);
            amb.SetRow(1, ambRow1);
        }
    }

}