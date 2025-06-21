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

using AstroRoutines;

namespace AstroRoutines.Samples.NetCore
{

    internal class RASamples
    {
        // Some examples are taken from PyMsOfa's repository (https://github.com/CHES2023/PyMsOfa)
        //
        // Copyright (c) 2023 CHES
        // 
        // Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
        // documentation files (the “Software”), to deal in the Software without restriction, including without limitation the 
        // rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit
        // persons to whom the Software is furnished to do so, subject to the following conditions:
        //
        // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
        // WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
        // COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
        // OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

        /// <summary>
        /// Example for the calculation of the RA and DEC at the given epoch.
        /// </summary>
        /// <remarks>
        /// Reference: Ji, Jiang-Hui, Tan, Dong-jie, Bao, Chun-hui, Huang, Xiu-min, Hu, Shoucun, Dong, Yao, Wang, Su. 2023,
        /// PyMsOfa: A Python Package for the Standards of Fundamental Astronomy (SOFA) Service,
        /// Research in Astronomy and Astrophysics, 23, 125015, doi:10.1088/1674-4527/ad0499
        /// </remarks>
        public void RADECCalculationExample()
        {
            var ra1 = 0.08788796644747092;
            var dec1 = -1.132188403551008;
            var pmr1 = 8.27454225597756e-06;
            var pmd1 = 5.647882757242327e-06;
            var px1 = 116.18257854098105e-3;
            var rv1 = 9.283571;
            var ep1a = Constants.DJM0;
            var ep1b = 57388.450625000056;
            var ep2a = Constants.DJM0;
            var ep2b = 60991.538933193;

            double ra2 = 0, dec2 = 0, pmr2 = 0, pmd2 = 0, px2 = 0, rv2 = 0;

            var j = AR.Pmsafe(ra1, dec1, pmr1, pmd1, px1, rv1, ep1a, ep1b, ep2a, ep2b
                , ref ra2, ref dec2, ref pmr2, ref pmd2, ref px2, ref rv2);

            Console.WriteLine($"{nameof(RADECCalculationExample)}: {nameof(ra2)} = {ra2}, {nameof(dec2)} = {dec2}");
        }

        /// <summary>
        /// Example for the calculation of the rectangular coordinates on focal plane.
        /// </summary>
        /// <remarks>
        /// Reference: Ji, Jiang-Hui, Tan, Dong-jie, Bao, Chun-hui, Huang, Xiu-min, Hu, Shoucun, Dong, Yao, Wang, Su. 2023,
        /// PyMsOfa: A Python Package for the Standards of Fundamental Astronomy (SOFA) Service,
        /// Research in Astronomy and Astrophysics, 23, 125015, doi:10.1088/1674-4527/ad0499
        /// </remarks>
        public void FocalPlaneRectCoordinatesCalcExample()
        {
            var a = 0.0902535601897608;
            var b = -1.1308652476489707;

            var a0 = 0.08796958189264041;
            var b0 = -1.1321326881050646;

            double xi = 0, eta = 0;
            AR.Tpxes(a, b, a0, b0, ref xi, ref eta);

            Console.WriteLine($"{nameof(FocalPlaneRectCoordinatesCalcExample)}: {nameof(xi)} = {xi}, {nameof(eta)} = {eta}");
        }

        /// <summary>
        /// An example for the precession-nutation calculation taken from PyMsOfa's repository (https://github.com/CHES2023/PyMsOfa).
        /// <summary></summary>
        /// <remarks>
        /// Reference: Wallace P T, Capitaine N. Precession-nutation procedures consistent with 
        /// IAU 2006 resolutions[J]. Astronomy & Astrophysics, 2006, 459(3): 981-985.
        /// </remarks>
        public void PrecessionNutationCalcExample()
        {
            AR.Cal2jd(2006, 1, 15, out var utc1, out var utc2);

            AR.Tf2d('+', 21, 24, 37.5, out var days);

            utc2 += days;

            var dut1 = 0.3341;
            double date1 = 0, date2 = 0;
            AR.Utcut1(utc1, utc2, dut1, ref date1, ref date2);

            Console.WriteLine($"{nameof(PrecessionNutationCalcExample)}: {nameof(date1)} = {date1}, {nameof(date2)} = {date2}");

            AR.Pn06a(date1, date2, out var dpsi, out var deps, out var epsa, out var rb, out var rp, out var rbp, out var rn, out var rbpn);

            Console.WriteLine();
            for (var i = 0; i < rbpn.GetLength(0); i++)
            {
                for (var j = 0; j < rbpn.GetLength(1); j++)
                {
                    Console.WriteLine($"{nameof(PrecessionNutationCalcExample)}: {nameof(rbpn)}[{i},{j}] = {rbpn[i,j]:E8}");
                }
            }

            double x = 0, y = 0, s = 0;
            AR.Xys06a(date1, date2, ref x, ref y, ref s);

            var cio = new double[3, 3];
            AR.C2ixys(x, y, s, ref cio);

            Console.WriteLine();
            for (var i = 0; i < cio.GetLength(0); i++)
            {
                for (var j = 0; j < cio.GetLength(1); j++)
                {
                    Console.WriteLine($"{nameof(PrecessionNutationCalcExample)}: {nameof(cio)}[{i},{j}] = {cio[i, j]:E8}");
                }
            }

            var era0 = AR.Era00(date1, date2);

            AR.Rz(era0, ref cio);

            var era = new int[4];
            AR.A2tf(5, era0, out char sign, ref era);

            Console.WriteLine();
            Console.WriteLine($"{nameof(PrecessionNutationCalcExample)}: {nameof(era)} = {sign}{era[0]:D2}:{era[1]:D2}:{era[2]:D2}:{era[3]:D2}");

            Console.WriteLine();
            for (var i = 0; i < cio.GetLength(0); i++)
            {
                for (var j = 0; j < cio.GetLength(1); j++)
                {
                    Console.WriteLine($"{nameof(PrecessionNutationCalcExample)}: {nameof(cio)}[{i},{j}] = {cio[i, j]:E8}");
                }
            }
        }
    }
}
