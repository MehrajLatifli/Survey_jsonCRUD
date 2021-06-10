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
using System.Windows.Forms;

namespace Survey
{
    public partial class EditList : Form
    {
        public EditList()
        {
            InitializeComponent();
            form1 = (Survey)this.Owner;
            rootObject = new RootObject();
        }

        Survey form1;


        public RootObject rootObject;

        string SelectedItemToString = "";

        private void Form3_Load(object sender, EventArgs e)
        {
            if ((this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex == -1)
            {
                textBox1.Text = textBox1.Text;
                textBox2.Text = textBox2.Text;
                textBox3.Text = textBox3.Text;
                textBox4.Text = textBox4.Text;

            }

            else
            {
                SelectedItemToString = (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedItem.ToString();

                string[] words = SelectedItemToString.Split(' ');

                textBox1.Text = words[1];
                textBox2.Text = words[2];
                textBox3.Text = words[3];
                textBox4.Text = words[4];
            }
        }

        private void Saveguna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        public void Edit()
        {
            rootObject = DeserializeFile();

            foreach (var item in rootObject.users)
            {
                if ((this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex != -1)
                {
                    rootObject.users[(this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex].Name = textBox1.Text;
                    rootObject.users[(this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex].LastName = textBox2.Text;
                    rootObject.users[(this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex].Age = Convert.ToInt32( textBox3.Text);
                    rootObject.users[(this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex].Mobilnumber = Convert.ToInt32(textBox4.Text);

                }
            }

            SerializeList(rootObject);
        }



        private void EditList_FormClosed(object sender, FormClosedEventArgs e)
        {

            try
            {

                rootObject = DeserializeFile();

                (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Focus();

               

                if ((this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex > -1)
                {


                    rootObject.users[(this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex].Name = textBox1.Text;
                    rootObject.users[(this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex].LastName = textBox2.Text;
                    rootObject.users[(this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex].Age = int.Parse(textBox3.Text);
                    rootObject.users[(this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).SelectedIndex].Mobilnumber = int.Parse(textBox4.Text);
                }





                (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Items.Clear();
                foreach (var name in rootObject.users)
                {

                    (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Items.Add(name);

                }
                (this.Owner.Controls.Find("listBox1", true).FirstOrDefault() as ListBox).Update();



                SerializeList(rootObject);
            }
            catch (Exception)
            {

             
            }

            
        }



        private static void SerializeList(RootObject users)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
