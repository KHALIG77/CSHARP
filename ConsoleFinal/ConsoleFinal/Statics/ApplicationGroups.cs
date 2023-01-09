using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleFinal.Statics
{
    internal static class ApplicationGroups
    {
        static ApplicationGroups()
        {
            Groups = new List<Qrup>();
            Students = new List<Student>();
        }

        public static List<Qrup> Groups { get; set; }
        public static List<Student> Students { get; set; }

    }
}
