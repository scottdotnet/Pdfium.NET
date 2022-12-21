using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfiumSharp.Internal.Types
{
    public enum SearchFlags : uint
    {
        /// <summary>
        /// If not set, it will not match case by default.
        /// </summary>
        MatchCase = 0x00000001,

        /// <summary>
        /// If not set, it will not match the whole word by default.
        /// </summary>
        MatchWholeWord = 0x00000002
    }
}
