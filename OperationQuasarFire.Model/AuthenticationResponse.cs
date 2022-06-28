using System;

namespace OperationQuasarFire.Model
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime? TokenExpires { get; set; }
    }
}
