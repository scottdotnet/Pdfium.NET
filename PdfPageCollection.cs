using Pdfium.NET.Internal;
using Pdfium.NET.Internal.Imports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pdfium.NET
{
    public sealed class PdfPageCollection : IEnumerable<PdfPage>, IDisposable
    {
        private readonly PdfDocument _doc;
        private readonly List<PdfPage> _pages;

        internal PdfPageCollection(PdfDocument doc)
        {
            _doc = doc;
            _pages = new List<PdfPage>(Enumerable.Repeat<PdfPage>(null, Count));
        }

        public int Count => FPDF.FPDF_GetPageCount(_doc.Handle);

        public PdfPage this[int index]
        {
            get
            {
                if (index >= _pages.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                if (_pages[index] is null || _pages[index].IsDisposed)
                    _pages[index] = PdfPage.Load(_doc, index);

                return _pages[index];
            }
        }

        public void Dispose()
        {
            foreach (var page in _pages)
                (page as IDisposable)?.Dispose();

            _pages.Clear();
        }

        public IEnumerator<PdfPage> GetEnumerator()
        {
            for (int i = 0; i < _pages.Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _pages.Count; i++)
                yield return this[i];
        }

        public PdfPage Insert(int index, double width, double height)
        {
            if (index <= _pages.Count)
            {
                var page = PdfPage.New(_doc, index, width, height);

                _pages.Insert(index, page);

                for (int i = 0; i < _pages.Count; i++)
                    if (_pages[i] is not null)
                        _pages[i].Index = i;

                return page;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        /// <summary>
		/// Imports pages of <paramref name="sourceDocument"/> into the current <see cref="PdfDocument"/>.
		/// </summary>
        /// <seealso cref="Pdfium.FPDF_ImportPages(Internal.Types.FPDF_DOCUMENT, Internal.Types.FPDF_DOCUMENT, int, int[])"/>
        public bool Insert(int index, PdfDocument sourceDocument, params int[] srcPageIndicies)
        {
            var result = false;

            if (index <= _pages.Count)
            {
                if (srcPageIndicies.Length == 0)
                    srcPageIndicies = FPDF.FPDF_GetPageCount(sourceDocument.Handle).ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x) - 1).ToArray(); ;

                result = Internal.Pdfium.FPDF_ImportPages(_doc.Handle, sourceDocument.Handle, index, srcPageIndicies);

                if (result)
                {
                    _pages.AddRange(Enumerable.Repeat<PdfPage>(null, srcPageIndicies.Length));

                    for (int i = index; i < _pages.Count; i++)
                        if (_pages[i] is not null)
                            _pages[i].Index = i;
                }
            }
            else
                throw new ArgumentOutOfRangeException(nameof(index));

            return result;
        }

        public bool Add(PdfDocument sourceDocument, params int[] srcPageIndices)
            => Insert(Count, sourceDocument, srcPageIndices);

        /// <summary>
		/// Adds a new page to the end of the document.
		/// </summary>
		public PdfPage Add(double width, double height)
            => Insert(Count, width, height);

        /// <summary>
        /// Removes the page at <paramref name="index"/>.
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index < _pages.Count)
            {
                ((IDisposable)_pages[index])?.Dispose();
                _pages.RemoveAt(index);
                for (int i = index; i < _pages.Count; i++)
                {
                    if (_pages[i] != null)
                        _pages[i].Index = i;
                }
            }
            FPDF_Edit.FPDFPage_Delete(_doc.Handle, index);
        }

        /// <summary>
        /// Removes the <paramref name="page"/> from the document.
        /// </summary>
        public void Remove(PdfPage page) => RemoveAt(page.Index);
    }
}
