using AppData.ViewModels;
using AppData.ViewModels.BanOffline;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Rotativa.AspNetCore;
using System.Globalization;
using System.Net;

namespace AppView.Controllers
{
    public class QuanLyHoaDonController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IServiceProvider _serviceProvider;
        private readonly ITempDataProvider _tempDataProvider;
        public QuanLyHoaDonController(IServiceProvider serviceProvider, ITempDataProvider tempDataProvider)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7095/api/");
            _serviceProvider = serviceProvider;
            _tempDataProvider = tempDataProvider;
        }
        //View QLHD
        public IActionResult _QuanLyHoaDon()
        {
            return View();
        }
        // Load tất cả hóa đơn
        
        // Cập nhật trạng thái
        public async Task<IActionResult> DoiTrangThai(Guid idhd, int trangthai)// Dùng cho trạng thái truyền  vào: 10, 3
        {
            try
            {
                var loginInfor = new LoginViewModel();
                string? session = HttpContext.Session.GetString("LoginInfor");
                if (session != null)
                {
                    loginInfor = JsonConvert.DeserializeObject<LoginViewModel>(session);
                    var idnv = loginInfor.Id;
                    if (trangthai == 6)
                    {
                        string url = $"HoaDon/GiaoThanhCong?idhd={idhd}&idnv={idnv}";
                        var response = await _httpClient.PutAsync(url, null);
                        if (response.IsSuccessStatusCode)
                        {
                            return Json(new { success = true, message = "Cập nhật trạng thái thành công" });
                        }
                    }
                    else
                    {
                        string url = $"HoaDon?idhoadon={idhd}&trangthai={trangthai}&idnhanvien={idnv}";
                        var response = await _httpClient.PutAsync(url, null);
                        if (response.IsSuccessStatusCode)
                        {
                            return Json(new { success = true, message = "Cập nhật trạng thái thành công" });
                        }
                    }
                }
                return Json(new { success = false, message = "Cập nhật trạng thái thất bại" });
            }
            catch (Exception)
            {
                return RedirectToAction("_QuanLyHoaDon", "QuanLyHoaDon");
            }
        }
        //Hủy hóa đơn
        [HttpGet("/QuanLyHoaDon/HuyHD")]
        public async Task<IActionResult> HuyHD(Guid idhd, string ghichu)
        {
            try
            {
                var loginInfor = new LoginViewModel();
                string? session = HttpContext.Session.GetString("LoginInfor");
                if (session != null)
                {
                    loginInfor = JsonConvert.DeserializeObject<LoginViewModel>(session);
                }
                var idnv = loginInfor.Id;
                if(ghichu != null)
                {
                    string url = $"HoaDon/HuyHD?idhd={idhd}&idnv={idnv}";
                    var response = await _httpClient.PutAsync(url, null);
                    if (response.IsSuccessStatusCode)
                    {
                        var stringURL = $"https://localhost:7095/api/HoaDon/UpdateGhichu?idhd={idhd}&idnv={loginInfor.Id}&ghichu={ghichu}";
                        var responseghichu = await _httpClient.PutAsync(stringURL, null);
                        if (responseghichu.IsSuccessStatusCode)
                        {
                            return Json(new { success = true, message = "Cập nhật trạng thái thành công" });
                        }
                    }
                }
                return Json(new { success = false, message = "Ghi chú không được để null" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("_QuanLyHoaDon", "QuanLyHoaDon");
            }
        }
        //Hoàn hàng
        [HttpGet("/QuanLyHoaDon/HoanHang")] //
        public async Task<IActionResult> HoanHang(Guid idhd, string ghichu)
        {
            try
            {
                var loginInfor = new LoginViewModel();
                string? session = HttpContext.Session.GetString("LoginInfor");
                if (session != null)
                {
                    loginInfor = JsonConvert.DeserializeObject<LoginViewModel>(session);
                }
                var idnv = loginInfor.Id;

                string url = $"HoaDon/HoanHD?idhd={idhd}&idnv={idnv}";
                var response = await _httpClient.PutAsync(url, null);
                if (response.IsSuccessStatusCode)
                {
                    var stringURL = $"https://localhost:7095/api/HoaDon/UpdateGhichu?idhd={idhd}&idnv={loginInfor.Id}&ghichu={ghichu}";
                    var responseghichu = await _httpClient.PutAsync(stringURL, null);
                    if (responseghichu.IsSuccessStatusCode)
                    {
                        return Json(new { success = true, message = "Cập nhật trạng thái thành công" });
                    }
                }
                return Json(new { success = false, message = "Cập nhật trạng thái thất bại" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("_QuanLyHoaDon", "QuanLyHoaDon");
            }
        }
        //Hoàn hàng thành công
        [HttpGet("/QuanLyHoaDon/HoanHangTC")] //
        public async Task<IActionResult> HoanHangTC(Guid idhd)
        {
            try
            {
                var loginInfor = new LoginViewModel();
                string? session = HttpContext.Session.GetString("LoginInfor");
                if (session != null)
                {
                    loginInfor = JsonConvert.DeserializeObject<LoginViewModel>(session);
                }
                var idnv = loginInfor.Id;

                string url = $"HoaDon/HoanTCHD?idhd={idhd}&idnv={idnv}";
                var response = await _httpClient.PutAsync(url, null);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Cập nhật trạng thái thành công" });
                }
                return Json(new { success = false, message = "Cập nhật trạng thái thất bại" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("_QuanLyHoaDon", "QuanLyHoaDon");
            }
        }

        //Xuất PDF
        [HttpGet("/Admin/QuanLyHoaDon/ExportPDF/{idhd}")]
        public async Task<IActionResult> ExportPDF(Guid idhd)
        {
            try
            {
                var cthd = await _httpClient.GetFromJsonAsync<ChiTietHoaDonQL>($"HoaDon/ChiTietHoaDonQL/{idhd}");
                var view = new ViewAsPdf("ExportHD", cthd)
                {
                    FileName = $"{cthd.MaHD}.pdf",
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                };
                return view;
            }
            catch (Exception ex)
            {
                return RedirectToAction("_QuanLyHoaDon", "QuanLyHoaDon");
            }
        }
        //In hóa đơn
        [HttpGet("/QuanLyHoaDon/PrintHD/{idhd}")]
        public async Task<IActionResult> PrintHD(Guid idhd)
        {
            var cthd = await _httpClient.GetFromJsonAsync<ChiTietHoaDonQL>($"HoaDon/ChiTietHoaDonQL/{idhd}");
            return View("ExportHD", cthd);
        }
    }
}
