using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace crud_system
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void save_88btn_Click(object sender, EventArgs e)
        {
            //string connetionString = null;
            string sql = null;
            MySqlConnection cnn;
            MySqlCommand command;
            //connetionString = "Server=localhost;Database=crud_system; Uid=root; Pwd=root;";
            cnn = new MySqlConnection("Server=localhost;Database=crud_system; Uid=root; Pwd=root;");     
            sql = "INSERT INTO `student` (`admision_no`,`first_name`,`last_name`)VALUES('" + txtaddmision.Text + "','" + txtfirstname.Text + "','" + txtlastname.Text + "')";
            

            try
            {
                cnn.Open();
                command = new Mysqlcommand(sql, cnn);
                command.ExecuteNonQuery();
                command.Dispose();
                cnn.Close();
                MessageBox.Show("ExecuteNonQuery in sqlCommand executed !!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection !" + ex.ToString());

            }
        }

        











        private void testbtn_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "Server=localhost;Database=crud_system; Uid=root; Pwd=root;"; 
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open! ");
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message.ToString());

            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;
            MySqlConnection cnn;
            MySqlCommand comm;
            connetionString = "Server=localhost;Database=crud_system;Uid=root;Pwd=root;";
            cnn = new MySqlConnection(connetionString);
            sql = "INSERT INTO `student` (  `admision_no`,  `first_name`,  `last_name`)VALUES('" + txtaddmision.Text + "','" + txtfirstname.Text + "','" + txtlastname.Text + "')";

            try
            {
               
              
                comm = new MySqlCommand(sql,cnn);
                cnn.Open();
                comm.ExecuteNonQuery();
                comm.Dispose();
               
                cnn.Close();
                MessageBox.Show("ExecuteNonQuery in sqlCommand executed !!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.ToString());

            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;
            MySqlConnection cnn;
            MySqlCommand comm;
            connetionString = "Server=localhost;Database=crud_system;Uid=root;Pwd=root;";
            cnn = new MySqlConnection(connetionString);
            sql = "UPDATE`student`SET``admision_no` = '"+txtaddmision.Text +"',`first_name` = '"+ txtfirstname.Text +"',`last_name` = '" +txtlastname.Text +"'WHERE `admision_no` = '" +txtaddmision.Text +"';";

            try
            {


                comm = new MySqlCommand(sql, cnn);
                cnn.Open();
                comm.ExecuteNonQuery();
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
