

namespace Application
{
    using System.Text.Json;
    using System.IO;

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public readonly string RollNumber;
        // public string RollNumber { get; set; }
        public float Grade { get; set; }

        public Student(string RollNumber)
        {
            this.RollNumber = RollNumber;
        }

        public override string ToString()
        {
            return $"------------------------------\nRoll Number: {RollNumber}\nName: {Name}\nAge: {Age}\nGrade: {Grade}\n------------------------------";
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   string.Equals(RollNumber, student.RollNumber);
        }



    }

    public class StudentList<T>
    {
        public List<T> studentList { get; set; }

        public StudentList()
        {
            studentList = new List<T>();
        }

        public void addStudent(T student)
        {
            studentList.Add(student);
        }

        public void removeStudent(T student)
        {
            studentList.Remove(student);
        }

        public List<T> getStudents()
        {
            return studentList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in studentList)
            {
                yield return t;
            }
        }

        // public IEnumerable<T> searchById(string rollNumber)
        // {
        //     return from student in studentList
        //            where student.RollNumber == rollNumber
        //            select student;
        // }

        // public IEnumerable<T> searchByName(string name)
        // {
        //     return from student in studentList
        //            where student.Name == name
        //            select student;
        // }




    }
    public class Program
    {
        public static async Task Main(string[] args)
        {
            StudentList<Student> studentList = new StudentList<Student>();
            // studentList.addStudent(new Student("1") { Name = "Yohannes", Age = 22, Grade = 3.0f });
            // studentList.addStudent(new Student("2") { Name = "Joh", Age = 22, Grade = 3.4f });
            // studentList.addStudent(new Student("3") { Name = "Mike", Age = 22, Grade = 3.4f });


            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Choose A Number");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. List Students");
                Console.WriteLine("3. Remove Student");
                Console.WriteLine("4. Search by Roll Number for Student");
                Console.WriteLine("5. Search by Name for Student");
                Console.WriteLine("6. Serialize to JSON");
                Console.WriteLine("7. Deserialize From Json");
                Console.WriteLine("8. Exit");

                string Choose = Console.ReadLine();

                switch (Choose)
                {
                    case "1":
                        Console.WriteLine("Enter Roll Number");
                        string RollNumber = Console.ReadLine();
                        Console.WriteLine("Enter Name");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Enter Age");
                        int Age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Grade");
                        float Grade = float.Parse(Console.ReadLine());
                        studentList.addStudent(new Student(RollNumber) { Name = Name, Age = Age, Grade = Grade });
                        break;
                    case "2":
                        foreach (Student student in studentList)
                        {
                            Console.WriteLine(student);

                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter Roll Number");
                        RollNumber = Console.ReadLine();
                        studentList.removeStudent(new Student(RollNumber));

                        break;
                    case "4":
                        Console.WriteLine("Enter Roll Number");
                        RollNumber = Console.ReadLine();

                        IEnumerable<Student> searchResultStudent = from student in studentList.getStudents()
                                                                   where student.RollNumber == RollNumber
                                                                   select student;
                        foreach (Student student in searchResultStudent)
                        {
                            Console.WriteLine(student);
                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter Name");
                        Name = Console.ReadLine();

                        IEnumerable<Student> searchResultStudent1 = from student in studentList.getStudents()
                                                                    where student.Name == Name
                                                                    select student;

                        foreach (Student student in searchResultStudent1)
                        {
                            Console.WriteLine(student);
                        }
                        break;
                    case "6":
                        try
                        {

                            string fileName = "student.json";
                            using FileStream createStream = File.Create(fileName);
                            await JsonSerializer.SerializeAsync<StudentList<Student>>(createStream, studentList);
                            await createStream.DisposeAsync();


                            Console.WriteLine(File.ReadAllText(fileName));


                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Error");
                        }
                        break;
                    case "7":
                        try
                        {
                            string fileName = "student.json";
                            using FileStream createStream = File.Open(fileName, FileMode.Open);
                            studentList = await JsonSerializer.DeserializeAsync<StudentList<Student>>(createStream);
                            await createStream.DisposeAsync();

                            foreach (Student student in studentList)
                            {
                                Console.WriteLine(student);
                            }
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Error");
                        }
                        break;
                    case "8":
                        quit = true;
                        break;
                }
            }

        }
    }
}
