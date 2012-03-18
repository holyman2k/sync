using System;
using System.IO;
using System.Text;
using Sync.Helper;
using Sync.Model;

namespace Sync
{
    class Program
    {
        private FileComparer comparer;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            if ( !(args.Length > 1) )
            {
                Console.WriteLine(@"Usage: Sync [-d -s] 'source path' 'destination path'");
                Console.WriteLine(@"-d: dry run output copy be copied and reason for copy");
                Console.WriteLine(@"-s: ignore file file when syncing");
                return;
            }
            CurrentMode.Mode = Mode.Normal;
            CurrentMode.CompareMode = Mode.Normal;

            int offset = 0;
            if (args[offset].ToLower() == "-d")
            {
                CurrentMode.Mode = Mode.DryRun;
                offset = offset + 1;
            }
            if (args[offset].ToLower() == "-s")
            {
                CurrentMode.CompareMode = Mode.Ignore_File_Size;
                offset = offset + 1;
            }

            DirectoryInfo source = new DirectoryInfo(args[offset]);
            DirectoryInfo destination = new DirectoryInfo(args[offset + 1]);

            //Console.WriteLine("{0}, {1}", source.FullName, destination.FullName);

            /*string src = @"D:\tmp\src";
            string dest = @"D:\tmp\dest";

            DirectoryInfo source = new DirectoryInfo(src);
            DirectoryInfo destination = new DirectoryInfo(dest);*/

            Program app = new Program();
            app.init();
            app.sync(source, destination);
        }

        public void init()
        {
            comparer = new FileSzieComparer();
        }

        public void sync(DirectoryInfo source, DirectoryInfo destination)
        {
            Folder folderSource = new Folder(source.FullName);
            Folder folderDestination = new Folder(destination.FullName);

            if (!folderSource.exists())
            {
                Console.WriteLine("source folder {0} does not exist", source.FullName);
                return;
            }
            folderSource.sync(folderDestination, comparer);
        }
    }
}
