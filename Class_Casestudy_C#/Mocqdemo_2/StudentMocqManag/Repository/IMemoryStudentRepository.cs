using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMocqManag.Domain;
namespace StudentMocqManag.Repository
{
    public class IMemoryStudentRepository:IStudentRepository
    {
        private readonly List<Student> students = new List<Student>
        {
            new Student {RollNo=1,Name="Krishna",Email="krish@gmail.com"},
            new Student {RollNo=2,Name="Jeffin",Email="jeffin@gmail.com"}
        };

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void Update(Student student)
        {
            var existing = students.FirstOrDefault(s => s.RollNo == student.RollNo);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Email = student.Email;
            }
        }

        public void Delete(int rollNo)
        {
            var student = students.Where(s => s.RollNo == rollNo).FirstOrDefault();
            if (student != null)
            {
                students.Remove(student);
            }
        }

        public List<Student> GetAll() => students;

        public Student GetByRollNo(int rollNo) =>
           students.FirstOrDefault(s => s.RollNo == rollNo);


        public Student GetByName(string name) =>
            students.FirstOrDefault(s => s.Name.Equals(name));
    }
}
