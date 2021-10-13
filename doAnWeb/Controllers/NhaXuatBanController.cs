using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doAnWeb.Models;

namespace doAnWeb.Controllers
{
    public class NhaXuatBanController : Controller
    {
        //
        // GET: /NhaXuatBan/
        dbQuanLyBanSachDataContext db = new dbQuanLyBanSachDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NhaXuatBanPartial()
        {
            var ListNXB = db.NhaXuatBans.Take(15).OrderBy(nxb => nxb.TenNXB).ToList();
            return View(ListNXB);
        }

        public ViewResult SachTheoNXB(int MaNXB)
        {
            var ListSach = db.Saches.Where(s => s.MaNXB == MaNXB).OrderBy(s => s.GiaBan).ToList();
            if (ListSach.Count == 0)
            {
                ViewBag.Sach = "không có sản phẩm nào thuộc chủ đề này!";
            }
            return View(ListSach);
        }

    }
}
