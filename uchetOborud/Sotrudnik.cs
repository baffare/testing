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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace uchetOborud
{
    public partial class Sotrudnik : Form
    {
        public SqlConnection connection = new SqlConnection(@"Data source = DESKTOP-949SEK0; Initial Catalog = uchetOborud; Integrated Security = true");

        public Sotrudnik()
        {
            InitializeComponent();
        }

        private void Sotrudnik_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "uchetOborudDataSet2.Oborud". При необходимости она может быть перемещена или удалена.
            this.oborudTableAdapter1.Fill(this.uchetOborudDataSet2.Oborud);
            label3.Text = Avtorization.FIO;
            label2.ForeColor = Color.FromArgb(159, 0, 61);
            label3.ForeColor = Color.FromArgb(159, 0, 61);
            button1.BackColor = Color.FromArgb(159, 0, 61);
            button2.BackColor = Color.FromArgb(159, 0, 61);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Avtorization avtorization = new Avtorization();
            avtorization.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
