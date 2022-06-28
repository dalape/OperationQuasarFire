using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationQuasarFire.Business.Interfaces;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Services.Tests
{
    [TestClass()]
    public class AuthenticationTests
    {
        [TestMethod()]
        public void ValidateCredentialsTest()
        {
            //Arrege
            IResponseService responseService = new ResponseService();
            IExceptionHandler exceptionHandler = new ExceptionHandler();
            IAuthentication authentication = new Authentication(responseService, exceptionHandler);
            string userName = "DiegoAlape";
            string password = "MercadoLibre123";

            //Act
            bool isAuth = authentication.ValidateCredentials(userName, password);

            //Assert
            Assert.IsTrue(isAuth, "Error al realizar la autenticación");
        }

        [TestMethod()]
        public async Task GetTokenTestAsync()
        {
            //Arrege
            IResponseService responseService = new ResponseService();
            IExceptionHandler exceptionHandler = new ExceptionHandler();
            IAuthentication authentication = new Authentication(responseService, exceptionHandler);

            //Act
            IResponseService response = await authentication.GetToken();

            //Assert
            Assert.IsTrue(response.Meta.Status, "Error al generar el token");
        }
    }
}