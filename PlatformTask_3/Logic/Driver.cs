using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Driver
    {
        
        CarClass carcl { get; set; }
        
        public string Name { get; set; }
       
        public string SurName { get; set; }
        
        public string Id  { get; set; }
       
        public Driver(string n, string id, string sur, CarClass car = CarClass.Econom)
        {
            Name = n;
            Id = id;
            SurName=sur;
            carcl = car;
        }
        public Driver()
        {
            Name = " ";
            Id = " ";
            SurName=" ";
            carcl = CarClass.Universal;
        }
        public override string ToString()
        {
            
            return String.Format("Name: {0}, SurName: {1}, ClassCar: {2} ;", Name, SurName, carcl );

        }

    }
}
