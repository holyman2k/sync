using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sync.Helper
{
    class CurrentMode
    {
        public static Mode TransferMode { get; set; }
        public static Mode CompareMode { get; set; }
        public static Mode LogMode { get; set; }
    }
}
