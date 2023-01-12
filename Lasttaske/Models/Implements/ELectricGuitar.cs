using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lasttaske.Models.Instruments;

namespace Lasttaske
{
    internal class ELectricGuitar : InstrumentAbstract
    {

    

         public override string Model { get; set; } = "Pasledni model";
        public override string Brand { get; set; } = "Suzuki";
        public override string Popularity { get; set; } = "Coxdu";
        public override string Price { get; set; } = "Almag isdedim alammadim";
        public string Uzunlugu { get; set; } = "1 yarim olar";






        public override string Sound { get {

                return "Electricguitar sound ";


            } }
    }
}
