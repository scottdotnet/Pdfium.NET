using Pdfium.NET.Internal.Types;
using System.Runtime.InteropServices;

namespace Pdfium.NET.Internal.Imports
{
    internal static class FPDF_Save
    {
        /// <summary>
        /// Saves the copy of specified document in custom way.
        /// </summary>
        /// <param name="document">Handle to document, as returned by FPDF_LoadDocument() or FPDF_CreateNewDocument().</param>
        /// <param name="fileWrite">A pointer to a custom file write structure.</param>
        /// <param name="flags">The creating flags.</param>
        /// <returns>TRUE for succeed, FALSE for failed.</returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_SaveAsCopy(FPDF_DOCUMENT document, FPDF_FILEWRITE fileWrite, SaveFlags flags);

        /// <summary>
        /// Same as FPDF_SaveAsCopy(), except the file version of the saved document can be specified by the caller.
        /// </summary>
        /// <param name="document">Handle to document.</param>
        /// <param name="fileWrite">A pointer to a custom file write structure.</param>
        /// <param name="flags">The creating flags.</param>
        /// <param name="fileVersion">The PDF file version. File version: 14 for 1.4, 15 for 1.5, ...</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_SaveWithVersion(FPDF_DOCUMENT document, FPDF_FILEWRITE fileWrite, SaveFlags flags, int fileVersion);
    }
}
