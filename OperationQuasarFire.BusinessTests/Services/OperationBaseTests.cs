using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Business.Services;
using OperationQuasarFire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Services.Tests
{
    [TestClass()]
    public class OperationBaseTests
    {
        [TestMethod()]
        public async Task TriangularPositionTestAsync()
        {
            //Arrange
            IResponseService responseService = new ResponseService();
            IExceptionHandler exceptionHandler = new ExceptionHandler();
            ICommunication communication = new Communication();
            IUtils utils = new Utils(communication);
            IOperationBase operationBase = new OperationBase(responseService, exceptionHandler, utils, communication);
            string[] messagesKenobi = { "este", "", "", "mensaje", "" };
            string[] messagesSkywalker = { "", "", "es", "", "secreto" };
            string[] messagesSato = { "este", "", "", "un", "" };
            List<Satelite> satellites = new()
            {
                new Satelite { Name = "kenobi", Distance = 100.0F, Message = messagesKenobi },
                new Satelite { Name = "skywalker", Distance = 115.5F, Message = messagesSkywalker },
                new Satelite { Name = "sato", Distance = 142.7F, Message = messagesSato }
            };
            //Act
            IResponseService response = await operationBase.TriangularPosition(satellites);
            //Assert
            Assert.IsTrue(response.Meta.Status, "Error al triangular la posición ");
        }

        [TestMethod()]
        public async Task SaveSateliteInformationKenobiTestAsync()
        {
            //Arrange
            IResponseService responseService = new ResponseService();
            IExceptionHandler exceptionHandler = new ExceptionHandler();
            ICommunication communication = new Communication();
            IUtils utils = new Utils(communication);
            IOperationBase operationBase = new OperationBase(responseService, exceptionHandler, utils, communication);
            string[] messagesKenobi = { "este", "", "", "mensaje", "" };
            Satelite satelite = new() { Name = "kenobi", Distance = 100.0F, Message = messagesKenobi };
            //Act
            IResponseService response = await operationBase.SaveSateliteInformation(satelite);
            //Assert
            Assert.IsTrue(response.Meta.Status, "Error al almacenar la información del satélite ");
        }

        [TestMethod()]
        public async Task SaveSateliteInformationSkywalkerTestAsync()
        {
            //Arrange
            IResponseService responseService = new ResponseService();
            IExceptionHandler exceptionHandler = new ExceptionHandler();
            ICommunication communication = new Communication();
            IUtils utils = new Utils(communication);
            IOperationBase operationBase = new OperationBase(responseService, exceptionHandler, utils, communication);
            string[] messagesSkywalker = { "", "", "es", "", "secreto" };
            Satelite satelite = new() { Name = "skywalker", Distance = 115.5F, Message = messagesSkywalker };
            //Act
            IResponseService response = await operationBase.SaveSateliteInformation(satelite);
            //Assert
            Assert.IsTrue(response.Meta.Status, "Error al almacenar la información del satélite ");
        }

        [TestMethod()]
        public async Task SaveSateliteInformationSatoTestAsync()
        {
            //Arrange
            IResponseService responseService = new ResponseService();
            IExceptionHandler exceptionHandler = new ExceptionHandler();
            ICommunication communication = new Communication();
            IUtils utils = new Utils(communication);
            IOperationBase operationBase = new OperationBase(responseService, exceptionHandler, utils, communication);
            string[] messagesSato = { "este", "", "", "un", "" };
            Satelite satelite = new() { Name = "sato", Distance = 142.7F, Message = messagesSato };
            //Act
            IResponseService response = await operationBase.SaveSateliteInformation(satelite);
            //Assert
            Assert.IsTrue(response.Meta.Status, "Error al almacenar la información del satélite ");
        }

        [TestMethod()]
        public async Task TriangularPositionByPartsTestAsync()
        {
            //Arrange
            IResponseService responseService = new ResponseService();
            IExceptionHandler exceptionHandler = new ExceptionHandler();
            ICommunication communication = new Communication();
            IUtils utils = new Utils(communication);
            IOperationBase operationBase = new OperationBase(responseService, exceptionHandler, utils, communication);

            //Act
            IResponseService response = await operationBase.TriangularPosition();
            //Assert
            Assert.IsTrue(response.Meta.Status, "Error al triangular posición por partes ");
        }
    }
}