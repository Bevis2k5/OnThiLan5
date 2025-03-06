using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppAPI.Model;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class KhachHangsController : Controller
    {
       

        public KhachHangsController()
        {
            
        }

        // GET: KhachHangs
        public async Task<IActionResult> Index()
        {
            List<KhachHang> khachHangs = new List<KhachHang>();
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7065/api/KhachHangs"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    khachHangs = JsonConvert.DeserializeObject<List<KhachHang>>(apiResponse);
                }
            }
            return View(khachHangs);
        }

        // GET: KhachHangs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            KhachHang khachHang = new KhachHang();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7065/api/KhachHangs/" + id))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        khachHang = JsonConvert.DeserializeObject<KhachHang>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ten,Tuoi,DiaChi,Email,SoDienThoai,LoaiKhachHang")] KhachHang khachHang)
        {
            KhachHang kh = new KhachHang();
            using (var http = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(khachHang), Encoding.UTF8, "application/json");
                using(var reponse = await http.PostAsync("https://localhost:7065/api/KhachHangs", content))
                {
                    string apiReponse = await reponse.Content.ReadAsStringAsync();
                    kh = JsonConvert.DeserializeObject<KhachHang>(apiReponse);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: KhachHangs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            KhachHang khachHang = new KhachHang();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7065/api/KhachHangs/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        khachHang = JsonConvert.DeserializeObject<KhachHang>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Ten,Tuoi,DiaChi,Email,SoDienThoai,LoaiKhachHang")] KhachHang khachHang)
        {
            KhachHang emp = new KhachHang();
            using (var http = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(khachHang), Encoding.UTF8, "application/json");
                using (var reponse = await http.PutAsync($"https://localhost:7056/api/SinhViens/{khachHang.Id}", content))
                {
                    if(reponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReponse = await reponse.Content.ReadAsStringAsync();
                        ViewBag.updateEmp = "Update thanh cong";
                        emp = JsonConvert.DeserializeObject<KhachHang>(apiReponse);
                    }
                    else
                    {
                        ViewBag.updateEmp = "Update khong thanh cong";
                        return RedirectToAction("Edit");
                    }

                }
            }
            return RedirectToAction("Index");
        }

        // GET: KhachHangs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            KhachHang emp = new KhachHang();
            using (var http = new HttpClient())
            {
                
                using (var reponse = await http.DeleteAsync("https://localhost:7065/api/KhachHangs/" + id))
                {
                    if (reponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReponse = await reponse.Content.ReadAsStringAsync();
                        ViewBag.updateEmp = "Xoa thanh cong";
                        emp = JsonConvert.DeserializeObject<KhachHang>(apiReponse);
                    }
                    else
                    {
                        ViewBag.updateEmp = "Xoa khong thanh cong";
                        return RedirectToAction("Index");
                    }

                }
            }
            return RedirectToAction("Index");
        }

        //// POST: KhachHangs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var khachHang = await _context.KhachHangs.FindAsync(id);
        //    if (khachHang != null)
        //    {
        //        _context.KhachHangs.Remove(khachHang);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool KhachHangExists(Guid id)
        //{
        //    return _context.KhachHangs.Any(e => e.Id == id);
        //}
    }
}
