using Pdfium.NET.Internal;
using Pdfium.NET.Internal.Imports;
using Pdfium.NET.Internal.Types;

namespace Pdfium.NET
{
    public sealed class PdfPage : NativeWrapper<FPDF_PAGE>
    {
        public PdfDocument Document { get; }

        /// <summary>
		/// Gets the page width (excluding non-displayable area) measured in points.
		/// One point is 1/72 inch(around 0.3528 mm).
		/// </summary>
        public double Width => FPDF.FPDF_GetPageWidth(_page);

        /// <summary>
		/// Gets the page height (excluding non-displayable area) measured in points.
		/// One point is 1/72 inch(around 0.3528 mm).
		/// </summary>
        public double Height => FPDF.FPDF_GetPageHeight(_page);

        /// <summary>
		/// Gets the page orientation.
		/// </summary>
		public PageOrientations Orientation
        {
            get => FPDF_Edit.FPDFPage_GetRotation(Handle);
            set => FPDF_Edit.FPDFPage_SetRotation(Handle, value);
        }

        /// <summary>
		/// Gets the zero-based index of the page in the <see cref="Document"/>
		/// </summary>
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

        /// <summary>
        /// Gets all the text found on the page.
        /// </summary>
        /// <returns>Returns a string of text</returns>
        public string GetText()
        {
            var count = FPDF_Text.FPDFText_CountChars(_textPage);

            if (count == 0)
                return string.Empty;

            return Internal.Pdfium.FPDFText_GetText(_textPage, 0, count);
        }
    }
}
