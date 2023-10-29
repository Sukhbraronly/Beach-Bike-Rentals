using KayakBikeRentalAPI.Model;

namespace KayakBikeRentalAPI.Services
{
    public interface IloginService
    {
        bool IsAuthenticated(LoginUserModel loginUserModel);
    }
    public class loginService : IloginService
    {
        private KayakBikeRentalDBContext _context;

        IUserService _userService;
        public loginService(KayakBikeRentalDBContext context, IUserService service)
        {
            _context = context;
            _userService = service;
        }
        public bool IsAuthenticated(LoginUserModel loginUserModel)
        {
            UserModel user = _userService.GetUserDetailsById(loginUserModel.UserName);
            if(user == null) return false;
            if (user.Password.Equals(loginUserModel.Password)) return true;
            return false;  
        }
    }
}
