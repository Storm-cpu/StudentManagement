using StudentManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement.Function
{
    internal class StudentFunc
    {
        ConnectDB connect = new ConnectDB(); //Tạo biến kết nối csdl

        public void LoadData(DataGridView dgv, ComboBox cbbFaculty, ComboBox cbbClass)  
        {
            var loadStudent = from student in connect.Students //Lấy các thông tin cần hiển thị từ bảng sinh viên
                              select new
                              {
                                  StudentID = student.studentID, //Mã sinh viên
                                  StudentName = student.fullName, //Tên sinh viên
                                  Gender = student.gender, //Giới tính
                                  Birthday = student.birthday, //Sinh nhật
                                  HomeTown = student.homeTown, //Quê quán
                                  Faculty = student.Faculty.facultyName, //Khoa
                                  Class = student.Class.className, //Lớp
                                  AvgScore = student.avgScore, //Điểm trung bình
                                  Email = student.email, //Email
                              };
            dgv.DataSource = loadStudent.ToList(); //Add thông tin vừa lấy truyền vào DataGridView (dgvStudent)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //Chỉnh kính thước các cột bằng với chiều dài bảng 

            var loadCbbFaculty = from faculty in connect.Faculties //Lấy các thông tin cần hiển thị từ bảng khoa
                                 select new
                                 {
                                     FacyltyID = faculty.facultyID, //Mã khoa
                                     FacultyName = faculty.facultyName //Tên khoa
                                 };
            cbbFaculty.DataSource = loadCbbFaculty.ToList(); //Add thông tin vừa lấy truyền vào ComboBox (cbbFaculty)
            cbbFaculty.DisplayMember = "FacultyName";  //Hiển thị tên khoa của từng đối tượng trên ComboBox
            cbbFaculty.ValueMember = "FacyltyID"; //Đặt giá trị của từng đối tượng tượng trên ComboBox là mã khoa

            var loadCbbClass = from _class in connect.Classes //Lấy các thông tin cần hiển thị từ bảng lớp
                               select new
                               {
                                   ClassID = _class.classID, //Mã lớp
                                   ClassName = _class.className //Tên lớp
                               };
            if (loadCbbClass.Count() == 0) //Nếu không tìm thấy lớp trong khoa
            {
                cbbClass.DataSource = null; //Data = null
                cbbClass.Text = ""; //Hiễn thị chuỗi rỗng lên ComboBox
            }
            cbbClass.DataSource = loadCbbClass.ToList(); //Add thông tin vừa lấy truyền vào ComboBox (cbbClass)
            cbbClass.DisplayMember = "ClassName"; //Hiển thị tên lớp của từng đối tượng trên ComboBox
            cbbClass.ValueMember = "ClassID"; //Đặt giá trị của từng đối tượng tượng trên ComboBox là mã lớp
        } //Hàm load dữ liệu sinh viên lên màn hình chính

        public void Insert(string studentID, string studentName, string gender, DateTimePicker dateTimePicker,
            string homeTown, string facultyID, string classID, string email, byte[] image)
        {
            Student checkID = connect.Students.SingleOrDefault(item => item.studentID == studentID);    //Kiểm tra có sinh viên trùng ID không
            if (checkID == null) //Nếu không
            {
                if (facultyID == null) //Nếu không nhập mã khoa
                {
                    AddInfo(studentID, studentName, gender, dateTimePicker, homeTown, null, null, email, image); //Thêm sinh viên với mã khoa và lớp = null
                }
                else if (classID == null) //Nếu không nhập mã lớp
                {
                    Faculty checkFacultyID = connect.Faculties.SingleOrDefault(item => item.facultyID == facultyID); //Kiểm tra khoa có tồn tại không
                    if (checkFacultyID == null) //Nếu không tìm thấy khoa
                    {
                        MessageBox.Show("Can't find this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo không tìm thấy khoa
                    }
                    else //Nếu tìm thấy khoa
                    {
                        AddInfo(studentID, studentName, gender, dateTimePicker, homeTown, null, null, email, image); //Thêm sinh viên với mã lớp = null
                    }
                }
                else //Nếu nhập đầy đủ
                {
                    Class checkClassID = connect.Classes.SingleOrDefault(item => item.classID == classID && item.facultyID == facultyID); ; //Kiểm tra lớp có trong khoa không
                    Faculty checkFacultyID = connect.Faculties.SingleOrDefault(item => item.facultyID == facultyID); //Kiểm tra khoa có tồn tại không
                    if (checkFacultyID == null) //Nếu không tìm thấy khoa
                    {
                        MessageBox.Show("Can't find this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo không tìm thấy khoa
                    }
                    else if (checkClassID == null) //Nếu không tìm thấy lớp
                    {
                        MessageBox.Show("Class is not in this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo không tìm lớp trong khoa
                    }
                    else //Nếu thỏa điều kiện
                    {
                        AddInfo(studentID, studentName, gender, dateTimePicker, homeTown, facultyID, classID, email, image); //Thêm sinh viên
                    }
                }

                if (facultyID != null) //Nếu có thông tin khoa
                {
                    List<FacultyCourse> listCourse = connect.FacultyCourses.Where(item => item.facultyID == facultyID).ToList(); //Lấy sanh sách các khóa học thuộc khoa
                    if (listCourse != null) //Nếu có
                    {
                        foreach (var item in listCourse) //Duyệt từng khóa học trong danh sách
                        {
                            StudentMark studentMark = new StudentMark() //Cập nhật khóa học cho sinh viên thuộc khoa
                            {
                                studentID = studentID, //Mã sinh viên
                                courseID = item.courseID, //Mã khóa học
                                score = null //Điểm
                            };
                            connect.StudentMarks.Add(studentMark); //Thêm khóa học của sinh viên vào csdl
                        }
                    }
                }

                connect.SaveChanges(); //Lưu lại trạng thái
                MessageBox.Show("Insert new data successful!!!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information); //Thông báo thêm thành công
            }
            else //Trùng ID
            {
                MessageBox.Show("This ID has been used", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);  //Thông báo trùng ID
            }
        } //Hàm thêm sinh viên

        public void Update(string studentID, string studentName, string gender, DateTimePicker dateTimePicker,
            string homeTown, string facultyID, string classID, string email, byte[] image)
        {
            Student dbUpdate = connect.Students.SingleOrDefault(item => item.studentID == studentID); //Tìm thông tin sinh viên
            if (dbUpdate != null) //Nếu tìm thấy
            {
                if (facultyID == null) //Nếu không nhập mã khoa
                {
                    UpdateInfo(dbUpdate, studentID, studentName, gender, dateTimePicker, homeTown, null, null, email, image); //Cập nhật thông tin sinh viên với mã lớp và mã khoa = null
                }
                else if (classID == null) //Nếu không nhập mã lớp
                {
                    Faculty checkFacultyID = connect.Faculties.SingleOrDefault(item => item.facultyID == facultyID); //Kiểm tra khoa có tồn tại không
                    if (checkFacultyID == null) //Nếu không tìm thấy khoa
                    {
                        MessageBox.Show("Can't find this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo không tìm thấy khoa
                    }
                    else //Nếu tìm thấy khoa
                    {
                        UpdateInfo(dbUpdate, studentID, studentName, gender, dateTimePicker, homeTown, facultyID, null, email, image); //Cập nhật thông tin sinh viên với mã lớp = null
                    }
                }
                else //Nếu nhập đầy đủ
                {
                    Class checkClassID = connect.Classes.SingleOrDefault(item => item.classID == classID && item.facultyID == facultyID); ; //Kiểm tra lớp có trong khoa không
                    Faculty checkFacultyID = connect.Faculties.SingleOrDefault(item => item.facultyID == facultyID); //Kiểm tra khoa có tồn tại không
                    if (checkFacultyID == null) //Nếu không tìm thấy khoa
                    {
                        MessageBox.Show("Can't find this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo không tìm thấy khoa
                    }
                    else if (checkClassID == null) //Nếu không tìm thấy lớp
                    {
                        MessageBox.Show("Class is not in this Faculty!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo không tìm lớp trong khoa
                    }
                    else //Nếu thỏa điều kiện
                    {
                        UpdateInfo(dbUpdate, studentID, studentName, gender, dateTimePicker, homeTown, facultyID, classID, email, image); //Cập nhật thông tin sinh viên
                    }
                }
            }
            else //Không tim thấy mã sinh viên
            {
                MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo không tìm thấy ID
            }
        } //Hàm cập nhật sinh viên

        public void Search(DataGridView dvg, string studentID, string studentName, string gender,
            string homeTown, string facultyName, string className, string email)
        {
            var find = from student in connect.Students //Tìm danh sách các sinh viên có thông tin giống với thông tin nhập vào
                       where student.studentID.Contains(studentID) && student.fullName.Contains(studentName) && student.gender.Contains(gender)
                        && student.homeTown.Contains(homeTown) && student.email.Contains(email)
                       select new
                       {
                           StudentID = student.studentID, //Mã sinh viên
                           StudentName = student.fullName, //Tên sinh viên
                           Gender = student.gender, //Giới tính
                           Birthday = student.birthday, //Sinh nhật
                           HomeTown = student.homeTown, //Quê quán
                           Faculty = student.Faculty.facultyName, //Khoa
                           Class = student.Class.className, //Lớp
                           AvgScore = student.avgScore, //Điểm trung bình
                           Email = student.email, //Email
                       };

            var data = find.ToList(); //Cho biến lưu dũ liệu
            if (className == "" && facultyName != "") //Nếu không nhập lớp
            {
                data = data.Where(x => x.Faculty == facultyName).ToList(); //Tìm các sinh viên chưa có lớp
            }
            else if (facultyName == "") //Nếu không nhập khoa
            {
                data = data.Where(x => x.Faculty == null && x.Class == null).ToList(); //Tìm các sinh viên chưa có lớp lẫn khoa
            }
            else //Đã có lớp lẫn khoa
            {
                data = data.Where(x => x.Faculty == facultyName && x.Class == className).ToList(); //Tìm các sinh viên đã có lớp lẫn khoa nhập vào
            }

            if (data != null) //Nếu tìm thầy
            {
                dvg.DataSource = data; // Add thông tin vừa lấy truyền vào DataGridView(dgvStudent)
            }
            else
            {
                dvg.DataSource = null; //Cho dữ liệu DataGridView(dgvStudent) bằng null
            }
        } //Hàm tìm kiếm sinh viên

        public void Delete(string studentID)
        {
            Student dbDelete = connect.Students.SingleOrDefault(item => item.studentID == studentID); //Tìm kiếm mã sinh viên
            if (dbDelete != null) //Nếu tìm thấy
            {
                DialogResult dr = MessageBox.Show("Do you want to delete?", "Yes/No", MessageBoxButtons.YesNo); //Thông báo muốn xóa hay không
                if (dr == DialogResult.Yes) //Nếu có
                {
                    List<StudentMark> listCourse = connect.StudentMarks.Where(item => item.studentID == studentID).ToList(); //Lấy các khóa học của sinh viên
                    if (listCourse != null) //Nếu có
                    {
                        foreach (var item in listCourse) //Duyệt từng khóa học
                        {
                            connect.StudentMarks.Remove(item); //Xóa khóa học trên csdl
                        }
                    }
                    AccountFunc account = new AccountFunc(); //Gọi hàm quản lý tài khoản
                    account.Delete(studentID); //Xóa tài khoản sinh viên
                    connect.Students.Remove(dbDelete); // Xóa thông tin sinh viên
                    connect.SaveChanges(); //Lưu trạng thái
                    MessageBox.Show("Delete data successful!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo xóa thành công
                }
            }
            else //Không tìm thấy
            {
                MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Thông báo không tìm thấy ID
            }
        } //Hàm xóa sinh viên

        private void AddInfo(string studentID, string studentName, string gender, DateTimePicker dateTimePicker,
            string homeTown, string facultyID, string classID, string email, byte[] image) {
            Student student = new Student() //Thêm thông tin cho sinh viên
            {
                studentID = studentID, //Mã sinh viên
                classID = classID,  //Mã lớp
                fullName = studentName, //Tên sinh viên
                gender = gender, //Giới tính
                birthday = dateTimePicker.Value, //Sinh nhật
                homeTown = homeTown, //Quê quán
                facultyID = facultyID, //Mã khoa
                email = email, //Email
                avgScore = null, //Điểm trung bình
                image = image, //Hình ảnh
            };
            connect.Students.Add(student); //Thêm sinh viên mới vào csdl

            AccountFunc account = new AccountFunc(); //Gọi hàm quản lý tài khoản
            account.Create(studentID, studentID); //Tạo tài khoản cho sinh viên
        } //Hàm thêm thông tin và account cho sinh viên

        private void UpdateInfo(Student dbUpdate, string studentID, string studentName, string gender, DateTimePicker dateTimePicker,
            string homeTown, string facultyID, string classID, string email, byte[] image) {
            CheckChangeFaculty(studentID, facultyID); //Cập nhật lại khóa học cho sinh viên
            dbUpdate.fullName = studentName; //Cập nhật tên
            dbUpdate.gender = gender; //Cập nhật giới tính
            dbUpdate.birthday = dateTimePicker.Value; //Cập nhật ngày sinh
            dbUpdate.homeTown = homeTown; //Cập nhật quê quán
            dbUpdate.facultyID = facultyID; //Cập nhật mã khoa
            dbUpdate.classID = classID; //Cập nhật lớp
            dbUpdate.email = email; //Cập nhật email
            dbUpdate.image = image; //Cập nhật hình ảnh
            connect.SaveChanges(); //Lưu trạng thái
            MessageBox.Show("Update data successful!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); //Thông báo cập nhật thành công
        } //Hàm cập nhật thông tin cho sinh viên

        private void CheckChangeFaculty(string studentID, string facultyID) 
        {
            Student check = connect.Students.SingleOrDefault(item => item.facultyID == facultyID && item.studentID == studentID); //Check xem sinh viên có chuyển khoa không
            if (check == null) //Nếu chuyển khoa
            {
                List<StudentMark> student = connect.StudentMarks.Where(x => x.studentID == studentID).ToList(); //Lấy danh sách các khóa học của sinh viên
                List<StudentMark> listLearnedCourse = connect.StudentMarks.Where(item => item.studentID == studentID && item.score != null).ToList(); //Lấy sanh sách các khóa học đã có điểm
                if (student != null) //Nếu có
                {
                    if (listLearnedCourse == null) //Nếu sinh viên chưa có điểm ở khóa học nào
                    {
                        foreach (var item in student) //Duyệt từng khóa học của sinh viên
                        {
                            connect.StudentMarks.Remove(item); //Xóa khóa học ở khoa cũ
                        }
                    }
                    else //Ngược lại (Sinh viên đã có điểm ở một số khóa học)
                    {
                        foreach (var item in student) //Duyệt từng khóa học của sinh viên
                        {
                            StudentMark checkLearned = listLearnedCourse.SingleOrDefault(x => x.courseID == item.courseID); //Kiểm tra sinh viên có điểm trong khóa học này chưa
                            if (checkLearned == null) //Nếu sinh viên chưa có điểm của khóa học này
                            {
                                connect.StudentMarks.Remove(item); //Xóa khóa học ở khoa cũ
                            }
                        }
                    }
                }

                if (facultyID != null) //Nếu có thông tin khoa mới
                {
                    List<FacultyCourse> listCourse = connect.FacultyCourses.Where(item => item.facultyID == facultyID).ToList(); //Lấy sanh sách các khóa học thuộc khoa mới
                    if (listCourse != null) //Nếu có
                    {
                        if (listLearnedCourse == null) //Nếu sinh viên chưa có điểm ở khóa học nào
                        {
                            foreach (var item in listCourse) //Duyệt từng khóa học trong danh sách
                            {
                                StudentMark studentMark = new StudentMark() //Cập nhật khóa học cho sinh viên thuộc khoa mới
                                {
                                    studentID = studentID, //Mã sinh viên
                                    courseID = item.courseID, //Mã khóa học
                                    score = null //Điểm
                                };
                                connect.StudentMarks.Add(studentMark); //Thêm khóa học của sinh viên vào csdl
                            }
                        }
                        else //Ngược lại (Sinh viên đã có điểm ở một số khóa học)
                        {
                            foreach (var item in listCourse) //Duyệt từng khóa học trong danh sách
                            {
                                StudentMark studentMark = new StudentMark() //Cập nhật khóa học cho sinh viên thuộc khoa mới
                                {
                                    studentID = studentID, //Mã sinh viên
                                    courseID = item.courseID, //Mã khóa học
                                    score = null //Điểm
                                };
                                StudentMark checkLearned = listLearnedCourse.SingleOrDefault(x => x.courseID == item.courseID); //Kiểm tra sinh viên có điểm trong khóa học này chưa
                                if (checkLearned == null) //Nếu sinh viên chưa có điểm của khóa học này
                                {
                                    connect.StudentMarks.Add(studentMark); //Thêm khóa học của sinh viên vào csdl
                                }
                            }
                        }
                    }
                }
            }
        } //Hàm cập nhật khóa học cho sinh viên nếu chuyển khoa
    }
}
