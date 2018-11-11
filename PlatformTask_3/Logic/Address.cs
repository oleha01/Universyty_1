using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [Serializable]
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Entrance { get; set; }
        public Address()
        {
            City = "";
            Street = "";
            House = "";
        }
        public Address(string city,string street,string house,string entrance)
        {
            City = city;
            Street = street;
            House = house;
            Entrance = entrance;
        }
        public override string ToString()
        {
            return String.Format("{0}, st.{1}, {2}", City, Street, House);
        }
    }
}
