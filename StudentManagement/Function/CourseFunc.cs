using StudentManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement.Function
{
    internal class CourseFunc
    {
        ConnectDB connect = new ConnectDB();

        public void LoadData(DataGridView dgv)
        {
            var loadCourse = from course in connect.Courses
                             select new
                             {
                                 CourseID = course.courseID,
                                 CourseName = course.courseName,
                                 Credits = course.credits,
                             };
            dgv.DataSource = loadCourse.ToList();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void Insert(string courseID, string courseName, string credits, List<string> listFacultyID)
        {
            List<Course> coursesList = connect.Courses.ToList();
            List<Course> checkID = coursesList.Where(item => item.courseID == courseID).ToList();
            if (checkID.Count == 0)
            {
                Course course = new Course()
                {
                    courseID = courseID,
                    courseName = courseName,
                    credits = int.Parse(credits)
                };
                connect.Courses.Add(course);
                foreach (var item in listFacultyID)
                {
                    FacultyCourse courseOfFaculty = new FacultyCourse() {
                        courseID = courseID,
                        facultyID = item,
                    };
                    connect.FacultyCourses.Add(courseOfFaculty);

                    List<Student> studentList = connect.Students.Where(x => x.facultyID == item).ToList(); //Tìm các sinh viên có trong khoa đó
                    foreach (var studentItem in studentList) //Duyệt từng sinh viên
                    {
                        StudentMark studentMark = new StudentMark() //Tạo biến để cập nhật khóa học cho các sinh viên học khoa đó
                        {
                            studentID = studentItem.studentID,
                            courseID = courseID,
                            score = null,
                        };
                        connect.StudentMarks.Add(studentMark); //Cập nhật khóa học cho sinh viên
                    }
                }
                connect.SaveChanges();
                MessageBox.Show("Insert new data successful!!!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This ID has been used", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Update(string courseID, string courseName, string credits, List<string> listFacultyID)
        {
            if (courseID == "" || courseName == "" || credits == "" || listFacultyID == null) {
                MessageBox.Show("Fill all the information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Course dbUpdate = connect.Courses.FirstOrDefault(item => item.courseID == courseID);
                if (dbUpdate != null)
                {
                    //Cập nhật tên khóa học và chứng chỉ
                    dbUpdate.courseName = courseName;
                    dbUpdate.credits = int.Parse(credits);
                    //Cập nhật khóa học cho sinh viên
                    UpdateStudentCourse(courseID,listFacultyID);
                    //Cập nhật lại các khóa học trong khoa
                    List<FacultyCourse> listFaculty = connect.FacultyCourses.Where(x => x.courseID == courseID).ToList();//Lấy danh sách khoa chứa khóa học này
                    if (listFaculty != null)
                    {
                        foreach (var item in listFaculty)
                        {
                            connect.FacultyCourses.Remove(item);
                        }
                    }
                    foreach (var item in listFacultyID)
                    {
                        FacultyCourse courseOfFaculty = new FacultyCourse()
                        {
                            facultyID = item,
                            courseID = courseID,
                        };
                        connect.FacultyCourses.Add(courseOfFaculty);
                    }
                    connect.SaveChanges();
                    MessageBox.Show("Update data successful!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void Search(DataGridView dvg, string courseID, string courseName, string credits)
        {
            var find = from course in connect.Courses
                       where course.courseID.Contains(courseID) && course.courseName.Contains(courseName) && course.credits.ToString().Contains(credits)
                       select new
                       {
                           CourseID = course.courseID,
                           CourseName = course.courseName,
                           Credits = course.credits,
                       };
            dvg.DataSource = find.ToList();
            dvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void Delete(string courseID)
        {
            Course dbDelete = connect.Courses.FirstOrDefault(item => item.courseID == courseID);
            var listCourse = connect.FacultyCourses.Where(x => x.courseID == courseID).ToList();
            var student = connect.StudentMarks.Where(x => x.courseID == courseID).ToList();
            if (dbDelete != null)
            {
                DialogResult dr = MessageBox.Show("Do you want to delete?", "Yes/No", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (student != null)
                    {
                        foreach (var item2 in student)
                        {
                            connect.StudentMarks.Remove(item2);
                        }
                    }//Xóa khóa học cho sinh viên

                    if (listCourse != null)
                    {
                        foreach (var item in listCourse)
                        {
                            connect.FacultyCourses.Remove(item);
                        }
                    }//Xóa khóa học trong khoa
                    connect.Courses.Remove(dbDelete);   
                } 
                connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateStudentCourse(string courseID, List<string> listFacultyID)
        {
            List<FacultyCourse> listFaculty = connect.FacultyCourses.Where(x => x.courseID == courseID).ToList();
            if (listFaculty != null)
            {
                foreach (var faculty in listFaculty)
                {
                    List<Student> listStudent = connect.Students.Where(x => x.facultyID == faculty.facultyID).ToList();
                    if (listStudent != null)
                    {
                        foreach (var student in listStudent)
                        {
                            StudentMark course = connect.StudentMarks.SingleOrDefault(x => x.studentID == student.studentID && x.courseID == courseID && x.score == null);
                            if (course != null)
                            {
                                connect.StudentMarks.Remove(course);
                            }
                        }
                    }
                }
            } //Xóa khóa học của sinh viên ở khoa cũ

            foreach (var facultyID in listFacultyID)
            {
                List<Student> listStudent = connect.Students.Where(x => x.facultyID == facultyID).ToList();
                if (listStudent != null)
                {
                    foreach (var student in listStudent)
                    {
                        StudentMark studentMark = new StudentMark()
                        {
                            studentID = student.studentID,
                            courseID = courseID,
                            score = null
                        };
                        StudentMark checkLearned = connect.StudentMarks.SingleOrDefault(x => x.studentID == student.studentID && x.courseID == courseID);
                        if (checkLearned == null)
                        {
                            connect.StudentMarks.Add(studentMark);
                        }
                    }
                }
            } //Cập nhật lại khóa học của sinh viên ở khoa mới
        }
    }
}
