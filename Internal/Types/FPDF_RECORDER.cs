using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_RECORDER : IHandle<FPDF_RECORDER>
    {
        IntPtr _ptr;

        FPDF_RECORDER(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_RECORDER: 0x" + _ptr.ToString("X16");

        public static FPDF_RECORDER Null => new FPDF_RECORDER();

        public FPDF_RECORDER SetToNull() => new FPDF_RECORDER(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
