using static System.Math;
using static AstroRoutines.Constants;

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
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Barycentric Dynamical Time, TDB, to Barycentric Coordinate Time, TCB.
        /// </summary>
        /// <param name="tdb1">TDB as a 2-part Julian Date</param>
        /// <param name="tdb2">TDB as a 2-part Julian Date</param>
        /// <param name="tcb1">TCB as a 2-part Julian Date</param>
        /// <param name="tcb2">TCB as a 2-part Julian Date</param>
        /// <returns>status: 0 = OK</returns>
        public static int Tdbtcb(double tdb1, double tdb2, out double tcb1, out double tcb2)
        {
            tcb1 = 0; tcb2 = 0;
            var t77td = DJM0 + DJM77;
            var t77tf = TTMTAI / DAYSEC;
            var tdb0 = TDB0 / DAYSEC;
            var elbb = ELB / (1.0 - ELB);
            double d, f;

            if (Abs(tdb1) > Abs(tdb2))
            {
                d = t77td - tdb1;
                f = tdb2 - tdb0;
                tcb1 = tdb1;
                tcb2 = f - (d - (f - t77tf)) * elbb;
            }
            else
            {
                d = t77td - tdb2;
                f = tdb1 - tdb0;
                tcb1 = f - (d - (f - t77tf)) * elbb;
                tcb2 = tdb2;
            }
            return 0;
        }
    }
}
