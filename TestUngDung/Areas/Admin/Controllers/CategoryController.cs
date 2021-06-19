using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var dm = new CategoryDao();
            var model = dm.ListWhereALL(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
    }
}