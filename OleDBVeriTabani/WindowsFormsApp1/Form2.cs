using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=AJANDA.accdb;");
            con.Open();

            string sql = "Select * From KISILER";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();
            //var dt = new DataTable();

           // adapter.Fill(dt);
            adapter.Fill(ds);


            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
            con.Close();


        }
    }
}
