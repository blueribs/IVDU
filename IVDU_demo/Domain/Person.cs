using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //This is the class
    public class Person
    {
        // This is the backing field
        int id;
        string firstName;
        string lastName;

        // This is your property
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string  LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

    }
}
