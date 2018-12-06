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
    public partial class cadastro : Form
    {
        public cadastro()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 60;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=db_login;password=root");
                objcon.Open();
                MySqlCommand objcmd = new MySqlCommand("insert into tb_login(usuario,senha) values(?,?)", objcon);
                objcmd.Parameters.Add("@usuario", MySqlDbType.VarChar, 60).Value = textBox1.Text;
                objcmd.Parameters.Add("@senha", MySqlDbType.Int64, 60).Value = textBox2.Text;
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro efetuado com sucesso");
                objcon.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Não conectou" + error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu m = new menu();
            m.Show();
        }

        private void cadastro_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }
    }
}
