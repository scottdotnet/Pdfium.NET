using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pdfium.NET.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_AVAIL : IHandle<FPDF_AVAIL>
    {
        IntPtr _ptr;

        FPDF_AVAIL(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_AVAIL: 0x" + _ptr.ToString("X16");

        public static FPDF_AVAIL Null => new FPDF_AVAIL();

        public FPDF_AVAIL SetToNull() => new FPDF_AVAIL(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
