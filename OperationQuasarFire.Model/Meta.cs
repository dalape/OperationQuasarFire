using System.Collections.Generic;

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
