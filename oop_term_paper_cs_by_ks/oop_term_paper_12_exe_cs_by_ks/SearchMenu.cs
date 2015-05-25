using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_term_paper_12_dll_cs_by_ks;

namespace oop_term_paper_12_exe_cs_by_ks
{
    class SearchMenu
    {
        private static SearchMenu searchMenu;

        public static SearchMenu GetInstance()
        {
            return (searchMenu != null) ? searchMenu : (searchMenu = new SearchMenu());
        }

        private SearchMenu()
        {

        }

        public void FindStudent()
        {
            Console.Write("Input a full name and transcript number of a student: ");
            string studentInput = Console.ReadLine();

            foreach(Group group in GroupDatabaseMenu.GetInstance().groupDatabase)
            {
                foreach(Student student in group)
                {
                    if(student.ToString().Equals(studentInput))
                    {
                        Console.WriteLine(student.ToString());
                        Console.WriteLine("Subjects:");
                        int i = 0;

                        foreach (Subject subject in student.SubjectList)
                        {
                            Console.WriteLine(++i + " " + subject.Name + " - Exam Grade: " + subject.ExamGrade);
                        }

                        int subjectRelatedChoice;

                        do
                        {
                            Console.Write("\nChoose a subject (0 - to stop): ");

                            try
                            {
                                subjectRelatedChoice = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                subjectRelatedChoice = -1;
                            }

                            if (subjectRelatedChoice < 0 || subjectRelatedChoice > student.SubjectList.Count)
                            {
                                Console.WriteLine("The argument is out of range. Try again.");
                                continue;
                            }
                            if (subjectRelatedChoice != 0)
                            {
                                Subject currentSubject = student.SubjectList[subjectRelatedChoice - 1];
                                Console.WriteLine(currentSubject.ToString());
                                int j = 0;

                                foreach (Module module in currentSubject.ModuleList)
                                {
                                    Console.WriteLine("Module " + ++j);
                                    Console.WriteLine("Module Control Work - " + module.ModuleControlWorkGrade);

                                    int k = 0;

                                    foreach (double d in module.LabWorkGradeList)
                                    {
                                        Console.WriteLine("Laboratory work " + ++k + " - " + d);
                                    }

                                    Console.WriteLine();
                                }
                            }

                        }
                        while (subjectRelatedChoice != 0);
                    }
                }
            }
        }

        public void FindSuccessfulStudentsByAverageGrade()
        {
            Console.Write("Input a rate of success: ");
            int successRate;

            try
            {
                successRate = int.Parse(Console.ReadLine());
            }
            catch
            {
                successRate = 101;
            }

            foreach (Group group in GroupDatabaseMenu.GetInstance().groupDatabase)
            {
                foreach(Student student in group)
                {
                    if(student.AverageGrade() >= successRate)
                    {
                        Console.WriteLine(student.ToString());
                    }
                }
            }
        }

        public void FindUnsuccessfulStudentsByAverageGrade()
        {
            Console.Write("Input a rate of success: ");
            int successRate;

            try
            {
                successRate = int.Parse(Console.ReadLine());
            }
            catch
            {
                successRate = 0;
            }

            foreach (Group group in GroupDatabaseMenu.GetInstance().groupDatabase)
            {
                foreach (Student student in group)
                {
                    if (student.AverageGrade() < successRate)
                    {
                        Console.WriteLine(student.ToString());
                    }
                }
            }
        }

        public void FindSuccessfulStudentsRelativeSpecificSubject()
        {
            Console.Write("Input the name of a subject: ");
            string discipline = Console.ReadLine();

            if (!SubjectRepository.GetInstance().subjectList.Exists((item) =>
                {
                    return item.Name.Equals(discipline);
                }))
            {
                Console.WriteLine("There is no such discipline.");
            }

            Console.WriteLine("Input success rate: ");
            double successRate; 

            try
            {
                successRate = double.Parse(Console.ReadLine());
            }
            catch
            {
                successRate = 101.0;
            }

            foreach (Student st in GroupDatabaseMenu.GetInstance().groupDatabase.FindSuccessfulStudentsRelativeSpecificDiscipline(discipline, successRate))
            {
                Console.WriteLine(st.ToString());
            }
        }

        public void FindUnsuccessfulStudentsRelativeSpecificSubject()
        {
            Console.Write("Input the name of a subject: ");
            string discipline = Console.ReadLine();

            if (!SubjectRepository.GetInstance().subjectList.Exists((item) =>
            {
                return item.Name.Equals(discipline);
            }))
            {
                Console.WriteLine("There is no such discipline.");
            }

            Console.WriteLine("Input success rate: ");
            double successRate;

            try
            {
                successRate = double.Parse(Console.ReadLine());
            }
            catch
            {
                successRate = 0.0;
            }

            foreach (Student st in GroupDatabaseMenu.GetInstance().groupDatabase.FindUnSuccessfulStudentsRelativeSpecificDiscipline(discipline, successRate))
            {
                Console.WriteLine(st.ToString());
            }
        }
    }
}