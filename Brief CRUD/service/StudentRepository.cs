using Brief_CRUD.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Brief_CRUD.Service
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connection = "server=localhost;user=root;password=;database=brief_crud;";

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(this._connection);
        }

        public List<Student> GetAll()
        {
            var students = new List<Student>();
            using (var conn = this.GetConnection())
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
            using (var conn = this.GetConnection())
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
                            return this.MapReaderToStudent(reader);
                        }
                    }
                }
            }
            return null;
        }

        public void Insert(Student student)
        {
            using (var conn = this.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO students (id, first_name, last_name, middle_name, gender, dob, course) " +
                             "VALUES (@id, @firstName, @lastName, @middleName, @gender, @dob, @course)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    this.AddStudentParameters(cmd, student);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Student student)
        {
            using (var conn = this.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE students SET first_name = @firstName, last_name = @lastName, " +
                             "middle_name = @middleName, gender = @gender, dob = @dob, course = @course " +
                             "WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    this.AddStudentParameters(cmd, student);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string id)
        {
            using (var conn = this.GetConnection())
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
            using (var conn = this.GetConnection())
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
                            students.Add(this.MapReaderToStudent(reader));
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
            using (var conn = this.GetConnection())
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
