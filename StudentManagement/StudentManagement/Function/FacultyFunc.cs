using StudentManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement.Function
{
    internal class FacultyFunc
    {
        ConnectDB connect = new ConnectDB(); //Tạo biến kết nối csdl

        public void LoadData(DataGridView dgv)
        {   
            var loadFaculty = from faculty in connect.Faculties //Lấy thông tin cần hiển thị từ bảng Khoa
                              select new
                              {
                                  FacultyID = faculty.facultyID,
                                  FacultyName = faculty.facultyName,
                                  TotalProfessor = faculty.totalProfessor,
                              };
            dgv.DataSource = loadFaculty.ToList(); //Add thông tin vừa lấy truyền vào DataGridView(dgvFaculty)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //Chỉnh kính thước các cột fill với chiều dài bảng 
        } //Hàm load dữ liệu lên DataGridView 

        public void Insert(string facultyID, string facultyName, List<string> listCourseID)
        {
            AccountFunc account1 = new AccountFunc();
            account1.Create(facultyID, facultyID);
            List<Faculty> facultyList = connect.Faculties.ToList(); //Lấy danh sách khoa
            List<Faculty> checkID = facultyList.Where(item => item.facultyID == facultyID).ToList(); //Lưu khoa có mã trùng với mã mình nhập vào
            if (checkID.Count == 0) //checkID là rỗng => không trùng ID
            {
                AccountFunc account = new AccountFunc();
                account.Create(facultyID, facultyID);
                Faculty faculty = new Faculty() //Lưu các giá trị mình đã nhập vào một biến
                {
                    facultyID = facultyID,
                    facultyName = facultyName,
                    totalProfessor = null,
                };
                connect.Faculties.Add(faculty); //Thêm khoa mới vào csdl
                foreach (var item in listCourseID) //Thêm các khóa học cho khoa
                {
                    FacultyCourse facultyCourse = new FacultyCourse()
                    {
                        courseID = item,
                        facultyID = facultyID,
                    };
                    connect.FacultyCourses.Add(facultyCourse);
                }
                connect.SaveChanges(); //Lưu lại trạng thái
                MessageBox.Show("Insert new data successful!!!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information); //Thông báo nhập thành công
            }
            else //Ngược lại => trùng ID
            {
                MessageBox.Show("This ID has been used", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo trùng ID
            }
        } //Hàm thêm một khoa

        public void Update(string facultyID, string facultyName, List<string> listCourseID)
        {
            Faculty dbUpdate = connect.Faculties.FirstOrDefault(item => item.facultyID == facultyID);
            if (dbUpdate != null) 
            {
                dbUpdate.facultyName = facultyName;
                UpdateStudentCourse(facultyID, listCourseID);
                List<FacultyCourse> listFacultyID = connect.FacultyCourses.Where(x => x.facultyID == facultyID).ToList(); 
                if (listFacultyID != null) 
                {
                    foreach (var item in listFacultyID) 
                    {
                        connect.FacultyCourses.Remove(item);
                    }
                }
                foreach (var item in listCourseID)
                {
                    FacultyCourse courseOfFaculty = new FacultyCourse()
                    {
                        facultyID = facultyID,
                        courseID = item,
                    };
                    connect.FacultyCourses.Add(courseOfFaculty);
                }
                connect.SaveChanges(); 
                    MessageBox.Show("Update data successful!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            else
            {
                MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo không tìm thấy ID
            }
        } //Hàm cập nhật khoa
 
        public void Search(DataGridView dvg, string facultyID, string facultyName)
        {
            var findName = from fT in connect.Faculties
                           where fT.facultyID.Contains(facultyID) && fT.facultyName.Contains(facultyName)
                           select new //Tìm kiếm ID và tên khoa trong csdl
                           {
                               FacultyID = fT.facultyID,
                               FacultyName = fT.facultyName,
                           };
            dvg.DataSource = findName.ToList(); //Add thông tin vừa lấy vào dgv truyền vào (dgvFaculty)
            dvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //Chỉnh kính thước các cột fill với chiều dài bảng 
        } //Hàm tìm kiếm khoa

        public void Delete(string facultyID)
        {
            Faculty faculyDel = connect.Faculties.SingleOrDefault(item => item.facultyID == facultyID);
            if (faculyDel != null)
            {   
                DialogResult dr = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo); 
                if (dr == DialogResult.Yes)
                {
              
                    List<FacultyCourse> listFacultyCourse = connect.FacultyCourses.Where(x => x.facultyID == facultyID).ToList();
                    if (listFacultyCourse != null)
                    {
                        foreach (var course in listFacultyCourse)
                        {
                            connect.FacultyCourses.Remove(course);
                        }
                    } //Cập nhật lại khóa học
            
                    List<Student> listStudent = connect.Students.Where(item => item.facultyID == facultyID).ToList(); 
                    if (listStudent != null) 
                    {
                        foreach (var student in listStudent) 
                        {
                            List<StudentMark> listCourse = connect.StudentMarks.Where(x => x.studentID == student.studentID).ToList(); 
                            if (listCourse != null) 
                            {
                                List<StudentMark> listLearnedCourse = listCourse.Where(x => x.score != null).ToList(); 
                                if (listLearnedCourse == null)
                                {
                                    foreach (var course in listCourse)
                                    {
                                        connect.StudentMarks.Remove(course);
                                    }
                                }
                                else
                                {
                                    foreach (var course in listCourse)
                                    {
                                        StudentMark checkLearned = listLearnedCourse.SingleOrDefault(x => x.courseID == course.courseID);
                                        if (checkLearned == null)
                                        {
                                            connect.StudentMarks.Remove(course);
                                        }
                                    }
                                }
                            }
                            student.classID = null;
                            student.facultyID = null;
                        }
                    }//Cập nhật lại sinh viên

                    List<Class> listClass = connect.Classes.Where(item => item.facultyID == facultyID).ToList();
                    if (listClass != null) 
                    {
                        foreach (var item in listClass)
                        {
                            item.facultyID = null;
                        }
                    } //Cập nhật lại lớp

                    List<Teacher> listTeacher = connect.Teachers.Where(item => item.facultyID == facultyID).ToList();
                    if (listTeacher != null)
                    {
                        foreach (var teacher in listTeacher)
                        {
                            teacher.facultyID = null;
                        }
                    } //Cập nhật lại giảng viên
   
                    AccountFunc account = new AccountFunc();
                    connect.Faculties.Remove(faculyDel);
                    connect.SaveChanges(); 
                    MessageBox.Show("Delete data successful!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
            else
            {
                MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        } //Hàm xóa khoa

        private void UpdateStudentCourse(string facultyID, List<string> listCourseID) {
            List<Student> listStudent = connect.Students.Where(item => item.facultyID == facultyID).ToList(); //Lấy ra các sinh viên học khoa đó
            if (listStudent != null)
            {
                foreach (var item in listStudent) //Duyệt từng sinh viên
                {
                    List<StudentMark> listCourse = connect.StudentMarks.Where(x => x.studentID == item.studentID).ToList(); //Lấy ra các khóa học sinh viên học khoa đó
                    if (listCourse != null) //Xóa các khóa học cũ
                    {
                        List<StudentMark> listLearnedCourse = listCourse.Where(x => x.score != null).ToList(); //Lấy ra các khóa học sinh viên đã học
                        if (listLearnedCourse == null)
                        {
                            foreach (var course in listCourse)
                            {
                                connect.StudentMarks.Remove(course);
                            }
                        }
                        else
                        {
                            foreach (var course in listCourse)
                            {
                                StudentMark checkLearned = listLearnedCourse.SingleOrDefault(x => x.courseID == course.courseID);
                                if (checkLearned == null)
                                {
                                    connect.StudentMarks.Remove(course);
                                }
                            }
                        }
                    }

                    foreach (var course in listCourseID) //Thêm các khóa học mới
                    {
                        StudentMark studentMark = new StudentMark()
                        {
                            studentID = item.studentID,
                            courseID = course,
                            score = null
                        };
                        List<StudentMark> listLearnedCourse = listCourse.Where(x => x.score != null).ToList();
                        if (listLearnedCourse == null) {
                            connect.StudentMarks.Add(studentMark);
                        }
                        else
                        {
                            StudentMark checkLearned = listLearnedCourse.SingleOrDefault(x => x.courseID == course);
                            if (checkLearned == null)
                            {
                                connect.StudentMarks.Add(studentMark);
                            }
                        }
                    }
                }
            }
        }
    }
}
