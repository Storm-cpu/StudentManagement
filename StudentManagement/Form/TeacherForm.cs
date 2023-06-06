using StudentManagement.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        ConnectDB connect = new ConnectDB();
        public static string studentID;

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            var teacher = connect.Teachers.SingleOrDefault(x => x.teacherID == Login.userID);
            if (teacher == null)
            {
                teacher = connect.Teachers.SingleOrDefault(x => x.teacherID == FacultyForm.teacherID);
            }
            var loadClass = from _class in connect.Classes
                       where _class.teacherID == teacher.teacherID
                       select new
                       {
                           ClassID = _class.classID,
                           ClassName = _class.className
                       };
            if (loadClass != null)
            {
                dgvClass.DataSource = loadClass.ToList();
                cbbClass.DataSource = loadClass.ToList();
                cbbClass.DisplayMember = "ClassName";
                cbbClass.ValueMember = "ClassID";
            }
          
            lblTeacherName.Text = teacher.fullName;
            lblTeacherID.Text = teacher.teacherID;
            lblEmail.Text = teacher.email;
            lblPhone.Text = teacher.phoneNumber;
            lblFaculty.Text = teacher.Faculty.facultyName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Logout?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
            }
        }

        private void btnViewStudent_Click(object sender, EventArgs e)
        {
            LoadDgvStudent();
        }

        private void LoadDgvStudent() {
            if (cbbClass.SelectedValue != null)
            {
                string classID = cbbClass.SelectedValue.ToString();
                var loadStudent = from student in connect.Students
                                  where student.classID == classID
                                  select new
                                  {
                                      StudentID = student.studentID,
                                      StudentName = student.fullName,
                                      Gender = student.gender,
                                      Birthday = student.birthday,
                                      HomeTown = student.homeTown,
                                      Faculty = student.Faculty.facultyName,
                                      Class = student.Class.className,
                                      AvgScore = student.avgScore,
                                      Email = student.email,
                                  };
                dgvStudent.DataSource = loadStudent.ToList();
            }     
        }

        private void dgvStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvStudent.Rows[e.RowIndex];
            studentID = row.Cells[0].Value.ToString();
            StudentForm studentForm = new StudentForm();
            studentForm.Show();
        }
    }
}
