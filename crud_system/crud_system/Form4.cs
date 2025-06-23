using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud_system
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;
            MySqlConnection cnn;
            MySqlCommand comm;
            connetionString = "Server=localhost;Database=crud_system;Uid=root;Pwd=root;";
            cnn = new MySqlConnection(connetionString);
            sql = "SELECT * FROM `subjects`;";
            try
            {
                comm = new MySqlCommand(sql, cnn);
                cnn.Open();
                MySqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                   

                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("No Row found");

                }

                comm.Dispose();

                cnn.Close();
                MessageBox.Show("ExecuteNonQuery in sqlCommand executed !!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.ToString());

            }

        }
    }
    
}
