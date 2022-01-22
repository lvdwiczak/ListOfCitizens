using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCitizens.Test
{
    public class AddCitizenTest
    {
        Citizens citizens = new Citizens();
        [Test]
        public void AddPerson_WhenPESELisCorrect_ShouldAddInhabitant()
        {
            try {
                citizens.AddCitizen("Imie","Nazwisko","Miasto","55030101193");
                Assert.IsTrue(true);
            }
            catch {
                Assert.IsTrue(false);
            }
        }
        [Test]
        public void AddPerson_WhenPESELisInCorrect_ShouldnotAddInhabitant()
        {
            try
            {
                citizens.AddCitizen("Imie", "Nazwisko", "Miasto", "00000000001");
                Assert.IsFalse(false);
            }
            catch
            {
                Assert.IsFalse(true);
            }
        }
        [Test]
        public void AddPerson_WhenPESELisNotANumber_ShouldAddnotInhabitant()
        {
            try
            {
                citizens.AddCitizen("Imie", "Nazwisko", "Miasto", "ABCDEFGHIJK");
                Assert.IsFalse(false);
            }
            catch
            {
                Assert.IsFalse(true);
            }
        }
        [Test]
        public void AddPerson_WhenPESELisNull_ShouldNotAddInhabitant()
        {
            try
            {
                citizens.AddCitizen("Imie", "Nazwisko", "Miasto", "");
                Assert.IsFalse(false);
            }
            catch
            {
                Assert.IsFalse(true);
            }
        }
        [Test]
        public void AddPerson_WhenPESELisShortherthan11char_ShouldNotAddInhabitant()
        {
            try
            {
                citizens.AddCitizen("Imie", "Nazwisko", "Miasto", "123");
                Assert.IsFalse(false);
            }
            catch
            {
                Assert.IsFalse(true);
            }
        }
        public void AddPerson_WhenPESELisLongerthan11char_ShouldNotAddInhabitant()
        {
            try
            {
                citizens.AddCitizen("Imie", "Nazwisko", "Miasto", "12334678765432345");
                Assert.IsFalse(false);
            }
            catch
            {
                Assert.IsFalse(true);
            }
        }
    }
}
