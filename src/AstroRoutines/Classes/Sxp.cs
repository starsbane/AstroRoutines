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
		/// Multiply a p-vector by a scalar.
		/// </summary>
		/// <param name="s">scalar</param>
		/// <param name="p">p-vector</param>
		/// <param name="sp">s * p</param>
		public static void Sxp(double s, double[] p, ref double[] sp)
		{
			sp[0] = s * p[0];
			sp[1] = s * p[1];
			sp[2] = s * p[2];
		}
	}
}