using Pdfium.NET.Internal.Types;
using System.Runtime.InteropServices;

namespace Pdfium.NET.Internal.Imports
{
    internal static class FPDF_Ppo
    {
        /// <summary>
        /// Import pages to a FPDF_DOCUMENT.
        /// </summary>
        /// <param name="dest_doc">The destination document for the pages.</param>
        /// <param name="src_doc">The document to be imported.</param>
        /// <param name="pagerange">A page range string, Such as "1,3,5-7". The first page is one. If <paramref name="pagerange"/> is NULL, all pages from <paramref name="src_doc"/> are imported.</param>
        /// <param name="index">The page index at which to insert the first imported page into <paramref name="dest_doc"/>. The first page is zero.</param>
        /// <returns></returns>
        [DllImport("pdfium")]
        public static extern bool FPDF_ImportPages(FPDF_DOCUMENT dest_doc, FPDF_DOCUMENT src_doc, [MarshalAs(UnmanagedType.LPStr)] string pagerange, int index);
    }
}
