using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_PAGE : IHandle<FPDF_PAGE>
    {
        IntPtr _ptr;

        FPDF_PAGE(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_PAGE: 0x" + _ptr.ToString("X16");

        public static FPDF_PAGE Null => new FPDF_PAGE();

        public FPDF_PAGE SetToNull() => new FPDF_PAGE(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
