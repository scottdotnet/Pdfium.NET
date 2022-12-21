using PdfiumSharp.Internal;
using PdfiumSharp.Internal.Imports;
using PdfiumSharp.Internal.Types;
using System.Reflection.Metadata;

namespace PdfiumSharp
{
    public sealed class PdfPage : NativeWrapper<FPDF_PAGE>
    {
        public PdfDocument Document { get; }

        public double Width => FPDF.FPDF_GetPageWidth(_page);
        public double Height => FPDF.FPDF_GetPageHeight(_page);

        public int Index { get; internal set; } = -1;

        private readonly FPDF_PAGE _page;
        private readonly FPDF_TEXTPAGE _textPage;

        PdfPage(PdfDocument document, FPDF_PAGE page, int index) : base(page)
        {
            Document = document;
            Index = index;

            _page = page;
            _textPage = FPDF_Text.FPDFText_LoadPage(page);
        }

        internal static PdfPage Load(PdfDocument document, int index) => new PdfPage(document, FPDF.FPDF_LoadPage(document.Handle, index), index);

        internal static PdfPage New(PdfDocument document, int index, double width, double height) => new PdfPage(document, FPDF_Edit.FPDFPage_New(document.Handle, index, width, height), index);

        protected override void Dispose(FPDF_PAGE handle)
        {
            FPDF_Text.FPDFText_ClosePage(_textPage);
            FPDF.FPDF_ClosePage(handle);
        }

        public string GetText()
            => Pdfium.FPDFText_GetText(_textPage, 0, FPDF_Text.FPDFText_CountChars(_textPage));
    }
}
