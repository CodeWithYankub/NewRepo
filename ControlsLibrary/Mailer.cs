using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ControlsLibrary
{
    class Mailer
    {
        private string Sender { get
            {
                return "schoolmanagementsystem13@gmail.com";
            }
        }

        public bool Send(string receiver, string name, int code)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(Sender);
                message.To.Add(new MailAddress(receiver));
                message.Subject = "SLMB School Management System Password Reset";
                message.IsBodyHtml = true;
                message.Body = ResetPasswordHTML(name, code);
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Sender, "school@123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

                return true;
            }catch(Exception ex)
            {
                App.Error = ex.Message;
                return false;
            }
        }

        private string ResetPasswordHTML(string name, int code)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<html><head><title>Mail From SLMB School Management System</title></head><body>");
            sb.Append(string.Format("<p><strong>Dear {0},</strong></p>", name.ToUpper()));
            sb.Append(string.Format("<p>We received a password reset request for your account at the <em>SLMB School Management System</em>. We have reset your password to <strong><em>{0}</em></strong>. <br /> Use this password to login and do not forget to reset it after you log in.</p>", code));
            sb.Append("<p>Best regards, <br /><small><strong>SLMB School Management System</strong></small></p>");

            return sb.ToString();
        }
    }
}
