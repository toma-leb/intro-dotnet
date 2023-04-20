using DataProvider;
using System;
using System.Security.Cryptography.X509Certificates;

namespace PersonneFormApp
{
    public partial class Form1 : Form
    {
        public PersonRepository rep = new PersonRepository();
        public string personId;
        public string firstName;
        public string lastName;
        public int age;

        public Form1()
        {
            InitializeComponent();
        }

        public void Loader()
        {
            listView2.Items.Clear();
            foreach (Person pers in rep.GetAll())
            {
                ListViewItem pers1 = new ListViewItem(pers.PersonId.ToString());
                pers1.SubItems.Add(pers.FirstName.ToString());
                pers1.SubItems.Add(pers.LastName.ToString());
                pers1.SubItems.Add(pers.Age.ToString());
                listView2.Items.Add(pers1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView2.View = View.Details;
            listView2.Columns.Add("PersonId", (int)(0.5 * listView2.Width), HorizontalAlignment.Left);
            listView2.Columns.Add("FirstName", (int)(0.2 * listView2.Width), HorizontalAlignment.Left);
            listView2.Columns.Add("LastName", (int)(0.2 * listView2.Width), HorizontalAlignment.Left);
            listView2.Columns.Add("Age", (int)(0.1 * listView2.Width), HorizontalAlignment.Left);

            Loader();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rep.Update(Guid.Parse(personId), textBox1.Text.ToString(), textBox2.Text.ToString(), int.Parse(textBox3.Text.ToString()));
            Loader();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView2.SelectedItems.Count == 1)
            {
                personId = listView2.SelectedItems[0].SubItems[0].Text.ToString();
                textBox1.Text = listView2.SelectedItems[0].SubItems[1].Text.ToString();
                textBox2.Text = listView2.SelectedItems[0].SubItems[2].Text.ToString();
                textBox3.Text = listView2.SelectedItems[0].SubItems[3].Text.ToString();
            }
        }
    }
}