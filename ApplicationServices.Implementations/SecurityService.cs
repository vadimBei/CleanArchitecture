using ApplicationServices.Interfaces;

namespace ApplicationServices.Implementations
{
    public class SecurityService : ISecurityService
    {
        public bool IsCurrentUserAdmin { get; }

        public string[] CurrentUserPermissions { get; }
    }
}
