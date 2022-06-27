using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Services.Tests
{
    [TestClass()]
    public class CommunicationTests
    {
        [TestMethod()]
        public void CoordinatesByNameKenobiTest()
        {
            //Arrange
            ICommunication communication = new Communication();
            float xCoordinate = -500;
            float yCoordinate = -200;

            //Act
            float[] coordinates = communication.CoordinatesByName("kenobi");

            //Assert
            Assert.AreEqual(coordinates[0], xCoordinate, "La coordenada X no es correcta");
            Assert.AreEqual(coordinates[1], yCoordinate, "La coordenada Y no es correcta");
        }

        [TestMethod()]
        public void CoordinatesByNameSkywalkerTest()
        {
            //Arrange
            ICommunication communication = new Communication();
            float xCoordinate = 100;
            float yCoordinate = -100;

            //Act
            float[] coordinates = communication.CoordinatesByName("skywalker");

            //Assert
            Assert.AreEqual(coordinates[0], xCoordinate, "La coordenada X no es correcta");
            Assert.AreEqual(coordinates[1], yCoordinate, "La coordenada Y no es correcta");
        }

        [TestMethod()]
        public void CoordinatesByNameSatoTest()
        {
            //Arrange
            ICommunication communication = new Communication();
            float xCoordinate = 500;
            float yCoordinate = 100;

            //Act
            float[] coordinates = communication.CoordinatesByName("sato");

            //Assert
            Assert.AreEqual(coordinates[0], xCoordinate, "La coordenada X no es correcta");
            Assert.AreEqual(coordinates[1], yCoordinate, "La coordenada Y no es correcta");
        }

        [TestMethod()]
        public void ValidateSateliteKenobiTest()
        {
            //Arrange
            ICommunication communication = new Communication();

            //Act
            bool exist = communication.ValidateSateliteName("kenobi");

            //Assert
            Assert.IsTrue(exist, "Satélite no existe");
        }

        [TestMethod()]
        public void ValidateSateliteSkywalkerTest()
        {
            //Arrange
            ICommunication communication = new Communication();

            //Act
            bool exist = communication.ValidateSateliteName("skywalker");

            //Assert
            Assert.IsTrue(exist, "Satélite no existe");
        }

        [TestMethod()]
        public void ValidateSateliteSatoTest()
        {
            //Arrange
            ICommunication communication = new Communication();

            //Act
            bool exist = communication.ValidateSateliteName("sato");

            //Assert
            Assert.IsTrue(exist, "Satélite no existe");
        }

        [TestMethod()]
        public void GetLocationKenobiTest()
        {
            //Arrange
            ICommunication communication = new Communication();
            float xCoordinate = -500;
            float yCoordinate = -200;
            //Act
            float[] coordinates = communication.GetLocation(100.0F);

            //Assert
            Assert.AreEqual(coordinates[0], xCoordinate, "La coordenada X no es correcta");
            Assert.AreEqual(coordinates[1], yCoordinate, "La coordenada Y no es correcta");
        }

        [TestMethod()]
        public void GetLocationSkywalkerTest()
        {
            //Arrange
            ICommunication communication = new Communication();
            float xCoordinate = 100;
            float yCoordinate = -100;
            //Act
            float[] coordinates = communication.GetLocation(115.5F);

            //Assert
            Assert.AreEqual(coordinates[0], xCoordinate, "La coordenada X no es correcta");
            Assert.AreEqual(coordinates[1], yCoordinate, "La coordenada Y no es correcta");
        }

        [TestMethod()]
        public void GetLocationSatoTest()
        {
            //Arrange
            ICommunication communication = new Communication();
            float xCoordinate = 500;
            float yCoordinate = 100;
            //Act
            float[] coordinates = communication.GetLocation(142.7F);

            //Assert
            Assert.AreEqual(coordinates[0], xCoordinate, "La coordenada X no es correcta");
            Assert.AreEqual(coordinates[1], yCoordinate, "La coordenada Y no es correcta");
        }

        [TestMethod()]
        public void GetMessageTest()
        {
            //Arrange
            ICommunication communication = new Communication();
            string[] messages = { "", "este", "es", "un", "mensaje" };
            string message = " este es un mensaje";

            //Act
            string messageValidation = communication.GetMessage(messages);
            //Assert
            Assert.AreEqual(messageValidation, message, "El mensaje decifrado no es correcto");
        }
    }
}