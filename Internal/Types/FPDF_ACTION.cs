using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_ACTION : IHandle<FPDF_ACTION>
    {
        IntPtr _ptr;

        FPDF_ACTION(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_ACTION: 0x" + _ptr.ToString("X16");

        public static FPDF_ACTION Null => new FPDF_ACTION();

        public FPDF_ACTION SetToNull() => new FPDF_ACTION(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
