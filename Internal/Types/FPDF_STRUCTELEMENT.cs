using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_STRUCTELEMENT : IHandle<FPDF_STRUCTELEMENT>
    {
        IntPtr _ptr;

        FPDF_STRUCTELEMENT(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_STRUCTELEMENT: 0x" + _ptr.ToString("X16");

        public static FPDF_STRUCTELEMENT Null => new FPDF_STRUCTELEMENT();

        public FPDF_STRUCTELEMENT SetToNull() => new FPDF_STRUCTELEMENT(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
