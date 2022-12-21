using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_PAGEOBJECT : IHandle<FPDF_PAGEOBJECT>
    {
        IntPtr _ptr;

        FPDF_PAGEOBJECT(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_PAGEOBJECT: 0x" + _ptr.ToString("X16");

        public static FPDF_PAGEOBJECT Null => new FPDF_PAGEOBJECT();

        public FPDF_PAGEOBJECT SetToNull() => new FPDF_PAGEOBJECT(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
