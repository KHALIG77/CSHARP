using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lasttaske.Models.Instruments;

namespace Lasttaske {

    internal static class MenuService
    {
    
         public static void  PrintAllInstruments()
        {
            Zurna zurna = new Zurna();
            Static.Classes.Add(zurna);


            ELectricGuitar electricguitar = new ELectricGuitar();

            Static.Classes.Add(electricguitar);


            Tar tar = new Tar();
            Static.Classes.Add(tar);


            Piano piano = new Piano();
            Static.Classes.Add(piano);

            foreach (var item in Static.Classes)
            {
                var properti = item.GetType().GetProperties();
                //var method = item.GetType().GetMethods();
                Console.WriteLine(item.GetType().Name);

                foreach (var item2 in properti)
                {
                    Console.WriteLine(item2.Name + ":" + item2.GetValue(item));
                    

                }
                foreach (var item4 in Static.Classes)
                {
                    //var meth = item4.GetType().GetMethod("Sound", BindingFlags.Public | BindingFlags.Instance);

                    
                }

                //Console.WriteLine(zurna.Sound());
                Console.WriteLine(" ");

            }



        }


       




        //



        //       


    }
}
