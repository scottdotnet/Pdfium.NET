using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfiumSharp.Internal.Types
{
    public enum FPDF_DUPLEXTYPE : int
    {
        DuplexUndefined = 0,
        Simplex,
        DuplexFlipShortEdge,
        DuplexFlipLongEdge
    }
}
