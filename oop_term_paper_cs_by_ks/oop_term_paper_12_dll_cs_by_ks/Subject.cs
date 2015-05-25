using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace oop_term_paper_12_dll_cs_by_ks
{
    [DataContract]
    public class Subject
    {
        [DataMember]
        public string Name
        {
            get;
            private set;
        }

        [DataMember]
        public Instructor Instructor
        {
            get;
            private set;
        }

        [DataMember]
        public int ModuleCount
        {
            get;
            private set;
        }

        [DataMember]
        public List<Module> ModuleList
        {
            get;
            private set;
        }

        [DataMember]
        public int ExamGrade
        {
            get;
            set;
        }

        private Subject(string name, Instructor instructor, int moduleCount, List<Module> moduleList, int examGrade)
        {
            Name = name;
            Instructor = instructor;
            ModuleCount = moduleCount;
            ModuleList = moduleList;
            ExamGrade = examGrade;
        }

        public static Subject SubjectFactory(string name, Instructor instructor, int moduleCount, List<Module> moduleList, int examGrade)
        {
            if (moduleCount < 1 || examGrade < 0 || examGrade > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!Regex.IsMatch(name, "^[A-Z][a-z]+( [A-Z]?[a-z]+)*$") || moduleList.Count != moduleCount)
            {
                throw new ArgumentException("Wromg discipline name");
            }

            return new Subject(name, instructor, moduleCount, moduleList, examGrade);
        }

        public double AverageGrade()
        {
            double result = 0.0;
            int count = 0;

            foreach(Module module in ModuleList)
            {
                foreach(double grade in module.LabWorkGradeList)
                {
                    result += grade;
                }

                count += module.LabWorkGradeList.Count;
            }

            return result / count;
        }

        public Module this[int index]
        {
            get
            {
                return ModuleList[index];
            }
            set
            {
                throw new NotSupportedException();
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return Name + "\n" + "Instructor: " + Instructor.ToString() + "\n" + ModuleCount + " modules";
        }

        public static Subject Copy(Subject subject)
        {
            List<Module> newModuleList = new List<Module>();

            foreach(Module m in subject.ModuleList)
            {
                newModuleList.Add(Module.Copy(m));
            }

            return SubjectFactory(subject.Name, Instructor.InstructorFactory(subject.Instructor.firstName, subject.Instructor.lastName), subject.ModuleCount, newModuleList, subject.ExamGrade);
        }
    }
}