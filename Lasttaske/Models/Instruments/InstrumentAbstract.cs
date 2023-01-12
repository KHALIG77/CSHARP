using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasttaske.Models.Instruments
{
    internal abstract class InstrumentAbstract
    {   
       
        public virtual string Model { get; set; }
        public virtual string Price { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Popularity { get; set; }
        public abstract string Sound { get; }

    }
}
