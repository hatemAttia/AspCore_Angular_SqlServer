using AspCore_Angular_SqlServer.Models;

namespace AspCore_Angular_SqlServer.Services
{
    public interface IAuthenticateService
    {

        Eleve Authenticate(string Email, string password);

    }
}
