using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uchetOborud
{
    public partial class Rucovoditel : Form
    {
        public SqlConnection connection = new SqlConnection(@"Data source = DESKTOP-949SEK0; Initial Catalog = uchetOborud; Integrated Security = true");
        public Rucovoditel()
        {
            InitializeComponent();
        }

        private void Rucovoditel_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(159, 0, 61);
            button2.BackColor = Color.FromArgb(159, 0, 61);
            label3.Text = Avtorization.FIO;
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string zapros = $"select FIO, telefon from Stuff where idRucov = '{Avtorization.id}'";
            SqlCommand comm = new SqlCommand(zapros, connection);
            adapter.SelectCommand = comm;
            adapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string zapros = $"select photo, serNumber, name, opiss, room from Oborud where idSotr = '{Avtorization.id}'";
            SqlCommand comm = new SqlCommand(zapros, connection);
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Avtorization avtorization = new Avtorization();
            avtorization.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
