﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using oop_term_paper_12_dll_cs_by_ks;

namespace oop_term_paper_12_exe_cs_by_ks
{
    class SubjectRepositoryMenu
    {
        private static SubjectRepositoryMenu subjectRepositoryMenu;

        public static SubjectRepositoryMenu GetInstance()
        {
            return (subjectRepositoryMenu != null) ? subjectRepositoryMenu : (subjectRepositoryMenu = new SubjectRepositoryMenu());
        }

        private SubjectRepositoryMenu()
        {

        }

        public void AddSubject()
        {
            string name;
            string firstName;
            string lastName;
            Instructor instructor;
            int n;
            int[] labWorksCounts;
            List<Module> moduleList;

            while(true)
            {
                try
                {
                    Console.Write("Input the name of a discipline: ");

                    name = Console.ReadLine();

                    

                    while (true)
                    {
                        Console.Write("Input the first name of an instructor: ");

                        firstName = Console.ReadLine();

                        Console.Write("Input the last name of an instructor: ");

                        lastName = Console.ReadLine();
                            
                        try
                        {
                            instructor = Instructor.InstructorFactory(firstName, lastName);
                            break;
                        }
                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }

                    while (true)
                    {
                        Console.Write("Input the number of modules: ");

                        n = int.Parse(Console.ReadLine());

                        if (n < 1)
                        {
                            Console.WriteLine("It must be natural number");
                            continue;
                        }

                        break;
                    }

                    labWorksCounts = new int[n];

                    for(int i=0; i<n; ++i)
                    {
                        Console.Write("Input the number of laboratory works in a " + (i + 1) + " module: ");
                        labWorksCounts[i] = int.Parse(Console.ReadLine());
                        if(labWorksCounts[i] < 1)
                        {
                            --i;
                        }
                    }

                    moduleList = new List<Module>(n);

                    for(int i=0; i<n; ++i)
                    {
                        List<double> grades = new List<double>(labWorksCounts[i]);

                        for(int j=0; j<labWorksCounts[i]; ++j)
                        {
                            grades.Add(0.0);
                        }

                        moduleList.Add(Module.ModuleFactory(labWorksCounts[i], grades, 0.0));
                    }

                    SubjectRepository.GetInstance().AddSubject(Subject.SubjectFactory(name, instructor, n, moduleList, 0));
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Some inputs were wrong");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void RemoveSubject()
        {
            Console.Write("Input a name of a discipline to remove: ");
            string discipline = Console.ReadLine();

            if (SubjectRepository.GetInstance().RemoveSubject(discipline))
            {
                Console.WriteLine("Subject was deleted");
            }
            else 
            {
                Console.WriteLine("Subject wasn't deleted");
            }
        }

        public void DisplaySubjects()
        {
            int i = 0;

            foreach (Subject subject in SubjectRepository.GetInstance().subjectList)
            {
                Console.Write(++i + " ");
                Console.WriteLine(subject.ToString());
            }
        }

        public void Save()
        {
            SubjectRepository.GetInstance().Save();
        }

        public int Count
        {
            get
            {
                return SubjectRepository.GetInstance().subjectList.Count;
            }
        }

        public Subject GetSubject(int index)
        {
            if (index < 0 || index >= SubjectRepository.GetInstance().subjectList.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return SubjectRepository.GetInstance().subjectList[index];
        }
    }
}