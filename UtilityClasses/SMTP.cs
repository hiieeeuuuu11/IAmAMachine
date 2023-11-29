using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAmAMachine
{
    internal class SMTP //Host: Quangduy162003@gmail.com
    {
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void SendTo(string desEmail, string subject, string body)
        {
            NetworkCredential login = new NetworkCredential("quangduy162003@gmail.com", "ymzq ztfr jpll ukqb");
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = login;
            MailMessage msg = new MailMessage { From = new MailAddress("quangduy162003@gmail.com", "Quang Duy", Encoding.UTF8) };
            try
            {
                msg.To.Add(new MailAddress(desEmail));
            }
            catch 
            {
                MessageBox.Show("Error sending message.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            msg.Subject = subject;
            msg.Body = body;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "Sending...";
            try
            {
                client.SendAsync(msg, userstate);
            }
            catch
            {
                MessageBox.Show("Error sending message.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
