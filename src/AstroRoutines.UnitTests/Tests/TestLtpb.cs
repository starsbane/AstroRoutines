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
        /// Test Ltpb function.
        /// </summary>
        [Fact]
        public void TestLtpb()
        {
            var epj = 1666.666;
            var rpb = new double[3, 3];
            var status = 0;

            Ltpb(epj, ref rpb);

            Vvd(rpb[0,0], 0.9967044167723271851, 1e-14, "Ltpb", "rpb11", ref status);
            Vvd(rpb[0,1], 0.7437794731203340345e-1, 1e-14, "Ltpb", "rpb12", ref status);
            Vvd(rpb[0,2], 0.3237632684841625547e-1, 1e-14, "Ltpb", "rpb13", ref status);
            Vvd(rpb[1,0], -0.7437795663437177152e-1, 1e-14, "Ltpb", "rpb21", ref status);
            Vvd(rpb[1,1], 0.9972293947500013666, 1e-14, "Ltpb", "rpb22", ref status);
            Vvd(rpb[1,2], -0.1205741865911243235e-2, 1e-14, "Ltpb", "rpb23", ref status);
            Vvd(rpb[2,0], -0.3237630543224664992e-1, 1e-14, "Ltpb", "rpb31", ref status);
            Vvd(rpb[2,1], -0.1206316791076485295e-2, 1e-14, "Ltpb", "rpb32", ref status);
            Vvd(rpb[2,2], 0.9994750220222438819, 1e-14, "Ltpb", "rpb33", ref status);

            Assert.Equal(0, status);
        }
    }
}
