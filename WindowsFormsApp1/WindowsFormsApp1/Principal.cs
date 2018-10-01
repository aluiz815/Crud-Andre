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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crud;password=root");
                objcon.Open();
                MySqlCommand objcmd = new MySqlCommand("insert into tb_dados(cd_dados,nm_nome,qt_quantidade) values(null,?,?)",objcon);
                objcmd.Parameters.Add("@nm_nome", MySqlDbType.VarChar, 60).Value = textBox1.Text;
                objcmd.Parameters.Add("@qt_quantidade", MySqlDbType.Int64,60).Value = textBox2.Text;
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro efetuado com sucesso");
                objcon.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Não conectou" +error);
            }
        }
        private void banco()
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crud;password=root");
                objcon.Open();
                MySqlCommand objcmd = new MySqlCommand("select * from tb_dados", objcon);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = objcmd;
                DataTable dba = new DataTable();
                da.Fill(dba);

                BindingSource bsource = new BindingSource();
                bsource.DataSource = dba;
                dgv.DataSource = bsource;
                da.Update(dba);
                objcon.Close();
            }
            catch
            {
                MessageBox.Show("Error ao carregar o banco de dados");
            }
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            banco();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crud;password=root");
                objcon.Open();
                MySqlCommand objcmd = new MySqlCommand("delete from tb_dados where cd_dados=?", objcon);
                objcmd.Parameters.Clear();
                objcmd.Parameters.Add("cd_dados", MySqlDbType.Int32).Value = textBox3.Text;
                objcmd.CommandType = CommandType.Text;
                objcmd.ExecuteNonQuery();     
                objcon.Close();
                MessageBox.Show("Registo removido com sucesso");

            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
            banco();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crud;password=root");
                objcon.Open();
                MySqlCommand objcmd = new MySqlCommand("update tb_dados set nm_nome=?,qt_quantidade=? where cd_dados=?", objcon);
                objcmd.Parameters.Clear();
                objcmd.Parameters.Add("@nm_nome", MySqlDbType.VarChar).Value = textBox1.Text;
                objcmd.Parameters.Add("@qt_quantidade", MySqlDbType.Int64,60).Value = textBox2.Text;
                objcmd.Parameters.Add("cd_dados", MySqlDbType.Int32).Value = textBox3.Text;
                objcmd.CommandType = CommandType.Text;
                objcmd.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("Registo atualizado com sucesso");

            }
            catch (Exception)
            {
                MessageBox.Show("Error ao atualizar o registro");
            }
            banco();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crud;password=root");
                objcon.Open();
                MySqlCommand objcmd = new MySqlCommand("select nm_nome,qt_quantidade from tb_dados where cd_dados=?",objcon);
                 objcmd.Parameters.Clear();
                objcmd.Parameters.Add("@cd_dados", MySqlDbType.Int32).Value = textBox3.Text;
                objcmd.CommandType = CommandType.Text;
                MySqlDataReader dr;
                dr = objcmd.ExecuteReader();
                dr.Read();
                textBox1.Text = dr.GetString(0);
                textBox2.Text = dr.GetString(1);
                objcon.Close();
                MessageBox.Show("Busca realizada com sucesso");

            }
            catch (Exception)
            {
                MessageBox.Show("Error ao buscar o registro");
            }
            banco();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
        }
     }
}
