using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doAnWeb.Models;

namespace doAnWeb.Controllers
{
    public class ChuDeController : Controller
    {
        //
        // GET: /ChuDe/
        dbQuanLyBanSachDataContext db = new dbQuanLyBanSachDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChuDePartial()
        {
            var ListChuDe = db.ChuDes.Take(26).OrderBy(cd => cd.TenChuDe).ToList();
            return View(ListChuDe);
        }

        public ViewResult SachTheoCD(int MaCD)
        {
            var ListSach = db.Saches.Where(s => s.MaChuDe == MaCD).OrderBy(s => s.GiaBan).ToList();
            if (ListSach.Count == 0)
            {
                ViewBag.Sach = "không có sản phẩm nào thuộc chủ đề này!";
            }
            return View(ListSach);
        }

    }
}
