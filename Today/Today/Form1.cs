using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Today
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=FPPOOLLAP37;Initial catalog=OnLogin;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from one where username = @user and password = @pass";
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            da.Fill(DT);

            try
            {
                if(DT.Rows.Count ==1)
                {
                 
                    MessageBox.Show("Your details entered is correct");

                    dataGridView1.DataSource = DT;
                }
                else
                {
                    MessageBox.Show("Username/Password is incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                con.Close();
            }

        }
    }
}
