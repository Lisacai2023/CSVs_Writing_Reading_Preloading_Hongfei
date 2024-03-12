using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ClassLibrary1
{
    public class Person
    {
        string _firstName;
        string _lastName;
        string _job;

        public Person() { }

        public Person(string firstName, string lastName, string job)
        {
            _firstName=firstName;
            _lastName=lastName;
            _job=job;
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Job { get => _job; set => _job=value; }
    }
}
