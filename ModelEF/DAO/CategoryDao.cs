using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
   public  class CategoryDao
    {
        private PhamThanhTamContext db;
        public CategoryDao()
        {
            db = new PhamThanhTamContext();
        }
        public List<Category> ListALL()
        {
            return db.Categories.ToList();
        }
        public IEnumerable<Category> ListWhereALL(string keysearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.NameCategory.Contains(keysearch));
            }
            return model.OrderBy(x => x.IDCategory).ToPagedList(page, pagesize);
        }
    }
}
