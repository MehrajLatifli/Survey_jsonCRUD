using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Survey
{
    public partial class AddList : Form
    {
        public AddList()
        {
            InitializeComponent();
            form1 = (Survey)this.Owner;
            rootObject = DeserializeFile();

      

       
        }



        Survey form1 ;

        public RootObject  rootObject;





        private void UnSaveguna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
   
        }

        private void Saveguna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            

            Add();

        }

        public void Add()
        {



           

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {


                string s1 = textBox1.Text;
                string s2 = textBox2.Text;
                string s3 = textBox3.Text;
                string s4 = textBox4.Text;

                rootObject = DeserializeFile();

                rootObject.Add(s1, s2, s3, s4);

                SerializeList(rootObject);



            }

            else
            {
                MessageBox.Show($"Least one textbox is empty");
            }



            foreach (var item in rootObject.users)
            {

                if (!(this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Items.Contains(item.FullData))
                {

                    (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Items.Add(item.FullData);
                }


                
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            //if ((this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex == -1)
            //{
            //    textBox1.Text = textBox1.Text;
            //    textBox2.Text = textBox2.Text;
            //    textBox3.Text = textBox3.Text;
            //    textBox4.Text = textBox4.Text;

            //}

            //else
            //{
            //    string SelectedItemToString = (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedItem.ToString();

            //    string[] words = SelectedItemToString.Split(' ');

            //    textBox1.Text = words[1];
            //    textBox2.Text = words[2];
            //    textBox3.Text = words[3];
            //    textBox4.Text = words[4];
            //}

        }

        public void AddList_FormClosed(object sender, FormClosedEventArgs e)
        {

          //  save();



        }


      
            private void SerializeList(RootObject users)
            {
                var f = Newtonsoft.Json.Formatting.Indented;
                string data = JsonConvert.SerializeObject(users, f);

                File.WriteAllText($"../../Data.json", data);
            }
        

        public RootObject DeserializeFile()
        {


            string data = File.ReadAllText($"../../Data.json");

            rootObject = JsonConvert.DeserializeObject<RootObject>(data);

            if (rootObject != null)
            {
                return rootObject;
            }



            return new RootObject();
        }

        /*
        public void save()
        {


            //var model = JsonConvert.DeserializeObject<UserList>($"../../Data.json");

            var jsonString = JsonConvert.SerializeObject(rootObject);
           // var amount = JsonConvert.DeserializeObject<RootObject>(jsonString);

          //  var amount = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText($"../../Data.json"));

            // MessageBox.Show($"{amount.userList[0].FullData}");



            //var collection = new List<User>();


            //dynamic collectionWrapper = new
            //{

            //    myRoot = collection

            //};


            try
            {





                //string _path = $"../../Data.json";

                var serializer = new JsonSerializer();
                using (var sw = new StreamWriter($"../../Data.json", true))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                        serializer.Serialize(jw, rootObject);



                    }


                }




                RootObject arrayuser = null;
                var serializer2 = new JsonSerializer();

                using (var sr = new StreamReader($"../../Data.json"))
                {
                    using (var jr = new JsonTextReader(sr))
                    {
                        arrayuser = serializer2.Deserialize<RootObject>(jr);
                    }

                }





            }
            catch (Exception)
            {

              
            }






            //var o = new JavaScriptSerializer();


            //var jsonString = JsonConvert.SerializeObject(rootObject);


            //try
            //{
            //    var serializer = new JsonSerializer();
            //    using (var sw = new StreamWriter($"../../Data.json", true))
            //    {
            //        using (var jw = new JsonTextWriter(sw))
            //        {
            //            jw.Formatting = Newtonsoft.Json.Formatting.Indented;
            //            serializer.Serialize(jw, users);



            //        }


            //    }




            //    UserList arrayuser = null;
            //    var serializer2 = new JsonSerializer();

            //    using (var sr = new StreamReader($"../../Data.json"))
            //    {
            //        using (var jr = new JsonTextReader(sr))
            //        {
            //            arrayuser = serializer2.Deserialize<UserList>(jr);
            //        }

            //    }
            //}
            //catch (Exception)
            //{


            //}


            //  users.view();
        }

        */
    }

}
