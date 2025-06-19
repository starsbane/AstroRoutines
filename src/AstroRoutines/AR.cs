using System.Diagnostics.CodeAnalysis;

namespace AstroRoutines
{
    /// <summary>
    /// An unofficial .NET Core clone of C Library of the SOFA software libraries from IAU, provides a collection of subroutines that implement official IAU algorithms for astronomical computations.
    /// </summary>
    /// <remarks>Software Routines from the IAU SOFA Collection were used. Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org)</remarks>
    [SuppressMessage("ReSharper", "CommentTypo")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
    public static partial class AR
    {
        /// <summary>
        /// No. of the base SOFA ANSI C release.
        /// </summary>
        public const int RELEASE_NO = 19;

        /// <summary>
        /// Release date of the base SOFA ANSI C release.
        /// </summary>
        public static readonly DateTime RELEASE_DATE = new DateTime(2023, 10, 11, 0, 0, 0, DateTimeKind.Utc);
    }
}
