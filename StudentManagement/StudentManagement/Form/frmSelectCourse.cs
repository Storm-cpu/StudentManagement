using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class frmSelectCourse : Form
    {
        public frmSelectCourse()
        {
            InitializeComponent();
        }

        ConnectDB connect = new ConnectDB();

        List<string> selectedCourse = new List<string>();
        public List<string> SelectedCourse { get => selectedCourse; set => selectedCourse = value; }

        private void frmSelectCourse_Load(object sender, EventArgs e)
        {
            selectedCourse.Clear();
            this.ControlBox = true;

            listBox1.Items.Clear();
            listBox1.DisplayMember = "CourseName";
            listBox1.ValueMember = "CourseID";

            listBox2.Items.Clear();
            listBox2.DisplayMember = "CourseName";
            listBox2.ValueMember = "CourseID";

            foreach (var item in connect.Courses.ToList())
            {
                listBox1.Items.Add(item);
            }

            foreach (var item in AdminForm.listCourseID)
            {
                var list = connect.Courses.FirstOrDefault(x => x.courseID == item);
                listBox2.Items.Add(list);
                listBox1.Items.Remove(list);
                selectedCourse.Add(listBox2.GetItemText(list));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedItems)
            {
                listBox2.Items.Add(item);
                //listBox1.Items.Remove(item);              //Remove ngay đây là lỗi liền T_T
                selectedCourse.Add(listBox2.GetItemText(item));
            }
            foreach (var item in listBox2.Items)
            {
                if (listBox1.Items.Contains(item))
                {
                    listBox1.Items.Remove(item);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox2.SelectedItems)
            {
                listBox1.Items.Add(item);
                if (selectedCourse != null)
                {
                    selectedCourse.Remove(listBox2.GetItemText(item));
                }
            }
            foreach (var item in listBox1.Items)
            {
                if (listBox2.Items.Contains(item))
                {
                    listBox2.Items.Remove(item);
                }
            }
        }
    }
}
