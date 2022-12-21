using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_JAVASCRIPT_ACTION : IHandle<FPDF_JAVASCRIPT_ACTION>
    {
        IntPtr _ptr;

        FPDF_JAVASCRIPT_ACTION(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_JAVASCRIPT_ACTION: 0x" + _ptr.ToString("X16");

        public static FPDF_JAVASCRIPT_ACTION Null => new FPDF_JAVASCRIPT_ACTION();

        public FPDF_JAVASCRIPT_ACTION SetToNull() => new FPDF_JAVASCRIPT_ACTION(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
