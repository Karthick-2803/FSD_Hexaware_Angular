using Moq;
using System;
using StudentMocqManag.Domain;
using StudentMocqManag.Repository;
using StudentMocqManag.Business_Logic;
namespace StudentServiceTests
{
    [TestFixture]
    public class UnitTest1
    {
        private Mock<IStudentRepository> _mockRepo;
        private StudentService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IStudentRepository>();
            _service = new StudentService(_mockRepo.Object);
        }

        [Test]
        public void AddStudent_ShouldCallAdd()
        {
            var student = new Student { RollNo = 3, Name = "Palani", Email = "palani@example.com" };
            _service.AddStudent(student);
            _mockRepo.Verify(r => r.Add(It.Is<Student>(s => s.Name == "Palani")), Times.Once);
        }

        [Test]
        public void UpdateStudent_ShouldCallUpdate()
        {
            var student = new Student { RollNo = 2, Name = "Jeffin soloman", Email = "jeffinsoloman@gmail.com" };
            _service.Update(student);
            _mockRepo.Verify(r => r.Update(student), Times.Once);
        }

        [Test]
        [TestCase(3)]
        public void DeleteStudent_ShouldCallDelete(int rollNo)
        {
            _service.DeleteStudent(rollNo);
            _mockRepo.Verify(r => r.Delete(rollNo), Times.Once);
        }

        [Test]
        public void GetStudentByRollNo_ShouldReturnStudent()
        {
            var student = new Student { RollNo = 1, Name = "Krishna", Email = "krish@gmail.com"};
            _mockRepo.Setup(r => r.GetByRollNo(1)).Returns(student);

            var result = _service.GetStudentByRollNo(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Krishna", result.Name);
            _mockRepo.Verify(r => r.GetByRollNo(1), Times.Once);
        }

        [Test]
        public void GetStudentByName_ShouldReturnStudent()
        {
            var student = new Student { RollNo = 2, Name = "Jeffin soloman", Email = "jeffinsoloman@gmail.com" };
            _mockRepo.Setup(r => r.GetByName("Jeffin soloman")).Returns(student);

            var result = _service.GetStudentByName("Jeffin soloman");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.RollNo);
            _mockRepo.Verify(r => r.GetByName("Jeffin soloman"), Times.Once);
        }

        [Test]
        public void GetAllStudents_ShouldReturnAll()
        {
            var students = new List<Student>
            {
               new Student {RollNo=1,Name="Krishna",Email="krish@gmail.com"},
            new Student {RollNo=2,Name="Jeffin",Email="jeffin@gmail.com"}
            };

            _mockRepo.Setup(r => r.GetAll()).Returns(students);
            var result = _service.GetAllStudents();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Krishna", result[0].Name);
            Assert.AreEqual("Jeffin", result[1].Name);
            _mockRepo.Verify(r => r.GetAll(), Times.Once);
        }
    }
}