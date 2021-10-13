using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doAnWeb.Models;

namespace doAnWeb.Controllers
{
    public class SachController : Controller
    {
        //
        // GET: /Sach/
        dbQuanLyBanSachDataContext db = new dbQuanLyBanSachDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SachPartial()
        {
            var ListSach = db.Saches.OrderBy(s => s.TenSach).ToList();
            return View(ListSach);
        }
        public ActionResult XemChiTiet(int ms)
        {
            Sach sach = db.Saches.Single(s => s.MaSach == ms);
            if (sach == null)
            {
                return HttpNotFound();

            }
            return View(sach);
        }

    }
}
