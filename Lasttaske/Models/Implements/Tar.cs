using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lasttaske.Models.Instruments;

namespace Lasttaske
{
    internal class Tar : InstrumentAbstract
    {



        public override string Model { get; set; } = "H2R";
        public override string Brand { get; set; } = "Kawasaki";
        public override string Popularity { get; set; } = "Localda";
        public override string Price { get; set; } = "200-300 arasi";
        public string SimlerinSayi { get; set; } = "5-6 olar";



        public override string Sound
        {
            get
            {



                return "Tar sound";


            }


        }
    }
}
