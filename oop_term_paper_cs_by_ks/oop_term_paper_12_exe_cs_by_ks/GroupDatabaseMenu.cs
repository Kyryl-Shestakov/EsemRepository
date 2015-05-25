using System;
using System.Collections.Generic;
using oop_term_paper_12_dll_cs_by_ks;
using System.IO;
using System.Runtime.Serialization;

namespace oop_term_paper_12_exe_cs_by_ks
{
    static class GroupDatabaseMenu
    {
        public static GroupDatabase groupDatabase;

        static GroupDatabaseMenu()
        {
            if (File.Exists("groups.xml"))
            {
                var ds = new DataContractSerializer(typeof(GroupDatabase));

                using (Stream s = File.OpenRead("groups.xml"))
                {
                    groupDatabase = (GroupDatabase) ds.ReadObject(s);
                }
            }
            else
            {
                groupDatabase = new GroupDatabase(new List<Group>());
            }
        }

        public static void AddTheGroup()
        {
            string groupId;
            int year;
            List<Subject> subjectList = new List<Subject>();

            Console.Write("Input group id: ");
            groupId = Console.ReadLine();

            while(true)
            {
                Console.Write("Input a year: ");
                try
                {
                    year = int.Parse(Console.ReadLine());
                    
                    if(year < 1)
                    {
                        Console.WriteLine("It must be a natural number. Try again.");
                        continue;
                    }

                    break;
                }
                catch
                {
                    Console.WriteLine("It must be a natural number. Try again.");
                }
            }
            
            
            Console.WriteLine("Available subjects:");
            SubjectRepositoryMenu.DisplaySubjects();
            int subjectRelatedChoice = 0;

            do
            {
                Console.WriteLine("Add a subject (to exit type 0): ");

                try
                {
                    subjectRelatedChoice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("It must be a natural number. Try again.");
                    continue;
                }

                if(subjectRelatedChoice > SubjectRepositoryMenu.Count || subjectRelatedChoice < 0)
                {
                    Console.WriteLine("The number is out of range. Try again.");
                    continue;
                }

                if (subjectRelatedChoice != 0)
                {
                    if (subjectList.Contains(SubjectRepositoryMenu.GetSubject(subjectRelatedChoice - 1)))
                    {
                        Console.WriteLine("Such discipline is already added");
                        continue;
                    }
                    else
                    {
                        subjectList.Add(SubjectRepositoryMenu.GetSubject(subjectRelatedChoice - 1));
                    }
                }
                
            }
            while (subjectRelatedChoice != 0);

            groupDatabase.Add(Group.GroupFactory(year, groupId, new List<Student>(), subjectList));
        }

        public static void RemoveTheGroup()
        {
            string groupId;
            
            Console.Write("Input the id of a group to remove: ");
            groupId = Console.ReadLine();

            if(groupDatabase.Remove(groupId))
            {
                Console.WriteLine("The group was deleted");
            }
            else
            {
                Console.WriteLine("There is no such group");
            }
        }

        public static void ChangeTheGroup()
        {
            string groupId;

            Console.Write("Select the group by its id: ");
            groupId = Console.ReadLine();

            if (groupDatabase.Exists((item) =>
                {
                    return item.GroupId.Equals(groupId);
                }))
            {
                Group currentGroup = groupDatabase.Find((item) =>
                    {
                        return item.GroupId.Equals(groupId);
                    });

                int groupChangeRelatedChoice;

                do
                {
                    Console.Clear();
                    Console.WriteLine("0 - Return to previous menu");
                    Console.WriteLine("1 - Add the student");
                    Console.WriteLine("2 - Remove the student");
                    Console.WriteLine("3 - Change the student");
                    Console.WriteLine("4 - Change the year");
                    Console.WriteLine("5 - Rename the group");

                    try
                    {
                        groupChangeRelatedChoice = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        groupChangeRelatedChoice = -1;
                    }

                    switch(groupChangeRelatedChoice)
                    {
                        case 0:
                            {

                            }
                            break;

                        case 1:
                            {
                                try
                                {
                                    Console.Write("Input a first name of a student: ");
                                    string firstName = Console.ReadLine();
                                    
                                    if(!Student.ValidName(firstName))
                                    {
                                        throw new Exception("Wrong Format.");
                                    }

                                    Console.Write("Input a last name of a student: ");
                                    string lastName = Console.ReadLine();

                                    if (!Student.ValidName(lastName))
                                    {
                                        throw new Exception("Wrong Format.");
                                    }

                                    Console.Write("Input a transcriptNumber of a student: ");
                                    string transcriptNumber = Console.ReadLine();

                                    if(!Student.ValidTranscriptNumber(transcriptNumber))
                                    {
                                        throw new Exception("Wrong Format.");
                                    }

                                    List<Subject> list = new List<Subject>();

                                    foreach(string subject in currentGroup.SubjectNameList)
                                    {
                                        list.Add(SubjectRepository.subjectList.Find((item) =>
                                            {
                                                return item.Name.Equals(subject);
                                            }));
                                    }

                                    currentGroup.Add(Student.StudentFactory(firstName, lastName, transcriptNumber, list));
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;

                        case 2:
                            {
                                string student;
                                Console.Write("Input the name of a student to remove: ");
                                student = Console.ReadLine();

                                if (currentGroup.StudentList.Exists((item) =>
                                    {
                                        return (item.FirstName + " " + item.LastName).Equals(student);
                                    }))
                                {
                                    currentGroup.StudentList.Remove(currentGroup.StudentList.Find((item) =>
                                        {
                                            return (item.FirstName + " " + item.LastName).Equals(student);
                                        }));
                                }
                                else
                                {
                                    Console.WriteLine("There is no such student.");
                                }

                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;

                        case 3:
                            {
                                int subjectChangeRelatedChoice;
                                int gradeRelatedChoice;
                                int newExamGrade;
                                double newControlWorkGrade;
                                double newLaboratoryWorkGrade;
                                int moduleChangeRelatedChoice;
                                int anotherGradeRelatedChoice;
                                int laboratoryWorkRelatedChoice;

                                Console.Write("Input first, last names and transcript number of a student to find: ");
                                string studentName = Console.ReadLine();

                                if(currentGroup.StudentList.Exists((item) =>
                                    {
                                        return item.ToString().Equals(studentName.ToString());
                                    }))
                                {
                                    Student st = currentGroup.StudentList.Find((item) =>
                                        {
                                            return item.ToString().Equals(studentName.ToString());
                                        });

                                    int i = 0;

                                    Console.WriteLine("Subjects:");

                                    foreach(Subject s in st.SubjectList)
                                    {
                                        Console.WriteLine(++i + " " + s.Name);
                                    }

                                    Console.WriteLine("Choose a subject: ");
                                    
                                    try
                                    {
                                        subjectChangeRelatedChoice = int.Parse(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        subjectChangeRelatedChoice = -1;
                                    }

                                    if(subjectChangeRelatedChoice < 1 || subjectChangeRelatedChoice > st.SubjectList.Count)
                                    {
                                        Console.WriteLine("The argument is out of range");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Choose what grade to change\n");
                                        Console.WriteLine("1 - Exam grade");
                                        Console.WriteLine("2 - Module grade");

                                        try
                                        {
                                            gradeRelatedChoice = int.Parse(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            gradeRelatedChoice = -1;
                                        }

                                        if(gradeRelatedChoice == 1)
                                        {
                                            Console.Write("Input new exam grade: ");

                                            try
                                            {
                                                newExamGrade = int.Parse(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                newExamGrade = -1;
                                            }

                                            if(newExamGrade < 0 || newExamGrade > 100)
                                            {
                                                Console.WriteLine("Invalid input.");
                                            }
                                            else
                                            {
                                                st.SubjectList[subjectChangeRelatedChoice - 1].ExamGrade = newExamGrade;
                                                Console.WriteLine("New exam grade was assigned.");
                                            }
                                        }
                                        else if(gradeRelatedChoice == 2)
                                        {
                                            if (st.SubjectList[subjectChangeRelatedChoice - 1].ModuleCount == 0)
                                            {
                                                Console.WriteLine("There are no modules.");
                                            }
                                            else
                                            {
                                                Console.Write("Input a number of module to change out of " + st.SubjectList[subjectChangeRelatedChoice - 1].ModuleCount + ": ");

                                                try
                                                {
                                                    moduleChangeRelatedChoice = int.Parse(Console.ReadLine());
                                                }
                                                catch
                                                {
                                                    moduleChangeRelatedChoice = -1;
                                                }

                                                if (moduleChangeRelatedChoice < 1 || moduleChangeRelatedChoice > st.SubjectList[subjectChangeRelatedChoice - 1].ModuleCount)
                                                {
                                                    Console.WriteLine("The argument is out of range");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Input what kind of grade you want to change");
                                                    Console.WriteLine("1 - Control work grade");
                                                    Console.WriteLine("2 - Laboratory work grade");

                                                    try
                                                    {
                                                        anotherGradeRelatedChoice = int.Parse(Console.ReadLine());
                                                    }
                                                    catch
                                                    {
                                                        anotherGradeRelatedChoice = -1;
                                                    }

                                                    if(anotherGradeRelatedChoice == 1)
                                                    {
                                                        Console.Write("Input new control work grade: ");

                                                        try
                                                        {
                                                            newControlWorkGrade = double.Parse(Console.ReadLine());
                                                        }
                                                        catch
                                                        {
                                                            newControlWorkGrade = -1.0;
                                                        }

                                                        if (newControlWorkGrade < 0.0)
                                                        {
                                                            Console.WriteLine("Invalid Format.");
                                                        }
                                                        else
                                                        {
                                                            st.SubjectList[subjectChangeRelatedChoice - 1].ModuleList[moduleChangeRelatedChoice - 1].ModuleControlWorkGrade = newControlWorkGrade;
                                                            Console.WriteLine("New control work grade was assigned.");
                                                        }

                                                    }
                                                    else if (anotherGradeRelatedChoice == 2)
                                                    {
                                                        Console.WriteLine("Input the number of laboratory work's grade to change out of " + st.SubjectList[subjectChangeRelatedChoice - 1].ModuleList[moduleChangeRelatedChoice - 1].GradeCount);

                                                        try
                                                        {
                                                            laboratoryWorkRelatedChoice = int.Parse(Console.ReadLine());
                                                        }
                                                        catch
                                                        {
                                                            laboratoryWorkRelatedChoice = -1;
                                                        }

                                                        if(laboratoryWorkRelatedChoice < 1 || laboratoryWorkRelatedChoice > st.SubjectList[subjectChangeRelatedChoice - 1].ModuleList[moduleChangeRelatedChoice - 1].LabWorkGradeList.Count)
                                                        {
                                                            Console.WriteLine("The argument is out of range.");
                                                        }
                                                        else
                                                        {
                                                            Console.Write("Input new laboratory work grade: ");

                                                            try
                                                            {
                                                                newLaboratoryWorkGrade = double.Parse(Console.ReadLine());
                                                            }
                                                            catch
                                                            {
                                                                newLaboratoryWorkGrade = -1.0;
                                                            }

                                                            if(newLaboratoryWorkGrade < 0.0)
                                                            {
                                                                Console.WriteLine("Invalid input.");
                                                            }
                                                            else
                                                            {
                                                                st.SubjectList[subjectChangeRelatedChoice - 1].ModuleList[moduleChangeRelatedChoice - 1].LabWorkGradeList[laboratoryWorkRelatedChoice - 1] = newLaboratoryWorkGrade;
                                                                Console.WriteLine("New laboratory work grade was assigned");
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("There is no such option");
                                                    }
                                                    
                                                }
                                            } 
                                        }
                                        else
                                        {
                                            Console.WriteLine("There is no such option");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There are no such students");
                                }

                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;

                        case 4:
                            {
                                int year = 1;
                                bool validFormat = true;

                                Console.WriteLine("Input new year: ");

                                try
                                {
                                    year = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("Wrong format.");
                                    validFormat = false;
                                }

                                if(validFormat)
                                {
                                    currentGroup.Year = year;
                                }

                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;

                        case 5:
                            {
                                string name;
                                Console.Write("Input new name: ");
                                name = Console.ReadLine();
                                currentGroup.GroupId = name;
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;

                        default:
                            {
                                Console.WriteLine("There is no such option");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;
                    }
                }
                while (groupChangeRelatedChoice != 0);
            }
            else
            {
                Console.WriteLine("The group was not found");
            }
        }

        public static void SelectTheGroup()
        {
            string groupId;

            Console.Write("Select the group by its id: ");
            groupId = Console.ReadLine();

            if (groupDatabase.Exists((item) =>
            {
                return item.GroupId.Equals(groupId);
            }))
            {
                Group currentGroup = groupDatabase.Find((item) =>
                {
                    return item.GroupId.Equals(groupId);
                });

                int groupChangeRelatedChoice;

                do
                {
                    Console.Clear();
                    Console.WriteLine("0 - Return to previous menu");
                    Console.WriteLine("1 - Show specific student");
                    Console.WriteLine("2 - Show all students");
                    Console.WriteLine("3 - Show group information");

                    try
                    {
                        groupChangeRelatedChoice = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        groupChangeRelatedChoice = -1;
                    }

                    switch (groupChangeRelatedChoice)
                    {
                        case 0:
                            {

                            }
                            break;

                        case 1:
                            {
                                ShowStudent(currentGroup);
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;

                        case 2:
                            {
                                foreach(Student st in currentGroup.StudentList)
                                {
                                    Console.WriteLine(st.ToString());
                                }

                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;

                        case 3:
                            {
                                Console.WriteLine(currentGroup.ToString());
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;

                        default:
                            {
                                Console.WriteLine("There is no such option");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                            }
                            break;
                    }
                }
                while (groupChangeRelatedChoice != 0);
            }
            else
            {
                Console.WriteLine("The group was not found");
            }
        }

        public static void ShowAllGroups()
        {
            int i = 0;

            foreach(Group group in groupDatabase)
            {
                Console.WriteLine(++i + " - " + group.ToString());
            }
        }

        static void ShowStudent(Group group)
        {
            if(group.Count == 0)
            {
                Console.WriteLine("There are no students");
                return;
            }

            int n;

            while (true)
            {
                Console.Write("Input a number of a student out of " + group.Count + ": ");

                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wrong format. Try again.");
                    continue;
                }

                if(n < 0 || n > group.Count)
                {
                    Console.WriteLine("Number is out of range. Try again.");
                    continue;
                }

                break;
            }

            Student st = group.StudentList[n - 1];
            Console.WriteLine(st.ToString());
            Console.WriteLine("Subjects:");
            Console.WriteLine("Average grade - " + st.AverageGrade());
            int i = 0;

            foreach(Subject subject in st.SubjectList)
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

                if(subjectRelatedChoice < 0 || subjectRelatedChoice > st.SubjectList.Count)
                {
                    Console.WriteLine("The argument is out of range. Try again.");
                    continue;
                }
                
                if (subjectRelatedChoice != 0)
                {
                    Subject currentSubject = st.SubjectList[subjectRelatedChoice - 1];
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
            while(subjectRelatedChoice != 0);
        }

        public static void Save()
        {
            groupDatabase.Save("groups.xml");
        }
    }
}