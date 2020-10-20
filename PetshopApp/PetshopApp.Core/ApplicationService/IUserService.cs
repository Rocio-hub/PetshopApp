using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;

namespace PetshopApp.Core.ApplicationService
{
    public interface IUserService
    {
        FilteredList<User> GetAllUsers(Filter filter);

        User CreateUser(User user, string readablePassword);

        User SignIn(User user, string readablePassword);
    }
}
