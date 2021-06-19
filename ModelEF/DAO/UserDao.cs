using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;
namespace ModelEF.DAO
{
    public class UserDao
    {
        private PhamThanhTamContext db;
        public UserDao()
        {
            db = new PhamThanhTamContext();
        }
        public int login(string user, string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName==user && x.Password.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            return 1;
        }
      
        public List<UserAccount> ListALL()
        {
            return db.UserAccounts.ToList();
        }

        public UserAccount Find(string username)
        {
            return db.UserAccounts.Find(username);
        }
       
        public IEnumerable<UserAccount> ListWhereALL(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }
            return model.OrderBy(x => x.IDUser).ToPagedList(page, pagesize);
        }

        public bool Delete(int id)
        {
            try
            {
                var IDUser = id;
                var User = db.UserAccounts.Find(IDUser);
                db.UserAccounts.Remove(User);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
