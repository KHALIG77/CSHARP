using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lasttaske.Models.Instruments;

namespace Lasttaske
{
    internal class Zurna : InstrumentAbstract
    {
        public override string Model { get; set; } = "Son model";
        public override string Brand { get; set; } = "Zurna Brand";
        public override string Popularity { get; set; } = "Populyar deyil";
        public override string Price { get; set; } = "200 Manat";
        public string Desikleri { get; set; } = "300";

        public override string Sound
        {
            get
            {

                return "Zurna sesi";



            }



        }
    }
}
