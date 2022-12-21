using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_PAGELINK : IHandle<FPDF_PAGELINK>
    {
        IntPtr _ptr;

        FPDF_PAGELINK(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_PAGELINK: 0x" + _ptr.ToString("X16");

        public static FPDF_PAGELINK Null => new FPDF_PAGELINK();

        public FPDF_PAGELINK SetToNull() => new FPDF_PAGELINK(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
