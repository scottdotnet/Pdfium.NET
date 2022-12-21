using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_GLYPHPATH : IHandle<FPDF_GLYPHPATH>
    {
        IntPtr _ptr;

        FPDF_GLYPHPATH(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_GLYPHPATH: 0x" + _ptr.ToString("X16");

        public static FPDF_GLYPHPATH Null => new FPDF_GLYPHPATH();

        public FPDF_GLYPHPATH SetToNull() => new FPDF_GLYPHPATH(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
