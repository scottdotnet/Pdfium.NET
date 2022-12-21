using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_ATTACHMENT : IHandle<FPDF_ATTACHMENT>
    {
        IntPtr _ptr;

        FPDF_ATTACHMENT(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_ATTACHMENT: 0x" + _ptr.ToString("X16");

        public static FPDF_ATTACHMENT Null => new FPDF_ATTACHMENT();

        public FPDF_ATTACHMENT SetToNull() => new FPDF_ATTACHMENT(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
