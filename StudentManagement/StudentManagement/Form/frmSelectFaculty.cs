using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class frmSelectFaculty : Form
    {
        public frmSelectFaculty()
        {
            InitializeComponent();
        }

        ConnectDB connect = new ConnectDB();

        List<string> selectedFaculty = new List<string>();
        public List<string> SelectedFaculty { get => selectedFaculty; set => selectedFaculty = value; }

        private void CourseOfFaculty_Load(object sender, EventArgs e)
        {
            selectedFaculty.Clear();
            this.ControlBox = true;

            listBox1.Items.Clear();
            listBox1.DisplayMember = "FacultyName";
            listBox1.ValueMember = "FacultyID";

            listBox2.Items.Clear();
            listBox2.DisplayMember = "FacultyName";
            listBox2.ValueMember = "FacultyID";

            foreach (var item in connect.Faculties.ToList())
            {
                listBox1.Items.Add(item);
            }

            foreach (var item in AdminForm.listFacultyID)
            {
                var list = connect.Faculties.FirstOrDefault(x => x.facultyID == item);
                listBox2.Items.Add(list);
                listBox1.Items.Remove(list);
                selectedFaculty.Add(listBox2.GetItemText(list));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedItems)
            {
                listBox2.Items.Add(item);
                //listBox1.Items.Remove(item);              //Remove ngay đây là lỗi liền T_T
                selectedFaculty.Add(listBox2.GetItemText(item));
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
                if (selectedFaculty != null)
                {
                    selectedFaculty.Remove(listBox2.GetItemText(item));
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
