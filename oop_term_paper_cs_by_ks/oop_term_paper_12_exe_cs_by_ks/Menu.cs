﻿using System;
using System.Collections.Generic;
using oop_term_paper_12_dll_cs_by_ks;
using System.Runtime.Serialization;
using System.IO;

namespace oop_term_paper_12_exe_cs_by_ks
{
    class Menu
    {
        private static Menu menu;

        public static Menu GetInstance() 
        {
            return (menu != null) ? menu : (menu = new Menu());
        }

        private Menu()
        {

        }

        public void Run()
        {
            Console.WriteLine("Welcome to Student Storage System\n");

            int choice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Group maintenance");
                Console.WriteLine("2 - Subject maintenance");
                Console.WriteLine("3 - Search\n");
                Console.Write("Make a choice: ");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                catch
                {
                    choice = -1; //indicates wrong input
                }

                switch(choice)
                {
                    case 0:
                        {
                            GroupDatabaseMenu.GetInstance().Save();
                            SubjectRepositoryMenu.GetInstance().Save();
                        }
                        break;
                        
                    case 1:
                        {
                            int groupRelatedChoice;

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("0 - Return to previous menu");
                                Console.WriteLine("1 - Add group");
                                Console.WriteLine("2 - Remove group");
                                Console.WriteLine("3 - Change group");
                                Console.WriteLine("4 - Select a group");
                                Console.WriteLine("5 - Show all groups");

                                try
                                {
                                    groupRelatedChoice = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    groupRelatedChoice = -1;
                                }

                                switch(groupRelatedChoice)
                                {
                                    case 0:
                                        {
                                            Console.WriteLine("Press any key to return");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 1:
                                        {
                                            GroupDatabaseMenu.GetInstance().AddTheGroup();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 2:
                                        {
                                            GroupDatabaseMenu.GetInstance().RemoveTheGroup();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 3:
                                        {
                                            GroupDatabaseMenu.GetInstance().ChangeTheGroup();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 4:
                                        {
                                            GroupDatabaseMenu.GetInstance().SelectTheGroup();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 5:
                                        {
                                            GroupDatabaseMenu.GetInstance().ShowAllGroups();
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
                            while (groupRelatedChoice != 0);
                            
                        }
                        break;

                    case 2:
                        {
                            int subjectRelatedChoice = 0;

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("0 - Return to previous menu");
                                Console.WriteLine("1 - Add discipline");
                                Console.WriteLine("2 - Remove discipline");
                                Console.WriteLine("3 - Show disciplines\n");
                                Console.Write("Make a choice: ");

                                try
                                {
                                    subjectRelatedChoice = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    subjectRelatedChoice = -1;
                                }

                                switch(subjectRelatedChoice)
                                {
                                    case 0:
                                        {
                                            Console.WriteLine("Press any key to return");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 1:
                                        {
                                            SubjectRepositoryMenu.GetInstance().AddSubject();
                                            Console.WriteLine("The subject was added");
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 2:
                                        {
                                            SubjectRepositoryMenu.GetInstance().RemoveSubject();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 3:
                                        {
                                            SubjectRepositoryMenu.GetInstance().DisplaySubjects();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    default:
                                        {
                                            Console.WriteLine("There is no such option\n");
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;
                                }
                            }
                            while (subjectRelatedChoice != 0);

                        }
                        break;

                    case 3:
                        {
                            int searchRelatedChoice;

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("0 - Return to previous menu");
                                Console.WriteLine("1 - Find student by full name and transcript");
                                Console.WriteLine("2 - Find successful students");
                                Console.WriteLine("3 - Find unsuccesssful students");
                                Console.WriteLine("4 - Find successful students relative specific subject");
                                Console.WriteLine("5 - Find unsuccessful students relative specific subject\n");
                                Console.Write("Make a choice: ");

                                try
                                {
                                    searchRelatedChoice = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    searchRelatedChoice = -1;
                                }

                                switch(searchRelatedChoice)
                                {
                                    case 0:
                                        {
                                            Console.WriteLine("Press any key to return");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 1:
                                        {
                                            SearchMenu.GetInstance().FindStudent();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 2:
                                        {
                                            SearchMenu.GetInstance().FindSuccessfulStudentsByAverageGrade();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 3:
                                        {
                                            SearchMenu.GetInstance().FindUnsuccessfulStudentsByAverageGrade();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 4:
                                        {
                                            SearchMenu.GetInstance().FindSuccessfulStudentsRelativeSpecificSubject();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    case 5:
                                        {
                                            SearchMenu.GetInstance().FindUnsuccessfulStudentsRelativeSpecificSubject();
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;

                                    default:
                                        {
                                            Console.WriteLine("There is no such option\n");
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey(true);
                                        }
                                        break;
                                }
                            }
                            while (searchRelatedChoice != 0);
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("There is no such option\n");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey(true);
                        }
                        break;
                }
            }
            while (choice != 0);
        }
    }
}