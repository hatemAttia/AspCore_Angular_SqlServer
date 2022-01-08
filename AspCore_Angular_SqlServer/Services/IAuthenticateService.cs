using AspCore_Angular_SqlServer.Models;

namespace AspCore_Angular_SqlServer.Services
{
    public interface IAuthenticateService
    {

        Eleve AuthenticateEleve(string Email, string password);
        Admin AuthenticateAdmin(string Email, string password);

    }
}
