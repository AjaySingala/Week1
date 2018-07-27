using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousTypes
{
    class Program
    {

        // REMEMBER:
        // 1. Anonymous type can be defined using the new keyword and object initializer syntax.
        // 2. The implicitly typed variable- var, is used to hold an anonymous type.
        // 3. Anonymous type is a reference type and all the properties are read-only.
        // 4. The scope of an anonymous type is local to the method where it is defined.
        static void Main(string[] args)
        {
            var anon = new
            {
                FirstProperty = "Ajay Singala",
                SecondProperty = 125,
                ThirdProperty = true

                // Nested Anon Properties
                , NestedAnonProperty = new { Id = 101, Name = "John Smith" }
                , AStudent = new Student { StudentID = 10, StudentName = "Ajay" }
            };

            foo(anon);

            // Anon with LINQ
            AnonWithLINQ();
        }

        static void foo(dynamic param)
        {
            Console.WriteLine($"{param.FirstProperty}");
            Console.WriteLine($"{param.SecondProperty}");
            Console.WriteLine($"{param.ThirdProperty}");
            Console.WriteLine($"{param.NestedAnonProperty.Name}");
            Console.WriteLine($"{param.AStudent.StudentName}");
        }

        static void AnonWithLINQ()
        {
            IList<Student> studentList = new List<Student>() {
                        new Student() { StudentID = 1, StudentName = "John", age = 18, City = "New York" } ,
                        new Student() { StudentID = 2, StudentName = "Steve",  age = 21, City = "Dallas" } ,
                        new Student() { StudentID = 3, StudentName = "Bill",  age = 18, City = "Chicago" } ,
                        new Student() { StudentID = 4, StudentName = "Ram" , age = 20, City = "Boston"  } ,
                        new Student() { StudentID = 5, StudentName = "Ron" , age = 21, City = "New York" }
                    };

            var studentNames = from s in studentList
                               select new
                               {
                                   StudentID = s.StudentID,
                                   StudentName = s.StudentName
                               };
            foreach(var student in studentNames)
            {
                Console.WriteLine(student.StudentName);
            }

            var names = studentList
                .Where(s => s.City == "New York")
                .ToList();
            foreach(var student in names)
            {
                Console.WriteLine($"{student.StudentName}, {student.City}");
            }

            var names2 = from s in studentList
                            where s.City == "Dallas"
                            select s;
            foreach(var student in names2)
            {
                Console.WriteLine($"{student.StudentName}, {student.City}");
            }

            var names3 = studentList
                .Where(s => s.City == "New York")
                .Select(item => new 
                {
                    City = item.City,
                    Name = item.StudentName
                })
                //.Select(s => s.StudentName)
                .ToList();
            Console.WriteLine("Only names / cities");
            foreach(var student in names3)
            {
                //Console.WriteLine($"{student}");
                Console.WriteLine($"{student.Name} is from {student.City}");
            }

        }
    }
}
