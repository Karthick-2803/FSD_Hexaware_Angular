using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMocqManag.Domain;
using StudentMocqManag.Repository;

namespace StudentMocqManag.Business_Logic
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            this._repository = repository;
        }

        public void AddStudent(Student student)
        {
            if(student!=null)
            {
                _repository.Add(student);
            }
        }

        public void Update(Student student)
        {
            if (student != null)
            {
                _repository.Update(student);
            }
        }

        public void DeleteStudent(int rollNo)
        {
            if (rollNo > 0)
                _repository.Delete(rollNo);
        }

        public Student GetStudentByRollNo(int rollNo)
        {
            if (rollNo> 0)
            {
                var stu = _repository.GetByRollNo(rollNo);
                return stu;
            }
            else
            {
                return null;
            }
        }

        public Student GetStudentByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var stu = _repository.GetByName(name);
                return stu;
            }
            else
            {
                return null;
            }
        }
        public List<Student> GetAllStudents() => _repository.GetAll();
    }
}
