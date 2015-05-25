using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace oop_term_paper_12_dll_cs_by_ks
{
    public static class SubjectRepository
    {
        [DataMember]
        public static List<Subject> subjectList;

        static SubjectRepository()
        {
            if (File.Exists("subjects.xml"))
            {
                var ds = new DataContractSerializer(typeof(List<Subject>));

                using (Stream s = File.OpenRead("subjects.xml"))
                {
                    subjectList = (List<Subject>)ds.ReadObject(s);
                }
            }
            else
            {
                subjectList = new List<Subject>();
            }
        }

        public static void AddSubject(Subject item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }

            if (!subjectList.Exists((currentItem) =>
                {
                    return currentItem.Name.Equals(item.Name);
                }))
            {
                subjectList.Add(item);
            }
        }

        public static bool RemoveSubject(string discipline)
        {
            if (discipline == null)
            {
                return false;
            }

            bool foundAndDeleted = true;

            if (subjectList.Exists((item) => item.Name.Equals(discipline)))
            {
                subjectList.Remove(subjectList.Find((item) =>
                {
                    return item.Name.Equals(discipline);
                }));
            }
            else
            {
                foundAndDeleted = false;
            }

            return foundAndDeleted;
        }

        public static void Save()
        {
            var ds = new DataContractSerializer(typeof(List<Subject>));

            using (Stream s = File.Create("subjects.xml"))
            {
                ds.WriteObject(s, subjectList);
            }
        }
    }
}