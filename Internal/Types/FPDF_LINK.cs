using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_LINK : IHandle<FPDF_LINK>
    {
        IntPtr _ptr;

        FPDF_LINK(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_LINK: 0x" + _ptr.ToString("X16");

        public static FPDF_LINK Null => new FPDF_LINK();

        public FPDF_LINK SetToNull() => new FPDF_LINK(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
