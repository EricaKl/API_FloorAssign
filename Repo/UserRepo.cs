using API_FloorAssign.DataContext;
using API_FloorAssign.IRepo;
using API_FloorAssign.Models;
using System.Collections.Generic;

namespace API_FloorAssign.Repo
{
    public class UserRepo : IUserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserDetails>  GetUsers(int id)
        {
            var list = new List<UserDetails>();
            try
            {
               list = _context.User.Where(x => x.CreatedBy == id && x.IsActive == true).ToList();
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public List<UserDetails> GetProfileUser(string email)
        {
            var list = new List<UserDetails>();
            try
            {
                list = _context.User.Where(x => x.Email == email && x.IsActive==true).ToList();
               
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public bool AddUser(UserRegistration user)
        {
           
                user.DOB.ToString("yyyy/MM/dd");
           
                var email = _context.UserRegistration.Where(x => x.Email == user.Email).SingleOrDefault();

                if (email != null)
                {
                    return false;
                }

                else
                {
                    _context.UserRegistration.Add(user);
                    _context.SaveChanges();
                    return true;
                }
            
        }

        public bool AddUserDetails(UserDetails user)
        {
            user.DOB.ToString("yyyy/MM/dd");
            var email = _context.User.Where(x => x.Email == user.Email).SingleOrDefault();
            if(email != null) 
            {
                return false;
            }
            else
            {
                user.IsActive = true;
                //user.CreatedBy = GetUserId();
                _context.User.Add(user);
                _context.SaveChanges();
                return true;
            }

        }
        public int GetUserId(string email)
        {
            var UserId = new UserRegistration();
            int id = 0;
            try
            {
                 UserId = _context.UserRegistration.Where(x => x.Email == email).SingleOrDefault();
                id = UserId.UserRegId;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return id;
        }

        public bool UpdateUserDetails(UserDetails user, int id)
        {
            UserDetails data = _context.User.Where(x=>x.UserDetailID == id).SingleOrDefault();
            if(data!=null)
            {
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.DOB = DateOnly.Parse(user.DOB.ToString("yyyy/MM/dd"));
                data.Mobile = user.Mobile;
                data.Address = user.Address;
                data.Email = user.Email;
                data.ProjectName = user.ProjectName;
                data.CompanyName = user.CompanyName;
                data.CompanyAddress = user.CompanyAddress;
                data.ModifiedDateTime = DateTime.Now;
                data.ModifiedBy = user.ModifiedBy;
                data.Password = user.Password;
                data.IsActive = true;
                _context.Update(data);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            var data = _context.User.Where(x=>x.UserDetailID==id).FirstOrDefault();
            if(data!=null)
            {
                data.IsActive = false;
                _context.Update(data);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
