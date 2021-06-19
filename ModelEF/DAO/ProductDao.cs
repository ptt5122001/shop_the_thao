using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private PhamThanhTamContext db;
        public ProductDao()
        {
            db = new PhamThanhTamContext();
        }
        public List<Product> ListALL()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> ListWhereALL(string keysearch, string sortOrder, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.NameProduct.Contains(keysearch));
            }
            switch (sortOrder)
            {
                case "UnitCost_desc":        
                    return model.OrderByDescending(x => x.UnitCost).ToPagedList(page, pagesize);
                case "Quantity":
                    return model.OrderBy(x => x.Quantity).ToPagedList(page, pagesize);
            }
            return model.OrderBy(x => x.IDProduct).ToPagedList(page, pagesize);
        }
        public int Insert(Product entitydmSP)
        {
            db.Products.Add(entitydmSP);
            db.SaveChanges();
            return entitydmSP.IDProduct;
        }

        public Product Find(int IDProduct)
        {
            return db.Products.Find(IDProduct);
        }
        
    }
}
