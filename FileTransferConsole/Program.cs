using FileTransferConsole.FileTransferService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TransferServiceClient proxy = new TransferServiceClient();

            Stream stream = new MemoryStream();
            string filename = string.Empty;
            
            var result = proxy.DownloadFile(ref filename, out stream);

            using (Stream file = File.Create(filename))
            {
                stream.CopyTo(file);
            }

            stream.Dispose();

            Console.ReadLine();

        }
    }
}
