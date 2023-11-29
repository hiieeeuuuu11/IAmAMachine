using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IAmAMachine.QuanLyCacDanhMuc;
using IAmAMachine.ThongKe;
using IAmAMachine.ThongTinCuaHang;
using IAmAMachine.UserControls;
using IAmAMachine.UserControlsOfQuanLyKho;
using IAmAMachine.UserControlsOfQuanLyThuocBan;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IAmAMachine
{
    public partial class TrangChuForm : Form
    {
        UserControl quanLyLoaiThuocUserControl = new QuanLyLoaiThuocUserControl();
        UserControl quanLyNhanVienUserControl = new QuanLyNhanVienUserControl();
        UserControl quanLyKhachHangUserControl = new QuanLyKhachHangUserControl();

        UserControl nhapThuocVaoKhoUserControl = new NhapThuocVaoKhoUserControl();
        UserControl quanLyHanSuDungUserControl = new QuanLyHanSuDungUserControl();
        UserControl quanLyHoaDonNhapUserControl = new QuanLyHoaDonNhapUserControl();

        UserControl inHoaDonBanUserControl = new InHoaDonBanUserControl();
        UserControl quanLyHoaDonBanUserControl = new QuanLyHoaDonBanUserControl();

        UserControl thongKeLoiNhuanUserControl = new ThongKeLoiNhuanUserControl();
        UserControl xepHangNhanVienUserControl = new XepHangNhanVienUserControl();

        UserControl lichSuHoatDongUserControl = new LichSuHoatDongUserControl();

        UserControl hoSoNhanVienUserControl = new HoSoNhanVienUserControl();

        UserControl thongTinCuaHangUserControl = new ThongTinCuaHangUserControl();

        System.Windows.Forms.Button prevBtn = new System.Windows.Forms.Button();
        public int CloseType { get; set; }
        public TrangChuForm(int auth)
        {
            InitializeComponent();
            //MessageBox.Show(this.ClientSize.Width + " " + this.ClientSize.Height);
            this.CloseType = 0;
            this.CenterToScreen();
            danhMucTransition.Start();
            quanLyKhoTransition.Start();
            quanLyThuocBanTransition.Start();
            thongKeTransition.Start();

            this.Controls.Add(quanLyLoaiThuocUserControl);
            this.Controls.Add(quanLyNhanVienUserControl);
            this.Controls.Add(quanLyKhachHangUserControl);

            this.Controls.Add(nhapThuocVaoKhoUserControl);
            this.Controls.Add(quanLyHanSuDungUserControl);
            this.Controls.Add(quanLyHoaDonNhapUserControl);

            this.Controls.Add(inHoaDonBanUserControl);
            this.Controls.Add(quanLyHoaDonBanUserControl);

            this.Controls.Add(thongKeLoiNhuanUserControl);
            this.Controls.Add(xepHangNhanVienUserControl);

            this.Controls.Add(lichSuHoatDongUserControl);
            
            this.Controls.Add(hoSoNhanVienUserControl);

            this.Controls.Add(thongTinCuaHangUserControl);
            //foreach (var button in Controls.OfType<Button>()) { }
        }

        private void TrangChuForm_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
        }
        private void TrangChuForm_Resize(object sender, EventArgs e)
        {
            quanLyLoaiThuocUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);
            quanLyNhanVienUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);
            quanLyKhachHangUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);

            nhapThuocVaoKhoUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);
            quanLyHanSuDungUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);
            quanLyHoaDonNhapUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);

            inHoaDonBanUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);
            quanLyHoaDonBanUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);

            thongKeLoiNhuanUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);

            xepHangNhanVienUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);

            lichSuHoatDongUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);

            hoSoNhanVienUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);

            thongTinCuaHangUserControl.Size = new Size(this.ClientSize.Width - 300, this.ClientSize.Height);
        }

        private void danhMucBtn_Click(object sender, EventArgs e)
        {
            prevBtn.Font = new Font(prevBtn.Font, FontStyle.Regular);
            danhMucBtn.Font = new Font(danhMucBtn.Font, FontStyle.Bold);
            prevBtn = danhMucBtn;
            danhMucTransition.Start();

        }
        bool danhMucExpand = false;
        private void danhMucExpand_Tick(object sender, EventArgs e)
        {
            if (!danhMucExpand)
            {
                danhMucPanel.Height -= 10;
                if(danhMucPanel.Height <= 50)
                {
                    danhMucExpand = true;
                    danhMucTransition.Stop();
                }
            }
            else
            {
                danhMucPanel.Height += 10;
                if(danhMucPanel.Height >= 3*40 + 50)
                {
                    danhMucExpand = false;
                    danhMucTransition.Stop();
                }
            }
        }
        private void quanLyThuocBanBtn_Click(object sender, EventArgs e)
        {
            prevBtn.Font = new Font(prevBtn.Font, FontStyle.Regular);
            quanLyThuocBanBtn.Font = new Font(quanLyThuocBanBtn.Font, FontStyle.Bold);
            prevBtn = quanLyThuocBanBtn;
            quanLyThuocBanTransition.Start();
        }
        bool quanLyThuocBanExpand = false;
        private void quanLyThuocBanTransition_Tick(object sender, EventArgs e)
        {
            if (!quanLyThuocBanExpand)
            {
                quanLyThuocBanPanel.Height -= 10;
                if (quanLyThuocBanPanel.Height <= 50)
                {
                    quanLyThuocBanExpand = true;
                    quanLyThuocBanTransition.Stop();
                }
            }
            else
            {
                quanLyThuocBanPanel.Height += 10;
                if (quanLyThuocBanPanel.Height >= 2 * 40 + 50)
                {
                    quanLyThuocBanExpand = false;
                    quanLyThuocBanTransition.Stop();
                }
            }
        }
        private void quanLyKhoBtn_Click(object sender, EventArgs e)
        {
            prevBtn.Font = new Font(prevBtn.Font, FontStyle.Regular);
            quanLyKhoBtn.Font = new Font(quanLyKhoBtn.Font, FontStyle.Bold);
            prevBtn = quanLyKhoBtn;
            quanLyKhoTransition.Start();
        }
        bool quanLyKhoExpand = false;
        private void quanLyKhoTransition_Tick(object sender, EventArgs e)
        {
            if (!quanLyKhoExpand)
            {
                quanLyKhoPanel.Height -= 10;
                if (quanLyKhoPanel.Height <= 50)
                {
                    quanLyKhoExpand = true;
                    quanLyKhoTransition.Stop();
                }
            }
            else
            {
                quanLyKhoPanel.Height += 10;
                if (quanLyKhoPanel.Height >= 3 * 40 + 50)
                {
                    quanLyKhoExpand = false;
                    quanLyKhoTransition.Stop();
                }
            }
        }

        private void thongKeBtn_Click(object sender, EventArgs e)
        {
            prevBtn.Font = new Font(prevBtn.Font, FontStyle.Regular);
            thongKeBtn.Font = new Font(thongKeBtn.Font, FontStyle.Bold);
            prevBtn = thongKeBtn;
            thongKeTransition.Start();
        }
        bool thongKeExpand = false;
        private void thongKeTransition_Tick(object sender, EventArgs e)
        {
            if (!thongKeExpand)
            {
               thongKePanel.Height -= 10;
                if (thongKePanel.Height <= 50)
                {
                    thongKeExpand = true;
                    thongKeTransition.Stop();
                }
            }
            else
            {
                thongKePanel.Height += 10;
                if (thongKePanel.Height >= 2 * 40 + 50)
                {
                    thongKeExpand = false;
                    thongKeTransition.Stop();
                }
            }
        }
        private void quanLyLoaiThuocBtn_Click(object sender, EventArgs e)
        {
            quanLyLoaiThuocUserControl.BringToFront();
        }
        private void quanLyNhanVienBtn_Click(object sender, EventArgs e)
        {
            quanLyNhanVienUserControl.BringToFront();
        }
        private void quanLyKhachHangBtn_Click(object sender, EventArgs e)
        {
            quanLyKhachHangUserControl.BringToFront();
        }
        private void quanLyHoaDonBanBtn_Click(object sender, EventArgs e)
        {
            quanLyHoaDonBanUserControl.BringToFront();
        }

        private void inHoaDonThuocBtn_Click(object sender, EventArgs e)
        {
            inHoaDonBanUserControl.BringToFront();
        }

        private void quanLyHoaDonNhapBtn_Click(object sender, EventArgs e)
        {
            quanLyHoaDonNhapUserControl.BringToFront();
        }

        private void nhapThuocVaoKhoBtn_Click(object sender, EventArgs e)
        {
            nhapThuocVaoKhoUserControl.BringToFront();
        }

        private void quanLyHanSuDungBtn_Click(object sender, EventArgs e)
        {
            quanLyHanSuDungUserControl.BringToFront();
        }

        private void xepHangNhanVienBtn_Click(object sender, EventArgs e)
        {
            xepHangNhanVienUserControl.BringToFront();
        }

        private void thongKeLoiNhuanBtn_Click(object sender, EventArgs e)
        {
            thongKeLoiNhuanUserControl.BringToFront();
        }

        private void lichSuHoatDongBtn_Click(object sender, EventArgs e)
        {
            prevBtn.Font = new Font(prevBtn.Font, FontStyle.Regular);
            lichSuHoatDongBtn.Font = new Font(lichSuHoatDongBtn.Font, FontStyle.Bold);
            prevBtn = lichSuHoatDongBtn;
            lichSuHoatDongUserControl.BringToFront();
        }

        private void hoSoBtn_Click(object sender, EventArgs e)
        {
            prevBtn.Font = new Font(prevBtn.Font, FontStyle.Regular);
            hoSoBtn.Font = new Font(hoSoBtn.Font, FontStyle.Bold);
            prevBtn = hoSoBtn;
            hoSoNhanVienUserControl.BringToFront();
        }

        private void thongTinCuaHangBtn_Click(object sender, EventArgs e)
        {
            prevBtn.Font = new Font(prevBtn.Font, FontStyle.Regular);
            thongTinCuaHangBtn.Font = new Font(thongTinCuaHangBtn.Font, FontStyle.Bold);
            prevBtn = thongTinCuaHangBtn;
            thongTinCuaHangUserControl.BringToFront();
        }
        private void dangXuatBtn_Click(object sender, EventArgs e)
        {
            this.CloseType = 1;
            this.Close();
        }


    }
}
