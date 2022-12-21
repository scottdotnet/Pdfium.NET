using PdfiumSharp.Internal.Imports;
using PdfiumSharp.Internal.Types;
using System;

namespace PdfiumSharp.Internal
{
    public sealed class PDFiumException : Exception
    {
        public PDFiumException()
            : base($"Pdfium Error: {FPDF.FPDF_GetLastError().GetDescription()}") { }
    }
}
