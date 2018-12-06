using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            password_txt.PasswordChar = '*';
            password_txt.MaxLength = 60;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            cadastro frm = new cadastro();
            frm.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {
            txtusers.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=db_login;password=root");
            objcon.Open();
            MySqlCommand objcmd = objcon.CreateCommand();
            objcmd.CommandType = CommandType.Text;
            objcmd.CommandText = "select * from tb_login where usuario='" + txt1.Text + "'and senha='" + password_txt.Text + "'";
            objcmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(objcmd);
            da.Fill(dt);
            a = Convert.ToInt32(dt.Rows.Count.ToString());
            if (a==0)
            {
                MessageBox.Show("Erro, usuario ou senha incorreto");
            }
            else
            {
                this.Hide();
                menu prin = new menu();
                prin.Show();
                objcon.Close();
            }
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {

        }
    }   
}
