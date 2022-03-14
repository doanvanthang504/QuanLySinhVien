using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai53_QuanLySinhVien.Data
{
    [Serializable]
    public class LopHoc
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public Khoa KhoaChuQuan { get; set; }
        
        public Dictionary<string, SinhVien> sinhviens { get; set; }

        public LopHoc()
        {
            sinhviens = new Dictionary<string, SinhVien>();
            
        }
        public override string ToString()
        {
            return TenLop;
        }
    }
}
