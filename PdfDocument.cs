using Pdfium.NET.Internal;
using Pdfium.NET.Internal.Imports;
using Pdfium.NET.Internal.Types;
using System;
using System.IO;

namespace Pdfium.NET
{
    public sealed class PdfDocument : NativeWrapper<FPDF_DOCUMENT>
    {
        public PdfPageCollection Pages { get; }

        public int PageCount => FPDF.FPDF_GetPageCount(Handle);

        PdfDocument(FPDF_DOCUMENT handle)
            : base(handle)
        {
            Pages = new PdfPageCollection(this);
        }

        public PdfDocument()
            : this(FPDF_Edit.FPDF_CreateNewDocument()) { }

        public PdfDocument(string fileName, string password = null)
            : this(FPDF.FPDF_LoadDocument(fileName, password)) { }

        public PdfDocument(byte[] data, int index = 0, int count = -1, string password = null)
            : this(Internal.Pdfium.FPDF_LoadDocument(data, index, count, password)) { }

        public PdfDocument(Stream stream, int count = 0, string password = null)
            : this(Internal.Pdfium.FPDF_LoadDocument(stream, count, password)) { }

        public bool Save(Stream stream, SaveFlags flags = SaveFlags.None, int version = 0)
            => Internal.Pdfium.FPDF_SaveAsCopy(Handle, stream, flags, version);

        public bool Save(string file, SaveFlags flags = SaveFlags.None, int version = 0)
        {
            using var stream = new FileStream(file, FileMode.Create);

            return Save(stream, flags, version);
        }

        public void Close() => ((IDisposable)this).Dispose();

        protected override void Dispose(FPDF_DOCUMENT handle)
        {
            Pages.Dispose();

            FPDF.FPDF_CloseDocument(handle);
        }
    }
}
