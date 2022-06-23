using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationQuasarFire.Model
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime? TokenExpires { get; set; }
    }
}
