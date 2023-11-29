using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAmAMachine
{
    public partial class KichHoatForm : Form
    {
        DateTime now = DateTime.Now;
        string code;
        public KichHoatForm(string _code)
        {
            InitializeComponent();
            code = _code;
        }

        private void doiMatKhauBtn_Click(object sender, EventArgs e)
        {
            DateTime then = DateTime.Now;
            if (then.Subtract(now).Seconds > 600)
            {
                MessageBox.Show("Mã kích hoạt quá thời hạn.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (maKichHoatTxt.Text.Trim().Length == 0)
            {
                danhDauMa.BackColor = Color.Red;
                codeIssue.Text = "Chưa nhập mã.";
                return;
            }
            if (maKichHoatTxt.Text.Trim().Length == 0)
            {
                danhDauMK.BackColor = Color.Red;
                passIssue.Text = "Chưa nhập mật khẩu.";
                return;
            }
            if (maKichHoatTxt.Text.Trim() != code)
            {
                danhDauMa.BackColor = Color.Red;
                codeIssue.Text = "Sai mã kích hoạt.";
                return;
            }
            MessageBox.Show("Cập nhật mật khẩu thành công.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void xemMatKhauBtn_MouseHover(object sender, EventArgs e)
        {
            this.xemMatKhauBtn.Image = IAmAMachine.Properties.Resources.green_view;
            matKhauTxt.UseSystemPasswordChar = false;
        }
        private void xemMatKhauBtn_MouseLeave(object sender, EventArgs e)
        {
            this.xemMatKhauBtn.Image = IAmAMachine.Properties.Resources.green_hide;
            matKhauTxt.UseSystemPasswordChar = true;
        }
        private void maKichHoatTxt_Click(object sender, EventArgs e)
        {
            danhDauMa.BackColor = Color.Transparent;
        }
        private void matKhauTxt_Click(object sender, EventArgs e)
        {
            danhDauMK.BackColor = Color.Transparent;
        }
    }
}
