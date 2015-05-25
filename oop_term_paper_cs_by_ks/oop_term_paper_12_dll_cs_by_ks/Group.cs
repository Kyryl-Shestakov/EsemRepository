using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace oop_term_paper_12_dll_cs_by_ks
{
    [DataContract]
    public class Group : IList<Student>
    {
        [DataMember]
        public int Year
        {
            get;
            set;
        }

        [DataMember]
        public string GroupId
        {
            get;
            set;
        }

        [DataMember]
        public List<Student> StudentList
        {
            get;
            private set;
        }

        [DataMember]
        public List<string> SubjectNameList
        {
            get;
            private set;
        }

        private Group(int year, string groupId, List<Student> studentList, List<string> subjectNameList)
        {
            Year = year;
            GroupId = groupId;
            StudentList = studentList;
            SubjectNameList = subjectNameList;
        }

        public static Group GroupFactory(int year, string groupId, List<Student> studentList, List<Subject> subjectList)
        {
            List<string> subjectNameList = new List<string>();

            foreach (Subject subject in subjectList)
            {
                subjectNameList.Add(subject.Name);
            }

            return new Group(year, groupId, studentList, subjectNameList);
        }

        public void Add(Student item)
        {
            if (!StudentList.Exists((currentItem) =>
                {
                    return currentItem.TranscriptNumber.Equals(item.TranscriptNumber);
                }))
            {
                StudentList.Add(item);
            }
        }

        public void RemoveAt(int i)
        {
            StudentList.RemoveAt(i);
        }

        public void ReplaceAt(int i, Student item)
        {
            StudentList.RemoveAt(i);
            StudentList.Insert(i, item);
        }

        public int IndexOf(Student item)
        {
            foreach (Student student in StudentList)
            {
                if (student.Equals(item))
                {
                    return StudentList.IndexOf(student);
                }
            }

            throw new ArgumentException();
        }

        public void Insert(int index, Student item)
        {
            throw new NotSupportedException();
            throw new NotImplementedException();
        }

        public Student this[int index]
        {
            get
            {
                return StudentList[index];
            }
            set
            {
                throw new NotSupportedException();
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            StudentList = new List<Student>();
        }

        public bool Contains(Student item)
        {
            foreach (Student student in StudentList)
            {
                if (student.ToString().Equals(item.ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(Student[] array, int arrayIndex)
        {
            throw new NotSupportedException();
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                return StudentList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(Student item)
        {
            throw new NotSupportedException();
            throw new NotImplementedException();
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return StudentList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return GroupId + " " + Year + " year";
        }
    }
}