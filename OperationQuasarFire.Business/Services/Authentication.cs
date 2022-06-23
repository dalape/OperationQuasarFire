using Microsoft.IdentityModel.Tokens;
using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Model;
using OperationQuasarFire.Model.Enums;
using OperationQuasarFire.Model.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Services
{
    public class Authentication : IAuthentication
    {
        private readonly IResponseService _responseService;
        private readonly IExceptionHandler _exceptionHandler;

        public Authentication(IResponseService responseService, IExceptionHandler exceptionHandler)
        {
            _responseService = responseService;
            _exceptionHandler = exceptionHandler;
        }
        public async Task<IResponseService> GetToken()
        {
            try
            {
                AuthenticationResponse authResponse = new();

                JwtSecurityTokenHandler tokenHandler = new();
                byte[] key = Encoding.ASCII.GetBytes("sfgsakfhgsdlfkahsdlfkasdlkf");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, "Api")
                }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                authResponse.Token = tokenHandler.WriteToken(token);
                authResponse.TokenExpires = tokenDescriptor.Expires;

                _responseService.SetResponse(true, MessagesEnum.HttpStateOk, authResponse);
                return _responseService;
            }
            catch (Exception ex)
            {
                _responseService.Meta.Errors.Add(_exceptionHandler.GetMessage(ex));
                _responseService.SetResponse(false, MessagesEnum.HttpStateBadRequest, null);
                return _responseService;
            }
        }

        public bool ValidateCredentials(string name, string password)
        {
            try
            {
                AuthenticationResponse authResponse = new();
                string encryptedPassword = Encrypter.EncryptString(password, "sfgsakfhgsdlfkahsdlfkasdlkf");

                if (name.Equals("DiegoAlape") && encryptedPassword.Equals("CtFNZrdM705Rm+UbgKuhbQ==")) return true; 
                else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
