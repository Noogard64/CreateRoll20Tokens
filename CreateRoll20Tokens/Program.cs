using System;
using System.IO;
using System.Diagnostics;

namespace CreateRoll20Tokens
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            //Setup
            Setup.CreateTempFolder();
            Setup.CreateLogFile();

            //Does GIMP exist in the default directory?
            string gimpExeFile = Setup.GetGimpExeFile();

            //Get the name of the file
            string[] files = Setup.GetImageFile();

            foreach (var file in files)
            {
                Functions.WriteToLogFile("File is located here: [" + file + "]");
                //#################################################################3

                //Execute GIMP-Python
                Functions.MakeImages(gimpExeFile, file);
                Console.WriteLine("When GIMP has finished processing the image, press any key to continue.");
                Console.ReadKey();

            }

            Functions.WriteToLogFile("Finished!");
            Console.ReadKey();

            string folderPath = Functions.GetTempFolder();
            Process.Start(folderPath);
        }
    }
}
