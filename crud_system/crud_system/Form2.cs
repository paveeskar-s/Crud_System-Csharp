using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace crud_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;
            MySqlConnection cnn;
            MySqlCommand comm;
            connetionString = "Server=localhost;Database=crud_system;Uid=root;Pwd=root;";
            cnn = new MySqlConnection(connetionString);
            sql = "SELECT `id`, `admision_no`, `first_name`, `last_name`, `gender`, `grade`, `subject`, `address`, `email`, `telephone`, `nic_no`, `hope` FROM `student`";

            try
            {


                comm = new MySqlCommand(sql, cnn);
                cnn.Open();
                MySqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                     //while (dr.Read()) 
                     //  {
                     //   MessageBox.Show("ID:" + dr["id"].ToString()+ "\nAdmission No:" + dr["admision_no"].ToString()+"\nFirst Name:" + dr["first_name"].ToString()+ "\nLast Name:" + dr["last_name"].ToString());
                     //   }

                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("No Row founs");

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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please selete a row first.");
                return;

            }

            string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            MessageBox.Show("seleted ID: " + id);
            delete(id);
        }

        private void delete(string id)
        {
            string connetionString = null;
            string sql = null;
            MySqlConnection cnn;
            MySqlCommand comm;
            connetionString = "Server=localhost;Database=crud_system;Uid=root;Pwd=root;";
            cnn = new MySqlConnection(connetionString);
            sql = "DELETE FROM`student`WHERE `id`='" + id + "';";

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
                    MessageBox.Show("No Row founs");

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

        private void Form2_Load(object sender, EventArgs e)
        {
            listhope.Items.Clear();
            listhope.Items.AddRange(new string[] { "Doctor", "Engineer", "Teacher", "Developer" });
            listhope.SelectionMode = SelectionMode.MultiSimple;

            
        }

        private void btnfill_Click(object sender, EventArgs e)

        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }

            
            string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            string admission_no = dataGridView1.SelectedRows[0].Cells["admision_no"].Value.ToString();
            string first_name = dataGridView1.SelectedRows[0].Cells["first_name"].Value.ToString();
            string last_name = dataGridView1.SelectedRows[0].Cells["last_name"].Value.ToString();
            string gender = dataGridView1.SelectedRows[0].Cells["gender"].Value.ToString();
            string grade = dataGridView1.SelectedRows[0].Cells["grade"].Value.ToString();
            string subject = dataGridView1.SelectedRows[0].Cells["subject"].Value.ToString();
            string address = dataGridView1.SelectedRows[0].Cells["address"].Value.ToString();
            string email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
            string telephone = dataGridView1.SelectedRows[0].Cells["telephone"].Value.ToString();
            string nic_no = dataGridView1.SelectedRows[0].Cells["nic_no"].Value.ToString();
            string hope = dataGridView1.SelectedRows[0].Cells["hope"].Value.ToString();

            
            txtid.Text = id;
            txtadd.Text = admission_no;
            txtfirstname.Text = first_name;
            txtlastname.Text = last_name;
            cmbgrade.Text = grade;
            txtaddress.Text = address;
            txtemail.Text = email;
            txttelephone.Text = telephone;
            txtnic.Text = nic_no;

            
            if (gender == "Male")
            {
                radmale.Checked = true;
            }
            else if (gender == "Female")
            {
                radfemale.Checked = true;
            }

            
            chkmaths.Checked = subject.Contains("Maths");
            chktamil.Checked = subject.Contains("Tamil");
            chkenglish.Checked = subject.Contains("English");
            chkscience.Checked = subject.Contains("Science");
            chkit.Checked = subject.Contains("IT");

            
            listhope.ClearSelected();
            string[] hopes = hope.Split(',');
            foreach (string h in hopes)
            {
                for (int i = 0; i < listhope.Items.Count; i++)
                {
                    if (listhope.Items[i].ToString() == h.Trim())
                    {
                        listhope.SetSelected(i, true);
                    }
                }
            }
        }

        

        private void updatebtn_Click(object sender, EventArgs e)
        {
         
            string connectionString = "Server=localhost;Database=crud_system;Uid=root;Pwd=root;";

            string gender = radmale.Checked ? "Male" : "Female";
            string grade = cmbgrade.GetItemText(cmbgrade.SelectedItem);

           
            string hope = "";
            foreach (var item in listhope.SelectedItems)
            {
                hope += item.ToString() + ",";
            }
            if (hope.EndsWith(","))
            {
                hope = hope.Substring(0, hope.Length - 1);
            }

            
            List<string> subjects = new List<string>();
            if (chkmaths.Checked) subjects.Add(chkmaths.Text);
            if (chktamil.Checked) subjects.Add(chktamil.Text);
            if (chkenglish.Checked) subjects.Add(chkenglish.Text);
            if (chkscience.Checked) subjects.Add(chkscience.Text);
            if (chkit.Checked) subjects.Add(chkit.Text);
            string subject = string.Join(",", subjects);

            string sql = @"UPDATE `student` SET `admision_no` = @admision_no,`first_name` = @first_name,`last_name` = @last_name,`gender` = @gender,`grade` = @grade,`subject` = @subject,`address` = @address,`email` = @email,`telephone` = @telephone,`nic_no` = @nic_no,`hope` = @hope WHERE `id` = @id";

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(connectionString))
                using (MySqlCommand comm = new MySqlCommand(sql, cnn))
                {
                   
                    comm.Parameters.AddWithValue("@admision_no", txtadd.Text);
                    comm.Parameters.AddWithValue("@first_name", txtfirstname.Text);
                    comm.Parameters.AddWithValue("@last_name", txtlastname.Text);
                    comm.Parameters.AddWithValue("@gender", gender);
                    comm.Parameters.AddWithValue("@grade", grade);
                    comm.Parameters.AddWithValue("@subject", subject);
                    comm.Parameters.AddWithValue("@address", txtaddress.Text);
                    comm.Parameters.AddWithValue("@email", txtemail.Text);
                    comm.Parameters.AddWithValue("@telephone", txttelephone.Text);
                    comm.Parameters.AddWithValue("@nic_no", txtnic.Text);
                    comm.Parameters.AddWithValue("@hope", hope);
                    comm.Parameters.AddWithValue("@id", txtid.Text);

                    cnn.Open();
                    int rowsAffected = comm.ExecuteNonQuery();
                    cnn.Close();

                    if (rowsAffected > 0)
                        MessageBox.Show("Data updated successfully!");
                    else
                        MessageBox.Show("No matching record found to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update data: " + ex.Message);
            }
        }


        

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;
            MySqlConnection cnn;
            MySqlCommand comm;
            connetionString = "Server=localhost;Database=crud_system;Uid=root;Pwd=root;";
            cnn = new MySqlConnection(connetionString);

            string gender = "";
            if (radmale.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            string grade = cmbgrade.GetItemText(cmbgrade.SelectedItem);

            string hope = "";
            foreach (var item in listhope.SelectedItems)
            {
                hope += item.ToString();
            }
            if (hope.EndsWith(","))
            {
                hope = hope.Substring(0, hope.Length - 1);
            }

            string subject = "";
            if (chkmaths.Checked)
            {
                subject = chkmaths.Text;
            }
            if (chktamil.Checked)
            {
                subject += chktamil.Text;
            }
            if (chkenglish.Checked)
            {
                subject += chkenglish.Text;
            }
            if (chkscience.Checked)
            {
                subject += chkscience.Text;

            }
            if (chkit.Checked)
            {
                subject += chkit.Text;
            }   
            sql = "INSERT INTO `student`(`admision_no`,`first_name`,`last_name`,`gender`,`grade`,`subject`,`address`,`email`,`telephone`,`nic_no`,`hope`)VALUES('" + txtadd.Text + "','" + txtfirstname.Text + "','" + txtlastname.Text + "','"+gender+ "','"+grade+"','"+subject+"','"+txtaddress.Text+"','"+txtemail.Text+"','"+txttelephone.Text+"','"+txtnic.Text+"','"+hope+"'); ";

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

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void btnsubjecttable_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm4 = new Form4();
            frm4.Show();

        }
    }
}
  

