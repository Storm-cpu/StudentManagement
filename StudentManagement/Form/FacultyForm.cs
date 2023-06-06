using StudentManagement.Function;
using StudentManagement.Models;
using System;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FacultyForm : Form
    {
        public FacultyForm()
        {
            InitializeComponent();
        }

        ConnectDB connect = new ConnectDB();
        TeacherFunc teacherFunc = new TeacherFunc();
        ClassFunc classFunc = new ClassFunc();
        StudentFunc studentFunc = new StudentFunc();

        private static string facultyID = Login.userID;
        public static string studentID;
        public static string teacherID;

        private void FacultyForm_Load(object sender, EventArgs e)
        {
            LoadStudent();
            LoadTeacher();
            LoadClass();
        }

        /*****************************************STUDENT FUNCTION*****************************************/
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvStudent.Rows[e.RowIndex];
            txtStudentID.Text = row.Cells[0].Value.ToString();
            txtStudentName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString() == "Nam")
            {
                rbntMale.Checked = true;
            }
            else
            {
                rbtnFemale.Checked = true;
            }
            dateTimePicker.Text = row.Cells[3].Value.ToString();
            txtHomeTown.Text = row.Cells[4].Value.ToString();
            if (row.Cells[5].Value == null)
            {
                cbbClass.Text = null;
            }
            else
            {
                cbbClass.Text = row.Cells[5].Value.ToString();
            }
            txtEmail.Text = row.Cells[7].Value.ToString();
            Student student = connect.Students.SingleOrDefault(x => x.studentID == txtStudentID.Text);
            if (student.image != null)
            {
                picBoxAvatar.Image = ByteArrayToImage(student.image);
            }
            else
            {
                picBoxAvatar.Image = null;
            }
        }

        private void dgvSubStudentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbClass.Text = dgvSubStudentTable.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dgvStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            studentID = txtStudentID.Text;
            frmStudentMark studentMark = new frmStudentMark();
            studentMark.Show();
        }

        private void picBoxAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                open.Filter = "(*.jpg;*.jpeg;*.bmp;*.png;*.jfif)| *.jpg; *.jpeg; *.bmp; *.png; *.jfif";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(open.FileName);
                }
            }
        }

        private void btnInsertStudent_Click(object sender, EventArgs e)
        {
            var studentID = txtStudentID.Text;
            var studentName = txtStudentName.Text;
            var gender = rbtnFemale.Checked == true ? "Nữ" : "Nam";
            var homeTown = txtHomeTown.Text;
            var email = txtEmail.Text;
            if (txtStudentID.Text == "" || txtStudentName.Text == "" || txtHomeTown.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Enter at least ID, NAME, HOME TOWN and EMAIL!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (picBoxAvatar.Image == null)
                {
                    studentFunc.Insert(studentID, studentName, gender, dateTimePicker, homeTown,
                    facultyID, cbbNullHandle(cbbClass), email, null);
                }
                else
                {
                    studentFunc.Insert(studentID, studentName, gender, dateTimePicker, homeTown,
                        facultyID, cbbNullHandle(cbbClass), email, ImageToByteArray(picBoxAvatar.Image));
                }
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "" || txtStudentName.Text == "" || txtHomeTown.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Enter at least ID, NAME, HOME TOWN and EMAIL!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var studentID = txtStudentID.Text;
                var studentName = txtStudentName.Text;
                var gender = rbtnFemale.Checked == true ? "Nữ" : "Nam";
                var homeTown = txtHomeTown.Text;
                var email = txtEmail.Text;
                if (picBoxAvatar.Image == null)
                {
                    studentFunc.Update(studentID, studentName, gender, dateTimePicker, homeTown,
                    facultyID, cbbNullHandle(cbbClass), email, null);
                }
                else
                {
                    studentFunc.Update(studentID, studentName, gender, dateTimePicker, homeTown,
                       facultyID, cbbNullHandle(cbbClass), email, ImageToByteArray(picBoxAvatar.Image));
                }
            }
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            string facultyName = connect.Faculties.SingleOrDefault(x => x.facultyID == facultyID).facultyName;
            var studentID = txtStudentID.Text;
            var studentName = txtStudentName.Text;
            var gender = rbtnFemale.Checked == true ? "Nữ" : "Nam";
            var homeTown = txtHomeTown.Text;
            var email = txtEmail.Text;
            studentFunc.Search(dgvStudent, studentID, studentName, gender, homeTown, facultyName, cbbClass.Text, email);
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            studentFunc.Delete(txtStudentID.Text);
        }

        /*****************************************TEACHER FUNCTION*****************************************/
        
       private void dgvTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTeacher.Rows[e.RowIndex];
            txtTeacherID.Text = row.Cells[0].Value.ToString();
            txtTeacherName.Text = row.Cells[1].Value.ToString();
            txtTeacherAddress.Text = row.Cells[2].Value.ToString();
            txtTeacherPhone.Text = row.Cells[3].Value.ToString();
            txtTeacherEmail.Text = row.Cells[4].Value.ToString();
        }

        private void dgvTeacher_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            teacherID = txtTeacherID.Text;
            TeacherForm teacherForm = new TeacherForm();
            teacherForm.Show();
        }

        private void btnTeacherInsert_Click(object sender, EventArgs e)
        {
            if (txtTeacherID.Text == "" || txtTeacherName.Text == "" || txtTeacherAddress.Text == "" || txtTeacherPhone.Text == "" || txtTeacherEmail.Text == "")
            {
                MessageBox.Show("Enter at least ID, Name, Address, Phone and Email!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!checkNumber(txtTeacherPhone.Text))
            {
                MessageBox.Show("Phone contain only number!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                teacherFunc.Insert(txtTeacherID.Text, txtTeacherName.Text,
                                   txtTeacherAddress.Text, txtTeacherPhone.Text,
                                   txtTeacherEmail.Text, facultyID);
            }
        }

        private void btnTeacherUpdate_Click(object sender, EventArgs e)
        {
            if (txtTeacherID.Text == "" || txtTeacherName.Text == "" || txtTeacherAddress.Text == "" || txtTeacherPhone.Text == "" || txtTeacherEmail.Text == "")
            {
                MessageBox.Show("Enter at least ID, Name, Address, Phone and Email!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!checkNumber(txtTeacherPhone.Text))
            {
                MessageBox.Show("!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                teacherFunc.Update(txtTeacherID.Text, txtTeacherName.Text,
                                   txtTeacherAddress.Text, txtTeacherPhone.Text,
                                   txtTeacherEmail.Text, facultyID);
            }
        }

        private void btnTeacherSearch_Click(object sender, EventArgs e)
        {
            string facultyName = connect.Faculties.SingleOrDefault(x => x.facultyID == facultyID).facultyName;
            teacherFunc.Search(dgvTeacher, txtTeacherID.Text, txtTeacherName.Text,
                txtTeacherAddress.Text, txtTeacherPhone.Text, txtTeacherEmail.Text, facultyName);
        }

        private void btnTeacherDelete_Click(object sender, EventArgs e)
        {
            teacherFunc.Delete(txtTeacherID.Text);
        }

        /*****************************************CLASS FUNCTION*****************************************/
        private void dgvClassSubTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbClassTeacher.Text = dgvClassSubTable.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvClass.Rows[e.RowIndex];
            txtClassID.Text = row.Cells[0].Value.ToString();
            txtClassName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value == null)
            {
                cbbClassTeacher.Text = "";
            }
            else
            {
                cbbClassTeacher.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnClassInsert_Click(object sender, EventArgs e)
        {
            if (txtClassID.Text == "" || txtClassName.Text == "")
            {
                MessageBox.Show("Enter at least ID and NAME!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                classFunc.Insert(txtClassID.Text, txtClassName.Text, cbbNullHandle(cbbClassTeacher), facultyID);
            }
        }

        private void btnClassUpdate_Click(object sender, EventArgs e)
        {
            if (txtClassID.Text == "" || txtClassName.Text == "")
            {
                MessageBox.Show("Enter at least ID and NAME!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                classFunc.Update(txtClassID.Text, txtClassName.Text, cbbNullHandle(cbbClassTeacher), facultyID);
            }
        }

        private void btnClassSearch_Click(object sender, EventArgs e)
        {
            classFunc.Search(dgvClass, txtClassID.Text, txtClassName.Text, cbbNullHandle(cbbClassTeacher), facultyID);
        }

        private void btnClassDelete_Click(object sender, EventArgs e)
        {
            classFunc.Delete(txtClassID.Text);
        }

        /*****************************************OTHER FUNCTION*****************************************/
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FacultyForm_Load(sender, e);
        }
        private void LoadStudent() {
            var loadStudent = from student in connect.Students
                              where student.facultyID == facultyID
                              select new
                              {
                                  StudentID = student.studentID,
                                  StudentName = student.fullName,
                                  Gender = student.gender,
                                  Birthday = student.birthday,
                                  HomeTown = student.homeTown,
                                  Class = student.Class.className,
                                  AvgScore = student.avgScore,
                                  Email = student.email,
                              };
            if (loadStudent == null)
            {
                dgvStudent.DataSource = null;
            }
            else
            {
                dgvStudent.DataSource = loadStudent.ToList();
            }
            

            var loadClass = from _class in connect.Classes
                               where _class.facultyID == facultyID
                               select new
                               {
                                   ClassID = _class.classID,
                                   ClassName = _class.className
                               };
            if (loadClass == null )
            {
                cbbClass.DataSource = null;
                dgvSubStudentTable.DataSource = null;
                cbbClass.Text = "";
            }
            else
            {
                cbbClass.DataSource = loadClass.ToList();
                dgvSubStudentTable.DataSource = loadClass.ToList();
                cbbClass.DisplayMember = "ClassName";
                cbbClass.ValueMember = "ClassID";
            }
            
            picBoxAvatar.Image = null;
            rbtnFemale.Checked = true;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyy-MM-dd";
        }
        private void LoadTeacher() {
            var loadTeacher = from teacher in connect.Teachers
                              where teacher.facultyID == facultyID
                              select new
                              {
                                  TeacherID = teacher.teacherID,
                                  FullName = teacher.fullName,
                                  Address = teacher.address,
                                  PhoneNumber = teacher.phoneNumber,
                                  Email = teacher.email,
                              };
            if (loadTeacher == null)
            {
                dgvTeacher.DataSource = null;
            }
            else
            {
                dgvTeacher.DataSource = loadTeacher.ToList();
            }
        }
        private void LoadClass() {
            var loadClass = from _class in connect.Classes
                            where _class.facultyID == facultyID
                            select new
                            {
                                ClassID = _class.classID,
                                ClassName = _class.className,
                                TeacherID = _class.teacherID,
                            };
            dgvClass.DataSource = loadClass.ToList();

            var loadTeacher = from teacher in connect.Teachers
                              where teacher.facultyID == facultyID
                              select new
                              {
                                  TeacherID = teacher.teacherID,
                                  FullName = teacher.fullName,
                              };
            if (loadTeacher == null)
            {
                dgvClassSubTable.DataSource = null;
                cbbClassTeacher.DataSource = null;
                cbbClass.Text = "";
            }
            else
            {
                cbbClassTeacher.DataSource = loadTeacher.ToList();
                dgvClassSubTable.DataSource = loadTeacher.ToList();
                cbbClassTeacher.DisplayMember = "TeacherID";
                cbbClassTeacher.ValueMember = "TeacherID";
            }

        }
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        } 
        private byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
        private string cbbNullHandle(ComboBox cbb)
        {
            if (cbb.Text == "")
            {
                return null;
            }
            else if (cbb.SelectedValue == null)
            {
                return cbb.Text;
            }
            {
                return cbb.SelectedValue.ToString();
            }
        }
        private bool checkNumber(string phoneNumber)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(phoneNumber);
        }
    }
}
