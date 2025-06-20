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
            var ambRow0 = new double[3];
            var ambRow1 = new double[3];

            Pmp(a.GetRow(0), b.GetRow(0), ref ambRow0);
            Pmp(a.GetRow(1), b.GetRow(1), ref ambRow1);

            amb.SetRow(0, ambRow0);
            amb.SetRow(1, ambRow1);
        }
    }

}