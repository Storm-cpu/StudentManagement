using StudentManagement.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class frmStudentMark : Form
    {
        public frmStudentMark()
        {
            InitializeComponent();
        }
        ConnectDB connect = new ConnectDB();
        private void frmStudentMark_Load(object sender, EventArgs e)
        {
            string studentID = AdminForm.studentID;
            if (studentID == null)
            {
                studentID = TeacherForm.studentID;
            }
            var load = from studentMark in connect.StudentMarks
                       where studentMark.studentID == studentID 
                       select new
                              {
                                  Course = studentMark.Course.courseName,
                                  Credits = studentMark.Course.credits,
                                  Score = studentMark.score,
                              };
            dgvScore.DataSource = load.ToList();
            dgvScore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var agvScoreUpdate = connect.StudentMarks.Where(x => x.studentID == studentID).ToList();
            int totalCredit = 0;
            float avgScore = 0;
            float number = 0;
            foreach (var item in agvScoreUpdate)
            {
                if (item.score != null)
                {
                    avgScore += float.Parse(item.score.ToString());
                    number++;
                    totalCredit += item.Course.credits.Value;
                }   
            }
            avgScore = avgScore / number;
            lblAvgScore.Text = string.Format("{0,6:##0.00}", avgScore.ToString());
            lblCredit.Text = totalCredit.ToString();
            var student = connect.Students.SingleOrDefault(x => x.studentID == studentID);   
            txtStudentID.Text = AdminForm.studentID;
            txtFullName.Text = student.fullName;
        }

        private void dgvScore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvScore.Rows[e.RowIndex];
            txtCourseName.Text = row.Cells[0].Value.ToString();
            if (row.Cells[2].Value != null)
            {
                txtScore.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var avgScoreUpdate = connect.StudentMarks.SingleOrDefault(x => x.studentID == txtStudentID.Text && x.Course.courseName == txtCourseName.Text);
            if (txtScore.Text == "")
            {
                avgScoreUpdate.score = null;
            }
            avgScoreUpdate.score = float.Parse(txtScore.Text);
            MessageBox.Show("Success");

            var studentAvgScore = connect.StudentMarks.Where(x => x.studentID == txtStudentID.Text).ToList();
            float avgScore = 0;
            float number = 0;
            foreach (var item in studentAvgScore)
            {
                if (item.score != null)
                {
                    avgScore += float.Parse(item.score.ToString());
                    number++;
                }
            }
            avgScore =  avgScore / number;
            avgScoreUpdate.Student.avgScore = avgScore;
            connect.SaveChanges();
            frmStudentMark_Load(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
