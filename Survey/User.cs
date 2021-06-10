using Newtonsoft.Json;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Survey
{

    //  [Serializable()]
    // [JsonObject(Title = "user")]
    // [DataContract(Name = "item")]

    //[JsonObject(Description = "Something", Title = "Something", Id = "Something")]


    //[JsonObject(MemberSerialization.OptIn)]


    // [Newtonsoft.Json.JsonObject(Title = "root")]

    [Newtonsoft.Json.JsonObject(Title = "root")]
    public class User
    {


        public User()
        {
                            
        }

        public User(string name, string lastName, int age, int mobilnumber)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Mobilnumber = mobilnumber;
        }

        public string Name { get; set; }


        public string LastName { get; set; }


        public int Age { get; set; }


        public int Mobilnumber { get; set; }


        public string FullData => $" {Name} {LastName} {Age} {Mobilnumber}";

        public override string ToString()
        {
            return $" {Name} {LastName} {Age} {Mobilnumber}";
        }
    }
}
