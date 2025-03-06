namespace AppAPI.Model
{
    public class KhachHang
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public int LoaiKhachHang { get; set; }
    }
}
