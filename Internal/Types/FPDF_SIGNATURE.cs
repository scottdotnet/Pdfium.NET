using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_SIGNATURE : IHandle<FPDF_SIGNATURE>
    {
        IntPtr _ptr;

        FPDF_SIGNATURE(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_SIGNATURE: 0x" + _ptr.ToString("X16");

        public static FPDF_SIGNATURE Null => new FPDF_SIGNATURE();

        public FPDF_SIGNATURE SetToNull() => new FPDF_SIGNATURE(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
