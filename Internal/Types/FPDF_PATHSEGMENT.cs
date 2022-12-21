using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pdfium.NET.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_PATHSEGMENT : IHandle<FPDF_PATHSEGMENT>
    {
        IntPtr _ptr;

        FPDF_PATHSEGMENT(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_PATHSEGMENT: 0x" + _ptr.ToString("X16");

        public static FPDF_PATHSEGMENT Null => new FPDF_PATHSEGMENT();

        public FPDF_PATHSEGMENT SetToNull() => new FPDF_PATHSEGMENT(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
