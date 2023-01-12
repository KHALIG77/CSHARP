using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lasttaske.Models.Instruments;

namespace Lasttaske
{
    internal class Piano : InstrumentAbstract
    {
        public override string Model { get; set; } = "mt-09";
        public override string Brand { get; set; } = "Yamaha";
        public override string Popularity { get; set; } = "Her yerde";
        public override string Price { get; set; } = "Masini sat al";
        public string Materiali { get; set; } = "Fil sumuyunnen olannan";

        public override string Sound
        {
            get {
                return "Piano sound";
            }
            
        }
    }
}
