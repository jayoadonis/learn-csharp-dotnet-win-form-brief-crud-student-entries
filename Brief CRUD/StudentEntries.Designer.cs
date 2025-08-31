namespace Brief_CRUD
{
    partial class StudentEntries
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
            System.Windows.Forms.Label lblTitle;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentEntries));
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.SplitContainer();
            this.tblForm = new System.Windows.Forms.TableLayoutPanel();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtBoxFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtBoxLastName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtBoxMiddleName = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.pnlGender = new System.Windows.Forms.FlowLayoutPanel();
            this.radioBtnMale = new System.Windows.Forms.RadioButton();
            this.radioBtnFemale = new System.Windows.Forms.RadioButton();
            this.lblDoB = new System.Windows.Forms.Label();
            this.dtpDoB = new System.Windows.Forms.DateTimePicker();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cBoxCourse = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.tblId = new System.Windows.Forms.TableLayoutPanel();
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.pnlControlId = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerateId = new System.Windows.Forms.Button();
            this.pnlBlankDivider = new System.Windows.Forms.Panel();
            this.btnUndoId = new System.Windows.Forms.Button();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.dataGridViewDataTable = new System.Windows.Forms.DataGridView();
            this.pnlSearchBar = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBoxSearch = new System.Windows.Forms.RichTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefreshTable = new System.Windows.Forms.Button();
            this.lblIndicator = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            this.pnlRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            this.pnlContent.Panel1.SuspendLayout();
            this.pnlContent.Panel2.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tblForm.SuspendLayout();
            this.pnlGender.SuspendLayout();
            this.tblId.SuspendLayout();
            this.pnlControlId.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataTable)).BeginInit();
            this.pnlSearchBar.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(884, 37);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Student Entries";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRoot
            // 
            this.pnlRoot.AutoScroll = true;
            this.pnlRoot.Controls.Add(this.pnlContent);
            this.pnlRoot.Controls.Add(this.pnlFooter);
            this.pnlRoot.Controls.Add(this.pnlHeader);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(15);
            this.pnlRoot.Size = new System.Drawing.Size(914, 654);
            this.pnlRoot.TabIndex = 15;
            this.pnlRoot.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRoot_Paint);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 92);
            this.pnlContent.Name = "pnlContent";
            // 
            // pnlContent.Panel1
            // 
            this.pnlContent.Panel1.Controls.Add(this.tblForm);
            this.pnlContent.Panel1MinSize = 335;
            // 
            // pnlContent.Panel2
            // 
            this.pnlContent.Panel2.Controls.Add(this.pnlTable);
            this.pnlContent.Panel2.Controls.Add(this.pnlSearchBar);
            this.pnlContent.Size = new System.Drawing.Size(884, 447);
            this.pnlContent.SplitterDistance = 351;
            this.pnlContent.SplitterWidth = 8;
            this.pnlContent.TabIndex = 0;
            // 
            // tblForm
            // 
            this.tblForm.AutoScroll = true;
            this.tblForm.AutoSize = true;
            this.tblForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblForm.BackColor = System.Drawing.Color.Gainsboro;
            this.tblForm.ColumnCount = 2;
            this.tblForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tblForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblForm.Controls.Add(this.lblFirstName, 0, 0);
            this.tblForm.Controls.Add(this.txtBoxFirstName, 1, 0);
            this.tblForm.Controls.Add(this.lblLastName, 0, 1);
            this.tblForm.Controls.Add(this.txtBoxLastName, 1, 1);
            this.tblForm.Controls.Add(this.lblMiddleName, 0, 2);
            this.tblForm.Controls.Add(this.txtBoxMiddleName, 1, 2);
            this.tblForm.Controls.Add(this.lblGender, 0, 3);
            this.tblForm.Controls.Add(this.pnlGender, 1, 3);
            this.tblForm.Controls.Add(this.lblDoB, 0, 4);
            this.tblForm.Controls.Add(this.dtpDoB, 1, 4);
            this.tblForm.Controls.Add(this.lblCourse, 0, 5);
            this.tblForm.Controls.Add(this.cBoxCourse, 1, 5);
            this.tblForm.Controls.Add(this.lblId, 0, 6);
            this.tblForm.Controls.Add(this.tblId, 1, 6);
            this.tblForm.Controls.Add(this.pnlControlId, 1, 7);
            this.tblForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblForm.Location = new System.Drawing.Point(0, 0);
            this.tblForm.Name = "tblForm";
            this.tblForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tblForm.RowCount = 9;
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblForm.Size = new System.Drawing.Size(351, 447);
            this.tblForm.TabIndex = 3;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(0, 12);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(0, 12, 8, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(102, 29);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxFirstName
            // 
            this.txtBoxFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFirstName.Location = new System.Drawing.Point(118, 12);
            this.txtBoxFirstName.Margin = new System.Windows.Forms.Padding(8, 12, 8, 0);
            this.txtBoxFirstName.MinimumSize = new System.Drawing.Size(200, 4);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.Size = new System.Drawing.Size(225, 29);
            this.txtBoxFirstName.TabIndex = 8;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(0, 53);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(0, 12, 8, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(102, 29);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxLastName
            // 
            this.txtBoxLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxLastName.Location = new System.Drawing.Point(118, 53);
            this.txtBoxLastName.Margin = new System.Windows.Forms.Padding(8, 12, 8, 0);
            this.txtBoxLastName.MinimumSize = new System.Drawing.Size(200, 4);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.Size = new System.Drawing.Size(225, 29);
            this.txtBoxLastName.TabIndex = 9;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleName.Location = new System.Drawing.Point(0, 94);
            this.lblMiddleName.Margin = new System.Windows.Forms.Padding(0, 12, 8, 0);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(102, 29);
            this.lblMiddleName.TabIndex = 2;
            this.lblMiddleName.Text = "Middle Name";
            this.lblMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxMiddleName
            // 
            this.txtBoxMiddleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMiddleName.Location = new System.Drawing.Point(118, 94);
            this.txtBoxMiddleName.Margin = new System.Windows.Forms.Padding(8, 12, 8, 0);
            this.txtBoxMiddleName.MinimumSize = new System.Drawing.Size(200, 4);
            this.txtBoxMiddleName.Name = "txtBoxMiddleName";
            this.txtBoxMiddleName.Size = new System.Drawing.Size(225, 29);
            this.txtBoxMiddleName.TabIndex = 10;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(0, 135);
            this.lblGender.Margin = new System.Windows.Forms.Padding(0, 12, 8, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(102, 28);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Gender";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlGender
            // 
            this.pnlGender.AutoSize = true;
            this.pnlGender.Controls.Add(this.radioBtnMale);
            this.pnlGender.Controls.Add(this.radioBtnFemale);
            this.pnlGender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGender.Location = new System.Drawing.Point(118, 135);
            this.pnlGender.Margin = new System.Windows.Forms.Padding(8, 12, 8, 0);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(225, 28);
            this.pnlGender.TabIndex = 17;
            this.pnlGender.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel3_Paint);
            // 
            // radioBtnMale
            // 
            this.radioBtnMale.AutoSize = true;
            this.radioBtnMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnMale.Location = new System.Drawing.Point(0, 0);
            this.radioBtnMale.Margin = new System.Windows.Forms.Padding(0);
            this.radioBtnMale.Name = "radioBtnMale";
            this.radioBtnMale.Size = new System.Drawing.Size(84, 28);
            this.radioBtnMale.TabIndex = 2;
            this.radioBtnMale.TabStop = true;
            this.radioBtnMale.Text = "MALE";
            this.radioBtnMale.UseVisualStyleBackColor = true;
            // 
            // radioBtnFemale
            // 
            this.radioBtnFemale.AutoSize = true;
            this.radioBtnFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnFemale.Location = new System.Drawing.Point(96, 0);
            this.radioBtnFemale.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.radioBtnFemale.Name = "radioBtnFemale";
            this.radioBtnFemale.Size = new System.Drawing.Size(111, 28);
            this.radioBtnFemale.TabIndex = 3;
            this.radioBtnFemale.TabStop = true;
            this.radioBtnFemale.Text = "FEMALE";
            this.radioBtnFemale.UseVisualStyleBackColor = true;
            // 
            // lblDoB
            // 
            this.lblDoB.AutoSize = true;
            this.lblDoB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoB.Location = new System.Drawing.Point(0, 175);
            this.lblDoB.Margin = new System.Windows.Forms.Padding(0, 12, 8, 0);
            this.lblDoB.Name = "lblDoB";
            this.lblDoB.Size = new System.Drawing.Size(102, 29);
            this.lblDoB.TabIndex = 6;
            this.lblDoB.Text = "Date of Birth";
            this.lblDoB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDoB
            // 
            this.dtpDoB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDoB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDoB.Location = new System.Drawing.Point(118, 175);
            this.dtpDoB.Margin = new System.Windows.Forms.Padding(8, 12, 8, 0);
            this.dtpDoB.MinimumSize = new System.Drawing.Size(200, 4);
            this.dtpDoB.Name = "dtpDoB";
            this.dtpDoB.Size = new System.Drawing.Size(225, 29);
            this.dtpDoB.TabIndex = 12;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.Location = new System.Drawing.Point(8, 236);
            this.lblCourse.Margin = new System.Windows.Forms.Padding(8, 32, 8, 0);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(94, 32);
            this.lblCourse.TabIndex = 7;
            this.lblCourse.Text = "Course";
            this.lblCourse.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cBoxCourse
            // 
            this.cBoxCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBoxCourse.DropDownWidth = 114;
            this.cBoxCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxCourse.FormattingEnabled = true;
            this.cBoxCourse.Items.AddRange(new object[] {
            "BSIT",
            "BSIS",
            "BSCS",
            "BSCE",
            "BSED"});
            this.cBoxCourse.Location = new System.Drawing.Point(118, 236);
            this.cBoxCourse.Margin = new System.Windows.Forms.Padding(8, 32, 8, 0);
            this.cBoxCourse.MinimumSize = new System.Drawing.Size(200, 0);
            this.cBoxCourse.Name = "cBoxCourse";
            this.cBoxCourse.Size = new System.Drawing.Size(225, 32);
            this.cBoxCourse.TabIndex = 11;
            this.cBoxCourse.Text = "- - -";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(8, 280);
            this.lblId.Margin = new System.Windows.Forms.Padding(8, 12, 8, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(94, 35);
            this.lblId.TabIndex = 15;
            this.lblId.Text = "ID";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tblId
            // 
            this.tblId.AutoSize = true;
            this.tblId.ColumnCount = 2;
            this.tblId.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblId.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblId.Controls.Add(this.txtBoxId, 0, 0);
            this.tblId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblId.Location = new System.Drawing.Point(113, 271);
            this.tblId.MinimumSize = new System.Drawing.Size(200, 0);
            this.tblId.Name = "tblId";
            this.tblId.RowCount = 1;
            this.tblId.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblId.Size = new System.Drawing.Size(235, 41);
            this.tblId.TabIndex = 16;
            // 
            // txtBoxId
            // 
            this.txtBoxId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxId.Location = new System.Drawing.Point(8, 12);
            this.txtBoxId.Margin = new System.Windows.Forms.Padding(8, 12, 8, 0);
            this.txtBoxId.MinimumSize = new System.Drawing.Size(200, 4);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(200, 29);
            this.txtBoxId.TabIndex = 15;
            // 
            // pnlControlId
            // 
            this.pnlControlId.Controls.Add(this.btnGenerateId);
            this.pnlControlId.Controls.Add(this.pnlBlankDivider);
            this.pnlControlId.Controls.Add(this.btnUndoId);
            this.pnlControlId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControlId.Location = new System.Drawing.Point(118, 315);
            this.pnlControlId.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlControlId.Name = "pnlControlId";
            this.pnlControlId.Size = new System.Drawing.Size(233, 100);
            this.pnlControlId.TabIndex = 18;
            this.pnlControlId.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel4_Paint);
            // 
            // btnGenerateId
            // 
            this.btnGenerateId.AutoSize = true;
            this.btnGenerateId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerateId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateId.Location = new System.Drawing.Point(0, 0);
            this.btnGenerateId.Margin = new System.Windows.Forms.Padding(0);
            this.btnGenerateId.MaximumSize = new System.Drawing.Size(0, 50);
            this.btnGenerateId.MinimumSize = new System.Drawing.Size(94, 0);
            this.btnGenerateId.Name = "btnGenerateId";
            this.btnGenerateId.Size = new System.Drawing.Size(98, 34);
            this.btnGenerateId.TabIndex = 0;
            this.btnGenerateId.Text = "Generate";
            this.btnGenerateId.UseVisualStyleBackColor = true;
            this.btnGenerateId.Click += new System.EventHandler(this.btnIdGenerate_click);
            // 
            // pnlBlankDivider
            // 
            this.pnlBlankDivider.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBlankDivider.Location = new System.Drawing.Point(101, 3);
            this.pnlBlankDivider.MaximumSize = new System.Drawing.Size(5, 5);
            this.pnlBlankDivider.MinimumSize = new System.Drawing.Size(5, 5);
            this.pnlBlankDivider.Name = "pnlBlankDivider";
            this.pnlBlankDivider.Size = new System.Drawing.Size(5, 5);
            this.pnlBlankDivider.TabIndex = 2;
            // 
            // btnUndoId
            // 
            this.btnUndoId.AutoSize = true;
            this.btnUndoId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUndoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndoId.Location = new System.Drawing.Point(109, 0);
            this.btnUndoId.Margin = new System.Windows.Forms.Padding(0);
            this.btnUndoId.MaximumSize = new System.Drawing.Size(0, 50);
            this.btnUndoId.MinimumSize = new System.Drawing.Size(94, 0);
            this.btnUndoId.Name = "btnUndoId";
            this.btnUndoId.Size = new System.Drawing.Size(94, 34);
            this.btnUndoId.TabIndex = 1;
            this.btnUndoId.Text = "Undo";
            this.btnUndoId.UseVisualStyleBackColor = true;
            this.btnUndoId.Click += new System.EventHandler(this.btnIdUndo_click);
            // 
            // pnlTable
            // 
            this.pnlTable.AutoScroll = true;
            this.pnlTable.Controls.Add(this.dataGridViewDataTable);
            this.pnlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTable.Location = new System.Drawing.Point(0, 44);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(525, 403);
            this.pnlTable.TabIndex = 1;
            // 
            // dataGridViewDataTable
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewDataTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDataTable.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDataTable.Name = "dataGridViewDataTable";
            this.dataGridViewDataTable.Size = new System.Drawing.Size(525, 403);
            this.dataGridViewDataTable.TabIndex = 1;
            // 
            // pnlSearchBar
            // 
            this.pnlSearchBar.AutoSize = true;
            this.pnlSearchBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSearchBar.Controls.Add(this.richTextBoxSearch);
            this.pnlSearchBar.Controls.Add(this.btnSearch);
            this.pnlSearchBar.Controls.Add(this.btnRefreshTable);
            this.pnlSearchBar.Controls.Add(this.lblIndicator);
            this.pnlSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchBar.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlSearchBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchBar.Name = "pnlSearchBar";
            this.pnlSearchBar.Size = new System.Drawing.Size(525, 44);
            this.pnlSearchBar.TabIndex = 0;
            // 
            // richTextBoxSearch
            // 
            this.richTextBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxSearch.Location = new System.Drawing.Point(212, 4);
            this.richTextBoxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.richTextBoxSearch.Name = "richTextBoxSearch";
            this.richTextBoxSearch.Size = new System.Drawing.Size(310, 26);
            this.richTextBoxSearch.TabIndex = 0;
            this.richTextBoxSearch.Text = "";
            this.richTextBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTxtBox_keyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(102, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 38);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_click);
            // 
            // btnRefreshTable
            // 
            this.btnRefreshTable.AutoSize = true;
            this.btnRefreshTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefreshTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshTable.Image = global::Brief_CRUD.Properties.Resources.refresh_page_option;
            this.btnRefreshTable.Location = new System.Drawing.Point(58, 3);
            this.btnRefreshTable.Name = "btnRefreshTable";
            this.btnRefreshTable.Size = new System.Drawing.Size(38, 38);
            this.btnRefreshTable.TabIndex = 2;
            this.btnRefreshTable.UseVisualStyleBackColor = true;
            this.btnRefreshTable.Click += new System.EventHandler(this.btnRefreshTable_click);
            // 
            // lblIndicator
            // 
            this.lblIndicator.AutoSize = true;
            this.lblIndicator.BackColor = System.Drawing.Color.Gold;
            this.lblIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIndicator.Location = new System.Drawing.Point(12, 8);
            this.lblIndicator.Margin = new System.Windows.Forms.Padding(8);
            this.lblIndicator.MinimumSize = new System.Drawing.Size(35, 0);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(35, 28);
            this.lblIndicator.TabIndex = 3;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.pnlControl);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(15, 539);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(884, 100);
            this.pnlFooter.TabIndex = 0;
            // 
            // pnlControl
            // 
            this.pnlControl.AutoScroll = true;
            this.pnlControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlControl.Controls.Add(this.btnNew);
            this.pnlControl.Controls.Add(this.btnInsert);
            this.pnlControl.Controls.Add(this.btnClear);
            this.pnlControl.Controls.Add(this.btnUpdate);
            this.pnlControl.Controls.Add(this.btnDelete);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(884, 100);
            this.pnlControl.TabIndex = 4;
            this.pnlControl.WrapContents = false;
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = true;
            this.btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(8, 18);
            this.btnNew.Margin = new System.Windows.Forms.Padding(8, 18, 14, 3);
            this.btnNew.MinimumSize = new System.Drawing.Size(120, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 34);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_click);
            // 
            // btnInsert
            // 
            this.btnInsert.AutoSize = true;
            this.btnInsert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(150, 18);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(8, 18, 14, 3);
            this.btnInsert.MinimumSize = new System.Drawing.Size(120, 0);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(120, 34);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "INSERT";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_click);
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(292, 18);
            this.btnClear.Margin = new System.Windows.Forms.Padding(8, 18, 14, 3);
            this.btnClear.MinimumSize = new System.Drawing.Size(120, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 34);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(434, 18);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(8, 18, 14, 3);
            this.btnUpdate.MinimumSize = new System.Drawing.Size(120, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 34);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(576, 18);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(8, 18, 14, 3);
            this.btnDelete.MinimumSize = new System.Drawing.Size(120, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 34);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Silver;
            this.pnlHeader.Controls.Add(lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(15, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlHeader.Size = new System.Drawing.Size(884, 77);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.Location = new System.Drawing.Point(0, 37);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(884, 20);
            this.lblSubTitle.TabIndex = 4;
            this.lblSubTitle.Text = "Brief CRUD Activity";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StudentEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(914, 654);
            this.Controls.Add(this.pnlRoot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "StudentEntries";
            this.Text = "Student Entries (Brief CRUD Activity)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlRoot.ResumeLayout(false);
            this.pnlContent.Panel1.ResumeLayout(false);
            this.pnlContent.Panel1.PerformLayout();
            this.pnlContent.Panel2.ResumeLayout(false);
            this.pnlContent.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.tblForm.ResumeLayout(false);
            this.tblForm.PerformLayout();
            this.pnlGender.ResumeLayout(false);
            this.pnlGender.PerformLayout();
            this.tblId.ResumeLayout(false);
            this.tblId.PerformLayout();
            this.pnlControlId.ResumeLayout(false);
            this.pnlControlId.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataTable)).EndInit();
            this.pnlSearchBar.ResumeLayout(false);
            this.pnlSearchBar.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.SplitContainer pnlContent;
        private System.Windows.Forms.TableLayoutPanel tblForm;
        private System.Windows.Forms.TextBox txtBoxFirstName;
        private System.Windows.Forms.DateTimePicker dtpDoB;
        private System.Windows.Forms.TextBox txtBoxMiddleName;
        private System.Windows.Forms.ComboBox cBoxCourse;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDoB;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtBoxLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.FlowLayoutPanel pnlSearchBar;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.FlowLayoutPanel pnlControl;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.DataGridView dataGridViewDataTable;
        private System.Windows.Forms.RichTextBox richTextBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TableLayoutPanel tblId;
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.FlowLayoutPanel pnlGender;
        private System.Windows.Forms.RadioButton radioBtnFemale;
        private System.Windows.Forms.RadioButton radioBtnMale;
        private System.Windows.Forms.Button btnGenerateId;
        private System.Windows.Forms.Button btnUndoId;
        private System.Windows.Forms.FlowLayoutPanel pnlControlId;
        private System.Windows.Forms.Panel pnlBlankDivider;
        private System.Windows.Forms.Button btnRefreshTable;
        private System.Windows.Forms.Label lblIndicator;
    }
}

