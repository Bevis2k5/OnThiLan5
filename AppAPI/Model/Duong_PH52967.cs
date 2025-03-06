using Microsoft.EntityFrameworkCore;

namespace AppAPI.Model
{
    public class Duong_PH52967 : DbContext
    {
        public Duong_PH52967()
        {
            
        }

        public Duong_PH52967(DbContextOptions <Duong_PH52967> options) : base(options)
        {
        }
        public DbSet<KhachHang> KhachHangs { get; set; }
    }
}
