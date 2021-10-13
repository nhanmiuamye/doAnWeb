using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doAnWeb.Models;

namespace doAnWeb.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        dbQuanLyBanSachDataContext db = new dbQuanLyBanSachDataContext();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang kh, FormCollection f)
        {
            var hoten = f["HotenKH"];
            var tendn = f["TenDN"];
            var matkhau = f["Matkhau"];
            var rematkhau = f["ReMatKhau"];
            var dienthoai = f["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/DD/YYYY}", f["NgaySinh"]);
            var email = f["Email"];
            var diachi = f["Diachi"];
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Ho ten khong duoc bo trong";
            }
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Ten dang nhap khong duoc bo trong";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mat khau khong duoc bo trong";
            }
            if (String.IsNullOrEmpty(rematkhau))
            {
                ViewData["Loi4"] = "Nhap lai mat khau";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi5"] = "Nhap lai dien thoai";
            }
            if (!String.IsNullOrEmpty(hoten) && !String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau) && !String.IsNullOrEmpty(rematkhau) && !String.IsNullOrEmpty(dienthoai))
            {
                kh.HoTen = hoten;
                kh.TaiKhoan = tendn;
                kh.MatKhau = matkhau;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                kh.DiaChi = diachi;
                kh.Email = email;
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            var tendn = f["TenDN"];
            var matkhau = f["Matkhau"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = " Ten dang nhap khong dc bo trong";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = " Vui long nhap mat khau";
            }
            if (!String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau))
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(c => c.TaiKhoan == tendn && c.MatKhau == matkhau);
                if (kh != null)
                {
                    ViewBag.TB = "Dang nhap thanh cong !!!";
                    Session["taikhoan"] = kh;
                    return RedirectToAction("SachPartial", "Sach");
                }
                else
                    ViewBag.TB = "Sai ten DN hoac sai mat khau, vui long dang nhap lai";
            }
            return View();
        }

    }
}
