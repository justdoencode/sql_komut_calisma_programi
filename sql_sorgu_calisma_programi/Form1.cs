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

namespace sql_sorgu_calisma_programi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=sql_sorgu_calisma;Uid=root;Pwd=root;");
        void listele()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select *from kisiler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(richTextBox1.Text, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(richTextBox1.Text, baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }
    }
}
