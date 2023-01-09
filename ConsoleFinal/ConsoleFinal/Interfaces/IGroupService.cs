using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFinal.Interfaces
{
    internal interface IGroupService
    {
        public void CreateGroup(string categoryName, int groupNo, bool isOnline);
        public void CreateStudent(string name, string groupName, bool? isGuarantee);
        public void EditGroup(string groupName);
        public void ShowAllStudents();
        public void ShowGroups();
        public void ShowStudentsInGroup(string groupName);
    }
}
