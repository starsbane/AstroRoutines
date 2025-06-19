using Xunit.Abstractions;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        private readonly ITestOutputHelper output;

        public SofaTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Validate an integer result.
        /// </summary>
        private void Viv(int ival, int ivalok, string func, string test, ref int status)
        {
            if (ival != ivalok)
            {
                status = 1;
                Assert.Fail($"{func} failed: {test} want {ivalok} got {ival}");
            }
            else if (verbose)
            {
                output.WriteLine($"{func} passed: {test} want {ivalok} got {ival}");
            }
        }

        /// <summary>
        /// Validate a double result.
        /// </summary>
        private void Vvd(double val, double valok, double dval, string func, string test, ref int status)
        {
            double a = val - valok;
            if (a != 0.0 && Abs(a) > Abs(dval))
            {
                double f = Abs(valok / a);
                status = 1;
                Assert.Fail($"{func} failed: {test} want {valok:G20} got {val:G20} (1/{f:G3})");
            }
            else if (verbose)
            {
                output.WriteLine($"{func} passed: {test} want {valok:G20} got {val:G20}");
            }
        }

#if DEBUG
        private static readonly bool verbose = true;
#else
        private static readonly bool verbose = false;
#endif
    }
}
