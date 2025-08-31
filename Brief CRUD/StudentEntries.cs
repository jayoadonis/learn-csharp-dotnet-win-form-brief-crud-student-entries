using Brief_CRUD.Model;
using Brief_CRUD.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Brief_CRUD
{
    public partial class StudentEntries : Form
    {
        private IStudentRepository _repository;
        private BindingSource _bindingSource;
        private Student _currentStudent;
        private bool _isNewMode;
        private string _previousId;
        private bool _isRefreshing;

        public StudentEntries()
        {
            this._repository = new StudentRepository();
            this._bindingSource = new BindingSource();
            this.InitializeComponent();
            this.dataGridViewDataTable.DataSource = this._bindingSource;
            this.dataGridViewDataTable.SelectionChanged += this.dataGridViewDataTable_SelectionChanged;

            this.FormClosing += this.StudentEntries_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.ClearFields();
            this.UpdateControlStates();

            //btnIndicator.TabStop = false;
            //btnIndicator.Click += (s, _) => { /*REM: ignore */ };
            //btnIndicator.KeyDown += (s, _) => { /*REM: ignore */ };

            dataGridViewDataTable.AllowUserToAddRows = false;

            dataGridViewDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var gridFont = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular);
            dataGridViewDataTable.DefaultCellStyle.Font = gridFont;
            dataGridViewDataTable.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
            dataGridViewDataTable.RowHeadersDefaultCellStyle.Font = gridFont;

            dataGridViewDataTable.AlternatingRowsDefaultCellStyle = null;

            this.SetColumnMinimumWidths();
        }

        private void SetColumnMinimumWidths()
        {
            //REM: Assuming columns are auto-generated from Student properties: Id, FirstName, LastName, MiddleName, Gender, DoB, Course
            if (dataGridViewDataTable.Columns.Count > 0)
            {
                //REM: Set reasonable minimum widths (adjust as needed)
                dataGridViewDataTable.Columns["Id"].MinimumWidth = 150; //REM: Wider for ID
                dataGridViewDataTable.Columns["FirstName"].MinimumWidth = 200;
                dataGridViewDataTable.Columns["LastName"].MinimumWidth = 200;
                dataGridViewDataTable.Columns["MiddleName"].MinimumWidth = 200;
                dataGridViewDataTable.Columns["Gender"].MinimumWidth = 100;
                dataGridViewDataTable.Columns["DoB"].MinimumWidth = 150; //REM: Date of Birth
                dataGridViewDataTable.Columns["Course"].MinimumWidth = 100;
            }
        }

        private void LoadData()
        {
            try
            {
                _isRefreshing = true;

                string selectedId = null;
                if (dataGridViewDataTable.CurrentRow != null)
                    selectedId = dataGridViewDataTable.CurrentRow.Cells["Id"]?.Value?.ToString();

                _bindingSource.DataSource = _repository.GetAll();
                _bindingSource.ResetBindings(false);

                dataGridViewDataTable.ClearSelection();

                //if (!string.IsNullOrEmpty(selectedId))
                //{
                //    SelectRowById(selectedId); 
                //}

                btnSearch.Enabled = true;
                richTextBoxSearch.Enabled = true;
                dataGridViewDataTable.Enabled = true;
                lblIndicator.BackColor = Color.ForestGreen;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSearch.Enabled = false;
                richTextBoxSearch.Enabled = false;
                dataGridViewDataTable.Enabled = false;
                lblIndicator.BackColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSearch.Enabled = false;
                richTextBoxSearch.Enabled = false;
                dataGridViewDataTable.Enabled = false;
                lblIndicator.BackColor = Color.Red;
            }
            finally
            {
                _isRefreshing = false;
            }
        }


        private void dataGridViewDataTable_SelectionChanged(object sender, EventArgs e)
        {
            if (_isRefreshing) return;

            if (dataGridViewDataTable.CurrentRow != null)
            {
                var row = dataGridViewDataTable.CurrentRow;
                if (row == null || row.IsNewRow)
                {
                    _currentStudent = null;
                    UpdateControlStates();
                    return;
                }

                var idCell = row.Cells["Id"];
                if (idCell == null || idCell.Value == null || idCell.Value == DBNull.Value)
                {
                    _currentStudent = null;
                    UpdateControlStates();
                    return;
                }

                string id = idCell.Value.ToString();
                try
                {
                    _currentStudent = _repository.GetById(id);
                    if (_currentStudent != null)
                    {
                        PopulateFields(_currentStudent);
                        _isNewMode = false;
                        UpdateControlStates();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _currentStudent = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _currentStudent = null;
                }
            }
            else
            {
                _currentStudent = null;
                this.UpdateControlStates();
            }
        }

        private void PopulateFields(Student student)
        {
            txtBoxFirstName.Text = student.FirstName;
            txtBoxLastName.Text = student.LastName;
            txtBoxMiddleName.Text = student.MiddleName;
            radioBtnMale.Checked = student.Gender == "MALE";
            radioBtnFemale.Checked = student.Gender == "FEMALE";
            dtpDoB.Value = student.DoB;
            cBoxCourse.SelectedItem = student.Course;
            txtBoxId.Text = student.Id;
        }

        private void ClearFields()
        {
            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxMiddleName.Text = "";
            radioBtnMale.Checked = false;
            radioBtnFemale.Checked = false;
            dtpDoB.Value = DateTime.Now;
            cBoxCourse.SelectedIndex = -1;
            txtBoxId.Text = "";
            _currentStudent = null;
            _isNewMode = false;
            _previousId = "";
            this.UpdateControlStates();
        }

        private void UpdateControlStates()
        {
            bool hasData = _currentStudent != null || _isNewMode;
            bool isEditMode = !_isNewMode && _currentStudent != null;

            //REM: Form fields: Enable only in new or edit mode
            txtBoxFirstName.Enabled = hasData;
            txtBoxLastName.Enabled = hasData;
            txtBoxMiddleName.Enabled = hasData;
            radioBtnMale.Enabled = hasData;
            radioBtnFemale.Enabled = hasData;
            dtpDoB.Enabled = hasData;
            cBoxCourse.Enabled = hasData;
            txtBoxId.Enabled = _isNewMode; //REM: ID editable only in new mode

            //REM: Buttons
            btnNew.Enabled = !hasData; //REM: Enable New only when no data (cleared state)
            btnInsert.Enabled = _isNewMode;
            btnClear.Enabled = hasData;
            btnUpdate.Enabled = isEditMode;
            btnDelete.Enabled = isEditMode;
            btnGenerateId.Enabled = _isNewMode;
            btnUndoId.Enabled = _isNewMode;
            txtBoxId.ReadOnly = !_isNewMode;
            btnSearch.Enabled = richTextBoxSearch.Enabled;
            btnRefreshTable.Enabled = true;
        }

        private Student GetStudentFromFields()
        {
            var student = new Student
            {
                Id = txtBoxId.Text.Trim(),
                FirstName = txtBoxFirstName.Text.Trim(),
                LastName = txtBoxLastName.Text.Trim(),
                MiddleName = txtBoxMiddleName.Text.Trim(),
                Gender = radioBtnMale.Checked ? "MALE" : (radioBtnFemale.Checked ? "FEMALE" : null),
                DoB = dtpDoB.Value,
                Course = cBoxCourse.SelectedItem?.ToString()
            };

            if (string.IsNullOrEmpty(student.Id))
            {
                MessageBox.Show(this, "ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (string.IsNullOrEmpty(student.FirstName))
            {
                MessageBox.Show(this, "First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (string.IsNullOrEmpty(student.LastName))
            {
                MessageBox.Show(this, "Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (string.IsNullOrEmpty(student.Gender))
            {
                MessageBox.Show(this, "Gender is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (string.IsNullOrEmpty(student.Course))
            {
                MessageBox.Show(this, "Course is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return student;
        }

        private void btnNew_click(object sender, EventArgs e)
        {
            this.ClearFields();
            _isNewMode = true;
            this.UpdateControlStates();
        }

        private void btnInsert_click(object sender, EventArgs e)
        {
            if (!_isNewMode)
            {
                MessageBox.Show("Use New button to create a new entry.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var student = this.GetStudentFromFields();
            if (student == null) return;

            try
            {
                _repository.Insert(student);

                MessageBox.Show(this, "Student inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.LoadData();
                this.ClearFields();

                // Highlight the newly added row: select, scroll into view, and flash it.
                //try
                //{
                //    SelectRowById(student.Id);
                //    var row = dataGridViewDataTable.Rows
                //              .Cast<DataGridViewRow>()
                //              .FirstOrDefault(r => r.Cells["Id"]?.Value?.ToString() == student.Id);
                //    FlashRow(row, 1500); // flash for 1.5 seconds
                //}
                //catch
                //{
                //    // don't crash the app if selection/flash fails for some reason
                //}
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Duplicate entry
                {
                    MessageBox.Show("Duplicate ID. Please generate a new one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Database error inserting student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClear_click(object sender, EventArgs e)
        {
            this.ClearFields();
        }

        private void btnUpdate_click(object sender, EventArgs e)
        {
            if (!_isNewMode && _currentStudent != null)
            {
                if (MessageBox.Show("Are you sure you want to update this student?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var student = this.GetStudentFromFields();
                    if (student != null)
                    {
                        student.Id = _currentStudent.Id; //REM: Ensure ID not changed
                        try
                        {
                            _repository.Update(student);
                            MessageBox.Show("Student updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadData();
                            this.ClearFields();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Database error updating student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a student to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_click(object sender, EventArgs e)
        {
            if (_currentStudent != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        _repository.Delete(_currentStudent.Id);
                        MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearFields();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Database error deleting student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a student to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_click(object sender, EventArgs e)
        {
            string query = richTextBoxSearch.Text.Trim();
            try
            {
                if (!string.IsNullOrEmpty(query))
                {
                    _bindingSource.DataSource = _repository.Search(query);
                }
                else
                {
                    _bindingSource.DataSource = _repository.GetAll();
                }
                _bindingSource.ResetBindings(false);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIdGenerate_click(object sender, EventArgs e)
        {
            if (_isNewMode)
            {
                string course = cBoxCourse.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(course))
                {
                    MessageBox.Show("Select a course first to generate ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _previousId = txtBoxId.Text;
                try
                {
                    string newId = _repository.GenerateId(course);
                    txtBoxId.Text = newId;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIdUndo_click(object sender, EventArgs e)
        {
            if (_isNewMode)
            {
                txtBoxId.Text = _previousId;
            }
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            //REM: Empty paint handler for pnlGender
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            //REM: Empty paint handler for pnlControlId
        }

        private void pnlRoot_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefreshTable_click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void richTxtBox_keyUp(object sender, KeyEventArgs e)
        {
            this.btnSearch_click(sender, e);
        }

        //private void SelectRowById(string id)
        //{
        //    if (string.IsNullOrEmpty(id) || dataGridViewDataTable.Rows.Count == 0) return;

        //    // If bound to a BindingSource, prefer this (respects sorting/filtering)
        //    if (dataGridViewDataTable.DataSource is BindingSource bs)
        //    {
        //        int pos = bs.Find("Id", id);
        //        if (pos >= 0)
        //        {
        //            bs.Position = pos;
        //            var row = dataGridViewDataTable.Rows[pos];
        //            EnsureRowVisible(row);
        //            row.Selected = true;
        //            return;
        //        }
        //    }

        //    // Fallback: scan rows
        //    foreach (DataGridViewRow r in dataGridViewDataTable.Rows)
        //    {
        //        if (r.Cells["Id"]?.Value?.ToString() == id)
        //        {
        //            r.Selected = true;
        //            dataGridViewDataTable.CurrentCell = r.Cells[0];
        //            EnsureRowVisible(r);
        //            return;
        //        }
        //    }
        //}

        //private void EnsureRowVisible(DataGridViewRow row)
        //{
        //    if (row == null) return;
        //    try
        //    {
        //        // ensure row is the first displayed scrolling row (or at least visible)
        //        dataGridViewDataTable.FirstDisplayedScrollingRowIndex = Math.Max(0, row.Index);
        //    }
        //    catch
        //    {
        //        // ignore if invalid state
        //    }
        //}

        //private void FlashRow(DataGridViewRow row, int ms = 1200)
        //{
        //    if (row == null) return;

        //    // Save original style (clone to preserve)
        //    var original = row.DefaultCellStyle.Clone() as DataGridViewCellStyle ?? new DataGridViewCellStyle();

        //    // Create temporary flash style (subtle)
        //    var flash = new DataGridViewCellStyle(row.DefaultCellStyle)
        //    {
        //        BackColor = System.Drawing.Color.LightGreen,
        //        ForeColor = System.Drawing.Color.Black,
        //        Font = new Font(dataGridViewDataTable.DefaultCellStyle.Font, FontStyle.Bold)
        //    };

        //    row.DefaultCellStyle = flash;

        //    var t = new System.Windows.Forms.Timer();
        //    t.Interval = ms;
        //    t.Tick += (s, e) =>
        //    {
        //        t.Stop();
        //        t.Dispose();
        //        try
        //        {
        //            row.DefaultCellStyle = original;
        //        }
        //        catch { }
        //    };
        //    t.Start();
        //}

        private void StudentEntries_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If user cancels closing, set e.Cancel = true
            if (!ConfirmExitAndSaveIfNeeded())
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Returns true when it is OK to close the form (either user confirmed and saved/ignored changes).
        /// Returns false when user cancelled the close (or save failed and user cancelled).
        /// </summary>
        private bool ConfirmExitAndSaveIfNeeded()
        {
            // Detect unsaved changes
            bool hasUnsaved = _isNewMode || (_currentStudent != null && IsFormDirty());

            if (!hasUnsaved)
            {
                // no unsaved changes — simple confirm exit
                var dr = MessageBox.Show(this,
                    "Are you sure you want to exit?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                return dr == DialogResult.Yes;
            }

            // There are unsaved changes. Offer Save / Don't save / Cancel (Yes = Save, No = Don't save, Cancel = Cancel)
            var result = MessageBox.Show(this,
                "You have unsaved changes. Do you want to save them before exiting?",
                "Unsaved Changes",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Cancel)
            {
                // user cancelled exit
                return false;
            }
            else if (result == DialogResult.No)
            {
                // user chose don't save — proceed closing
                return true;
            }
            else // DialogResult.Yes -> save before exiting
            {
                // Try to save — show errors if save fails and allow user to cancel exit.
                if (SaveCurrent(out string errorMessage))
                {
                    // saved successfully
                    MessageBox.Show(this, "Changes saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // update UI if needed
                    this.LoadData();
                    this.ClearFields();
                    return true;
                }
                else
                {
                    // save failed — show message and cancel exit so user can correct
                    MessageBox.Show(this, $"Failed to save changes: {errorMessage}", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns true if the form's visible fields differ from the current student (or the new-mode defaults).
        /// Keep this conservative/simple — tweak comparisons to your needs.
        /// </summary>
        private bool IsFormDirty()
        {
            // If new mode and any field is non-empty / changed, it's dirty
            if (_isNewMode)
            {
                if (!string.IsNullOrWhiteSpace(txtBoxId.Text)) return true;
                if (!string.IsNullOrWhiteSpace(txtBoxFirstName.Text)) return true;
                if (!string.IsNullOrWhiteSpace(txtBoxLastName.Text)) return true;
                if (!string.IsNullOrWhiteSpace(txtBoxMiddleName.Text)) return true;
                if (radioBtnMale.Checked || radioBtnFemale.Checked) return true;
                if (cBoxCourse.SelectedIndex != -1) return true;
                // if DateTime default matters in your app, compare to a default value — here we assume a new form uses DateTime.Now
                return false;
            }

            // Not new mode: if no current student, nothing to compare
            if (_currentStudent == null) return false;

            // Compare trimmed strings and date only for clarity
            string formGender = radioBtnMale.Checked ? "MALE" : (radioBtnFemale.Checked ? "FEMALE" : null);
            string formCourse = cBoxCourse.SelectedItem?.ToString();

            if (txtBoxFirstName.Text.Trim() != (_currentStudent.FirstName ?? "")) return true;
            if (txtBoxLastName.Text.Trim() != (_currentStudent.LastName ?? "")) return true;
            if (txtBoxMiddleName.Text.Trim() != (_currentStudent.MiddleName ?? "")) return true;
            if (formGender != (_currentStudent.Gender ?? "")) return true;
            if (dtpDoB.Value.Date != _currentStudent.DoB.Date) return true;
            if ((formCourse ?? "") != (_currentStudent.Course ?? "")) return true;

            // ID should not be editable in edit mode; ignore it
            return false;
        }

        /// <summary>
        /// Attempts to save current visible fields either as Insert (new mode) or Update (edit mode).
        /// Returns true on success; false on failure and sets errorMessage accordingly.
        /// Does not show additional modal dialogs except error message returned to caller.
        /// </summary>
        private bool SaveCurrent(out string errorMessage)
        {
            errorMessage = null;

            // Gather student from fields — validates and shows validation modal inside GetStudentFromFields.
            var student = GetStudentFromFields();
            if (student == null)
            {
                errorMessage = "Validation failed.";
                return false;
            }

            try
            {
                if (_isNewMode)
                {
                    // Insert new record
                    _repository.Insert(student);
                    return true;
                }
                else if (_currentStudent != null)
                {
                    // Update existing record — ensure we keep original ID
                    student.Id = _currentStudent.Id;
                    _repository.Update(student);
                    return true;
                }

                // Nothing to do
                return true;
            }
            catch (MySqlException ex)
            {
                // pass meaningful message up
                errorMessage = $"Database error: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

    }

}