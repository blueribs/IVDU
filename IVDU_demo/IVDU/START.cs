using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Session;

namespace IVDU
{
    public partial class START : Form
    {
        Broker b = new Broker();

        public START()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)  // Insert program
        {
            Person p = new Person();
            p.FirstName = txtFirstName.Text;
            p.LastName = txtLastName.Text;

            b.Insert(p);

            txtFirstName.Text = " ";
            txtLastName.Text = " ";
        }

        private void btnFillComboBox_Click(object sender, EventArgs e)  // view program
        {
            cmbPersons.DataSource = b.FillComboBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)  // update program
        {
            Person oldPerson = new Person();
            Person newPerson = new Person();

            oldPerson = cmbPersons.SelectedItem as Person;

            newPerson.FirstName = txtNewFirstName.Text;
            newPerson.LastName = txtNewLastName.Text;

            b.Update(oldPerson, newPerson);
        }

        private void btnDelete_Click(object sender, EventArgs e)  // delete program
        {
            Person p = new Person();
            p = cmbPersons.SelectedItem as Person;
            b.Delete(p);

            dataGridView1.Update();

        }

        private void START_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.TPersons' table. You can move, or remove it, as needed.
            this.tPersonsTableAdapter.Fill(this.databaseDataSet.TPersons);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
