using PetshopApp.Core.DomainService;
using PetshopApp.Core.DomainService.Filtering;
using PetshopApp.Core.Entity;
using System;

namespace PetshopApp.Core.ApplicationService.Services
{
    public class UserService : IUserService
    { 
        readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
    
        public User CreateUser(User user, string readablePassword)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (readablePassword == null)
                throw new ArgumentNullException(nameof(readablePassword));

            //Add minimum password length!!


            return _userRepo.CreateUser(user, readablePassword);
        }

        public FilteredList<User> GetAllUsers(Filter filter)
        {
            return _userRepo.ReadAll(filter);
        }

        public User SignIn(User user, string readablePassword)
        {
            //Add minimum password length!!


            return _userRepo.SignIn(user, readablePassword);
        }
    }
}
