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
    public partial class Form3 : Form
    {
        DB db = new DB();
        public Form3()
        {
            InitializeComponent();
        }

        private void LoadData1()
        {
            
                DataTable table = new DataTable();
                try
                {
                    dataGridView1.AllowUserToAddRows = false;
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    MySqlCommand command = new MySqlCommand("SELECT Суши.idСуши AS id, Суши.Название, Суши.Описание,Суши.Цена FROM Суши", db.GetConnection());
                    adapter.SelectCommand = command;


                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Суши");

                    dataGridView1.DataSource = dataSet.Tables["Суши"];
                    dataGridView1.AutoResizeColumns();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadData1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                string Название = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                string Описание = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                string Цена = dataGridView2.CurrentRow.Cells[3].Value.ToString();


                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT ordered.idordered AS id,ordered.Название AS Название, ordered.Описание AS Описание,ordered.Цена AS Цена FROM ordered", db.GetConnection());

                adapter.SelectCommand = command;

                MySqlCommand command1 = new MySqlCommand("insert `ordered` ( `Название`, `Описание`, `Цена`) VALUES (@1U, @2U, @3U )", db.GetConnection());

                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Название;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Описание;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Цена;



                adapter.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "ordered");

                adapter.Fill(dataSet, "ordered");
                dataSet.Tables["ordered"].Clear();
                adapter.Fill(dataSet, "ordered");
                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dataSet.Tables["ordered"];
                dataGridView2.AutoResizeColumns();


            }
            catch (Exception ex)
            {

            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                dataGridView2.Columns.Add(c.Clone() as DataGridViewColumn);

            }

            
            foreach (DataGridViewRow a in dataGridView1.SelectedRows)
            {
                int index = dataGridView2.Rows.Add(a.Clone() as DataGridViewRow);

                foreach (DataGridViewCell o in a.Cells)
                {
                    dataGridView2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                }
            }
        }
    }
}
