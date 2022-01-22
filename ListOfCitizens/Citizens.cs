using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListOfCitizens
{
    public class Citizens : IEnumerable<Citizen>
    {
        public List<Citizen> Citizen { get; set; }

        public Citizens()
        {
            Citizen= new List<Citizen>();
        }

        public void AddCitizen(string city, string firstName, string lastName, string pesel)
        {
            Citizen newCitizen = new Citizen();
            newCitizen.City = city;
            newCitizen.FirstName = firstName;
            newCitizen.LastName = lastName;
            newCitizen.Pesel = pesel;

            if(PeselAlreadyExist(pesel))
            {
                foreach(var pe in Citizen.Where(x => x.Pesel == pesel))
                {
                    pe.City = newCitizen.City;
                    pe.FirstName = newCitizen.FirstName;
                    pe.LastName = newCitizen.LastName;
                }
            }
            else
            {
                Citizen.Add(newCitizen);
            }
        }

        public bool CheckControlNumber(string pesel)
        {
            if (pesel == "")
                return false;
            if (pesel.Length != 11)
                return false;
            int controlNumber = (pesel[pesel.Length-1] - '0'), sumOfNumbers=0;
            int[] pattern = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3};
            int i = 0;
            int[] numbers = pesel.Remove(pesel.Length-1).Select(c => c - '0').ToArray();
            foreach(int number in numbers)
            {
                sumOfNumbers = sumOfNumbers + (number * pattern[i]);
                i++;
            }

            if(controlNumber==0 && (sumOfNumbers.ToString().LastOrDefault() - '0' == 0))
            {
                return true;
            }
            if (controlNumber ==(10 - (sumOfNumbers.ToString().LastOrDefault() - '0')))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowListOfCitizens()
        {
            foreach(Citizen citizen in Citizen)
            {
                Console.WriteLine(citizen.City + " " + citizen.FirstName + " " + citizen.LastName + " " + citizen.Pesel);
            }
        }
        public void DeleteCitizenByPesel() {
            Console.Write("Podaj Pesel: ");
            string pesel = Console.ReadLine();
            if (CheckControlNumber(pesel) == true);
            foreach(Citizen citizen in Citizen)
            {
                if(citizen.Pesel == pesel) {
                    Citizen.Remove(citizen);
                }
            }
        }
        private bool PeselAlreadyExist(string pesel)
        {
            foreach (Citizen citizen in Citizen)
            {
                if(citizen.Pesel == pesel)
                {
                    return true;
                }
            }
            return false;
        }
        
        public static void CitizenValidate(Citizens ListOfCitizens)
        {
            string city, firstName, lastName, pesel;
            long peselHelper;

            Console.Write("Podaj miejsce zamieszkania: ");
            city = Console.ReadLine();

            Console.Write("Podaj imię: ");
            firstName = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            lastName = Console.ReadLine();

            do
            {
                Console.Write("Podaj pesel: ");
                pesel = Console.ReadLine();

                if (!long.TryParse(pesel, out peselHelper))
                {
                    Console.WriteLine("Podany pesel jest błędny.");
                }
                else if (!ListOfCitizens.CheckControlNumber(pesel))
                {
                    Console.WriteLine("Liczba kontrolna się nie zgadza");
                }


            } while (!long.TryParse(pesel, out peselHelper) || !ListOfCitizens.CheckControlNumber(pesel));

            ListOfCitizens.AddCitizen(city, firstName, lastName, pesel);
        }

        public IEnumerator<Citizen> GetEnumerator()
        {
            foreach(Citizen citizen in Citizen)
            {
                yield return citizen;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
