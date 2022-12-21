using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pdfium.NET.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_BITMAP : IHandle<FPDF_BITMAP>
    {
        IntPtr _ptr;

        FPDF_BITMAP(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_BITMAP: 0x" + _ptr.ToString("X16");

        public static FPDF_BITMAP Null => new FPDF_BITMAP();

        public FPDF_BITMAP SetToNull() => new FPDF_BITMAP(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
