using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_ANNOTATION : IHandle<FPDF_ANNOTATION>
    {
        IntPtr _ptr;

        FPDF_ANNOTATION(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_ANNOTATION: 0x" + _ptr.ToString("X16");

        public static FPDF_ANNOTATION Null => new FPDF_ANNOTATION();

        public FPDF_ANNOTATION SetToNull() => new FPDF_ANNOTATION(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
