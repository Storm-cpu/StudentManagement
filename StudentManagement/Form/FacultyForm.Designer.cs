namespace StudentManagement
{
    partial class FacultyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacultyForm));
            this.formClass = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtHomeTown = new System.Windows.Forms.TextBox();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.rbntMale = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbbClass = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.picBoxAvatar = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.dgvSubStudentTable = new System.Windows.Forms.DataGridView();
            this.btnSearchStudent = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.btnUpdateStudent = new System.Windows.Forms.Button();
            this.btnInsertStudent = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTeacherSearch = new System.Windows.Forms.Button();
            this.btnTeacherDelete = new System.Windows.Forms.Button();
            this.btnTeacherUpdate = new System.Windows.Forms.Button();
            this.btnTeacherInsert = new System.Windows.Forms.Button();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvTeacher = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTeacherAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTeacherID = new System.Windows.Forms.TextBox();
            this.txtTeacherEmail = new System.Windows.Forms.TextBox();
            this.txtTeacherPhone = new System.Windows.Forms.TextBox();
            this.txtTeacherName = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button13 = new System.Windows.Forms.Button();
            this.dgvClassSubTable = new System.Windows.Forms.DataGridView();
            this.btnClassSearch = new System.Windows.Forms.Button();
            this.txtClassSubTableSearch = new System.Windows.Forms.TextBox();
            this.btnClassDelete = new System.Windows.Forms.Button();
            this.btnClassUpdate = new System.Windows.Forms.Button();
            this.btnClassInsert = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbbClassTeacher = new System.Windows.Forms.ComboBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtClassID = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.btnExit4 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvClass = new System.Windows.Forms.DataGridView();
            this.formClass.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubStudentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassSubTable)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).BeginInit();
            this.SuspendLayout();
            // 
            // formClass
            // 
            this.formClass.CausesValidation = false;
            this.formClass.Controls.Add(this.tabPage1);
            this.formClass.Controls.Add(this.tabPage2);
            this.formClass.Controls.Add(this.tabPage4);
            this.formClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formClass.ItemSize = new System.Drawing.Size(448, 30);
            this.formClass.Location = new System.Drawing.Point(1, 0);
            this.formClass.Name = "formClass";
            this.formClass.RightToLeftLayout = true;
            this.formClass.SelectedIndex = 0;
            this.formClass.Size = new System.Drawing.Size(1349, 747);
            this.formClass.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.formClass.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.dgvSubStudentTable);
            this.tabPage1.Controls.Add(this.btnSearchStudent);
            this.tabPage1.Controls.Add(this.btnDeleteStudent);
            this.tabPage1.Controls.Add(this.btnUpdateStudent);
            this.tabPage1.Controls.Add(this.btnInsertStudent);
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dgvStudent);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1341, 709);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Student";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtStudentID);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtEmail);
            this.groupBox5.Controls.Add(this.txtHomeTown);
            this.groupBox5.Controls.Add(this.rbtnFemale);
            this.groupBox5.Controls.Add(this.txtStudentName);
            this.groupBox5.Controls.Add(this.rbntMale);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.cbbClass);
            this.groupBox5.Controls.Add(this.dateTimePicker);
            this.groupBox5.Controls.Add(this.picBoxAvatar);
            this.groupBox5.Location = new System.Drawing.Point(8, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1010, 219);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Student Infomation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(608, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Class";
            // 
            // txtStudentID
            // 
            this.txtStudentID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtStudentID.Location = new System.Drawing.Point(305, 23);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(271, 26);
            this.txtStudentID.TabIndex = 25;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label29.Location = new System.Drawing.Point(606, 76);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(48, 20);
            this.label29.TabIndex = 16;
            this.label29.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(606, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Home Town";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(184, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Full Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(184, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "StudentID";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtEmail.Location = new System.Drawing.Point(727, 73);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(271, 26);
            this.txtEmail.TabIndex = 24;
            // 
            // txtHomeTown
            // 
            this.txtHomeTown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHomeTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtHomeTown.Location = new System.Drawing.Point(727, 19);
            this.txtHomeTown.Name = "txtHomeTown";
            this.txtHomeTown.Size = new System.Drawing.Size(271, 26);
            this.txtHomeTown.TabIndex = 24;
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbtnFemale.Location = new System.Drawing.Point(390, 125);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(80, 24);
            this.rbtnFemale.TabIndex = 31;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "Female";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // txtStudentName
            // 
            this.txtStudentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtStudentName.Location = new System.Drawing.Point(305, 76);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(271, 26);
            this.txtStudentName.TabIndex = 23;
            // 
            // rbntMale
            // 
            this.rbntMale.AutoSize = true;
            this.rbntMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbntMale.Location = new System.Drawing.Point(305, 125);
            this.rbntMale.Name = "rbntMale";
            this.rbntMale.Size = new System.Drawing.Size(61, 24);
            this.rbntMale.TabIndex = 31;
            this.rbntMale.TabStop = true;
            this.rbntMale.Text = "Male";
            this.rbntMale.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(184, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Gender";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(184, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 20);
            this.label11.TabIndex = 12;
            this.label11.Text = "Date Of Birth";
            // 
            // cbbClass
            // 
            this.cbbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbbClass.FormattingEnabled = true;
            this.cbbClass.Location = new System.Drawing.Point(729, 121);
            this.cbbClass.Name = "cbbClass";
            this.cbbClass.Size = new System.Drawing.Size(269, 28);
            this.cbbClass.TabIndex = 26;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePicker.Location = new System.Drawing.Point(305, 174);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(271, 26);
            this.dateTimePicker.TabIndex = 27;
            // 
            // picBoxAvatar
            // 
            this.picBoxAvatar.BackColor = System.Drawing.Color.Gainsboro;
            this.picBoxAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxAvatar.Location = new System.Drawing.Point(6, 22);
            this.picBoxAvatar.Name = "picBoxAvatar";
            this.picBoxAvatar.Size = new System.Drawing.Size(172, 184);
            this.picBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxAvatar.TabIndex = 30;
            this.picBoxAvatar.TabStop = false;
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(1298, 351);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(35, 35);
            this.button8.TabIndex = 51;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dgvSubStudentTable
            // 
            this.dgvSubStudentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubStudentTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubStudentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubStudentTable.Location = new System.Drawing.Point(1024, 112);
            this.dgvSubStudentTable.Name = "dgvSubStudentTable";
            this.dgvSubStudentTable.Size = new System.Drawing.Size(312, 219);
            this.dgvSubStudentTable.TabIndex = 37;
            this.dgvSubStudentTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubStudentTable_CellClick);
            // 
            // btnSearchStudent
            // 
            this.btnSearchStudent.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSearchStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchStudent.ForeColor = System.Drawing.Color.White;
            this.btnSearchStudent.Location = new System.Drawing.Point(785, 337);
            this.btnSearchStudent.Name = "btnSearchStudent";
            this.btnSearchStudent.Size = new System.Drawing.Size(75, 32);
            this.btnSearchStudent.TabIndex = 29;
            this.btnSearchStudent.Text = "Search";
            this.btnSearchStudent.UseVisualStyleBackColor = false;
            this.btnSearchStudent.Click += new System.EventHandler(this.btnSearchStudent_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDeleteStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStudent.ForeColor = System.Drawing.Color.White;
            this.btnDeleteStudent.Location = new System.Drawing.Point(943, 337);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(75, 32);
            this.btnDeleteStudent.TabIndex = 29;
            this.btnDeleteStudent.Text = "Delete";
            this.btnDeleteStudent.UseVisualStyleBackColor = false;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // btnUpdateStudent
            // 
            this.btnUpdateStudent.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpdateStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStudent.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStudent.Location = new System.Drawing.Point(632, 337);
            this.btnUpdateStudent.Name = "btnUpdateStudent";
            this.btnUpdateStudent.Size = new System.Drawing.Size(75, 32);
            this.btnUpdateStudent.TabIndex = 29;
            this.btnUpdateStudent.Text = "Update";
            this.btnUpdateStudent.UseVisualStyleBackColor = false;
            this.btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);
            // 
            // btnInsertStudent
            // 
            this.btnInsertStudent.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnInsertStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertStudent.ForeColor = System.Drawing.Color.White;
            this.btnInsertStudent.Location = new System.Drawing.Point(473, 337);
            this.btnInsertStudent.Name = "btnInsertStudent";
            this.btnInsertStudent.Size = new System.Drawing.Size(75, 32);
            this.btnInsertStudent.TabIndex = 29;
            this.btnInsertStudent.Text = "Insert";
            this.btnInsertStudent.UseVisualStyleBackColor = false;
            this.btnInsertStudent.Click += new System.EventHandler(this.btnInsertStudent_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleDescription = "";
            this.btnExit.AccessibleName = "";
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.Location = new System.Drawing.Point(1276, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "";
            this.button1.AccessibleName = "";
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Location = new System.Drawing.Point(1230, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvStudent
            // 
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AllowUserToDeleteRows = false;
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Location = new System.Drawing.Point(6, 392);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.ReadOnly = true;
            this.dgvStudent.Size = new System.Drawing.Size(1327, 304);
            this.dgvStudent.TabIndex = 2;
            this.dgvStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellClick);
            this.dgvStudent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(154, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 100);
            this.label1.TabIndex = 1;
            this.label1.Text = "STUDENT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.btnTeacherSearch);
            this.tabPage2.Controls.Add(this.btnTeacherDelete);
            this.tabPage2.Controls.Add(this.btnTeacherUpdate);
            this.tabPage2.Controls.Add(this.btnTeacherInsert);
            this.tabPage2.Controls.Add(this.btnExit2);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.dgvTeacher);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1341, 709);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Teacher";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(1298, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 35);
            this.button2.TabIndex = 50;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnTeacherSearch
            // 
            this.btnTeacherSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTeacherSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTeacherSearch.ForeColor = System.Drawing.Color.White;
            this.btnTeacherSearch.Location = new System.Drawing.Point(1063, 285);
            this.btnTeacherSearch.Name = "btnTeacherSearch";
            this.btnTeacherSearch.Size = new System.Drawing.Size(85, 42);
            this.btnTeacherSearch.TabIndex = 30;
            this.btnTeacherSearch.Text = "Search";
            this.btnTeacherSearch.UseVisualStyleBackColor = false;
            this.btnTeacherSearch.Click += new System.EventHandler(this.btnTeacherSearch_Click);
            // 
            // btnTeacherDelete
            // 
            this.btnTeacherDelete.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTeacherDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTeacherDelete.ForeColor = System.Drawing.Color.White;
            this.btnTeacherDelete.Location = new System.Drawing.Point(1177, 285);
            this.btnTeacherDelete.Name = "btnTeacherDelete";
            this.btnTeacherDelete.Size = new System.Drawing.Size(85, 42);
            this.btnTeacherDelete.TabIndex = 31;
            this.btnTeacherDelete.Text = "Delete";
            this.btnTeacherDelete.UseVisualStyleBackColor = false;
            this.btnTeacherDelete.Click += new System.EventHandler(this.btnTeacherDelete_Click);
            // 
            // btnTeacherUpdate
            // 
            this.btnTeacherUpdate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTeacherUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTeacherUpdate.ForeColor = System.Drawing.Color.White;
            this.btnTeacherUpdate.Location = new System.Drawing.Point(948, 285);
            this.btnTeacherUpdate.Name = "btnTeacherUpdate";
            this.btnTeacherUpdate.Size = new System.Drawing.Size(85, 42);
            this.btnTeacherUpdate.TabIndex = 32;
            this.btnTeacherUpdate.Text = "Update";
            this.btnTeacherUpdate.UseVisualStyleBackColor = false;
            this.btnTeacherUpdate.Click += new System.EventHandler(this.btnTeacherUpdate_Click);
            // 
            // btnTeacherInsert
            // 
            this.btnTeacherInsert.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTeacherInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTeacherInsert.ForeColor = System.Drawing.Color.White;
            this.btnTeacherInsert.Location = new System.Drawing.Point(836, 285);
            this.btnTeacherInsert.Name = "btnTeacherInsert";
            this.btnTeacherInsert.Size = new System.Drawing.Size(85, 42);
            this.btnTeacherInsert.TabIndex = 33;
            this.btnTeacherInsert.Text = "Insert";
            this.btnTeacherInsert.UseVisualStyleBackColor = false;
            this.btnTeacherInsert.Click += new System.EventHandler(this.btnTeacherInsert_Click);
            // 
            // btnExit2
            // 
            this.btnExit2.AccessibleDescription = "";
            this.btnExit2.AccessibleName = "";
            this.btnExit2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit2.BackgroundImage")));
            this.btnExit2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit2.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit2.Location = new System.Drawing.Point(1278, 6);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(40, 40);
            this.btnExit2.TabIndex = 7;
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button4
            // 
            this.button4.AccessibleDescription = "";
            this.button4.AccessibleName = "";
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Cursor = System.Windows.Forms.Cursors.Default;
            this.button4.Location = new System.Drawing.Point(1232, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 8;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvTeacher
            // 
            this.dgvTeacher.AllowUserToAddRows = false;
            this.dgvTeacher.AllowUserToDeleteRows = false;
            this.dgvTeacher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeacher.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacher.Location = new System.Drawing.Point(6, 361);
            this.dgvTeacher.Name = "dgvTeacher";
            this.dgvTeacher.ReadOnly = true;
            this.dgvTeacher.Size = new System.Drawing.Size(1327, 335);
            this.dgvTeacher.TabIndex = 6;
            this.dgvTeacher.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeacher_CellClick);
            this.dgvTeacher.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeacher_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(3, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 60);
            this.label2.TabIndex = 5;
            this.label2.Text = "TEACHER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(259, 211);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTeacherAddress);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtTeacherID);
            this.groupBox1.Controls.Add(this.txtTeacherEmail);
            this.groupBox1.Controls.Add(this.txtTeacherPhone);
            this.groupBox1.Controls.Add(this.txtTeacherName);
            this.groupBox1.Location = new System.Drawing.Point(309, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 229);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teacher Infromation";
            // 
            // txtTeacherAddress
            // 
            this.txtTeacherAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacherAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtTeacherAddress.Location = new System.Drawing.Point(660, 51);
            this.txtTeacherAddress.Name = "txtTeacherAddress";
            this.txtTeacherAddress.Size = new System.Drawing.Size(269, 35);
            this.txtTeacherAddress.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label13.Location = new System.Drawing.Point(25, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 29);
            this.label13.TabIndex = 9;
            this.label13.Text = "TeacherID";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label31.Location = new System.Drawing.Point(522, 119);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(74, 29);
            this.label31.TabIndex = 9;
            this.label31.Text = "Email";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label30.Location = new System.Drawing.Point(25, 182);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(83, 29);
            this.label30.TabIndex = 9;
            this.label30.Text = "Phone";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label14.Location = new System.Drawing.Point(25, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 29);
            this.label14.TabIndex = 9;
            this.label14.Text = "Full Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label15.Location = new System.Drawing.Point(523, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 29);
            this.label15.TabIndex = 9;
            this.label15.Text = "Address";
            // 
            // txtTeacherID
            // 
            this.txtTeacherID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacherID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtTeacherID.Location = new System.Drawing.Point(184, 51);
            this.txtTeacherID.Name = "txtTeacherID";
            this.txtTeacherID.Size = new System.Drawing.Size(258, 35);
            this.txtTeacherID.TabIndex = 10;
            // 
            // txtTeacherEmail
            // 
            this.txtTeacherEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacherEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtTeacherEmail.Location = new System.Drawing.Point(660, 113);
            this.txtTeacherEmail.Name = "txtTeacherEmail";
            this.txtTeacherEmail.Size = new System.Drawing.Size(269, 35);
            this.txtTeacherEmail.TabIndex = 10;
            // 
            // txtTeacherPhone
            // 
            this.txtTeacherPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacherPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtTeacherPhone.Location = new System.Drawing.Point(184, 176);
            this.txtTeacherPhone.Name = "txtTeacherPhone";
            this.txtTeacherPhone.Size = new System.Drawing.Size(258, 35);
            this.txtTeacherPhone.TabIndex = 10;
            // 
            // txtTeacherName
            // 
            this.txtTeacherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtTeacherName.Location = new System.Drawing.Point(184, 113);
            this.txtTeacherName.Name = "txtTeacherName";
            this.txtTeacherName.Size = new System.Drawing.Size(258, 35);
            this.txtTeacherName.TabIndex = 10;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox4);
            this.tabPage4.Controls.Add(this.button13);
            this.tabPage4.Controls.Add(this.dgvClassSubTable);
            this.tabPage4.Controls.Add(this.btnClassSearch);
            this.tabPage4.Controls.Add(this.txtClassSubTableSearch);
            this.tabPage4.Controls.Add(this.btnClassDelete);
            this.tabPage4.Controls.Add(this.btnClassUpdate);
            this.tabPage4.Controls.Add(this.btnClassInsert);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.label28);
            this.tabPage4.Controls.Add(this.lblClass);
            this.tabPage4.Controls.Add(this.btnExit4);
            this.tabPage4.Controls.Add(this.btnLogout);
            this.tabPage4.Controls.Add(this.dgvClass);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1341, 709);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Class";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(21, 62);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(323, 245);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // button13
            // 
            this.button13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button13.BackgroundImage")));
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.Location = new System.Drawing.Point(1295, 364);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(35, 35);
            this.button13.TabIndex = 51;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button8_Click);
            // 
            // dgvClassSubTable
            // 
            this.dgvClassSubTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassSubTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvClassSubTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassSubTable.Location = new System.Drawing.Point(888, 95);
            this.dgvClassSubTable.Name = "dgvClassSubTable";
            this.dgvClassSubTable.Size = new System.Drawing.Size(430, 257);
            this.dgvClassSubTable.TabIndex = 38;
            this.dgvClassSubTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassSubTable_CellClick);
            // 
            // btnClassSearch
            // 
            this.btnClassSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClassSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnClassSearch.ForeColor = System.Drawing.Color.White;
            this.btnClassSearch.Location = new System.Drawing.Point(507, 310);
            this.btnClassSearch.Name = "btnClassSearch";
            this.btnClassSearch.Size = new System.Drawing.Size(85, 42);
            this.btnClassSearch.TabIndex = 34;
            this.btnClassSearch.Text = "Search";
            this.btnClassSearch.UseVisualStyleBackColor = false;
            // 
            // txtClassSubTableSearch
            // 
            this.txtClassSubTableSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassSubTableSearch.Location = new System.Drawing.Point(964, 60);
            this.txtClassSubTableSearch.Name = "txtClassSubTableSearch";
            this.txtClassSubTableSearch.Size = new System.Drawing.Size(354, 30);
            this.txtClassSubTableSearch.TabIndex = 10;
            // 
            // btnClassDelete
            // 
            this.btnClassDelete.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClassDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnClassDelete.ForeColor = System.Drawing.Color.White;
            this.btnClassDelete.Location = new System.Drawing.Point(784, 310);
            this.btnClassDelete.Name = "btnClassDelete";
            this.btnClassDelete.Size = new System.Drawing.Size(85, 42);
            this.btnClassDelete.TabIndex = 35;
            this.btnClassDelete.Text = "Delete";
            this.btnClassDelete.UseVisualStyleBackColor = false;
            // 
            // btnClassUpdate
            // 
            this.btnClassUpdate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClassUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnClassUpdate.ForeColor = System.Drawing.Color.White;
            this.btnClassUpdate.Location = new System.Drawing.Point(646, 310);
            this.btnClassUpdate.Name = "btnClassUpdate";
            this.btnClassUpdate.Size = new System.Drawing.Size(85, 42);
            this.btnClassUpdate.TabIndex = 36;
            this.btnClassUpdate.Text = "Update";
            this.btnClassUpdate.UseVisualStyleBackColor = false;
            // 
            // btnClassInsert
            // 
            this.btnClassInsert.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClassInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnClassInsert.ForeColor = System.Drawing.Color.White;
            this.btnClassInsert.Location = new System.Drawing.Point(363, 310);
            this.btnClassInsert.Name = "btnClassInsert";
            this.btnClassInsert.Size = new System.Drawing.Size(85, 42);
            this.btnClassInsert.TabIndex = 37;
            this.btnClassInsert.Text = "Insert";
            this.btnClassInsert.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbbClassTeacher);
            this.groupBox3.Controls.Add(this.txtClassName);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txtClassID);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Location = new System.Drawing.Point(362, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 247);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Class Information";
            // 
            // cbbClassTeacher
            // 
            this.cbbClassTeacher.FormattingEnabled = true;
            this.cbbClassTeacher.Location = new System.Drawing.Point(183, 196);
            this.cbbClassTeacher.Name = "cbbClassTeacher";
            this.cbbClassTeacher.Size = new System.Drawing.Size(281, 33);
            this.cbbClassTeacher.TabIndex = 13;
            // 
            // txtClassName
            // 
            this.txtClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassName.Location = new System.Drawing.Point(183, 118);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(281, 30);
            this.txtClassName.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 25);
            this.label19.TabIndex = 9;
            this.label19.Text = "ClassID";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 25);
            this.label20.TabIndex = 9;
            this.label20.Text = "Class Name";
            // 
            // txtClassID
            // 
            this.txtClassID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassID.Location = new System.Drawing.Point(183, 41);
            this.txtClassID.Name = "txtClassID";
            this.txtClassID.Size = new System.Drawing.Size(281, 30);
            this.txtClassID.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 201);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 25);
            this.label21.TabIndex = 9;
            this.label21.Text = "Teacher ID";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(883, 62);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(75, 25);
            this.label28.TabIndex = 9;
            this.label28.Text = "Search";
            // 
            // lblClass
            // 
            this.lblClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClass.BackColor = System.Drawing.Color.Transparent;
            this.lblClass.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.lblClass.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblClass.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClass.Location = new System.Drawing.Point(21, 310);
            this.lblClass.Name = "lblClass";
            this.lblClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblClass.Size = new System.Drawing.Size(322, 43);
            this.lblClass.TabIndex = 5;
            this.lblClass.Text = "CLASSROOM";
            this.lblClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit4
            // 
            this.btnExit4.AccessibleDescription = "";
            this.btnExit4.AccessibleName = "";
            this.btnExit4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit4.BackgroundImage")));
            this.btnExit4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit4.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit4.Location = new System.Drawing.Point(1278, 6);
            this.btnExit4.Name = "btnExit4";
            this.btnExit4.Size = new System.Drawing.Size(40, 40);
            this.btnExit4.TabIndex = 7;
            this.btnExit4.UseVisualStyleBackColor = true;
            this.btnExit4.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleDescription = "";
            this.btnLogout.AccessibleName = "";
            this.btnLogout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.BackgroundImage")));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLogout.Location = new System.Drawing.Point(1232, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(40, 40);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvClass
            // 
            this.dgvClass.AllowUserToAddRows = false;
            this.dgvClass.AllowUserToDeleteRows = false;
            this.dgvClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClass.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClass.Location = new System.Drawing.Point(8, 405);
            this.dgvClass.Name = "dgvClass";
            this.dgvClass.ReadOnly = true;
            this.dgvClass.Size = new System.Drawing.Size(1322, 291);
            this.dgvClass.TabIndex = 6;
            this.dgvClass.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClass_CellClick);
            // 
            // FacultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 754);
            this.ControlBox = false;
            this.Controls.Add(this.formClass);
            this.Name = "FacultyForm";
            this.Text = "FacultyForm";
            this.Load += new System.EventHandler(this.FacultyForm_Load);
            this.formClass.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubStudentTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassSubTable)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl formClass;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtHomeTown;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.RadioButton rbntMale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbbClass;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.PictureBox picBoxAvatar;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridView dgvSubStudentTable;
        private System.Windows.Forms.Button btnSearchStudent;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Button btnUpdateStudent;
        private System.Windows.Forms.Button btnInsertStudent;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTeacherSearch;
        private System.Windows.Forms.Button btnTeacherDelete;
        private System.Windows.Forms.Button btnTeacherUpdate;
        private System.Windows.Forms.Button btnTeacherInsert;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvTeacher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTeacherAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTeacherID;
        private System.Windows.Forms.TextBox txtTeacherEmail;
        private System.Windows.Forms.TextBox txtTeacherPhone;
        private System.Windows.Forms.TextBox txtTeacherName;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGridView dgvClassSubTable;
        private System.Windows.Forms.Button btnClassSearch;
        private System.Windows.Forms.TextBox txtClassSubTableSearch;
        private System.Windows.Forms.Button btnClassDelete;
        private System.Windows.Forms.Button btnClassUpdate;
        private System.Windows.Forms.Button btnClassInsert;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbbClassTeacher;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtClassID;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Button btnExit4;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvClass;
    }
}