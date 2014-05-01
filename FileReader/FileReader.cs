using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.FileReader
{
    public class FileReaderTool
    {
        public string ReadFile(string path)
        {
            string str = string.Empty;
            using (System.IO.StreamReader myStream = new System.IO.StreamReader(path))
            {
                string stringLine = myStream.ReadLine();
                while (stringLine != null)
                {
                    str += stringLine;
                    stringLine = myStream.ReadLine();
                }
            }
            return str;
        }
    }
}
