namespace AstroRoutines
{
	public static partial class AR
	{
		/// <summary>
		/// Multiply two r-matrices.
		/// </summary>
		/// <param name="a">first r-matrix</param>
		/// <param name="b">second r-matrix</param>
		/// <param name="atb">a * b</param>
		public static void Rxr(double[,] a, double[,] b, ref double[,] atb)
		{
			double w;
			var wm = new double[3, 3];

			for (var i = 0; i < 3; i++)
			{
				for (var j = 0; j < 3; j++)
				{
					w = 0.0;
					for (var k = 0; k < 3; k++)
					{
						w += a[i, k] * b[k, j];
					}
					wm[i, j] = w;
				}
			}
			Cr(wm, ref atb);
		}
	}
}