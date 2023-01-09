using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFinal
{
    internal class Qrup 
    {
        static int _id = 1;
        public int Id { get; set; }
        public Qrup()
        {
            Id = _id;
            _id++;
            Students = new List<Student>();
        }

        public string No { get; set; }
        public bool IsOnline { get; set; }
        public int Limit  { get; set; }
        public List<Student> Students { get; set; }
    }
}
