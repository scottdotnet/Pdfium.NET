using Pdfium.NET.Internal.Imports;
using Pdfium.NET.Internal.Types;
using System;

namespace Pdfium.NET.Internal
{
    public sealed class PDFiumException : Exception
    {
        public PDFiumException()
            : base($"Pdfium Error: {FPDF.FPDF_GetLastError().GetDescription()}") { }
    }
}
