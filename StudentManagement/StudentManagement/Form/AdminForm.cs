using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using StudentManagement.Function;
using StudentManagement.Models;

namespace StudentManagement
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        ConnectDB connect = new ConnectDB();
        FacultyFunc facultyFunc = new FacultyFunc();
        TeacherFunc teacherFunc = new TeacherFunc();    
        ClassFunc classFunc = new ClassFunc();
        StudentFunc studentFunc = new StudentFunc();
        CourseFunc courseFunc = new CourseFunc();

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
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
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AdminForm_Load(sender, e);
        }

        /*****************************************LOAD*****************************************/
        private void AdminForm_Load(object sender, EventArgs e)
        {
            picBoxAvatar.Image = null;
            facultyFunc.LoadData(dgvFaculty);
            lbxCourse.DisplayMember = "CourseName";
            lbxCourse.ValueMember = "CourseID";
            teacherFunc.LoadData(dgvTeacher,cbbTeacherFaculty);
            classFunc.LoadData(dgvClass, cbbClassFaculty, cbbClassTeacher);
            studentFunc.LoadData(dgvStudent, cbbFaculty, cbbClass);
            rbtnFemale.Checked = true;
            courseFunc.LoadData(dgvCourse);
            lbxFaculty.DisplayMember = "FacultyName";
            lbxFaculty.ValueMember = "FacultyID";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyy-MM-dd";
            dgvSubStudentTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClassSubTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        /*****************************************STUDENT FUNCTION*****************************************/
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
                    cbbNullHandle(cbbFaculty), cbbNullHandle(cbbClass), email, null);
                }
                else {
                    studentFunc.Insert(studentID, studentName, gender, dateTimePicker, homeTown,
                        cbbNullHandle(cbbFaculty), cbbNullHandle(cbbClass), email, ImageToByteArray(picBoxAvatar.Image));
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
                    cbbNullHandle(cbbFaculty), cbbNullHandle(cbbClass), email, null);
                }
                else
                {
                    studentFunc.Update(studentID, studentName, gender, dateTimePicker, homeTown,
                        cbbNullHandle(cbbFaculty), cbbNullHandle(cbbClass), email, ImageToByteArray(picBoxAvatar.Image));
                }
            }
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            var studentID = txtStudentID.Text;
            var studentName = txtStudentName.Text;
            var gender = rbtnFemale.Checked == true ? "Nữ" : "Nam";
            var homeTown = txtHomeTown.Text;
            var email = txtEmail.Text;
            studentFunc.Search(dgvStudent,studentID, studentName, gender, homeTown, cbbFaculty.Text, cbbClass.Text, email);
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            studentFunc.Delete(txtStudentID.Text);
        }

        public static string studentID;
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
            if (row.Cells[5].Value == null && row.Cells[6].Value != null)
            {
                cbbFaculty.Text = "";
                cbbClass.Text = row.Cells[6].Value.ToString();
            }
            else if (row.Cells[6].Value == null && row.Cells[5].Value != null)
            {
                cbbFaculty.Text = row.Cells[5].Value.ToString();
                cbbClass.Text = "";
            }
            else if (row.Cells[5].Value == null && row.Cells[6].Value == null)
            {
                cbbFaculty.Text = "";
                cbbClass.Text = "";
            }
            else
            {
                cbbFaculty.Text = row.Cells[5].Value.ToString();
                cbbClass.Text = row.Cells[6].Value.ToString();
            }
            txtEmail.Text = row.Cells[8].Value.ToString();
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

        private void btnViewSubClass_Click(object sender, EventArgs e)
        {
            string getFacultyID = cbbFaculty.SelectedValue.ToString();
            var loadSubClass = from _class in connect.Classes
                               where _class.facultyID == getFacultyID
                                 select new
                                 {
                                     ClassName = _class.className,
                                 };
            dgvSubStudentTable.DataSource = loadSubClass.ToList();
        }

        private void btnViewSubFaculty_Click(object sender, EventArgs e)
        {
            var loadSubFaculty = from faculty in connect.Faculties
                                 select new
                                 {
                                     FacultyName = faculty.facultyName,
                                 };
            dgvSubStudentTable.DataSource = loadSubFaculty.ToList(); 
        }

        private void cbbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getFacultyID = cbbFaculty.SelectedValue.ToString();
            var loadCbbClass = from _class in connect.Classes
                               where _class.facultyID == getFacultyID
                                 select new
                                 {
                                     ClassID = _class.classID,
                                     ClassName = _class.className
                                 };
            if (loadCbbClass.Count() == 0)
            {
                cbbClass.DataSource = null;
                cbbClass.Text = "";
            }
            else
            {
                cbbClass.DataSource = loadCbbClass.ToList();
                cbbClass.DisplayMember = "ClassName";
                cbbClass.ValueMember = "ClassID";
            }
        }

        private void dgvSubStudentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSubStudentTable.Columns[0].HeaderText == "FacultyName")
            {
                cbbFaculty.Text = dgvSubStudentTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else
            {
                cbbClass.Text = dgvSubStudentTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        /*****************************************FACULTY FUNCTION*****************************************/

        public static List<string> listCourseID = new List<string>();

        private void btnFacultyInsert_Click(object sender, EventArgs e)
        {
            getListCourseID();
            if (txtFacultyID.Text == "" || txtFacultyName.Text == "" || listCourseID == null)
            {
                MessageBox.Show("Fill in all box!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                getListCourseID();
                facultyFunc.Insert(txtFacultyID.Text, txtFacultyName.Text, listCourseID);
            }
        }

        private void btnFacultyUpdate_Click(object sender, EventArgs e)
        {
            if (txtFacultyID.Text == "" || txtFacultyName.Text == "" || listCourseID == null)
            {
                MessageBox.Show("Fill in all box!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                getListCourseID();
                facultyFunc.Update(txtFacultyID.Text, txtFacultyName.Text, listCourseID); ;
            }
        }

        private void btnFacultySearch_Click(object sender, EventArgs e)
        {
            facultyFunc.Search(dgvFaculty, txtFacultyID.Text, txtFacultyName.Text);
        }

        private void btnFacultyDelete_Click(object sender, EventArgs e)
        {
            facultyFunc.Delete(txtFacultyID.Text);
        }

        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvFaculty.Rows[e.RowIndex];
            txtFacultyID.Text = row.Cells[0].Value.ToString();
            txtFacultyName.Text = row.Cells[1].Value.ToString();

            var load = from course in connect.FacultyCourses
                       where course.facultyID == txtFacultyID.Text
                       select new
                       {
                           CourseID = course.courseID,
                           CourseName = course.Course.courseName
                       };

            lbxCourse.Items.Clear();
            listCourseID.Clear();
            foreach (var item in load)
            {
                lbxCourse.Items.Add(item);
                listCourseID.Add(item.CourseID);
            }
        }

        private void getListCourseID()
        {
            listCourseID.Clear();
            foreach (var item in lbxCourse.Items)
            {
                string courseName = lbxCourse.GetItemText(item);
                var course = connect.Courses.FirstOrDefault(x => x.courseName == courseName);
                listCourseID.Add(course.courseID);
            }
        } //Hàm cập nhật mã khóa học từ listbox

        private void btnSelectCourse_Click(object sender, EventArgs e)
        {
            frmSelectCourse frmSelectCourse = new frmSelectCourse();
            listCourseID.Clear();
            if (lbxCourse.Items != null)
            {
                foreach (var item in lbxCourse.Items)
                {
                    string courseName = lbxCourse.GetItemText(item);
                    frmSelectCourse.SelectedCourse.Add(courseName);
                    var course = connect.Courses.FirstOrDefault(x => x.courseName == courseName);
                    listCourseID.Add(course.courseID);
                }
            }
            lbxCourse.Items.Clear();
            if (frmSelectCourse.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in frmSelectCourse.SelectedCourse)
                {
                    Course selectedItem = connect.Courses.FirstOrDefault(x => x.courseName == item);
                    lbxCourse.Items.Add(item);
                }
            }
        }

        /*****************************************TEACHER FUNCTION*****************************************/
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
                                   txtTeacherEmail.Text, cbbNullHandle(cbbTeacherFaculty));
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
                                   txtTeacherEmail.Text, cbbNullHandle(cbbTeacherFaculty));
            }
        }

        private void btnTeacherSearch_Click(object sender, EventArgs e)
        {
            teacherFunc.Search(dgvTeacher, txtTeacherID.Text, txtTeacherName.Text,
                txtTeacherAddress.Text, txtTeacherPhone.Text, txtTeacherEmail.Text, cbbTeacherFaculty.Text);
        }

        private void btnTeacherDelete_Click(object sender, EventArgs e)
        {
            teacherFunc.Delete(txtTeacherID.Text);
            AdminForm_Load(sender, e);
        }

        private void dgvTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTeacher.Rows[e.RowIndex];
            txtTeacherID.Text = row.Cells[0].Value.ToString();
            txtTeacherName.Text = row.Cells[1].Value.ToString();
            txtTeacherAddress.Text = row.Cells[2].Value.ToString();
            txtTeacherPhone.Text = row.Cells[3].Value.ToString();
            txtTeacherEmail.Text = row.Cells[4].Value.ToString();
            if (row.Cells[5].Value == null)
            {
                cbbTeacherFaculty.Text = "";
            }
            else
            {
                cbbTeacherFaculty.Text = row.Cells[5].Value.ToString();
            }
        }

        /*****************************************CLASS FUNCTION*****************************************/
        private void btnViewTeacherList_Click(object sender, EventArgs e)
        {
            string getFacultyID = cbbClassFaculty.SelectedValue.ToString();
            var loadSubTeacher = from teacher in connect.Teachers
                                 where teacher.facultyID == getFacultyID
                                 select new
                                 {
                                     TeacherID = teacher.teacherID,
                                     FullName = teacher.fullName,
                                 };
            dgvClassSubTable.DataSource = loadSubTeacher.ToList();
        }

        private void btnViewFacultyList_Click(object sender, EventArgs e)
        {
            var loadSubFaculty = from faculty in connect.Faculties
                                 select new
                                 {
                                     FacultyID = faculty.facultyID,
                                     FacultyName = faculty.facultyName,
                                 };
            dgvClassSubTable.DataSource = loadSubFaculty.ToList();
        }

        private void txtClassSubTableSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgvClassSubTable.Columns[0].HeaderText == "FacultyID")
            {
                var search = from faculty in connect.Faculties
                             where faculty.facultyID.Contains(txtClassSubTableSearch.Text) || faculty.facultyName.Contains(txtClassSubTableSearch.Text)
                             select new
                             {
                                 FacultyID = faculty.facultyID,
                                 FacultyName = faculty.facultyName,
                             };
                dgvClassSubTable.DataSource = search.ToList();
            }
            else
            {
                var search = from teacher in connect.Teachers
                             where teacher.teacherID.Contains(txtClassSubTableSearch.Text) || teacher.fullName.Contains(txtClassSubTableSearch.Text)
                             select new
                             {
                                 TeacherID = teacher.teacherID,
                                 FullName = teacher.fullName,
                             };
                dgvClassSubTable.DataSource = search.ToList();
            }
        }

        private void dgvSubTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClassSubTable.Columns[0].HeaderText == "FacultyID")
            {
                cbbClassFaculty.Text = dgvClassSubTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else
            {
                cbbClassTeacher.Text = dgvClassSubTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnClassInsert_Click(object sender, EventArgs e)
        {
            if(txtClassID.Text == "" || txtClassName.Text == "")
            {
                MessageBox.Show("Enter at least ID and NAME!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                classFunc.Insert(txtClassID.Text, txtClassName.Text, cbbNullHandle(cbbClassTeacher), cbbNullHandle(cbbClassFaculty));
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
                classFunc.Update(txtClassID.Text, txtClassName.Text, cbbNullHandle(cbbClassTeacher), cbbNullHandle(cbbClassFaculty));
            }
        }

        private void btnClassSearch_Click(object sender, EventArgs e)
        {
            classFunc.Search(dgvClass, txtClassID.Text, txtClassName.Text, cbbNullHandle(cbbClassTeacher), cbbNullHandle(cbbClassFaculty));
        }

        private void btnClassDelete_Click(object sender, EventArgs e)
        {
            classFunc.Delete(txtClassID.Text);
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
            if (row.Cells[3].Value == null) {
                cbbClassFaculty.Text = "";
            }
            else
            {
                cbbClassFaculty.Text = row.Cells[3].Value.ToString();
            }
        }

        private void cbbClassFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getFacultyID = cbbClassFaculty.SelectedValue.ToString();
            var loadCbbClass = from teacher in connect.Teachers
                               where teacher.facultyID == getFacultyID
                               select new
                               {
                                   TeacherID = teacher.teacherID,
                                   FullName = teacher.fullName
                               };
            if (loadCbbClass.Count() == 0)
            {
                cbbClassTeacher.DataSource = null;
                cbbClassTeacher.Text = "";
            }
            else
            {
                cbbClassTeacher.DataSource = loadCbbClass.ToList();
                cbbClassTeacher.DisplayMember = "TeacherID";
                cbbClassTeacher.ValueMember = "TeacherID";
            }
        }

        /*****************************************COURSE FUNCTION*****************************************/
        public static List<string> listFacultyID = new List<string>();

        private void getListFacultyID() {
            listFacultyID.Clear();
            foreach (var item in lbxFaculty.Items)
            {
                string facultyName = lbxFaculty.GetItemText(item);
                var faculty = connect.Faculties.SingleOrDefault(x => x.facultyName == facultyName);
                listFacultyID.Add(faculty.facultyID);
            }
        } //Lấy mã khoa từ listbox

        private void dgvCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCourse.Rows[e.RowIndex];
            txtCourseID.Text = row.Cells[0].Value.ToString();
            txtCourseName.Text = row.Cells[1].Value.ToString();
            txtCredits.Text = row.Cells[2].Value.ToString();

            var load = from course in connect.FacultyCourses
                       where course.courseID == txtCourseID.Text
                            select new
                            {
                                FacultyID = course.facultyID,
                                FacultyName = course.Faculty.facultyName
                            };

            lbxFaculty.Items.Clear();
            listFacultyID.Clear();
            foreach (var item in load)
            {
                lbxFaculty.Items.Add(item);
                listFacultyID.Add(item.FacultyID);
            }

        }

        private void btnSelectFaculty_Click(object sender, EventArgs e)
        {
            frmSelectFaculty frmSelectFaculty = new frmSelectFaculty();
            listFacultyID.Clear();
            if (lbxFaculty.Items != null)
            {
                foreach (var item in lbxFaculty.Items)
                {
                    string facultyName = lbxFaculty.GetItemText(item);
                    frmSelectFaculty.SelectedFaculty.Add(facultyName);
                    var faculty = connect.Faculties.FirstOrDefault(x => x.facultyName == facultyName);
                    listFacultyID.Add(faculty.facultyID);
                }
            }
            lbxFaculty.Items.Clear();
            if (frmSelectFaculty.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in frmSelectFaculty.SelectedFaculty)
                {
                    Faculty selectedItem = connect.Faculties.FirstOrDefault(x => x.facultyName == item);
                    lbxFaculty.Items.Add(item);
                }
            }
        }

        private void btnCourseInsert_Click(object sender, EventArgs e)
        {
            getListFacultyID();
            if (txtCourseID.Text == "" || txtCourseName.Text == "" || txtCredits.Text == "")
            {
                MessageBox.Show("Fill in all box!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                courseFunc.Insert(txtCourseID.Text, txtCourseName.Text, txtCredits.Text, listFacultyID);
            }
        }

        private void btnCourseUpdate_Click(object sender, EventArgs e)
        {
            getListFacultyID();
            if (txtCourseID.Text == "" || txtCourseName.Text == "" || txtCredits.Text == "" || listFacultyID == null)
            {
                MessageBox.Show("Fill in all box!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                courseFunc.Update(txtCourseID.Text, txtCourseName.Text, txtCredits.Text, listFacultyID);
            }
            
        }

        private void btnCourseSearch_Click(object sender, EventArgs e)
        {
            courseFunc.Search(dgvCourse, txtCourseID.Text, txtCourseName.Text, txtCredits.Text);
        }

        private void btnCourseDelete_Click(object sender, EventArgs e)
        {
            courseFunc.Delete(txtCourseID.Text);
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
        } //Kiểm tra null và trả về value từ ComboBox
        private bool checkNumber(string phoneNumber)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(phoneNumber);
        } //Hàm kiểm tra chuỗi chứa toàn chữ số
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        } //Hàm chuyển mã byte thành hình ảnh
        private byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        } //Hàm chuyển hình ảnh thành mã byte
    }
}
