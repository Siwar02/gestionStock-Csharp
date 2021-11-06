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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public string sconstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data source = C:\\Users\\hp\\OneDrive\\Documents\\examenttp.accdb;";
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

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string txtsql = "update authentification set password = '" + textBox2.Text +
              "',Nom='" + textBox3.Text +
              "',type compte='" + textBox4.Text +
              "',Description='" + textBox5.Text +
              "', where Login = '" + textBox1.Text + "' ";
            lancerRequete(txtsql);
            MessageBox.Show("modification terminer");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
            Form5 f = new Form5();
            f.Show();
        }
    }
}
