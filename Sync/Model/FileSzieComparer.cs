using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sync.Helper
{
    class FileSzieComparer : FileComparer
    {
        public bool match(FileInfo source, FileInfo destination)
        {
            if (!destination.Exists)
            {
                if (CurrentMode.TransferMode == Mode.DryRun)
                {
                    Log.log("{0} does not exist", destination.FullName);
                }
                return false;
            }

            if (CurrentMode.CompareMode == Mode.Ignore_File_Size)
            {
                return true;
            }

            if (source.Length != destination.Length)
            {
                if (CurrentMode.TransferMode == Mode.DryRun)
                {
                    Log.trace("{0} have different size: {1} - {2}", source.FullName, source.Length, destination.Length);
                }
                return false;
            }

            return true;
        }
    }
}
