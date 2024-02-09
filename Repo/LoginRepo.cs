using API_FloorAssign.DataContext;
using API_FloorAssign.IRepo;
using API_FloorAssign.ViewModel;

namespace API_FloorAssign.Repo
{
    public class LoginRepo : ILoginRepo
    {
        ApplicationDbContext _context;

        public LoginRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Login(LoginViewModel user)
        {
            var email = _context.UserRegistration.Where(x => x.Email == user.Email).SingleOrDefault();
            if (email != null)
            {
                var password = _context.UserRegistration.Where(x => x.Password == user.Password).SingleOrDefault();
                if (password != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
