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
        /// <summary>
        /// Test D2dtf function.
        /// </summary>
        [Fact]
        public void TestD2dtf()
        {
            var status = 0;
            var ihmsf = new int[4];
            int iy = 0, im = 0, id = 0;

            // Call the D2dtf function with test values
            var j = D2dtf("UTC", 5, 2400000.5, 49533.99999, ref iy, ref im, ref id, ref ihmsf);

            // Check the year
            Viv(iy, 1994, "D2dtf", "y", ref status);
            // Check the month
            Viv(im, 6, "D2dtf", "mo", ref status);
            // Check the day
            Viv(id, 30, "D2dtf", "d", ref status);
            // Check the hours
            Viv(ihmsf[0], 23, "D2dtf", "h", ref status);
            // Check the minutes
            Viv(ihmsf[1], 59, "D2dtf", "m", ref status);
            // Check the seconds
            Viv(ihmsf[2], 60, "D2dtf", "s", ref status);
            // Check the fractions
            Viv(ihmsf[3], 13599, "D2dtf", "f", ref status);
            // Check the return status
            Viv(j, 0, "D2dtf", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}