using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Survey
{
    // [Serializable()]
    //[JsonObject(Title = "user")]
    // [DataContract(Name = "item")]
    //[JsonObject(Description = "Something", Title = "Something", Id = "Something")]

    // [JsonObject]

    // [JsonObject(Title = "root")]


    public class RootObject
    {
        public RootObject()
        {
            users = new List<User>();
        }


        public List<User> users { get; set; }

        public void Add(string s1, string s2, string s3, string s4)
        {
           


            users.Add(new User
            {
                Name = s1,
                LastName = s2,
                Age = int.Parse(s3),
                Mobilnumber = int.Parse(s4),

            });


     

            //userList = new List<User>
            //{
            //    new User {

            //      Name = s1,
            //      LastName = s2,
            //      Age = int.Parse(s3),
            //      Mobilnumber = int.Parse(s4),
            //    },
            //};


        }

       
        public void View()
        {
            foreach (var item in users)
            {
                MessageBox.Show($"{item}");
            }

          
        }
    }
}
