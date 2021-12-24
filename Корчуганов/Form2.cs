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

namespace Корчуганов
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            try
            {




                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `Client` (`Фамилия`, `Имя`, `Телефон`, `Емайл`,`Адрес`) VALUES (@1U, @2U, @3U, @4U,@5U)", db.GetConnection());

                adapter1.SelectCommand = command1;
                string Фамилия = textBox1.Text;
                string Имя = textBox2.Text;
                string Телефон = textBox3.Text;
                string Емайл = textBox4.Text;
                string Адрес = textBox5.Text;

                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Фамилия;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Имя;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Телефон;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Емайл;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Адрес;



              
                {
                    DataSet Furry = new DataSet();
                    adapter1.Fill(Furry, "Client");
                    this.Hide();
                    Form5 techForm = new Form5();
                    techForm.Show();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 forma = new Form5();
            forma.Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form5 forma = new Form5();
            forma.Show();
        }
    }
}
