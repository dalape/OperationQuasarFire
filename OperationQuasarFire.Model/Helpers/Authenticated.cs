using System.Security.Principal;

namespace OperationQuasarFire.Model.Helpers
{
    public class Authenticated : IIdentity
    {
        public Authenticated(string authenticationType, bool isAuthenticated, string name)
        {
            AuthenticationType = authenticationType;
            IsAuthenticated = isAuthenticated;
            Name = name;
        }

        public string AuthenticationType { get; }
        public bool IsAuthenticated { get; }
        public string Name { get; }
    }
}
