using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTestApp
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RollNo { get; set; }

    }

    public class StudentEnumerator : IEnumerator
    {
        Student[] studentArray;
        int iterator = -1;
        public StudentEnumerator(Student[] studentArray)
        {
            this.studentArray = studentArray;
        }

        public object Current
        {
            get
            {
                return studentArray[iterator];
            }
        }

        public bool MoveNext()
        {
            if (iterator < studentArray.Length)
            {
                ++iterator;
                if (studentArray[iterator] != null)
                {
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            iterator = -1;
        }
    }

    public class StudentCollection : IEnumerable
    {
        Student[] studentArray;
        int index = 0;

        public StudentCollection(int length)
        {
            studentArray = new Student[length];
        }

        public void Add(Student student)
        {
            studentArray[index] = student;
            ++index;
        }
        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(studentArray);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();
            student1.FirstName = "John";
            student1.LastName = "Doe";
            student1.RollNo = 1;

            Student student2 = new Student();
            student2.FirstName = "Joe";
            student2.LastName = "Doe";
            student2.RollNo = 2;

            StudentCollection studentCollection = new StudentCollection(5);
            studentCollection.Add(student1);
            studentCollection.Add(student2);

            foreach (Student student in studentCollection)
            {
                Console.WriteLine("Student Name:{0} and Roll No:{1}", (student.FirstName + " " + student.LastName), student.RollNo);
            }
            Console.ReadLine();
        }
    }
}
