using StudentManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement.Function
{
    internal class TeacherFunc
    {
        ConnectDB connect = new ConnectDB();

        public void LoadData(DataGridView dgv, ComboBox cbb) 
        {
            var loadTeacher = from teacher in connect.Teachers
                              select new
                              {
                                  TeacherID = teacher.teacherID,
                                  FullName = teacher.fullName,
                                  Address = teacher.address,
                                  PhoneNumber = teacher.phoneNumber,
                                  Email = teacher.email,
                                  Faculty= teacher.Faculty.facultyName,
                              };
            dgv.DataSource = loadTeacher.ToList(); 
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 

            var loadCbb = from faculty in connect.Faculties 
                          select new
                          {
                              FacultyID = faculty.facultyID,
                              FacultyName = faculty.facultyName,
                          };
            cbb.DataSource = loadCbb.ToList(); 
            cbb.DisplayMember = "FacultyName";
            cbb.ValueMember = "FacultyID"; 
        }

        public void Insert(string teacherID, string teacherName, string address, string phoneNumber, string email, string facultyID)
        {
            List<Teacher> teacherList = connect.Teachers.ToList();
            List<Teacher> checkID = teacherList.Where(item => item.teacherID == teacherID).ToList();
            if (checkID.Count == 0)
            {
                AddInfo(teacherID, teacherName, address, phoneNumber, email, facultyID);
                connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("This ID has been used", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } 

        public void Update(string teacherID, string teacherName, string address, string phoneNumber, string email, string facultyID)
        {
            Teacher dbUpdate = connect.Teachers.FirstOrDefault(item => item.teacherID == teacherID);
            if (dbUpdate != null)
            {
                UpdateInfo(dbUpdate, teacherName, address,phoneNumber, email, facultyID);
                connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } 

        public void Search(DataGridView dvg, string teacherID, string teacherName, string address, string phoneNumber, string email, string facultyName)
        {
            var search = from teacher in connect.Teachers
                           where teacher.teacherID.Contains(teacherID) && teacher.fullName.Contains(teacherName) 
                           && teacher.address.Contains(address) && teacher.email.Contains(email) && teacher.phoneNumber.Contains(phoneNumber)
                           select new
                           {
                               TeacherID = teacher.teacherID,
                               FullName = teacher.fullName,
                               Address = teacher.address,
                               PhoneNumber = teacher.phoneNumber,
                               Email = teacher.email,
                               Faculty = teacher.Faculty.facultyName,
                           };
            var data = search.ToList();
            if (facultyName == "")
            {
                data = data.Where(x => x.Faculty == null).ToList();
            }
            else
            {
                data = data.Where(x => x.Faculty == facultyName).ToList();
            }
            dvg.DataSource = data;
        } 

        public void Delete(string teacherID)
        {
            Teacher dbDelete = connect.Teachers.FirstOrDefault(item => item.teacherID == teacherID);

            if (dbDelete != null)
            {
                DialogResult dr = MessageBox.Show("Do you want to delete?", "Yes/No", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    List<Class> listClass = connect.Classes.Where(x => x.teacherID == teacherID).ToList();
                    if (listClass != null)
                    {
                        foreach (var item in listClass)
                        {
                            item.teacherID = null;
                        }
                    }
                    AccountFunc account = new AccountFunc(); 
                    account.Delete(teacherID); 
                    dbDelete.Faculty.totalProfessor--;
                    connect.Teachers.Remove(dbDelete);
                }
                connect.SaveChanges();
                MessageBox.Show("Delete data successful!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Can't find this ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddInfo(string teacherID, string teacherName, string address, string phoneNumber, string email, string facultyID) {
            AccountFunc account = new AccountFunc();
            account.Create(teacherID, teacherID);
            Teacher teacher = new Teacher()
            {
                teacherID = teacherID,
                fullName = teacherName,
                address = address,
                phoneNumber = phoneNumber,
                email = email,
                facultyID = facultyID,
            };
            ProfessorUpdate(teacher.facultyID);
            connect.Teachers.Add(teacher);
            MessageBox.Show("Insert new data successful!!!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateInfo(Teacher dbUpdate, string teacherName, string address, string phoneNumber, string email, string facultyID) {
            Faculty professorUpdate = connect.Faculties.SingleOrDefault(item => item.facultyID == dbUpdate.facultyID);
            if (professorUpdate != null && professorUpdate.facultyID != facultyID || facultyID == null)
            {
                List<Class> listClass = connect.Classes.Where(x => x.teacherID == dbUpdate.teacherID).ToList();
                if (listClass != null)
                {
                    foreach (var item in listClass)
                    {
                        item.teacherID = null;
                    }
                }
                professorUpdate.totalProfessor--;
            }
            ProfessorUpdate(facultyID);
            dbUpdate.fullName = teacherName;
            dbUpdate.address = address;
            dbUpdate.facultyID = facultyID;
            dbUpdate.email = email;
            dbUpdate.phoneNumber = phoneNumber;
            MessageBox.Show("Update data successful!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProfessorUpdate(string facultuID) {
            Faculty professorUpdate = connect.Faculties.SingleOrDefault(item => item.facultyID == facultuID);
            if (professorUpdate != null) {
                if (professorUpdate.totalProfessor == null)
                {
                    professorUpdate.totalProfessor = 1;
                }
                else
                {
                    professorUpdate.totalProfessor++;
                }
            }      
        } 
    }
}
