using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ParsingManager.DL.Services;

namespace ParsingManager.DL
{
	public class FileUploader : IFileUploader
	{
        public byte[] ReadFileStream(string filename)
        {
            byte[] Buffer;
            using (FileStream SourceStream = File.Open(filename, FileMode.Open))
            {
                Buffer = new byte[SourceStream.Length];
                SourceStream.Read(Buffer, 0, (int)SourceStream.Length);
            }
            return Buffer;
        }


    }
}
