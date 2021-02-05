using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using ParsingManager.DL.Services;
using System.Text.RegularExpressions;

namespace ParsingManager.DL
{
	public class FileUploader : IFileUploader
	{
        public List<string> ReadFileLines(string filename)
        {
            List<string> lines = new List<string>();
            foreach (var line in File.ReadLines(filename))
            {
                var match0 = Regex.Matches(line, @"\$G([A-Z]{4}),(.*?)\*([0-9A-F]{2})", RegexOptions.Singleline);
                if (match0 != null)
                    foreach (Match mVotes in match0) lines.Add(mVotes.Value);
            }
            return lines;
        }


    }
}
