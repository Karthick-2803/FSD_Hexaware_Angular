namespace Collections
{
    class Student
    {
        public int id {  get; set; }
        public string name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           List<Student> student = new List<Student>();

            //add
            student.Add(new Student { id = 1, name = "Karthick" });
            student.Add(new Student { id = 2, name = "Krishna" });
            student.Add(new Student { id = 3, name = "Jeffin" });

            //display all students:
            Console.WriteLine("All the students:");
            foreach(var students in student)
            {
                Console.WriteLine($"Id:{students.id},Name : {students.name}");
            }

            //search:
            Console.WriteLine("Enter the name to search:");
            string searchName = Console.ReadLine();
            var found = student.FirstOrDefault(s => s.name.Equals(searchName,StringComparison.OrdinalIgnoreCase));

            if(found != null)
            {
                Console.WriteLine($"Id:{found.id},Name:{found.name}");
            }
            else
            {
                Console.WriteLine("Nt found");
            }

            Console.WriteLine("Enter the name to remove:");
            string removeName = Console.ReadLine();
            var remove = student.FirstOrDefault(s => s.name.Equals(removeName, StringComparison.OrdinalIgnoreCase));

            if (remove != null)
            {
                student.Remove(remove);
                Console.WriteLine("removed sucessfully");
            }
            else
            {
                Console.WriteLine("Nt found");
            }

            Console.WriteLine("\nUpdated List of Students:");
            foreach (var students in student)
            {
                Console.WriteLine($"ID: {students.id}, Name: {students.name}");
            }

            // Count of total students
            Console.WriteLine($"\nTotal number of students: {student.Count}");


        }
    }
}
