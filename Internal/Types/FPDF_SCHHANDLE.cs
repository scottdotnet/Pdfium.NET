using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_SCHHANDLE : IHandle<FPDF_SCHHANDLE>
    {
        IntPtr _ptr;

        FPDF_SCHHANDLE(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_SCHHANDLE: 0x" + _ptr.ToString("X16");

        public static FPDF_SCHHANDLE Null => new FPDF_SCHHANDLE();

        public FPDF_SCHHANDLE SetToNull() => new FPDF_SCHHANDLE(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
