using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleFinal.Interfaces;
using ConsoleFinal.Statics;

namespace ConsoleFinal
{
    internal class GroupService : IGroupService
    {
        public void CreateGroup(string categoryName, int groupNo, bool isOnline)
        {
            if (categoryName != null && groupNo != 0)
            {
                bool hasGroup = false;

                foreach (var group in ApplicationGroups.Groups)
                {
                    if (categoryName == group.No.Substring(0, 1) && groupNo.ToString() == group.No.Substring(1))
                    {
                        hasGroup = true;
                        break;
                    }
                }


                if (!hasGroup)
                {
                    Qrup qrup = new Qrup();

                    qrup.No = categoryName + groupNo;
                    qrup.IsOnline = isOnline;
                    if (isOnline)
                    {
                        qrup.Limit = 15;
                    }
                    else
                    {
                        qrup.Limit = 10;
                    }
                    ApplicationGroups.Groups.Add(qrup);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("There is already a group with this name");
                    Console.WriteLine("-----------------------------------------");
                }
            }
        }

        public void CreateStudent(string name, string groupName, bool? isGuarantee)
        {
            if (name != null && groupName != null && isGuarantee != null)
            {
                bool hasGroup = false;

                if (ApplicationGroups.Groups.Count != 0)
                {
                    foreach (var group in ApplicationGroups.Groups)
                    {
                        if (group.No.ToLower() == groupName.ToLower())
                        {
                            if (group.IsOnline)
                            {
                                if (ApplicationGroups.Students.Count <= 15)
                                {


                                    Student student = new Student();

                                    student.FullName = name;
                                    student.GroupNo = group.No;
                                    student.Type = (bool)isGuarantee;

                                    ApplicationGroups.Students.Add(student);

                                    group.Students.Add(student);
                                    hasGroup = true;
                                    return;
                                }
                                else
                                {   
                                    Console.WriteLine("Group is full");
                                    return;
                                }

                            }
                            else 
                            {
                                if(ApplicationGroups.Students.Count <= 10)
                                {
                                    Student student = new Student();

                                    student.FullName = name;
                                    student.GroupNo = group.No;
                                    student.Type = (bool)isGuarantee;

                                    ApplicationGroups.Students.Add(student);

                                    group.Students.Add(student);
                                    hasGroup = true;
                                    Console.WriteLine(ApplicationGroups.Students.Count);

                                    return;

                                }
                                else
                                {
                                    Console.WriteLine("Group is full");
                                    return;

                                }


                            }
                        }
                    }


                }
                if (!hasGroup)
                {
                    Console.Clear();
                    Console.WriteLine($"This group: {groupName} not found  , please create group");
                    Console.WriteLine("-----------------------------------------");
                }

            }
            Console.Clear();
        }

        public void EditGroup(string groupName)
        {

            if (ApplicationGroups.Groups.Count != 0)
            {


                foreach (var group in ApplicationGroups.Groups)
                {
                    if (group.No.ToLower().Trim() == groupName.ToLower().Trim())
                    {
                        Console.WriteLine("Please write new group number");

                        int newGroupNo;

                    CheckIsNumberGroupNo:

                        bool isNumber = int.TryParse(Console.ReadLine(), out newGroupNo);

                        if (!isNumber)
                        {
                            Console.WriteLine("Please write number");
                            goto CheckIsNumberGroupNo;
                        }

                        foreach (var qrup in ApplicationGroups.Groups)
                        {
                            if ((group.No.Substring(0, 1) + newGroupNo.ToString()).ToLower() == qrup.No.ToString().ToLower())
                            {
                                Console.Clear();
                                Console.WriteLine("This group is already avaliable ");
                                return;
                            }
                        }
                        Console.Clear();
                        group.No = group.No.Substring(0, 1) + newGroupNo.ToString();
                        Console.WriteLine("Successfully Replaced");

                        return;

                    }

                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please create group");
                return;
            }
            Console.Clear();
            Console.WriteLine("Please write correctly");
        }



        public void ShowAllStudents()
        {
            if (ApplicationGroups.Groups.Count > 0)
            {
               
                foreach (var group in ApplicationGroups.Groups)
                {
                    if (ApplicationGroups.Students.Count > 0)
                    {
                        if (group.Students.Count > 0)
                        {
                            foreach (var student in group.Students)
                            {
                                Console.WriteLine($"Fullname--{student.FullName},Group NO--{student.GroupNo},Status--{group.IsOnline}");

                            }

                        }
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Students not found");
                        return;
                    }
                    
                   

                }
            }
            
            

            
            else
            {
                Console.Clear();
                Console.WriteLine("Please create group");
                return;

            }

        }

        public void ShowGroups()
        {
            if (ApplicationGroups.Groups.Count != 0)
            {
                Console.Clear();
                foreach (var group in ApplicationGroups.Groups)
                {
                    string groupType = "";
                    if (group.IsOnline)
                    {
                        groupType = "Online";
                    }
                    else
                    {
                        groupType = "Offline";

                    }
                    Console.WriteLine($"Grop NO : {group.No} , Group Type : {groupType} , The count of students : {group.Students.Count}");
                    Console.WriteLine("-----------------------------------------");


                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("There is no group");
                Console.WriteLine("-----------------------------------------");
                return;
            }
        }

        public void ShowStudentsInGroup(string groupName)
        { 
            if (ApplicationGroups.Groups.Count != 0)
            {

                foreach (var group in ApplicationGroups.Groups)
                {
                   

                    if (group.No.Trim().ToLower() == groupName.Trim().ToLower())
                    {
                        if (group.Students.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("This group is empty");
                            return;
                        }

                        foreach (var student in group.Students)
                        { 
                            string studentStatus = "";
                            if (student.Type)
                            {
                                studentStatus = "Guarantee";
                            }
                            else
                            {
                                studentStatus = "Without Guarantee";

                            }
                            Console.WriteLine($"Fullname of student : {student.FullName} , Student Status: {studentStatus}");
                            Console.WriteLine("-----------------------------------------");
                        }
                        continue;
                    }
                    else if(ApplicationGroups.Groups.Count == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Group not found");
                        return;
                    }

                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please create group");
                return;
            }


        }
    }
}

