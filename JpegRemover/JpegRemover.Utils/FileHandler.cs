using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpegRemover.Utils
{
    public static class FileHandler
    {
        private const string JpgFormat = "jpg";
        private const string JpegFormat = "jpeg";

        public static List<string> GetDuplicatedJpegsList(string path, string rawFormat)
        {
            //Get a list of the raw files in the given directory
            var rawFiles = System.IO.Directory.GetFiles(path, "*." + rawFormat).ToList();
            var jpgList = new List<string>();
            foreach (var rawFile in rawFiles)
            {
                var jpgFile = System.IO.Path.ChangeExtension(rawFile,JpgFormat);
                var jpegFile = System.IO.Path.ChangeExtension(rawFile, JpegFormat);
                if (System.IO.File.Exists(jpgFile))
                {
                    jpgList.Add(jpgFile);
                }
                if (System.IO.File.Exists(jpegFile))
                {
                    jpgList.Add(jpegFile);
                }
            }
            return jpgList;
        }
    }
}
