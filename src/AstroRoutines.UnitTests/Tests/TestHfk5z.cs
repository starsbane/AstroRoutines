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
        /// Test Hfk5z function.
        /// </summary>
        [Fact]
        public void TestHfk5z()
        {
            var status = 0;
            var rh = 1.767794352;
			var dh = -0.2917512594;

            Hfk5z(rh, dh, 2400000.5, 54479.0, out var r5, out var d5, out var dr5, out var dd5);

            Vvd(r5, 1.767794490535581026, 1e-13, "Hfk5z", "ra", ref status);
            Vvd(d5, -0.2917513695320114258, 1e-14, "Hfk5z", "dec", ref status);
            Vvd(dr5, 0.4335890983539243029e-8, 1e-22, "Hfk5z", "dr5", ref status);
            Vvd(dd5, -0.8569648841237745902e-9, 1e-23, "Hfk5z", "dd5", ref status);

            Assert.Equal(0, status);
        }
    }
}
