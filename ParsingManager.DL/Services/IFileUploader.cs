using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.DL.Services
{
	public interface IFileUploader
	{
		List<string> ReadFileLines(string filename);
	}
}
