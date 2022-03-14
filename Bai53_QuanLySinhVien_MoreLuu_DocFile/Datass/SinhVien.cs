using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai53_QuanLySinhVien.Data
{
    [Serializable]
    public class SinhVien
    {
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NamSinh { get; set; }
        public LopHoc LopChuQuan { get; set; }
       

        public override string ToString()
        {
            return TenSinhVien;
        }
    }
}
