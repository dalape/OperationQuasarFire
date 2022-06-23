using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationQuasarFire.Model
{
    public class Meta
    {
        public Meta()
        {
            Errors = new List<string>();
        }
        public bool Status { get; set; }
        public string HttpStatus { get; set; }
        public List<string> Errors { get; set; }
    }
}
