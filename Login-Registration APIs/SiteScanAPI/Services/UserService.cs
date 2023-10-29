using Microsoft.AspNetCore.Mvc;
using KayakBikeRentalAPI.Model;

namespace KayakBikeRentalAPI.Services
{
    public interface IUserService
    {
        List<UserModel> GetUsersList();
        UserModel GetUserDetailsById(string userEmail);
        bool SaveUser(UserModel userModel);
        bool DeleteUser(string userEmail);
    }

    public class UserService : IUserService
    {
        private KayakBikeRentalDBContext _context;
        public UserService(KayakBikeRentalDBContext context)
        {
            _context = context;
        }
        public bool DeleteUser(string userEmail)
        {

            try {
                var user = _context.Users.FirstOrDefault(x => x.Email == userEmail);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges(); // Call SaveChanges to persist the deletion to the database
                    return true;
                }
                else
                {
                    return false; // User not found, no deletion occurred
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("exception in deleting user :" + e.Message);
                return false;
            }
}

        public UserModel GetUserDetailsById(string userEmail)
        {
            UserModel user;
            try
            {
                user = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            }
            catch (Exception e)
            {
                Console.WriteLine("exception in getting user :"+e.Message);
                return null;
            }
            return user;
        }

        public List<UserModel> GetUsersList()
        {
            List<UserModel> userList;
            try
            {
                userList = _context.Set<UserModel>().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception in getting user list:" + e.Message);
                return null;
            }
            return userList;
        }

        public bool SaveUser(UserModel userModel)
        {
            try
            {
                if (userModel != null)
                {
                    _context.Add(userModel);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("exception in saving user :" + e.Message);
                return false;
            }
           
        }
    }
}
