using StudentManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement.Function
{
    internal class ClassFunc
    {
        ConnectDB connect = new ConnectDB();

        public void LoadData(DataGridView dgv, ComboBox cbbFaculty, ComboBox cbbTeacher)
        {
            var loadClass = from _class in connect.Classes
                            select new
                            {
                                ClassID = _class.classID,
                                ClassName = _class.className,
                                TeacherID = _class.teacherID,
                                Faculty = _class.Faculty.facultyName,
                            };
            dgv.DataSource = loadClass.ToList();

            var loadCbbFaculty = from faculty in connect.Faculties
                                 select new
                                 {
                                     FacyltyID = faculty.facultyID,
                                     FacultyName = faculty.facultyName
                                 };
            cbbFaculty.DataSource = loadCbbFaculty.ToList();
            cbbFaculty.DisplayMember = "FacultyName";
            cbbFaculty.ValueMember = "FacyltyID";

            string getFacultyID = cbbFaculty.SelectedValue.ToString();
            var loadCbbTeacher = from teacher in connect.Teachers
                               where teacher.facultyID == getFacultyID
                               select new
                               {
                                   TeacherID = teacher.teacherID,
                                   FullName = teacher.fullName
                               };
            if (loadCbbTeacher.Count() == 0)
            {
                cbbTeacher.DataSource = null;
                cbbTeacher.Text = "";
            }
            else
            {
                cbbTeacher.DataSource = loadCbbTeacher.ToList();
                cbbTeacher.DisplayMember = "TeacherID";
                cbbTeacher.ValueMember = "TeacherID";
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void Insert(string classID, string className, string teacherID, string facultyID)
        {
            Class checkClassID = connect.Classes.SingleOrDefault(item => item.classID == classID);
            if (checkClassID == null)
            {
                if (facultyID == null)
                {
                    AddInfo(classID, className, null, null);
                }
                else if (teacherID == null)
                {
                    Faculty checkFacultyID = connect.Faculties.SingleOrDefault(item => item.facultyID == facultyID);
                    if (checkFacultyID == null)
                    {
                        MessageBox.Show("Can't find this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        AddInfo(classID, className, null, facultyID);
                    }
                }
                else
                {
                    Teacher checkTeacherID = connect.Teachers.SingleOrDefault(item => item.teacherID == teacherID && item.facultyID == facultyID);
                    Faculty checkFacultyID = connect.Faculties.SingleOrDefault(item => item.facultyID == facultyID);
                    if (checkFacultyID == null)
                    {
                        MessageBox.Show("Can't find this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (checkTeacherID == null)
                    {
                        MessageBox.Show("Teacher is not in this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        AddInfo(classID, className, teacherID, facultyID);
                    }
                }
                connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("This ID has been used!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Update(string classID, string className, string teacherID, string facultyID)
        {
            Class dbUpdate = connect.Classes.SingleOrDefault(item => item.classID == classID);
            if (dbUpdate != null)
            {
                if (facultyID == null)
                {
                    List<Student> listStudent = connect.Students.Where(x => x.classID == classID).ToList();
                    UpdateInfo(dbUpdate, classID, className, null, null);
                }
                else if (teacherID == null)
                {
                    Faculty checkFacultyID = connect.Faculties.SingleOrDefault(item => item.facultyID == facultyID);
                    if (checkFacultyID == null)
                    {
                        MessageBox.Show("Can't find this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        UpdateInfo(dbUpdate, classID, className, null, facultyID);
                    }
                }
                else
                {
                    Teacher checkTeacherID = connect.Teachers.SingleOrDefault(item => item.teacherID == teacherID && item.facultyID == facultyID);
                    Faculty checkFacultyID = connect.Faculties.SingleOrDefault(item => item.facultyID == facultyID);
                    if (checkFacultyID == null)
                    {
                        MessageBox.Show("Can't find this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (checkTeacherID == null)
                    {
                        MessageBox.Show("Teacher is not in this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        UpdateInfo(dbUpdate, classID, className, teacherID, facultyID);
                    }
                }
                connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Search(DataGridView dgv, string classID, string className, string teacherID, string facultyID)
        {
            if (teacherID == null || facultyID == null)
            {
                var search = from _class in connect.Classes
                             where _class.classID.Contains(classID) && _class.className.Contains(className)
                             && _class.teacherID.Contains(teacherID) || _class.facultyID.Contains(facultyID)
                             select new
                             {
                                 ClassID = _class.classID,
                                 ClassName = _class.className,
                                 TeacherID = _class.teacherID,
                                 Faculty = _class.Faculty.facultyName
                             };
                dgv.DataSource = search.ToList();
            }
            else
            {
                var search = from _class in connect.Classes
                             where _class.classID.Contains(classID) && _class.className.Contains(className)
                             && _class.teacherID.Contains(teacherID) && _class.facultyID.Contains(facultyID)
                             select new
                             {
                                 ClassID = _class.classID,
                                 ClassName = _class.className,
                                 TeacherID = _class.teacherID,
                                 Faculty = _class.Faculty.facultyName
                             };
                dgv.DataSource = search.ToList();
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void Delete(string classID)
        {
            Class dbDelete = connect.Classes.SingleOrDefault(item => item.classID == classID);

            if (dbDelete != null)
            {
                DialogResult dr = MessageBox.Show("Do you want to delete?", "Yes/No", MessageBoxButtons.YesNo);
                
                if (dr == DialogResult.Yes)
                {
                    List<Student> listStudent = connect.Students.Where(item => item.classID == classID).ToList();
                    foreach (var item in listStudent)
                    {
                        item.classID = null;
                    }
                    connect.Classes.Remove(dbDelete);
                    connect.SaveChanges();
                    MessageBox.Show("Delete data successful!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteClass(string classID, string newFacultyID) {
            Class check = connect.Classes.SingleOrDefault(x => x.classID == classID && x.facultyID == newFacultyID);
            if (check == null || newFacultyID == null) {
                List<Student> listStudent = connect.Students.Where(item => item.classID == classID).ToList();
                foreach (var item in listStudent)
                {
                    item.classID = null;
                }
            }
            connect.SaveChanges();
        } //Hàm đặt mã lớp của sinh viên = null nếu thay đổi hoặc xóa mã khoa của lớp

        private void AddInfo(string classID, string className, string teacherID, string facultyID) 
        {
            Class _class = new Class()
            {
                classID = classID,
                className = className,
                teacherID = teacherID,
                facultyID = facultyID
            };
            connect.Classes.Add(_class);
            MessageBox.Show("Insert new data successful!!!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateInfo(Class dbUpdate, string classID, string className, string teacherID, string facultyID) {
            deleteClass(classID, facultyID);
            dbUpdate.className = className;
            dbUpdate.teacherID = teacherID;
            dbUpdate.facultyID = facultyID;
            MessageBox.Show("Update data successful!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
