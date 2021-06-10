using Microsoft.AspNet.SignalR.Json;
using Newtonsoft.Json;
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
using System.Xml;

namespace Survey
{
    public partial class Survey : Form
    {
        public Survey()
        {
            InitializeComponent();

            if (!File.Exists($"../../Data.json"))
            {
                File.Create($"../../Data.json").Close();
            }

            rootObject = DeserializeFile();


            foreach (var item in rootObject.users)
            {
                if (!listBox1.Items.Contains(item.FullData))
                {

                    listBox1.Items.Add(item.FullData);
                }
            }

        }

        public RootObject rootObject;


        private void Addguna2Button1_Click(object sender, EventArgs e)
        {
            AddList form2 = new AddList();

            this.Hide();


            form2.ShowDialog(this);
            this.Show();
        }

        private void Editguna2Button1_Click(object sender, EventArgs e)
        {

            Editguna2Button1.Enabled = true;
            EditList form3 = new EditList();

            this.Hide();


            form3.ShowDialog(this);
            this.Show();



        }

        private void Deleteguna2Button1_Click(object sender, EventArgs e)
        {

            rootObject = DeserializeFile();


            if (listBox1.SelectedIndex != -1)
            {
                rootObject.users.RemoveAt(listBox1.SelectedIndex);
            }

            listBox1.Items.RemoveAt(listBox1.SelectedIndex);

            SerializeList(rootObject);

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

        private void Survey_Load(object sender, EventArgs e)
        {
            if (!File.Exists($"../../Data.json"))
            {
                File.Create($"../../Data.json").Close();
            }



        }

        private void Survey_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
