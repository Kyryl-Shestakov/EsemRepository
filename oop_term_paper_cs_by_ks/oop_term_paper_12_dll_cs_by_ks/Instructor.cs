using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace oop_term_paper_12_dll_cs_by_ks
{
    [DataContract]
    public class Instructor
    {
        [DataMember]
        public string firstName
        {
            get;
            private set;
        }
        [DataMember]
        public string lastName
        {
            get;
            private set;
        }

        private Instructor(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }

        public static Instructor InstructorFactory(string firstName, string lastName)
        {
            if ((firstName == null) || (lastName == null))
            {
                throw new ArgumentNullException();
            }

            if (!Regex.IsMatch(firstName, "^[A-Z][a-z]+(-[A-Z][a-z]+)?$") || !Regex.IsMatch(lastName, "^[A-Z][a-z]+(-[A-Z][a-z]+)?$"))
            {
                throw new ArgumentException("The names are wrong");
            }

            return new Instructor(firstName, lastName);
        }
    }
}