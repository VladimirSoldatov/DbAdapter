using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "SELECT * FROM PERSONS";
            dataGridView1.AllowUserToDeleteRows = true;
     
        }
        SqlCommandBuilder cmd = null;
        SqlDataAdapter sqlDataAdapter = null;
        DataTable dataTable = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {

            dataTable.Columns.Clear();
            dataTable.Rows.Clear();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Age");
            String query = textBox1.Text;
            sqlDataAdapter = new SqlDataAdapter
                (
                query
                , ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString
                );
            sqlDataAdapter.Fill(dataTable);
   
            dataGridView1.DataSource = dataTable;
            cmd = new  SqlCommandBuilder(sqlDataAdapter);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlDataAdapter.Update(dataTable);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
        }
    }
}
