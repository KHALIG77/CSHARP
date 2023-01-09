using ConsoleFinal.Statics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleFinal
{
    internal static class MenuMethods
    {
        private static GroupService groupservice = new GroupService();
        public static void MenuCreateGroup()
        {
            Console.Clear();
            Console.WriteLine("Choose category");
            Console.WriteLine("   ");



        CheckIsNumberCategoryNo:
            CategoryRepeat();


        NotFoundError:

            int categoryNo;
            bool isNumberCategoryNo = int.TryParse(Console.ReadLine(), out categoryNo);
            int EnumMin = Enum.GetValues(typeof(GroupCategory)).Cast<int>().Min();
            int EnumMax = Enum.GetValues(typeof(GroupCategory)).Cast<int>().Max();

            if ((categoryNo < EnumMin || categoryNo > EnumMax))
            {
                Console.Clear();
                Console.WriteLine("Category is not found please choose correctly");
                Console.WriteLine("");
                CategoryRepeat();

                goto NotFoundError;
            }
            else
            {
                if (!isNumberCategoryNo)
                {


                    Console.Clear();
                    Console.WriteLine("Please enter the number");
                    Console.WriteLine("  ");

                    goto CheckIsNumberCategoryNo;


                }
                else if (categoryNo == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the  group number great than 0");
                    Console.WriteLine("");

                    goto CheckIsNumberCategoryNo;


                }




                string NewCategoryName = "";

                foreach (GroupCategory category in Enum.GetValues(typeof(GroupCategory)))
                {
                    if (categoryNo == (int)category)
                    {
                        NewCategoryName = category.ToString().Substring(0, 1);
                    }
                }

                Console.WriteLine("Please enter the group number");

                int groupNo;

            CheckIsNumberGroupNo:

                bool isNumber = int.TryParse(Console.ReadLine(), out groupNo);

                if (!isNumber)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the number");
                    goto CheckIsNumberGroupNo;
                }
                else if (groupNo == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the number great than 0");
                    Console.WriteLine("");
                    goto CheckIsNumberGroupNo;


                }


                bool IsOnline;
                int IntCreateGroup;

                Console.Clear();
                Console.WriteLine($"Online or offline group do you want create?");

            CheckIsNumberIsOnline:

                Console.WriteLine($"~~~For online Press 0");
                Console.WriteLine($"~~~For offline Press 1");

                bool CreateCheckStatus = int.TryParse(Console.ReadLine(), out IntCreateGroup);

                if (CreateCheckStatus)
                {
                    if (IntCreateGroup == 1)
                    {
                        IsOnline = false;
                    }
                    else if (IntCreateGroup == 0)
                    {
                        IsOnline = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter 0 or 1");
                        Console.WriteLine("");


                        goto CheckIsNumberIsOnline;

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the number");
                    goto CheckIsNumberIsOnline;
                }

                groupservice.CreateGroup(NewCategoryName, groupNo, IsOnline);
                Console.Clear();
                return;
            }

        }




        public static void MenuCreateStudent()
        {
            Console.Clear();
            string FullName = "";
        namecheck:
        fullcheck:
            Console.WriteLine("Please write your Name ");
            string Name = Console.ReadLine();
            Console.WriteLine("Please write your Surname ");

            string Surname = Console.ReadLine();
            while (true)
            {
                bool namestatus = int.TryParse(Name, out int namecheck);
                bool surnamestatus = int.TryParse(Surname, out int surnamecheck);
                if (namestatus && surnamestatus)
                {
                    Console.WriteLine(" Please don`t write number ");
                    goto namecheck;
                }
                else if (Name.Length >= 3 && Name.Length <= 15 && Surname.Length <= 15 && Surname.Length >= 3)
                {
                    Name.Trim();
                    Console.WriteLine("");
                    Surname.Trim();
                    Console.WriteLine("");

                    FullName = Name + " " + Surname;
                    break;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The letters of your fullname cannot be less than 3 and more than 15");
                    goto fullcheck;
                }



            }


            Console.WriteLine("Write your group number");

            string groupName = Console.ReadLine();


            Console.WriteLine($"Do you want a guaranteed education?");


            bool isGuarantee;

            int IntCreateStudent;

        CheckIsNumberIsGuarantee:
            Console.WriteLine($"For guaranteed press 1 ");
            Console.WriteLine($"For without guaranteed press 0");
            bool CreateStudentStatus = int.TryParse(Console.ReadLine(), out IntCreateStudent);

            if (CreateStudentStatus)
            {
                if (IntCreateStudent == 0)
                {
                    isGuarantee = false;
                }
                else if (IntCreateStudent == 1)
                {
                    isGuarantee = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please write 1 or 0");
                    Console.WriteLine("-----------------------------------------");
                    goto CheckIsNumberIsGuarantee;

                }
            }
            else
            {
                Console.WriteLine("Please write number");
                goto CheckIsNumberIsGuarantee;
            }

            groupservice.CreateStudent(FullName, groupName, isGuarantee);

        }

        public static void MenuShowAllStudents()
        {

            groupservice.ShowAllStudents();

        }

        public static void MenuShowAllGroups()
        {
            groupservice.ShowGroups();
        }

        public static void MenuShowStudentsInGroup()
        {

            Console.WriteLine("Please write group name");
        namecheckempty:
            string groupName = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(groupName))
            {
                Console.Clear();
                Console.WriteLine("Cannot be empty,write again please");
                Console.WriteLine("  ");
                goto namecheckempty;
            }

            groupservice.ShowStudentsInGroup(groupName);

        }

        public static void MenuShowEditGroup()
        {
            Console.WriteLine("Please write group name");
        editgrroup:
            string groupName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(groupName))
            {
                Console.Clear();
                Console.WriteLine("Cannot be empty,write again please");
                Console.WriteLine("  ");
                goto editgrroup;
            }
            groupservice.EditGroup(groupName);

        }
        public static void Info()
        {
            Console.WriteLine("Choose one of them ");
            Console.WriteLine("   ");

            Console.WriteLine("1.Create new group");
            Console.WriteLine("---------------------------");


            Console.WriteLine("2.Show list of all groups");
            Console.WriteLine("-----------------------------");


            Console.WriteLine("3.Edit group");
            Console.WriteLine("-----------------------------");


            Console.WriteLine("4.Show students in group");
            Console.WriteLine("-------------------------------------------");


            Console.WriteLine("5.Show list of all students");
            Console.WriteLine("-----------------------------");


            Console.WriteLine("6.Create new student");
            Console.WriteLine("-----------------------------");

        }
        public static int MenuInput()
        {


            bool status = true;
            while (status)
            {
                status = int.TryParse(Console.ReadLine(), out int result);

                if (result > 0 && result < 7 && status == true)
                {
                    status = false;
                    return result;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter correctly");
                    break;
                }
            }
            return 0;

        }
        static void CategoryRepeat()
        {

            foreach (GroupCategory category in Enum.GetValues(typeof(GroupCategory)))
            {
                Console.WriteLine($" For {category} press {(int)category}");
                Console.WriteLine("-----------------------------------------");
            }
        }








































































    }
}
