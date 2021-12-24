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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

       private void button1_Click(object sender, EventArgs e)
        {
            String Телефон = textBox1.Text;
            String Адрес = textBox2.Text;
            

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT idClient from `Client` WHERE `Телефон` = @uL AND `Адрес` =@uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Телефон;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = Адрес;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            int a = table.Rows[0].Field<int>("idClient");
            Телефон = a.ToString();
            if (table.Rows.Count > 0)
            {
               
                {
                    this.Hide();
                    Form1 techForm = new Form1();
                    techForm.Show();
                }
            }
            else
                MessageBox.Show("You are FURRY!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 forma = new Form2();
            forma.Show();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }
    }
}
