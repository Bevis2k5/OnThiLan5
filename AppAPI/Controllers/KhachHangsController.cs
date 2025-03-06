using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppAPI.Model;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangsController : ControllerBase
    {
        private readonly Duong_PH52967 _duong_PH52967;

        public KhachHangsController(Duong_PH52967 duong_PH52967)
        {
            _duong_PH52967 = duong_PH52967;
        }

        // GET: api/KhachHangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHang>>> GetKhachHangs()
        {
            var khachHang =  await _duong_PH52967.KhachHangs.ToListAsync();
            return Ok(khachHang);
        }

        // GET: api/KhachHangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhachHang>> GetKhachHang(Guid id)
        {
            var khachHang = await _duong_PH52967.KhachHangs.FindAsync(id);

            return Ok(khachHang);
        }

        // PUT: api/KhachHangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhachHang(Guid id, KhachHang khachHang)
        {
            if (id != khachHang.Id)
            {
                return BadRequest();
            }

            _duong_PH52967.Entry(khachHang).State = EntityState.Modified;
            await _duong_PH52967.SaveChangesAsync();
            return Ok();
            
        }

        // POST: api/KhachHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KhachHang>> PostKhachHang(KhachHang khachHang)
        {
            _duong_PH52967.KhachHangs.Add(khachHang);
            await _duong_PH52967.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/KhachHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachHang(Guid id)
        {
            var khachHang = await _duong_PH52967.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            _duong_PH52967.KhachHangs.Remove(khachHang);
            await _duong_PH52967.SaveChangesAsync();

            return Ok();
        }

    }
}
