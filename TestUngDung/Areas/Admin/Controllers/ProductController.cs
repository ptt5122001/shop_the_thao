using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString,string sortOrder, int page = 1, int pagesize = 5) 
        {
            var dm = new ProductDao();
            var model = dm.ListWhereALL(searchString,sortOrder, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase hinh)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                if (dao.Find(model.IDProduct) != null)
                {
                    return RedirectToAction("Create", "Product");
                }
                string _tenanh =  hinh.FileName;
                model.Image = _tenanh;
                string _path = Path.Combine(Server.MapPath("~/Upload/image/"),_tenanh);
                hinh.SaveAs(_path);
                int result = dao.Insert(model);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo không thành công");
                }
                
            }
            SetViewBag(model.CategoryNO);
            return View();
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryNO = new SelectList(dao.ListALL(), "IDCategory", "NameCategory", selectedId);
        }
        public ActionResult Details(int IDProduct)
        {
            var model = new ProductDao().Find(IDProduct);
 
            return View(model);
        }

    }
}