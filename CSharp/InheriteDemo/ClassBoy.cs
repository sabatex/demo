using System;
using System.Collections.Generic;
using System.Text;

namespace InheriteDemo
{

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBorn { get; set; }
    }

     public class ClassRoom
    {
        public Student[] classBoys;
        public string Name;
    }
}
