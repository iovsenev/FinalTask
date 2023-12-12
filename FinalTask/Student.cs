using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    [Serializable]
    internal class Student
    {
        public string Name;
        public string Group;
        public DateTime DateOfBirth;

        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            dateOfBirth = dateOfBirth;
        }
    }
}
