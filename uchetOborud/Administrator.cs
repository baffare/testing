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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace uchetOborud
{
    public partial class Administrator : Form
    {
        public SqlConnection connection = new SqlConnection(@"Data source = DESKTOP-949SEK0; Initial Catalog = uchetOborud; Integrated Security = true");
        public Administrator()
        {
            InitializeComponent();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "uchetOborudDataSet2.HistoryVhod". При необходимости она может быть перемещена или удалена.
            this.historyVhodTableAdapter.Fill(this.uchetOborudDataSet2.HistoryVhod);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "uchetOborudDataSet.HistoryVhod". При необходимости она может быть перемещена или удалена.
            this.historyVhodTableAdapter.Fill(this.uchetOborudDataSet.HistoryVhod);
            label3.Text = Avtorization.FIO;
            label2.ForeColor = Color.FromArgb(159, 0, 61);
            label3.ForeColor = Color.FromArgb(159, 0, 61);
            button2.BackColor = Color.FromArgb(159, 0, 61);
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            // TODO: данная строка кода позволяет загрузить данные в таблицу "uchetOborudDataSet.Stuff". При необходимости она может быть перемещена или удалена.
            this.stuffTableAdapter.Fill(this.uchetOborudDataSet.Stuff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "uchetOborudDataSet.Oborud". При необходимости она может быть перемещена или удалена.
            this.oborudTableAdapter.Fill(this.uchetOborudDataSet.Oborud);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            string serNumber = textBox1.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string zapros = $"select name, serNumber, room, opiss, photo, status from Oborud where serNumber = '{serNumber}'";
            SqlCommand comm = new SqlCommand(zapros, connection);
            adapter.SelectCommand = comm;
            adapter.Fill(dt);

            if(dt.Rows.Count == 1) 
            {
                var photo = dt.Rows[0][2].ToString();
                if (photo == " SN00002")
                {
                    pictureBox3.Image = Image.FromFile("C:\\Users\\artmk\\source\\repos\\uchetOborud\\uchetOborud\\PhotoOborudovaniya\\SN00002.jpg");

                }
                else if (photo == " SN00011")
                {
                    pictureBox3.Image = Image.FromFile("C:\\Users\\artmk\\source\\repos\\uchetOborud\\uchetOborud\\PhotoOborudovaniya\\SN00011.jpg");
                }
                else if (photo == " SN13579")
                {
                    pictureBox3.Image = Image.FromFile("C:\\Users\\artmk\\source\\repos\\uchetOborud\\uchetOborud\\PhotoOborudovaniya\\SN13579.jpg");
                }
                else if (photo == " SN54321")
                {
                    pictureBox3.Image = Image.FromFile("C:\\Users\\artmk\\source\\repos\\uchetOborud\\uchetOborud\\PhotoOborudovaniya\\SN54321.jpg");
                }
                else if (photo == " SN77777")
                {
                    pictureBox3.Image = Image.FromFile("C:\\Users\\artmk\\source\\repos\\uchetOborud\\uchetOborud\\PhotoOborudovaniya\\SN77777.jpg");
                }
                else
                {
                    pictureBox3.Image = Image.FromFile("C:\\Users\\artmk\\source\\repos\\uchetOborud\\uchetOborud\\PhotoOborudovaniya\\placeholder.jpg");
                }
                string room = dt.Rows[0][2].ToString();
                string status = dt.Rows[0][5].ToString();
                if(room == "1")
                {
                    if(status == " в работе")
                    {
                        panel2.Visible = true;
                        panel2.BackColor = Color.Green;

                    }
                    if (status == " не в работе")
                    {
                        panel2.Visible = true;
                        panel2.BackColor = Color.Red;
                    }
                }
                if (room == "2")
                {
                    if (status == " в работе")
                    {
                        panel3.Visible = true;
                        panel3.BackColor = Color.Green;

                    }
                    if (status == " не в работе")
                    {
                        panel3.Visible = true;
                        panel3.BackColor = Color.Red;
                    }
                }
                if (room == "3")
                {
                    if (status == " в работе")
                    {
                        panel4.Visible = true;
                        panel4.BackColor = Color.Green;

                    }
                    if (status == " не в работе")
                    {
                        panel4.Visible = true;
                        panel4.BackColor = Color.Red;
                    }
                }
                if (room == "4")
                {
                    if (status == " в работе")
                    {
                        panel5.Visible = true;
                        panel5.BackColor = Color.Green;

                    }
                    if (status == " не в работе")
                    {
                        panel5.Visible = true;
                        panel5.BackColor = Color.Red;
                    }
                }
                if (room == "5")
                {
                    if (status == " в работе")
                    {
                        panel6.Visible = true;
                        panel6.BackColor = Color.Green;

                    }
                    if (status == " не в работе")
                    {
                        panel6.Visible = true;
                        panel6.BackColor = Color.Red;
                    }
                }
                if (room == "6")
                {
                    if (status == " в работе")
                    {
                        panel7.Visible = true;
                        panel7.BackColor = Color.Green;

                    }
                    if (status == " не в работе")
                    {
                        panel7.Visible = true;
                        panel7.BackColor = Color.Red;
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
