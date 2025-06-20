using Xunit.Abstractions;

//
// Copyright 2025 Alex Man (Starsbane)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Software Routines from the IAU SOFA Collection were used. 
// Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        private readonly ITestOutputHelper output;

        public RATests(ITestOutputHelper output)
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
                output.WriteLine($"{func} failed: {test} want {ivalok} got {ival}");
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
            var a = val - valok;
            if (a != 0.0 && Abs(a) > Abs(dval))
            {
                var f = Abs(valok / a);
                status = 1;
                output.WriteLine($"{func} failed: {test} want {valok:G20} got {val:G20} (1/{f:G3})");
            }
            else if (verbose)
            {
                output.WriteLine($"{func} passed: {test} want {valok:G20} got {val:G20}");
            }
        }

#if VERBOSE
        private static readonly bool verbose = true;
#else
        private static readonly bool verbose = false;
#endif
    }
}
