using Pdfium.NET.Internal;
using Pdfium.NET.Internal.Imports;
using Pdfium.NET.Internal.Types;
using System;
using System.IO;

namespace Pdfium.NET
{
    public sealed class PdfDocument : NativeWrapper<FPDF_DOCUMENT>
    {
        /// <summary>
		/// Gets the pages in the current <see cref="PdfDocument"/>.
		/// </summary>
        public PdfPageCollection Pages { get; }

        /// <summary>
        /// Gets the current count of pages in the <see cref="PdfDocument"/>.
        /// </summary>
        public int PageCount => FPDF.FPDF_GetPageCount(Handle);

        PdfDocument(FPDF_DOCUMENT handle)
            : base(handle)
        {
            Pages = new PdfPageCollection(this);
        }

        /// <summary>
		/// Creates a new <see cref="PdfDocument"/>.
		/// <see cref="Close"/> must be called in order to free unmanaged resources.
		/// </summary>
        public PdfDocument()
            : this(FPDF_Edit.FPDF_CreateNewDocument()) { }

        /// <summary>
		/// Loads a <see cref="PdfDocument"/> from the file system.
		/// <see cref="Close"/> must be called in order to free unmanaged resources.
		/// </summary>
		/// <param name="fileName">Filepath of the PDF file to load.</param>
        public PdfDocument(string fileName, string password = null)
            : this(FPDF.FPDF_LoadDocument(fileName, password)) { }

        /// <summary>
		/// Loads a <see cref="PdfDocument"/> from memory.
		/// <see cref="Close"/> must be called in order to free unmanaged resources.
		/// </summary>
		/// <param name="data">Byte array containing the bytes of the PDF document to load.</param>
		/// <param name="index">The index of the first byte to be copied from <paramref name="data"/>.</param>
		/// <param name="count">The number of bytes to copy from <paramref name="data"/> or a negative value to copy all bytes.</param>
        public PdfDocument(byte[] data, int index = 0, int count = -1, string password = null)
            : this(Internal.Pdfium.FPDF_LoadDocument(data, index, count, password)) { }

        /// <summary>
		/// Loads a <see cref="PdfDocument"/> from '<paramref name="count"/>' bytes read from a <paramref name="stream"/>.
		/// <see cref="Close"/> must be called in order to free unmanaged resources.
		/// </summary>
		/// <param name="count">
		/// The number of bytes to read from the <paramref name="stream"/>.
		/// If the value is equal to or smaller than 0, the stream is read to the end.
		/// </param>
        public PdfDocument(Stream stream, int count = 0, string password = null)
            : this(Internal.Pdfium.FPDF_LoadDocument(stream, count, password)) { }

        /// <summary>
		/// Saves the <see cref="PdfDocument"/> to a <paramref name="stream"/>.
		/// </summary>
		/// <param name="version">
		/// The new PDF file version of the saved file.
		/// 14 for 1.4, 15 for 1.5, etc. Values smaller than 10 are ignored.
		/// </param>
        public bool Save(Stream stream, SaveFlags flags = SaveFlags.None, int version = 0)
            => Internal.Pdfium.FPDF_SaveAsCopy(Handle, stream, flags, version);

        /// <summary>
		/// Saves the <see cref="PdfDocument"/> to the file system.
		/// </summary>
		/// <param name="version">
		/// The new PDF file version of the saved file.
		/// 14 for 1.4, 15 for 1.5, etc. Values smaller than 10 are ignored.
		/// </param>
        public bool Save(string file, SaveFlags flags = SaveFlags.None, int version = 0)
        {
            using var stream = new FileStream(file, FileMode.Create);

            return Save(stream, flags, version);
        }

        /// <summary>
		/// Closes the <see cref="PdfDocument"/> and frees unmanaged resources.
		/// </summary>
        public void Close() => ((IDisposable)this).Dispose();

        protected override void Dispose(FPDF_DOCUMENT handle)
        {
            Pages.Dispose();

            FPDF.FPDF_CloseDocument(handle);
        }
    }
}
