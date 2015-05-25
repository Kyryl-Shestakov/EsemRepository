using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace oop_term_paper_12_dll_cs_by_ks
{
    [DataContract]
    public class Module
    {
        [DataMember]
        public int GradeCount
        {
            get;
            private set;
        }

        [DataMember]
        public List<double> LabWorkGradeList
        {
            get;
            private set;
        }

        [DataMember]
        public double ModuleControlWorkGrade
        {
            get;
            set;
        }

        private Module(int gradeCount, List<double> labWorkGradeList, double moduleControlWorkGrade)
        {
            GradeCount = gradeCount;
            LabWorkGradeList = labWorkGradeList;
            ModuleControlWorkGrade = moduleControlWorkGrade;
        }

        public static Module ModuleFactory(int gradeCount, List<double> labWorkGradeList, double moduleControlWorkGrade)
        {
            if (gradeCount < 1 || moduleControlWorkGrade < 0.0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (labWorkGradeList.Count != gradeCount)
            {
                throw new ArgumentException();
            }

            foreach (double grade in labWorkGradeList)
            {
                if (grade < 0.0 || grade > 5.0)
                {
                    throw new ArgumentException("The list of grades contains out-of-range values");
                }
            }

            return new Module(gradeCount, labWorkGradeList, moduleControlWorkGrade);
        }

        public double this[int index]
        {
            get
            {
                return LabWorkGradeList[index];
            }
            set
            {
                if (value < 0.0 || value > 5.0)
                {
                    throw new ArgumentOutOfRangeException("Such value is invalid for a grade");
                }

                LabWorkGradeList[index] = value;
            }
        }

        public static Module Copy(Module module)
        {
            List<double> gradeList = new List<double>();

            foreach(double d in module.LabWorkGradeList)
            {
                gradeList.Add(d);
            }

            return ModuleFactory(module.GradeCount, gradeList, module.ModuleControlWorkGrade);
        }
    }
}