using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_FONT : IHandle<FPDF_FONT>
    {
        IntPtr _ptr;

        FPDF_FONT(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_FONT: 0x" + _ptr.ToString("X16");

        public static FPDF_FONT Null => new FPDF_FONT();

        public FPDF_FONT SetToNull() => new FPDF_FONT(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
