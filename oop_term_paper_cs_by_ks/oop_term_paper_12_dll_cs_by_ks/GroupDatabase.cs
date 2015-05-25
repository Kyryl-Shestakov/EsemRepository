using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace oop_term_paper_12_dll_cs_by_ks
{
    [DataContract] 
    public class GroupDatabase : IList<Group>
    {
        [DataMember] 
        private List<Group> groupList;

        public GroupDatabase(List<Group> groupList)
        {
            this.groupList = groupList;
        }

        public void Add(Group item)
        {
            //foreach (Group group in groupList)
            //{
            //    if (group.GroupId.Equals(item.GroupId))
            //    {
            //        throw new ArgumentException();
            //    }
            //}

            if (!groupList.Exists((currentItem) =>
                {
                    return currentItem.GroupId.Equals(item.GroupId);
                }))
            {
                groupList.Add(item);
            }   
        }

        public int IndexOf(Group item)
        {
            foreach (Group group in groupList)
            {
                if (group.GroupId.Equals(item.GroupId))
                {
                    return groupList.IndexOf(group);
                }
            }

            throw new ArgumentException();
        }

        public bool Exists(Predicate<Group> pr)
        {
            foreach(Group gr in groupList)
            {
                if(pr(gr))
                {
                    return true;
                }
            }

            return false;
        }

        public Group Find(Predicate<Group> predicate)
        {
            foreach(Group gr in groupList)
            {
                if(predicate(gr))
                {
                    return gr;
                }
            }

            return null;
        }

        public void Insert(int index, Group item)
        {
            throw new NotSupportedException();
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            groupList.RemoveAt(index);
        }

        public Group this[int index]
        {
            get
            {
                return groupList[index];
            }
            set
            {
                throw new NotSupportedException();
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            groupList = new List<Group>();
        }

        public bool Contains(Group item)
        {
            foreach (Group group in groupList)
            {
                if (group.GroupId.Equals(item.GroupId))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(Group[] array, int arrayIndex)
        {
            throw new NotSupportedException();
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                return groupList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(Group item)
        {
            foreach (Group group in groupList)
            {
                if (group.GroupId.Equals(item.GroupId))
                {
                    groupList.Remove(group);
                    return true;
                }
            }

            return false;
        }

        public bool Remove(string id)
        {
            bool foundAndDeleted = true;

            if (Exists((item) =>
            {
                return item.GroupId.Equals(id.ToString());
            }))
            {
                Remove(Find((item) =>
                {
                    return item.GroupId.Equals(id.ToString());
                }));
            }
            else
            {
                foundAndDeleted = false;
            }

            return foundAndDeleted;
        }

        public IEnumerator<Group> GetEnumerator()
        {
            return groupList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<Student> FindSuccessfulStudentsRelativeSpecificDiscipline(string discipline, double subjectSuccessRate)
        {
            List<Student> tempStudentList = new List<Student>();

            List<Group> tempGroupList = groupList.FindAll((item1) =>
                {
                    return item1.SubjectNameList.Exists((item2) =>
                    {
                        return item2.Equals(discipline);
                    });
                });

            if(tempGroupList == null)
            {
                return tempStudentList;
            }

            foreach(Group gr in tempGroupList)
            {
                foreach(Student st in gr)
                {
                    foreach(Subject subj in st.SubjectList)
                    {
                        if(subj.Name.Equals(discipline))
                        {
                            if(subj.AverageGrade() >= subjectSuccessRate)
                            {
                                tempStudentList.Add(st);
                            }
                        }
                    }
                }
            }

            return tempStudentList;
        }

        public List<Student> FindUnSuccessfulStudentsRelativeSpecificDiscipline(string discipline, double subjectSuccessRate)
        {
            List<Student> tempStudentList = new List<Student>();

            List<Group> tempGroupList = groupList.FindAll((item1) =>
            {
                return item1.SubjectNameList.Exists((item2) =>
                {
                    return item2.Equals(discipline);
                });
            });

            foreach (Group gr in tempGroupList)
            {
                foreach (Student st in gr)
                {
                    foreach (Subject subj in st.SubjectList)
                    {
                        if (subj.Name.Equals(discipline))
                        {
                            if (subj.AverageGrade() < subjectSuccessRate)
                            {
                                tempStudentList.Add(st);
                            }
                        }
                    }
                }
            }

            return tempStudentList;
        }

        public void Save(string path)
        {
            var ds = new DataContractSerializer(typeof(GroupDatabase));

            using (Stream s = File.Create(path))
            {
                ds.WriteObject(s, this);
            }
        }
    }
}