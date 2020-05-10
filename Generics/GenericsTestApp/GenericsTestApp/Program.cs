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

    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }

    }

    public class StudentEnumerator<T> : IEnumerator<T>
    {
        T[] studentArray;
        int iterator = -1;

        public T Current
        {
            get
            {
                return studentArray[iterator];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public StudentEnumerator(T[] studentArray)
        {
            this.studentArray = studentArray;
        }

        public void Dispose()
        {

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

    public class GenericCollection<T> : IEnumerable<T>
    {
        T[] studentArray;
        int index = 0;

        public GenericCollection(int length)
        {
            studentArray = new T[length];
        }

        public void Add(T student)
        {
            studentArray[index] = student;
            ++index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StudentEnumerator<T>(studentArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

            GenericCollection<Student> GenericCollection = new GenericCollection<Student>(5);
            GenericCollection.Add(student1);
            GenericCollection.Add(student2);

            Employee emp = new Employee();
            emp.EmployeeId = 1;
            emp.Name = "Joey";

            GenericCollection<Employee> employeeCollection = new GenericCollection<Employee>(5);
            employeeCollection.Add(emp);


            foreach (Student student in GenericCollection)
            {
                Console.WriteLine("Student Name:{0} and Roll No:{1}", (student.FirstName + " " + student.LastName), student.RollNo);
            }

            foreach (Employee student in employeeCollection)
            {
                Console.WriteLine("Employee Name:{0} and Employee Id:{1}", emp.Name,emp.EmployeeId);
            }
            Console.ReadLine();
        }
    }
}
