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

namespace Siwar_Jdir
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public string sconstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data source = C:\\Users\\hp\\OneDrive\\Documents\\examenttp.accdb;";

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void lancerRequete(string requete)
        {
            OleDbConnection ocn = new OleDbConnection();
            OleDbCommand ocm = new OleDbCommand();
            ocn.ConnectionString = sconstr;
            try
            {
                ocn.Open();
                ocm.Connection = ocn;
                ocm.CommandText = requete;
                ocm.ExecuteNonQuery();
                ocn.Close();
                MessageBox.Show("***insertion terminer avec succée***");
            }

            catch (Exception ex)
            {
                MessageBox.Show("exception Générée : " + ex.Message);
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string txtinsert;
            txtinsert = "insert into Client values('"+textBox1.Text+"','" + textBox2.Text +"','" + textBox3.Text +"','" + textBox4.Text +"','" + textBox5.Text +"','" + textBox6.Text +"')";
            lancerRequete(txtinsert);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Int32 count = 0;
            string txtsql;
            txtsql = "select count (*) from Client";
            OleDbConnection ocn = new OleDbConnection(sconstr);
            OleDbCommand ocm = new OleDbCommand(txtsql, ocn);
            ocm.Connection.Open();
            count = Convert.ToInt32(ocm.ExecuteScalar());

            ocn.Close();
            count++;
            textBox1.Text = count.ToString();
            textBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 f = new Form3();
            f.Show();
        }
    }
}
