using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        List<PeopleModel> people = new List<PeopleModel>();
        public Form1()
        {
            InitializeComponent();
            LoadPeopleList();
        }
        private void LoadPeopleList()
        {
            people = SqliteDataAccess.LoadPeople();
            WireUpPeopleList();
        }
        private void WireUpPeopleList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = people;
            listBox1.DisplayMember = "FullName";
        }

        private void addPerson_Click(object sender, EventArgs e)
        {
            PeopleModel p = new PeopleModel();
            p.FirstName = inputFirst.Text;
            p.LastName = inputLast.Text;
            SqliteDataAccess.SavePerson(p);

            inputFirst.Text = "";
            inputLast.Text = "";
            LoadPeopleList();
        }

        private void refreshList_Click(object sender, EventArgs e)
        {
            LoadPeopleList();
        }
    }
}
