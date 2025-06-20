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
        /// Test Eform function.
        /// </summary>
        [Fact]
        public void TestEform()
        {
            var status = 0;

            var j = Eform(0, out var a, out var f);
            Viv(j, -1, "Eform", "j0", ref status);

            j = Eform(WGS84, out a, out f);
            Viv(j, 0, "Eform", "j1", ref status);
            Vvd(a, 6378137.0, 1e-10, "Eform", "a1", ref status);
            Vvd(f, 0.3352810664747480720e-2, 1e-18, "Eform", "f1", ref status);

            j = Eform(GRS80, out a, out f);
            Viv(j, 0, "Eform", "j2", ref status);
            Vvd(a, 6378137.0, 1e-10, "Eform", "a2", ref status);
            Vvd(f, 0.3352810681182318935e-2, 1e-18, "Eform", "f2", ref status);

            j = Eform(WGS72, out a, out f);
            Viv(j, 0, "Eform", "j3", ref status);
            Vvd(a, 6378135.0, 1e-10, "Eform", "a3", ref status);
            Vvd(f, 0.3352779454167504862e-2, 1e-18, "Eform", "f3", ref status);

            j = Eform(4, out a, out f);
            Viv(j, -1, "Eform", "j4", ref status);

            Assert.Equal(0, status);
        }
    }
}
