using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pdfium.NET.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_STRUCTELEMENT_ATTR : IHandle<FPDF_STRUCTELEMENT_ATTR>
    {
        IntPtr _ptr;

        FPDF_STRUCTELEMENT_ATTR(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_STRUCTELEMENT_ATTR: 0x" + _ptr.ToString("X16");

        public static FPDF_STRUCTELEMENT_ATTR Null => new FPDF_STRUCTELEMENT_ATTR();

        public FPDF_STRUCTELEMENT_ATTR SetToNull() => new FPDF_STRUCTELEMENT_ATTR(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
