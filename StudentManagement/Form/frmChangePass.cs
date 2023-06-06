using StudentManagement.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
        }

        ConnectDB connect = new ConnectDB();

        private void btnOK_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string oldPassword = txtOldPass.Text;
            string newPassword = txtNewPass.Text;
            string confirm = txtConfirm.Text;

            if (username == "" || oldPassword == "" || newPassword == "" || confirm == "")
            {
                MessageBox.Show("Enter in all box!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Account account = connect.Accounts.SingleOrDefault(x => x.username == username);
                if (account == null)
                {
                    MessageBox.Show("Username or password is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (account.password != oldPassword)
                {
                    MessageBox.Show("Username or password is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (newPassword.Length < 8)
                {
                    MessageBox.Show("New password has at least 8 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!checkPass(newPassword))
                {
                    MessageBox.Show("New password must contains uppercase, lowercase, special characters and numeric values!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (newPassword != confirm)
                {
                    MessageBox.Show("New password does not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    account.password = newPassword;
                    connect.SaveChanges();
                    MessageBox.Show("Your password have been changed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool checkPass(string password) 
        {
            string regex = "^(?=.*[a-z])(?=."
                    + "*[A-Z])(?=.*\\d)"
                    + "(?=.*[-+_!@#$%^&*., ?]).+$";
            Regex check = new Regex(regex);
            Match result = check.Match(password);
            return result.Success;
        }
    }
}
