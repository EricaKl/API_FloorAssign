using API_FloorAssign.ViewModel;

namespace API_FloorAssign.IRepo
{
    public interface ILoginRepo
    {
        bool Login(LoginViewModel user);
    }
}
