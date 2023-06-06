using StudentManagement.Models;
using System;
using System.Linq;
using System.Windows.Forms;
namespace StudentManagement
//#47B5FF
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        ConnectDB connect = new ConnectDB();

        public static string userID;
        public void SelectData(string userInsert, string passInsert) {
            Account account = connect.Accounts.SingleOrDefault(item => item.password == passInsert && item.username == userInsert);//Lấy dữ liệu các account
            if (cbbLoginAs.SelectedIndex == 0)
            {
                if (account != null && userInsert == "Admin")
                {
                    Hide();
                    AdminForm adminform = new AdminForm();
                    adminform.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Username or password is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (cbbLoginAs.SelectedIndex == 1)
            {
                Faculty faculty = connect.Faculties.SingleOrDefault(item => item.facultyID == userInsert);
                if (account != null && faculty != null)
                {
                    if (checkFirstLogin(account.username, account.password))
                    {
                        frmChangePass changePass = new frmChangePass();
                        changePass.ShowDialog();
                        if (changePass.DialogResult == DialogResult.OK)
                        {
                            userID = userInsert;
                            Hide();
                            FacultyForm facultyForm = new FacultyForm();
                            facultyForm.Text = faculty.facultyName;
                            facultyForm.ShowDialog();
                            Close();
                        }
                    }
                    else
                    {
                        userID = userInsert;
                        Hide();
                        FacultyForm facultyForm = new FacultyForm();
                        facultyForm.Text = faculty.facultyName;
                        facultyForm.ShowDialog();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Username or password is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (cbbLoginAs.SelectedIndex == 2)
            {
                Teacher teacher = connect.Teachers.SingleOrDefault(item => item.teacherID == userInsert);
                if (account != null && teacher != null)
                {
                    if (checkFirstLogin(account.username, account.password))
                    {
                        frmChangePass changePass = new frmChangePass();
                        changePass.ShowDialog();
                        if (changePass.DialogResult == DialogResult.OK)
                        {
                            userID = userInsert;
                            Hide();
                            TeacherForm teacherForm = new TeacherForm();
                            teacherForm.ShowDialog();
                            Close();
                        }
                    }
                    else
                    {
                        userID = userInsert;
                        Hide();
                        TeacherForm teacherForm = new TeacherForm();
                        teacherForm.ShowDialog();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Username or password is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(cbbLoginAs.SelectedIndex == 3)
            {
                Student student = connect.Students.SingleOrDefault(item => item.studentID == userInsert);
                if (account != null && student != null)
                {
                    if (checkFirstLogin(account.username, account.password))
                    {
                        frmChangePass changePass = new frmChangePass();
                        changePass.ShowDialog();
                        if (changePass.DialogResult == DialogResult.OK)
                        {
                            userID = userInsert;
                            Hide();
                            StudentForm studentForm = new StudentForm();
                            studentForm.ShowDialog();
                            Close();
                        }
                    }
                    else
                    {
                        userID = userInsert;
                        Hide();
                        StudentForm studentForm = new StudentForm();
                        studentForm.ShowDialog();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Username or password is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length < 3 || txtPassword.Text.Length < 3)
                MessageBox.Show("Username or password is invalid or too short!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SelectData(txtUsername.Text, txtPassword.Text);
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePass changePass = new frmChangePass();
            changePass.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cbbLoginAs.SelectedIndex = 0;
        }

        private void lblShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == false)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            
        }

        private bool checkFirstLogin(string userInsert, string passInsert)
        {
            if (userInsert == passInsert)
            {
                MessageBox.Show("You must change password at the first time login!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }
    }
}
