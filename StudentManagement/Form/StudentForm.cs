using StudentManagement.Models;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        ConnectDB connect = new ConnectDB();

        private void StudentForm_Load(object sender, EventArgs e)
        {
            var student = connect.Students.SingleOrDefault(x => x.studentID == Login.userID);
            if (student == null)
            {
                student = connect.Students.SingleOrDefault(x => x.studentID == TeacherForm.studentID);
                if (student == null)
                {
                    student = connect.Students.SingleOrDefault(x => x.studentID == FacultyForm.studentID);
                }
            }

            var load = from studentMark in connect.StudentMarks
                       where studentMark.studentID == student.studentID
                       select new
                       {
                           Course = studentMark.Course.courseName,
                           Credits = studentMark.Course.credits,
                           Score = studentMark.score,
                       };
            dgvScore.DataSource = load.ToList();
            dgvScore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (student != null)
            {
                lblStudentID.Text = student.studentID;
                lblStudentName.Text = student.fullName;
                lblGender.Text = student.gender;
                lblHomeTown.Text = student.homeTown;
                lblClass.Text = student.Class.className;
                lblFaculty.Text = student.Faculty.facultyName;
                lblAvgScore.Text = string.Format("{0,6:##0.00}", student.avgScore.ToString());
                lblBirday.Text = student.birthday.Value.Date.ToShortDateString();
                lblEmail.Text = student.email;
                var studentMarks = connect.StudentMarks.Where(x => x.studentID == student.studentID).ToList();
                int totalCredit = 0;
                foreach (var item in studentMarks)
                {
                    if (item.score != null)
                    {
                        totalCredit += item.Course.credits.Value;
                    }
                }
                lblTotalCredit.Text = totalCredit.ToString();

                if (student.image != null)
                {
                    picBox.Image = ByteArrayToImage(student.image);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
            Close();
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        } //Hàm chuyển mã byte thành hình ảnh

    }
}
