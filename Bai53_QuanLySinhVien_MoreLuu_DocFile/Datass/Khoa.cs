using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai53_QuanLySinhVien.Data
{
    [Serializable]
    public class Khoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public Dictionary<string, LopHoc> lops { get; set; }
        public Hashtable kkk { get; set; } // Xem them Hàm Hashtable nó là collections như Dictionary but cao cấp hơn


        public Khoa()
        {
            lops = new Dictionary<string, LopHoc>();
        }
        public override string ToString()
        {
            return TenKhoa;
        }

    }
}
