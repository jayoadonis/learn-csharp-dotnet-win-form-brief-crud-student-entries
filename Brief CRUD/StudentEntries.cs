using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Brief_CRUD.Model;

namespace Brief_CRUD
{
    public partial class StudentEntries : Form
    {
        private IStudentRepository _repository;
        private BindingSource _bindingSource;
        private Student _currentStudent;
        private bool _isNewMode;
        private string _previousId;

        public StudentEntries()
        {
            _repository = new StudentRepository();
            _bindingSource = new BindingSource();
            InitializeComponent();
            dataGridViewDataTable.DataSource = _bindingSource;
            dataGridViewDataTable.SelectionChanged += dataGridViewDataTable_SelectionChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
        }

        private void LoadData()
        {
            try
            {
                _bindingSource.DataSource = _repository.GetAll();
                _bindingSource.ResetBindings(false);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewDataTable_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDataTable.CurrentRow != null)
            {
                string id = dataGridViewDataTable.CurrentRow.Cells["Id"].Value.ToString();
                try
                {
                    _currentStudent = _repository.GetById(id);
                    if (_currentStudent != null)
                    {
                        PopulateFields(_currentStudent);
                        _isNewMode = false;
                        btnGenerateId.Enabled = false;
                        btnUndoId.Enabled = false;
                        txtBoxId.ReadOnly = true;
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
            btnGenerateId.Enabled = false;
            btnUndoId.Enabled = false;
            txtBoxId.ReadOnly = false;
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
                MessageBox.Show("ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (string.IsNullOrEmpty(student.FirstName))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (string.IsNullOrEmpty(student.LastName))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (string.IsNullOrEmpty(student.Gender))
            {
                MessageBox.Show("Gender is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (string.IsNullOrEmpty(student.Course))
            {
                MessageBox.Show("Course is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return student;
        }

        private void btnNew_click(object sender, EventArgs e)
        {
            ClearFields();
            _isNewMode = true;
            btnGenerateId.Enabled = true;
            btnUndoId.Enabled = true;
            txtBoxId.ReadOnly = false;
        }

        private void btnInsert_click(object sender, EventArgs e)
        {
            if (_isNewMode)
            {
                var student = GetStudentFromFields();
                if (student != null)
                {
                    try
                    {
                        _repository.Insert(student);
                        MessageBox.Show("Student inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearFields();
                    }
                    catch (MySqlException ex)
                    {
                        if (ex.Number == 1062) //REM: Duplicate entry
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
            }
            else
            {
                MessageBox.Show("Use New button to create a new entry.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnUpdate_click(object sender, EventArgs e)
        {
            if (!_isNewMode && _currentStudent != null)
            {
                if (MessageBox.Show("Are you sure you want to update this student?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var student = GetStudentFromFields();
                    if (student != null)
                    {
                        student.Id = _currentStudent.Id; //REM: Ensure ID not changed
                        try
                        {
                            _repository.Update(student);
                            MessageBox.Show("Student updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearFields();
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
    }

    //REM: Repository interface (for SOLID: Dependency Inversion and Interface Segregation)
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(string id);
        void Insert(Student student);
        void Update(Student student);
        void Delete(string id);
        List<Student> Search(string query);
        string GenerateId(string course);
    }

    //REM: Concrete repository implementation (Single Responsibility: handles DB operations)
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString = "server=localhost;user=root;password=;database=brief_crud;";

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public List<Student> GetAll()
        {
            var students = new List<Student>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM students ORDER BY id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(MapReaderToStudent(reader));
                        }
                    }
                }
            }
            return students;
        }

        public Student GetById(string id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM students WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToStudent(reader);
                        }
                    }
                }
            }
            return null;
        }

        public void Insert(Student student)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO students (id, first_name, last_name, middle_name, gender, dob, course) " +
                             "VALUES (@id, @firstName, @lastName, @middleName, @gender, @dob, @course)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    AddStudentParameters(cmd, student);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Student student)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "UPDATE students SET first_name = @firstName, last_name = @lastName, " +
                             "middle_name = @middleName, gender = @gender, dob = @dob, course = @course " +
                             "WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    AddStudentParameters(cmd, student);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM students WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> Search(string query)
        {
            var students = new List<Student>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM students WHERE CONCAT(id, ' ', first_name, ' ', last_name, ' ', " +
                             "middle_name, ' ', gender, ' ', course) LIKE @query ORDER BY id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@query", "%" + query + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(MapReaderToStudent(reader));
                        }
                    }
                }
            }
            return students;
        }

        public string GenerateId(string course)
        {
            string year = DateTime.Now.Year.ToString().Substring(2);
            string prefix = $"{year}-{course}-";
            int seq = 1;
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT MAX(id) FROM students WHERE id LIKE @prefix";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@prefix", prefix + "%");
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        string maxId = result.ToString();
                        string seqStr = maxId.Substring(prefix.Length);
                        if (int.TryParse(seqStr, out int maxSeq))
                        {
                            seq = maxSeq + 1;
                        }
                    }
                }
            }
            return prefix + seq.ToString("D4");
        }

        private Student MapReaderToStudent(MySqlDataReader reader)
        {
            return new Student
            {
                Id = reader["id"].ToString(),
                FirstName = reader["first_name"].ToString(),
                LastName = reader["last_name"].ToString(),
                MiddleName = reader["middle_name"].ToString(),
                Gender = reader["gender"].ToString(),
                DoB = Convert.ToDateTime(reader["dob"]),
                Course = reader["course"].ToString()
            };
        }

        private void AddStudentParameters(MySqlCommand cmd, Student student)
        {
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@firstName", student.FirstName);
            cmd.Parameters.AddWithValue("@lastName", student.LastName);
            cmd.Parameters.AddWithValue("@middleName", student.MiddleName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@gender", student.Gender);
            cmd.Parameters.AddWithValue("@dob", student.DoB.Date);
            cmd.Parameters.AddWithValue("@course", student.Course);
        }
    }
}