using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pdfium.NET.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_TEXTPAGE : IHandle<FPDF_TEXTPAGE>
    {
        IntPtr _ptr;

        FPDF_TEXTPAGE(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_TEXTPAGE: 0x" + _ptr.ToString("X16");

        public static FPDF_TEXTPAGE Null => new FPDF_TEXTPAGE();

        public FPDF_TEXTPAGE SetToNull() => new FPDF_TEXTPAGE(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
