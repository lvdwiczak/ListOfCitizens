using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ListOfCitizens
{
    public class Files
    {
        private static bool CheckFileExist(string nameOfFile)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\" + nameOfFile + ".txt";
            if (File.Exists(filePath))
            {
                string choose;

                Console.WriteLine("Plik o podanej nazwie już istnieje, czy chcesz go nadpisać?[T/N]");

                choose = Console.ReadLine();
                if(choose=="T" || choose == "t")
                {
                    Console.WriteLine();
                    Console.WriteLine("Plik został nadpisany");
                    Console.WriteLine();
                    return true;
                }
            }
            else
            {
                return true;
            }
            Console.WriteLine("Nie nadpisano pliku");
            return false;
        }

        public static void SaveFile(string nameOfFile, Citizens listOfCitizens)
        {
            if(CheckFileExist(nameOfFile))
            {
                using (StreamWriter sw = new StreamWriter(nameOfFile + ".txt"))
                {
                    foreach (var citizen in listOfCitizens)
                    {
                        sw.WriteLine(citizen.City + " " + citizen.FirstName + " " + citizen.LastName + " " + citizen.Pesel);
                    }
                }
            }
        }
    }
}
