using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;

namespace PetshopApp.Core.DomainService
{
    public interface IUserRepository
    {
        FilteredList<User> ReadAll(Filter filter);
        User CreateUser(User user, string readablePassword);
        User SignIn(User user, string readablePassword);
    }
}
