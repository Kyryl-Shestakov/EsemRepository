using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace oop_term_paper_12_dll_cs_by_ks
{
    [DataContract]
    public class Student : IEquatable<Student>
    {
        [DataMember]
        public string FirstName
        {
            get;
            private set;
        }

        [DataMember]
        public string LastName
        {
            get;
            private set;
        }

        [DataMember]
        public string TranscriptNumber
        {
            get;
            private set;
        }

        [DataMember]
        public List<Subject> SubjectList
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + TranscriptNumber;
        }

        public bool Equals(Student other)
        {
            return ToString().Equals(other.ToString());
        }

        private Student(string firstName, string lastName, string transcriptNumber, List<Subject> subjectList)
        {
            FirstName = firstName;
            LastName = lastName;
            TranscriptNumber = transcriptNumber;
            SubjectList = subjectList;
        }

        public static Student StudentFactory(string firstName, string lastName, string transcriptNumber, List<Subject> subjectList)
        {
            if ((firstName == null) || (lastName == null) || (transcriptNumber == null))
            {
                throw new ArgumentNullException();
            }

            if (!Regex.IsMatch(firstName, "^[A-Z][a-z]+(-[A-Z][a-z]+)?$") || !Regex.IsMatch(lastName, "^[A-Z][a-z]+(-[A-Z][a-z]+)?$") || !Regex.IsMatch(transcriptNumber, @"^[A-Z]{2}[0-9]+$"))
            {
                throw new ArgumentException();
            }

            if (subjectList == null)
            {
                subjectList = new List<Subject>();
            }

            List<Subject> newSubjectList = new List<Subject>();

            foreach(Subject s in subjectList)
            {
                newSubjectList.Add(Subject.Copy(s));
            }

            return new Student(firstName, lastName, transcriptNumber, newSubjectList);
        }

        public static bool ValidName(string name)
        {
            return Regex.IsMatch(name, "^[A-Z][a-z]+(-[A-Z][a-z]+)?$");
        }

        public static bool ValidTranscriptNumber(string transcriptNumber)
        {
            return Regex.IsMatch(transcriptNumber, @"^[A-Z]{2}\d+$");
        }

        public int AverageGrade()
        {
            int sum = 0;
            int count = 0;

            foreach(Subject s in SubjectList)
            {
                sum += s.ExamGrade;
                ++count;
            }

            return sum / count;
        }

        public Subject this[int index]
        {
            get
            {
                if (index < 0 || index >= SubjectList.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return SubjectList[index];
            }
            set
            {
                throw new NotSupportedException();
                throw new NotImplementedException();
            }
        }
    }
}