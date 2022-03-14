using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai53_QuanLySinhVien.Data;
using System.IO;

namespace Bai53_QuanLySinhVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        public Dictionary<string, Khoa> CSDL = new Dictionary<string, Khoa>();
        SinhVien SelectecdSV = null;
        LopHoc selectedLop = null;
             
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm:ss \ndd/MM/yyyy");
            lblTmeNow.Text = time;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DemoCSDL();
            HienThiLenTreeView();
            HienLenComBoBox();
        }

       
        

        private void HienLenComBoBox()
        {
            comboKhoa.Items.Clear();
            foreach(KeyValuePair<string, Khoa> itemKhoa in CSDL)
            {
                Khoa kh = itemKhoa.Value;
                comboKhoa.Items.Add(kh);

            }
        }

        private void HienThiLenTreeView()
        {
            tvThongTinKhoa.Nodes.Clear();
            foreach(KeyValuePair<string, Khoa> itemKhoa in CSDL)
            {
                Khoa kh = itemKhoa.Value;
                TreeNode nodeKhoa = new TreeNode(kh.TenKhoa);
                tvThongTinKhoa.Nodes.Add(nodeKhoa);
                nodeKhoa.Tag = kh;
                foreach(KeyValuePair<string, LopHoc> itemLop in kh.lops)
                {
                    LopHoc lp = itemLop.Value;
                    TreeNode nodeLop = new TreeNode(lp.TenLop);
                    nodeKhoa.Nodes.Add(nodeLop);
                    nodeLop.Tag = lp;
                }
            }
            tvThongTinKhoa.ExpandAll();
        }

        private void DemoCSDL()
        {
            #region CNTT
            Khoa cntt = new Khoa()
            {
                MaKhoa = "CNTT",
                TenKhoa = "Khoa CNTT"
            };
            CSDL.Add(cntt.MaKhoa,cntt);

            LopHoc lopcntt1 = new LopHoc()
            {
                MaLop = "CNTT1",
                TenLop = "Lơp CNTT1"
            };
            lopcntt1.KhoaChuQuan = cntt;
            cntt.lops.Add(lopcntt1.MaLop, lopcntt1);

            LopHoc lopcntt2 = new LopHoc()
            {
                MaLop = "CNTT2",
                TenLop = "Lơp CNTT2"

            };
            lopcntt2.KhoaChuQuan = cntt ;
            cntt.lops.Add(lopcntt2.MaLop, lopcntt2);

            LopHoc lopcntt3 = new LopHoc()
            {
                MaLop = "CNTT3",
                TenLop = "Lơp CNTT3",

            };
            lopcntt3.KhoaChuQuan = cntt;
            cntt.lops.Add(lopcntt3.MaLop, lopcntt3);
            #endregion

            #region 

            Khoa ktoan = new Khoa() { MaKhoa = "Kế Toán", TenKhoa = "Khoa KT" };
            CSDL.Add(ktoan.MaKhoa, ktoan);
            LopHoc Ktoan1 = new LopHoc()
            {
                MaLop = "KT1",
                TenLop = "Lớp Kế Toán 1"
            };
            Ktoan1.KhoaChuQuan = ktoan;
            ktoan.lops.Add(Ktoan1.MaLop, Ktoan1);

            LopHoc Ktoan2 = new LopHoc()
            {
                MaLop = "KT2",
                TenLop = "Lớp Kế Toán 2"
            };
            Ktoan2.KhoaChuQuan = ktoan;
            ktoan.lops.Add(Ktoan2.MaLop, Ktoan2);

            Khoa tudonghoa = new Khoa() { MaKhoa = "TĐH", TenKhoa = "Khoa Tự Động Hóa" };
            CSDL.Add(tudonghoa.MaKhoa, tudonghoa);

            LopHoc tudonghoa1 = new LopHoc()
            {
                MaLop = "TDH1",
                TenLop = "Tự Động Hóa 1"
            };
            tudonghoa1.KhoaChuQuan = tudonghoa;
            tudonghoa.lops.Add(tudonghoa1.MaLop, tudonghoa1);

            LopHoc tudonghoa2 = new LopHoc()
            {
                MaLop = "TDH2",
                TenLop = "Tự Động Hóa 2"
            };
            tudonghoa2.KhoaChuQuan = tudonghoa;
            tudonghoa.lops.Add(tudonghoa2.MaLop, tudonghoa2);

            LopHoc tudonghoa3 = new LopHoc()
            {
                MaLop = "TDH3",
                TenLop = "Tự Động Hóa 3"
            };
            tudonghoa3.KhoaChuQuan = tudonghoa;
            tudonghoa.lops.Add(tudonghoa3.MaLop, tudonghoa3);



            #endregion

            #region SInhVien
            SinhVien thang = new SinhVien()
            {
                MaSinhVien = "sv1",
                TenSinhVien = "Đoàn Văn Thẳng",
                GioiTinh = true,
                NamSinh=new DateTime(1992,2,2) // Cấu trúc DateTime phải để dấu phẩy trong ngày tháng năm
            };
            lopcntt1.sinhviens.Add(thang.MaSinhVien,thang);
            thang.LopChuQuan = lopcntt1;

            SinhVien suon = new SinhVien()
            {
                MaSinhVien = "sv2",
                TenSinhVien = "Đoàn văn Suôn",
                GioiTinh = true,
                NamSinh = new DateTime(1992 , 12 , 19)
            };
            lopcntt1.sinhviens.Add(suon.MaSinhVien, suon);
            suon.LopChuQuan = lopcntt1;

            SinhVien thanh = new SinhVien()
            {
                MaSinhVien = "sv1",
                TenSinhVien = "Phan Văn Thanh",
                GioiTinh = true,
                NamSinh = new DateTime(1999 , 11 , 19)
            };
            tudonghoa1.sinhviens.Add(thanh.MaSinhVien, thanh);
            thanh.LopChuQuan = tudonghoa1;

            SinhVien yen = new SinhVien()
            {
                MaSinhVien = "sv2",
                TenSinhVien = "Nguyễn thị Yến",
                GioiTinh = false,
                NamSinh = new DateTime(1992 , 2 , 1)
            };
            tudonghoa1.sinhviens.Add(yen.MaSinhVien, yen);
            yen.LopChuQuan = tudonghoa1 ;
            #endregion
        }

        private void tvThongTinKhoa_AfterSelect(object sender, 
            TreeViewEventArgs e) //SỐ e để biết mình chọn cái nào>?
        {
            if (e.Node != null)
            {
                if (e.Node.Level == 1)
                {
                    LopHoc lp = e.Node.Tag as LopHoc;  //Lưu ý ếp kiểu dữ liệu vào lớp để lấy sinh viên ra
                    HienThiThongTinSinhVienLenListView(lp);
                    selectedLop = lp;
                }
                else
                {
                    lvDanhSachSinhVien.Items.Clear();
                }
            }

           
       
        }

        private void HienThiThongTinSinhVienLenListView(LopHoc lp)
        {
            lvDanhSachSinhVien.Items.Clear();
            foreach(KeyValuePair<string, SinhVien> itemSinhVien in lp.sinhviens)
            {
                SinhVien sv = itemSinhVien.Value;
                ListViewItem liv = new ListViewItem(sv.MaSinhVien);
                liv.SubItems.Add(sv.TenSinhVien);
                liv.SubItems.Add(sv.GioiTinh == false ? "nữ" : "nam");
                liv.SubItems.Add(sv.NamSinh.ToString("dd/MM/yyyy"));
                liv.Tag = sv;
                lvDanhSachSinhVien.Items.Add(liv);
            }
        }

        private void comboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKhoa.SelectedIndex == -1) return;
            Khoa kh = comboKhoa.SelectedItem as Khoa;  //ÉP kiểu khoa, do ta đã đưa khoa vào comboKhoa
            HienThiLenComBoBoxLop(kh);
        }
        private void HienThiLenComBoBoxLop(Khoa kh)
        {
            comboLopHoc.Items.Clear();
            foreach(KeyValuePair<string,LopHoc> itemLop in kh.lops)
            {
                LopHoc lp = itemLop.Value;
                comboLopHoc.Items.Add(lp);
            }
        }

        private void lvDanhSachSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachSinhVien.SelectedItems.Count ==0) return; // DK .Count==0 thì không có người dùng
            ListViewItem liv = lvDanhSachSinhVien.SelectedItems[0];
            SinhVien sv = liv.Tag as SinhVien;
            txtMaSinhVien.Text = sv.MaSinhVien;
            txtTenSinhVien.Text = sv.TenSinhVien;
            if (sv.GioiTinh)
            {
                radioNam.Checked = true;
            }
            else
            {
                radioNu.Checked = true;
            }
            dtpNamSinh.Value = sv.NamSinh;
           
            comboLopHoc.Text = sv.LopChuQuan + "";

            LopHoc lp = selectedLop;
            comboKhoa.Text = lp.KhoaChuQuan + "";

        
             SelectecdSV = sv; //
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (comboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn khoa");
                return;
            }
            if (comboLopHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn lớp");
                return;
            }
            SinhVien sv = new SinhVien();
            sv.MaSinhVien = txtMaSinhVien.Text;
            sv.TenSinhVien = txtTenSinhVien.Text;
            sv.GioiTinh = radioNam.Checked;
            sv.NamSinh = dtpNamSinh.Value;
            LopHoc lp = comboLopHoc.SelectedItem as LopHoc;
            sv.LopChuQuan = lp;
            selectedLop = lp;
            Khoa kh = comboKhoa.SelectedItem as Khoa;
            lp.KhoaChuQuan = kh;

            

            if (lp.sinhviens.ContainsKey(sv.MaSinhVien) == true) //Câu điều kiện kiểm tra xem mã sv có tồn tại hay chưa??
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại");
                return;
            }
            else
            {
                lp.sinhviens.Add(sv.MaSinhVien, sv);
                              
                MessageBox.Show("Bạn đã lưu thành công");
                HienThiThongTinSinhVienLenListView(lp);
               
            }
           
        }

        private void btnX0a_Click(object sender, EventArgs e)
        {
            // XÓA
           

            if (SelectecdSV==null)
            {
                MessageBox.Show("Bạn chưa chọn sinh viên");
                return;
            }
            if (SelectecdSV!=null)
            {
                DialogResult rit = MessageBox.Show("Bạn có Muốn Xóa sinh viên này?", "Question",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rit ==DialogResult.OK)
                {
                    LopHoc lp = SelectecdSV.LopChuQuan;
                    lp.sinhviens.Remove(SelectecdSV.MaSinhVien);
                    HienThiThongTinSinhVienLenListView(lp);
                }
            }
            
            

        }

        #region THOÁT CHƯƠNG TRÌNH
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn thoát không??", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region LƯU VÀ ĐỌC DỮU LIỆU
        private void mnuHeThongLuuDuLieu_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bool rt = FactoryFile.SaveFile(CSDL, saveDlg.FileName);
                    if (rt == true) { MessageBox.Show("Bạn đã lưu dữ liệu"); }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void mnuHeThongDocDuLieu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CSDL = FactoryFile.ReadFile(openDlg.FileName);
                    HienThiLenTreeView();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }
        #endregion
    }
}
