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
    public partial class Form6 : Form
    {
        public Form6()
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
            string txtsql = "update client set Nom_Clt = '" + textBox2.Text +
               "',Prenom_Clt='" + textBox3.Text +
               "',Age_Clt='" + textBox4.Text +
               "',Adresse_Clt='" + textBox5.Text +
               "', TEL_Clt='" + textBox6.Text +
               "' where ID_Client = '" + textBox1.Text + "' ";
            lancerRequete(txtsql);
            MessageBox.Show("modification terminer");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 f = new Form3();
            f.Show();
        }
    }
}
