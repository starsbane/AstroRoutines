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
        /// Time scale transformation: Barycentric Coordinate Time, TCB, to Barycentric Dynamical Time, TDB.
        /// </summary>
        /// <param name="tcb1">TCB as a 2-part Julian Date</param>
        /// <param name="tcb2">TCB as a 2-part Julian Date</param>
        /// <param name="tdb1">TDB as a 2-part Julian Date</param>
        /// <param name="tdb2">TDB as a 2-part Julian Date</param>
        /// <returns>status: 0 = OK</returns>
        public static int Tcbtdb(double tcb1, double tcb2, out double tdb1, out double tdb2)
        {
            tdb1 = 0; tdb2 = 0;
            var t77td = DJM0 + DJM77;
            var t77tf = TTMTAI / DAYSEC;
            var tdb0 = TDB0 / DAYSEC;
            double d;

            if (Abs(tcb1) > Abs(tcb2))
            {
                d = tcb1 - t77td;
                tdb1 = tcb1;
                tdb2 = tcb2 + tdb0 - (d + (tcb2 - t77tf)) * ELB;
            }
            else
            {
                d = tcb2 - t77td;
                tdb1 = tcb1 + tdb0 - (d + (tcb1 - t77tf)) * ELB;
                tdb2 = tcb2;
            }
            return 0;
        }
    }
}
