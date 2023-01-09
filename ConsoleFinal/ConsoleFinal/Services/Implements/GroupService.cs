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
                    if (categoryName.ToLower() == group.No.ToLower().Substring(0,1)&& groupNo.ToString() ==group.No.Substring(1))
                    {
                        hasGroup = true;
                        Console.Clear();
                        Console.WriteLine("This group already avaliable");
                        Console.WriteLine(" ");
                        return ;
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
                                if (ApplicationGroups.Students.Count < 15)
                                {

                                    Student student = new Student();

                                    student.FullName = name;
                                    student.GroupNo = group.No;
                                    student.Type = (bool)isGuarantee;

                                    ApplicationGroups.Students.Add(student);

                                    group.Students.Add(student);
                                    hasGroup = true;
                                    Console.Clear();
                                    Console.WriteLine("Successfully Added");
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
                                if(ApplicationGroups.Students.Count < 10)
                                {
                                    Student student = new Student();

                                    student.FullName = name;
                                    student.GroupNo = group.No;
                                    student.Type = (bool)isGuarantee;

                                    ApplicationGroups.Students.Add(student);

                                    group.Students.Add(student);
                                    hasGroup = true;
                                    Console.Clear();
                                    Console.WriteLine("Successfully Added");

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
                        else if (newGroupNo == 0) 
                        { 
                        
                        Console.Clear();
                        Console.WriteLine("Please write number great than 0");
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
            Console.Clear();
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
                                if (group.IsOnline)
                                {
                                    string statusGroup = "ONLINE";
                                }
                                else {
                                    string statusGroup = "OFFLINE";
                                    Console.WriteLine($"Fullname--{student.FullName},Group NO--{student.GroupNo},Status Group--{statusGroup}");
                                }

                            }
                        }
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Students not found,Plaease add student to group");
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
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("  ");

                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("There is no group");
                Console.WriteLine("----------------------");
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
                            Console.WriteLine($"Fullname of student : {student.FullName} ,Group No:{student.GroupNo}, Student Status: {studentStatus}");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("  ");
                        }
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine("Group not found");
                return;
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
