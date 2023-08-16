using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    internal class DummyFriend
    {
        public String Name { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String BirthDay { get; set; }
        public String Email { get; set; }
        public String Religion { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public double LatitudeLocation { get; set; }
        public double LongtitudeLocation { get; set; }

        public DummyFriend(string i_FirstName, string i_lastName, string i_BirthDay,
            string i_Email, string i_Religion, string i_City, string i_Country,
            double i_LatitudeLocation, double i_LongtitudeLocation)
        {
            FirstName = i_FirstName;
            LastName = i_lastName;
            BirthDay = i_BirthDay;
            Email = i_Email;
            Religion = i_Religion;
            City = i_City;
            Country = i_Country;
            LatitudeLocation = i_LatitudeLocation;
            LongtitudeLocation = i_LongtitudeLocation;
            Name = i_FirstName + " " + i_lastName;
        }
    }
}
