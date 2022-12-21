using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_CLIPPATH : IHandle<FPDF_CLIPPATH>
    {
        IntPtr _ptr;

        FPDF_CLIPPATH(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_CLIPPATH: 0x" + _ptr.ToString("X16");

        public static FPDF_CLIPPATH Null => new FPDF_CLIPPATH();

        public FPDF_CLIPPATH SetToNull() => new FPDF_CLIPPATH(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
