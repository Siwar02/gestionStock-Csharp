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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            nbr_client();
            charger_Liste_client();

        }
                public string sconstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data source = C:\\Users\\hp\\OneDrive\\Documents\\examenttp.accdb;";

            public void charger_Liste_client()
        {
            dataGridView1.Rows.Clear();
            string txtsql;
            txtsql = "select * from authentification";
            OleDbConnection ocn = new OleDbConnection(sconstr);
            OleDbCommand ocm = new OleDbCommand(txtsql, ocn);
            ocm.Connection.Open();
            OleDbDataReader reader = ocm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                string[] row = new string[] { reader.GetValue(0).ToString(), 
                    reader.GetValue(1).ToString(), 
                    reader.GetValue(2).ToString(), 
                    reader.GetValue(3).ToString(), 
                    reader.GetValue(4).ToString()};
                    
                dataGridView1.Rows.Add(row);

            }
            reader.Close();
            ocn.Close();
        }
            public void nbr_client()
            {
                Int32 count = 0;
                string txtsql;
                txtsql = "select count (*) from authentification";
                OleDbConnection ocn = new OleDbConnection(sconstr);
                OleDbCommand ocm = new OleDbCommand(txtsql, ocn);
                ocm.Connection.Open();
                count = Convert.ToInt32(ocm.ExecuteScalar());

                ocn.Close();
                label2.Text = count.ToString();
            }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form7 fm = new Form7();
            fm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f = new Form2();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            Form8 frm_modif = new Form8();
            int lignecourrant;
            string id, nom, prenom, age, adresse;

            if (dataGridView1.RowCount == 0)
                return;
            lignecourrant = dataGridView1.CurrentRow.Index;

            id = dataGridView1.Rows[lignecourrant].Cells[0].Value.ToString();
            nom = dataGridView1.Rows[lignecourrant].Cells[1].Value.ToString();
            prenom = dataGridView1.Rows[lignecourrant].Cells[2].Value.ToString();
            age = dataGridView1.Rows[lignecourrant].Cells[3].Value.ToString();
            adresse = dataGridView1.Rows[lignecourrant].Cells[4].Value.ToString();
          

            frm_modif.textBox1.Text = id;
            frm_modif.textBox2.Text = nom;
            frm_modif.textBox3.Text = prenom;
            frm_modif.textBox4.Text = age;
            frm_modif.textBox5.Text = adresse;
            frm_modif.textBox1.Enabled = false;
            frm_modif.Show();
            charger_Liste_client();
            this.Close();
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
                int k = ocm.ExecuteNonQuery();
                ocn.Close();
                MessageBox.Show("***Supression terminée avec succée***");
            }

            catch (Exception ex)
            {
                MessageBox.Show("exception Générée : " + ex.Message);
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {

            charger_Liste_client();
            nbr_client();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            string txtsql;
            txtsql = "select *  from authentification where  Nom like '%" + textBox1.Text + "%'";
            OleDbConnection ocn = new OleDbConnection(sconstr);
            OleDbCommand ocm = new OleDbCommand(txtsql, ocn);
            ocm.Connection.Open();
            OleDbDataReader reader = ocm.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                string[] row = new string[] { reader.GetValue(0).ToString(), 
                reader.GetValue(1).ToString(), 
                reader.GetValue(2).ToString(), 
                reader.GetValue(3).ToString(), 
                reader.GetValue(4).ToString() };
                dataGridView1.Rows.Add(row);

            }
            reader.Close();
            ocn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
              int lignecourrant;
            string login;
            string req_sup;
            if (dataGridView1.RowCount == 0)
                return;
            lignecourrant = dataGridView1.CurrentRow.Index;

            login = dataGridView1.Rows[lignecourrant].Cells[0].Value.ToString();
            DialogResult Supp_client =
                (MessageBox.Show("voulez vous supprimer l'utilisateur '" +
                dataGridView1.Rows[lignecourrant].Cells[0].Value.ToString() +
                "'", "supression utilisateur", MessageBoxButtons.YesNo));
            if (Supp_client == DialogResult.Yes)
            {
                req_sup = "delete from authentification where Login='" + login + "' ";
                lancerRequete(req_sup);
                charger_Liste_client();
            }
            else
            {
                return;
            }
            nbr_client();
            
        }
        }
    }

