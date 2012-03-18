using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sync.Helper
{
    class FileCopy
    {
        public void copy(FileInfo source, FileInfo destination)
        {
            Log.log(source.FullName + " ===> " + destination.FullName + " === copy");
            
            if (CurrentMode.TransferMode == Mode.Normal)
            {
                source.CopyTo(destination.FullName, true);
            }
        }
    }
}
