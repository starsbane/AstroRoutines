namespace AstroRoutines
{
    internal static class DoubleExtensions
    {
        internal static double[] GetRow(this double[,] array, int rowIndex)
        {
            return
                new[]
                {
                    array[rowIndex, 0],
                    array[rowIndex, 1],
                    array[rowIndex, 2]
                };
        }

        internal static void SetRow(this double[,] array, int rowIndex, double[] value)
        {
            for (var i = 0; i < 3; i++)
            {
                array[rowIndex, i] = value[i];
            }
        }
    }
}
