using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note
{
    public partial class SendFeedback : Form
    {
        public SendFeedback()
        {
            InitializeComponent();
        }

        private void SendFeedback_Load(object sender, EventArgs e)
        {
            checkPass.Checked = true;
        }

        #region Mask Passord
        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPass.Checked == false)
            {
                string a = txtPass.Text;
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }
        #endregion

        #region From Button Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region From Button Send
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(txtEmail.Text);
                mail.To.Add("Dsvk23020818@outlook.it");
                mail.Subject = txtSubject.Text;
                mail.Body = txtBody.Text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(txtEmail.Text, txtPass.Text);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                MessageBox.Show("Thank you for your Feedback");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
