using System.Collections.Generic;

namespace Brief_CRUD.Model
{
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
}
