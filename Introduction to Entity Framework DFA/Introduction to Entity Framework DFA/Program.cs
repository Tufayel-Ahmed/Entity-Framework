using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_to_Entity_Framework_DFA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Show();
            Insert();
            Update();
            Delete();
            AddRangeMethod();
        }

        public static void Show()
        {
            using (EF_Demo_DBEntities1 eF_Demo_DBEntities1 = new EF_Demo_DBEntities1())
            {
                Console.WriteLine("Student Details");
                List<Student> students = eF_Demo_DBEntities1.Students.ToList();
                Console.WriteLine();
                foreach (var student in students)
                {
                    Console.WriteLine($" Name = {student.FirstName} {student.LastName}");
                }
                Console.ReadKey();
            }
        }

        public static void Insert()
        {
            using (EF_Demo_DBEntities1 eF_Demo_DBEntities1 = new EF_Demo_DBEntities1())
            {
                var student = new Student()
                {
                    FirstName = "Yousuf",
                    LastName = "Hossan",
                    StandardId = 3
                };
                eF_Demo_DBEntities1.Students.Add(student);
                eF_Demo_DBEntities1.SaveChanges();
                Console.Write("After Inserting ");
                Show();
                Console.ReadKey();
            }
        }

        public static void Update()
        {
            using (EF_Demo_DBEntities1 eF_Demo_DBEntities1 = new EF_Demo_DBEntities1())
            {
                var student = eF_Demo_DBEntities1.Students.FirstOrDefault(x => x.StudentId == 4);
                if (student != null)
                {
                    student.FirstName = "Selim";
                    student.LastName = "Reza";
                    eF_Demo_DBEntities1.SaveChanges();
                }
                Console.Write("After Updating ");
                Show();
                Console.ReadKey();
            }
        }

        public static void Delete()
        {
            using (EF_Demo_DBEntities1 eF_Demo_DBEntities1 = new EF_Demo_DBEntities1())
            {
                var student = eF_Demo_DBEntities1.Students.FirstOrDefault(x => x.StudentId == 10);
                if(student != null)
                {
                    eF_Demo_DBEntities1.Students.Remove(student);
                    eF_Demo_DBEntities1.SaveChanges();
                }
                Console.WriteLine("After Deleting ");
                Show();
                Console.ReadKey();
            }
        }

        public static void AddRangeMethod()
        {
            using (EF_Demo_DBEntities1 eF_Demo_DBEntities1 = new EF_Demo_DBEntities1())
            {
                IList<Student> students = new List<Student>()
                {
                    new Student() {FirstName = "Test1", LastName = "Test11", StandardId = 1},
                    new Student() {FirstName = "Test2", LastName = "Test22", StandardId = 2},
                    new Student() {FirstName = "Test3", LastName = "Test33", StandardId = 3}
                };
                eF_Demo_DBEntities1.Students.AddRange(students);
                eF_Demo_DBEntities1.SaveChanges();
                Console.Write("After Adding Using Range Method ");
                Show();
                Console.ReadKey();
            }
        }
    }
}
