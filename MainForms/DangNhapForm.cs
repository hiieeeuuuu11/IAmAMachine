using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Diagnostics.Eventing.Reader;

namespace IAmAMachine
{
    public partial class DangNhapForm : Form
    {
        public DangNhapForm()
        {
            InitializeComponent();
            this.ActiveControl = null;
            this.CenterToScreen(); 
        }

        private void tenDangNhapTxt_Click(object sender, EventArgs e)
        {
            danhDauEmail.BackColor = Color.Transparent;
            accIssue.Text = "";
        }

        private void matKhauTxt_Click(object sender, EventArgs e)
        {
            danhDauMK.BackColor = Color.Transparent;
            passIssue.Text = "";
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

        private void Login(int auth)
        {
            this.Hide();
            var mainForm = new TrangChuForm(auth);
            mainForm.Closed += delegate (object s, EventArgs e)
            {
                if (mainForm.CloseType == 0)
                {
                    this.Close();
                }
                else
                {
                    this.CenterToScreen();
                    this.Show();
                };
            };
            
            mainForm.Show();
        }
        private void dangNhapBtn_Click(object sender, EventArgs e)
        {
            Login(1);
            const string headAdminAcc = "admin@gmail.com";
            const string headAdminPass = "admintag000";
            const string testUserAcc = "user@gmail.com";
            const string testUserPass = "usertag000"; /*-----Cập nhật vào CSDL-----*/
            string acc = tenDangNhapTxt.Text;
            string pass = matKhauTxt.Text;
            if (acc.Trim().Length == 0)
            {
                danhDauEmail.BackColor = Color.Red;
                accIssue.Text = "Chưa nhập Email.";
                return;
            }
            if (pass.Trim().Length == 0)
            {
                danhDauMK.BackColor = Color.Red;
                passIssue.Text = "Chưa nhập mật khẩu.";
                return;
            }
           
            if (acc.Trim().ToLower() == headAdminAcc && MD5En.MD5Hash(pass) == MD5En.MD5Hash(headAdminPass))
            {
                this.Login(2);
                return;
            }
            else if (acc.Trim().ToLower() == testUserAcc && MD5En.MD5Hash(pass) == MD5En.MD5Hash(testUserPass))
            {
                this.Login(1);
                return;
            }
            /*-------*/
            string dbAcc = ""; /*-----Lấy email trong csdl-----*/
            string dbMD5Pass = ""; /*-----Lấy mật khẩu đã được hash trong csdl-----*/
            int auth = 0; /*-----Lất quyền người dùng trong csdl-----*/
            if (dbAcc == "")
            {
                danhDauEmail.BackColor = Color.Red;
                accIssue.Text = "Không tìm thấy tài khoản.";
                return;
            }
            if (auth == 0)
            {
                danhDauEmail.BackColor = Color.Red;
                accIssue.Text = "Tài khoản chưa được kích hoạt bởi chủ cửa hàng.";
                return;
            }
            if (MD5En.MD5Hash(pass) == dbMD5Pass)
            {
                this.Login(auth);
            }
            else
            {
                danhDauMK.BackColor = Color.Red;
                passIssue.Text = "Mật khẩu không chính xác.";
                return;
            }
        }
        private void quenMatKhauBtn_Click(object sender, EventArgs e)
        {
            if (tenDangNhapTxt.Text.Trim().Length == 0)
            {
                danhDauEmail.BackColor = Color.Red;
                accIssue.Text = "Chưa nhập email.";
                return;
            }
            if (false) /*-----Kiểm tra xem email có tồn tại không-----*/
            {
                danhDauEmail.BackColor = Color.Red;
                accIssue.Text = "Không tìm thấy tài khoản.";
                return;
            }
            SecureRandom sr = new SecureRandom();
            string email = tenDangNhapTxt.Text.Trim().ToLower();
            string code = sr.Next(1000000, 9999999).ToString();
            SMTP.SendTo(email, "Thay đổi mật khẩu vào ứng dụng quản lý BFR", "Mã kích hoạt của bạn là: " + code + ".\nMã kích hoạt sẽ hết hạn trong 10 phút.");
            Form kichHoat = new KichHoatForm(code);
            kichHoat.ShowDialog();
        }

    }
}

