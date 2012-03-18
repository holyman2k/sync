using System.IO;

namespace Sync.Helper
{
    interface FileComparer
    {
        bool match(FileInfo source, FileInfo destination);
    }
}
