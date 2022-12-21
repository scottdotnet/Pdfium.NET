using Pdfium.NET.Internal.Imports;
using Pdfium.NET.Internal.Types;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Pdfium.NET.Internal
{
    public static partial class Pdfium
    {
        public static bool IsAvailable { get; }

        static Pdfium()
        {
            IsAvailable = Initialize();
        }

        public static bool Initialize()
        {
            try { FPDF.FPDF_InitLibrary(); }
            catch { return false; }

            return true;
        }

        public static FPDF_DOCUMENT FPDF_LoadDocument(byte[] data, int index = 0, int count = -1, string password = null)
        {
            if (count < 0)
                count = data.Length - index;

            return FPDF.FPDF_LoadMemDocument(ref data[index], count, password);
        }

        public static FPDF_DOCUMENT FPDF_LoadDocument(Stream stream, int count = 0, string password = null)
            => FPDF.FPDF_LoadCustomDocument(FPDF_FILEREAD.FromStream(stream, count), password);

        public static bool FPDF_SaveAsCopy(FPDF_DOCUMENT document, Stream stream, SaveFlags flags, int version = 0)
        {
            byte[] buffer = null;

            var fileWrite = new FPDF_FILEWRITE((ignore, data, size) =>
            {
                if (buffer == null || buffer.Length < size)
                    buffer = new byte[size];

                Marshal.Copy(data, buffer, 0, size);

                stream.Write(buffer, 0, size);

                return true;
            });

            if (version >= 10)
                return FPDF_Save.FPDF_SaveWithVersion(document, fileWrite, flags, version);
            else
                return FPDF_Save.FPDF_SaveAsCopy(document, fileWrite, flags);
        }

        public static string FPDFText_GetText(FPDF_TEXTPAGE textPage, int startIndex, int count)
        {
            var buffer = new byte[2 * (count + 1)];
            int length = FPDF_Text.FPDFText_GetText(textPage, startIndex, count, ref buffer[0]);
            return Encoding.Unicode.GetString(buffer, 0, (length - 1) * 2);
        }

        /// <summary>
		/// Imports pages from <paramref name="src_doc"/> to <paramref name="dest_doc"/>
		/// </summary>
		/// <param name="index">Zero-based index of where the imported pages should be inserted in the destination document.</param>
		/// <param name="srcPageIndices">Zero-based indices of the pages to import in the source document</param>
		public static bool FPDF_ImportPages(FPDF_DOCUMENT dest_doc, FPDF_DOCUMENT src_doc, int index, params int[] srcPageIndices)
        {
            string pageRange = null;

            if (srcPageIndices != null && srcPageIndices.Length > 0)
                pageRange = string.Join(",", srcPageIndices.Select(p => (p + 1).ToString(CultureInfo.InvariantCulture)));

            return FPDF_Ppo.FPDF_ImportPages(dest_doc, src_doc, pageRange, index);
        }
    }
}
