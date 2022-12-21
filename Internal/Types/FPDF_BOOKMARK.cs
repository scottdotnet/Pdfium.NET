using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_BOOKMARK : IHandle<FPDF_BOOKMARK>
    {
        IntPtr _ptr;

        FPDF_BOOKMARK(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_BOOKMARK: 0x" + _ptr.ToString("X16");

        public static FPDF_BOOKMARK Null => new FPDF_BOOKMARK();

        public FPDF_BOOKMARK SetToNull() => new FPDF_BOOKMARK(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
