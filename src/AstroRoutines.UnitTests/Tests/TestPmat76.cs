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
        /// Test Pmat76 function.
        /// </summary>
        [Fact]
        public void TestPmat76()
        {
            var rmatp = new double[3, 3];
            var status = 0;

            Pmat76(2400000.5, 50123.9999, ref rmatp);

            Vvd(rmatp[0, 0], 0.9999995504328350733, 1e-12,"Pmat76", "11", ref status);
            Vvd(rmatp[0, 1], 0.8696632209480960785e-3, 1e-14, "Pmat76", "12", ref status);
            Vvd(rmatp[0, 2], 0.3779153474959888345e-3, 1e-14, "Pmat76", "13", ref status);

            Vvd(rmatp[1, 0], -0.8696632209485112192e-3, 1e-14, "Pmat76", "21", ref status);
            Vvd(rmatp[1, 1], 0.9999996218428560614, 1e-12, "Pmat76", "22", ref status);
            Vvd(rmatp[1, 2], -0.1643284776111886407e-6, 1e-14, "Pmat76", "23", ref status);

            Vvd(rmatp[2, 0], -0.3779153474950335077e-3, 1e-14, "Pmat76", "31", ref status);
            Vvd(rmatp[2, 1], -0.1643306746147366896e-6, 1e-14, "Pmat76", "32", ref status);
            Vvd(rmatp[2, 2], 0.9999999285899790119, 1e-12, "Pmat76", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
