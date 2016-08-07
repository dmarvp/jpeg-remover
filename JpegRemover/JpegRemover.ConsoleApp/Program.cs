using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JpegRemover.Utils;

namespace JpegRemover.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Let's make sure the directory exists
            var directory = args[0];
            if (!System.IO.Directory.Exists(directory))
            {
                Console.WriteLine("Please, specify a valid directory.");
                return;
            }

            //Ask the user which mode does he want the app to run in
            Console.WriteLine("Please, choose an option (1 or 2):");
            Console.WriteLine("1. List mode: Will list all the duplicate jpgs on a given folder.");
            Console.WriteLine("2. Delete mode: Will delete all the duplicate jpgs on a given folder.");
            var line = Console.ReadLine();
            var option = 0;
            if (!Int32.TryParse(line, out option) || !Enum.IsDefined(typeof(OperationModes), option))
            {
                Console.WriteLine("Please, specify a valid option.");
                return;
            }

            //Ask the user which format of raw files he's using
            Console.Clear();
            var rawFormats = Enum.GetValues(typeof(Enums.RawFormats)).Cast<Enums.RawFormats>();
            Console.WriteLine("Type in the number of the raw format to search for:");
            foreach (var rawFormat in rawFormats)
            {
                Console.WriteLine("{0}. {1} - {2}", ((int)rawFormat), rawFormat,
                    Enums.GetEnumDescription(rawFormat));

            }

            //Get the option sent by the user
            line = Console.ReadLine();
            var format = 0;

            if (!Int32.TryParse(line, out format) || !Enum.IsDefined(typeof(Enums.RawFormats), format))
            {
                Console.WriteLine("Please, specify a valid option.");
                return;
            }
            Enums.RawFormats rawFormatPicked = (Enums.RawFormats)format;

            //Get the list of duplicated files
            Console.Clear();
            var duplicatedList = FileHandler.GetDuplicatedJpegsList(directory, rawFormatPicked.ToString());

            if (option == (int) OperationModes.List)
            {
                var count = 0;
                foreach (var jpegFile in duplicatedList)
                {
                    count++;
                    Console.WriteLine(jpegFile);
                    if (count == 20)
                    {
                        Console.WriteLine("Press any key for more...");
                        Console.ReadLine();
                        count = 0;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Found {0} .jpg files.", duplicatedList.Count);
            }
            else
            {
                foreach (var jpegFile in duplicatedList)
                {
                    System.IO.File.Delete(jpegFile);
                }
                Console.WriteLine();
                Console.WriteLine("Deleted {0} .jpg files.", duplicatedList.Count);
            }

            Console.WriteLine("Press a key to exit...");
            Console.ReadLine();
        }

        enum OperationModes
        {
            List = 1,
            Delete = 2
        }
    }
}
