using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_DEST : IHandle<FPDF_DEST>
    {
        IntPtr _ptr;

        FPDF_DEST(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_DEST: 0x" + _ptr.ToString("X16");

        public static FPDF_DEST Null => new FPDF_DEST();

        public FPDF_DEST SetToNull() => new FPDF_DEST(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
