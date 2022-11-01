using NoteTaking.SampleDatabaseDataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaking
{
    public partial class Form1 : Form
    {

        DataTable table;


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            numberID.Clear();
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(numberID.Text, txtTitle.Text, txtMessage.Text);

            int id = int.Parse(numberID.Text);

            NotesTableAdapter notes = new NotesTableAdapter();

            notes.Insert(id, txtTitle.Text, txtMessage.Text);
            //notes.Fill(this.SampleDatabaseDataSet1.notes);

            numberID.Clear();
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void bttRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if(index > -1)
            {
                numberID.Text = table.Rows[index].ItemArray[0].ToString();
                txtTitle.Text = table.Rows[index].ItemArray[1].ToString();
                txtMessage.Text = table.Rows[index].ItemArray[2].ToString();
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            table.Rows[index].Delete();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("ID", typeof(String));
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));

            dataGridView1.DataSource = table;
            
            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Title"].Width = 175;
        }


    }
}
