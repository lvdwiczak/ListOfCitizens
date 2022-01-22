using System;

namespace ListOfCitizens
{
    public class Program
    {
        public static void Menu()
        {
            Console.WriteLine("1. Dodaj mieszkańca");
            Console.WriteLine("2. Pokaż listę mieszkańców do dodania");
            Console.WriteLine("3. Usun osobe");
            Console.WriteLine("4. Zapisz listę do pliku");
            Console.WriteLine("5. Wyczyść konsole");
            Console.WriteLine("6. Exit");
        }
        public static void Main(string[] args)
        {
            Citizens ListOfCitizens = new Citizens();
            ListOfCitizens.AddCitizen("CITY", "FIRSTNAME", "LASTNAME", "82070323171");
            
            while(true)
            { 
                Menu();
                Console.Write("Wybór: ");
                string choose = Console.ReadLine();
                if(choose == "6") { break; }

                switch (choose)
                {
                    case "1":
                        Console.WriteLine();
                        Citizens.CitizenValidate(ListOfCitizens);
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        ListOfCitizens.ShowListOfCitizens();
                        Console.WriteLine();
                        break;
                    case "3":
                            Console.WriteLine();
                            ListOfCitizens.DeleteCitizenByPesel();
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("Podaj nazwę pliku do którego chcesz zapisać listę: ");
                        Files.SaveFile(Console.ReadLine(), ListOfCitizens);
                        break;
                    case "5":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Nie ma takiej opcji do wyboru");
                        Console.WriteLine();
                        break;
                }
            }
            
        }
    }
}
