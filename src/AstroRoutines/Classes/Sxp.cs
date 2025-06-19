namespace AstroRoutines
{
	public static partial class AR
	{
		/// <summary>
		/// Multiply a p-vector by a scalar.
		/// </summary>
		/// <param name="s">scalar</param>
		/// <param name="p">p-vector</param>
		/// <param name="sp">s * p</param>
		public static void Sxp(double s, double[] p, ref double[] sp)
		{
			sp[0] = s * p[0];
			sp[1] = s * p[1];
			sp[2] = s * p[2];
		}
	}
}