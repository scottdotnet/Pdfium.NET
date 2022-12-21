using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_PAGERANGE : IHandle<FPDF_PAGERANGE>
    {
        IntPtr _ptr;

        FPDF_PAGERANGE(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_PAGERANGE: 0x" + _ptr.ToString("X16");

        public static FPDF_PAGERANGE Null => new FPDF_PAGERANGE();

        public FPDF_PAGERANGE SetToNull() => new FPDF_PAGERANGE(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
