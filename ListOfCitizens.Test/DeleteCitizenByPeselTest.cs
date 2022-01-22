using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCitizens.Test
{
    public class DeleteCitizenByPeselTest
    {
        [Test]
        public void DeleteCitizenByPesel_WhenPESELisCorrect_ShouldAddInhabitant()
        {
            //arrange
            var a = new Citizens();
            //act
            var result = a.DeleteCitizenByPesel("82070323171");
            //assert
            Assert.AreEqual(true, result);
        }
        [Test]
        public void DeleteCitizenByPesel_WhenPESELisInCorrect_ShouldAddInhabitant()
        {
            //arrange
            var a = new Citizens();
            //act
            var result = a.DeleteCitizenByPesel("00000000001");
            //assert
            Assert.AreEqual(false, result);
        }
        [Test]
        public void DeleteCitizenByPesel_WhenPESELisNotANumber_ShouldAddInhabitant()
        {
            //arrange
            var a = new Citizens();
            //act
            var result = a.DeleteCitizenByPesel("ABCDEFGHIJK");
            //assert
            Assert.AreEqual(false, result);
        }
    }
}
