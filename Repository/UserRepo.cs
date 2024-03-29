using Lap3_2.Models;
using Lap3_2.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Lap3_2.Repository
{
    public interface IUserRepo
    {
        public List<User> GetAll();
        public void Add(User user);
        public User GetById(LoginViewModel model);
    }
    public class UserRepo:IUserRepo
    {
        ITIContext db;
        public UserRepo(ITIContext _db)
        {
            db= _db;
        }

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public List<User> GetAll()
        {
          return  db.Users.Include(a=>a.Roles).ToList();
        }

		public User GetById(LoginViewModel model)
		{
            return db.Users.FirstOrDefault(a=>a.Email == model.Email && a.Password == model.Password);
		}
	}
}
