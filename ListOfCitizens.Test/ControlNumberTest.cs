using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListOfCitizens;
using NUnit.Framework;

namespace ListOfCitizens.Test
{
    public class ControlNumberTest
    {
        [Test]
        public void CheckControlNumber_WhenPESELisCorrect_ShouldAddInhabitant()
        {
            //arrange
            var a = new Citizens();
            //act
            var result = a.CheckControlNumber("55030101193");
            //assert
            Assert.AreEqual(true, result);
        }
        [Test]
        public void CheckControlNumber_WhenPESELisInCorrect_ShouldNotAddInhabitant()
        {
            //arrange
            var a = new Citizens();
            //act
            var result = a.CheckControlNumber("00000000001");
            //assert
            Assert.AreEqual(false, result);
        }
        [Test]
        public void CheckControlNumber_WhenPESELisNotANumber_ShoulNotdAddInhabitant()
        {
            //arrange
            var a = new Citizens();
            //act
            var result = a.CheckControlNumber("ABCDEFGHIJK");
            //assert
            Assert.AreEqual(false, result);
        }
        [Test]
        public void CheckControlNumber_WhenPESELisNull_ShouldNotAddInhabitant()
        {
            //arrange
            var a = new Citizens();
            //act
            var result = a.CheckControlNumber("");
            //assert
            Assert.AreEqual(false, result);
        }
        [Test]
        public void CheckControlNumber_WhenPESELisLongerthan11Chars_ShouldNotAddInhabitant()
        {
            //arrange
            var a = new Citizens();
            //act
            var result = a.CheckControlNumber("123456789101112");
            //assert
            Assert.AreEqual(false, result);
        }
        [Test]
        public void CheckControlNumber_WhenPESELisShortherthan11chars_ShouldNotAddInhabitant()
        {
            //arrange
            var a = new Citizens();
            //act
            var result = a.CheckControlNumber("123");
            //assert
            Assert.AreEqual(false, result);
        }

    }
}
